using System;
using System.IO;
using Xunit;

namespace MPSTI.PlenoSoft.Selenium.Extension.Test
{
	public class UnitTest1
	{
		[Fact]
		public void Test1()
		{
			var update = ChromeUpdateDriverVersion.Update(@"Program Files");

			Assert.NotNull(update);
		}

		[Fact]
		public void Test2()
		{
			var driverPath = @"D:\Prj\Git\MPSC.PlenoSoft.WhatsApp.API\src\Libs\";

			var webDriver = SeleniumFactory.ChromeWebDriver(webDriverLocation: new FileInfo(driverPath));

			Assert.NotNull(webDriver);
		}
	}
}
