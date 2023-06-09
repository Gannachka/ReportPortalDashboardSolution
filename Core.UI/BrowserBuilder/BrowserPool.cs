using Core.UI.WebDriver.Interfaces;
using System.Collections.Concurrent;

namespace Core.UI.BrowserBuilder
{
    public sealed class BrowserPool
    {
        public const string DefaultBrowserName = "default";
        public static readonly object Locker = new object();

        private static readonly ConcurrentDictionary<int, string> ThreadActiveBrowser = new ConcurrentDictionary<int, string>();
        private static ConcurrentDictionary<string, IBrowser> BrowserDictionary = new ConcurrentDictionary<string, IBrowser>();

        public static IBrowser CurrentBrowser
        {
            get
            {
                string browserName = ThreadActiveBrowser[Thread.CurrentThread.ManagedThreadId];
                return BrowserDictionary[GetBrowserNameWithThreadId(browserName)];
            }
        }

        public static void MakeCurrentBrowser(string browserName)
        {
            RemoveDisposedInstances();
            lock (Locker)
            {
                if (BrowserDictionary.ContainsKey(GetBrowserNameWithThreadId(browserName)))
                {
                    ThreadActiveBrowser.AddOrUpdate(Thread.CurrentThread.ManagedThreadId, browserName, (key, oldValue) => browserName);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(browserName), $"No browser'{browserName}");
                }
            }
        }

        public static void RegisterAndMakeCurrentBrowser(string browserName, IBrowser newBrowser)
        {
            RegisterBrowser(browserName, newBrowser);
            MakeCurrentBrowser(browserName);
        }

        private static void RegisterBrowser(string browserName, IBrowser newBrowser)
        {
            if (string.IsNullOrEmpty(browserName))
            {
                throw new ArithmeticException("problem");
            }

            RemoveDisposedInstances();

            if (!BrowserDictionary.TryAdd(GetBrowserNameWithThreadId(browserName), newBrowser))

            {
                throw new InvalidOperationException("problem");
            }
        }
        private static void RemoveDisposedInstances()
        {
            lock (Locker)
            {
                IEnumerable<string> keys = BrowserDictionary.Where(pair => pair.Value.IsDisposed).Select(pair => pair.Key);
                foreach (string key in keys)
                {
                    IBrowser value;
                    BrowserDictionary.TryRemove(key, out value);
                }
            }
        }
        private static string GetBrowserNameWithThreadId(string browserName)
            => browserName.EndsWith($"_{Thread.CurrentThread.ManagedThreadId}")
            ? browserName
            : $"{browserName}_{Thread.CurrentThread.ManagedThreadId}";
    }
}
