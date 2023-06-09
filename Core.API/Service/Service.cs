using Core.API.Domain;
using Core.API.Domain.Resourses;
using Core.API.Resourses;

namespace Core.API.Service
{
    // <inheritdoc cref="IClientService"/>
    public class Service : IClientService, IDisposable
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor to initialize a new object of service.
        /// </summary>
        /// <param name="uri">Base URI for REST service.</param>
        /// <param name="projectName">A project to manage.</param>
        /// <param name="token">A token for user. Can be UID given from user's profile page.</param>
        /// <param name="httpClientFactory">Factory object to create an instance of <see cref="HttpClient"/>.</param>
        public Service(APIConfig apiConfig, IHttpClientFactory httpClientFactory = null)
        {
            ProjectName = apiConfig.ProjectName;
           
            if (httpClientFactory == null)
            {
                httpClientFactory = new HttpClientFactory(new Uri(apiConfig.BaseUrl + apiConfig.ApiPath), apiConfig.Uuid);
            }

            _httpClient = httpClientFactory.Create();
            Dashboard = new ServiceDashboardResource(_httpClient, ProjectName);
        }

        /// <summary>
        /// Gets current project name to interact with.
        /// </summary>
        public string ProjectName { get; }
     
        /// <inheritdoc />
        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public IDashboardResource Dashboard { get; }
    }
}
