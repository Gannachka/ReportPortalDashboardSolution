using Core;
using Core.Enums;
using Core.UI.WebDriverWrapper.Interfaces;
using System.Threading;

namespace Core.UI.BrowserBuilder
{
    public class BrowserSingleton
    {
        private static ThreadLocal<IBrowser> instance = new ThreadLocal<IBrowser>();

        public static IBrowser GetBrowser(Browsers browserName)
        {
            if (instance.Value == null)
            {
                instance.Value = BrowserFactory.Create(browserName);
            }

            return instance.Value;
        }

        public static void ReleaseInstance()
        {
            instance.Value = null;
        }
    }
}