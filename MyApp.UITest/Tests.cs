using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MyApp.UITest
{
	[TestFixture(Platform.Android)]
	//[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
            app.WaitForElement("MainPage.buttonNavi", "Timeout", TimeSpan.FromSeconds(10));
        }

        [Test]
        public void MainPage_Label()
        {
            app.EnterText("MainPage.entry", "This is test.");
            Assert.AreEqual("entry: This is test.", app.Query("MainPage.label")[0].Text);
        }


        [Test]
        public void MainPage_NavigateButton()
        {
            app.Tap("MainPage.buttonNavi");
            AppResult[] results = app.WaitForElement(c => c.Marked("SubPage!"));
            app.Screenshot("Welcome screen.");
            Assert.IsTrue(results.Any());
        }
    }
}
