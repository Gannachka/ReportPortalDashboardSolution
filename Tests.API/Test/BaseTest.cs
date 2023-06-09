using Core.API;
using Core.API.Service;

namespace Tests.API.Test
{
    public abstract class BaseTest
    {
        protected readonly Service Service;
       
        public BaseTest()
        {
            APIConfig apiConfig = new APIConfig();
                      
            Service = new Service(apiConfig);
        }
    }
}
