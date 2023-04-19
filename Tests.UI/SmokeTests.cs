using FluentAssertions;
using NUnit.Framework;
using PageObjects.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.UI
{
    [TestFixture]
    public class SmokeTests : BaseUITest
    {
        [Test]
        public void LogoDisplaingTest()
        {
            LoginPage login = new LoginPage(Browser);

            login.Logo.Displayed.Should().BeTrue();
        }
    }
}
