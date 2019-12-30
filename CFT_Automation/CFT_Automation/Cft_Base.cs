using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support;



namespace CFT_Automation
{
    [TestClass]
    public class Cft_Base
    {
        IWebDriver driver;

        [TestMethod]
        public IWebDriver InitiateDriver()
        {

            InternetExplorerOptions options = new InternetExplorerOptions();
            options.PageLoadStrategy = PageLoadStrategy.Eager;
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.IgnoreZoomLevel = true;
           // options.AddAdditionalCapability(
            driver = new InternetExplorerDriver(@"C:\CFT\CFTAutomation\CFT_Automation\packages\Driver", options);
            return driver;
           
        }

        [TestMethod]
        public bool validatelementexist(By by)
        {
            try
            {

                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        [TestMethod]
        public void ImplicitwaitforPageload()
        {
            Thread.Sleep(15000);
          
        }

        [TestMethod]
        public void Implicitwaitforreport()
        {
            Thread.Sleep(5000);

        }

        [TestMethod]
        public void ImplicitwaitforDocumentload()
        {
            Thread.Sleep(15000);

        }

        [TestMethod]
        public void ImplicitwaitAdminload()
        {
            Thread.Sleep(20000);

        }
        [TestMethod]
        public void ImplicitwaitforxpathELementload(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

    }
}
