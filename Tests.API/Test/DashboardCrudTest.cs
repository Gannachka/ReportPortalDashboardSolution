using Core.API;
using FluentAssertions;
using NUnit.Framework;

namespace Tests.API.Test
{
    [TestFixture]
    public class DashboardCrudTest : BaseTest
    {
        private int _projectId = 27;

        [Test]
        public async Task CreateTest()
        {
            var response = await Service.Dashboard.CreateAsync(
                new CreateDashboardRequest
                {
                    Description = "This is a new dashboard created from api",
                    Name = "Api dashboard " + DateTime.Now,
                    //Share = true
                });

            // Check dashboard number is returned
            response.Id.Should().BeGreaterThan(0);
            _projectId = response.Id;
        }

    }
}
