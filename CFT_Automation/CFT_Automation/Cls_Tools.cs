using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Linq;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace CFT_Automation
{
  
    [TestClass]
    public class Cls_Tools
    {

        IWebDriver drivertools;
        Cft_Base objbase = new Cft_Base();

        [TestMethod]
        public void Validate_csv()
        {
            try
            {
                string filepath = @"C:\CFT\CFTAutomation\CFT_Automation\runfiledata.csv";
                List<string> lsttestdata = new List<string>();
               // lsttestdata = server
               

            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception Message:"+exc.Message.ToString());
            }

        }

        [TestMethod]
        public void validate_CFT_Tools()
        {
            try
            {
                drivertools = objbase.InitiateDriver();

                IJavaScriptExecutor toolsexecutor = (IJavaScriptExecutor)drivertools;
                drivertools.Navigate().GoToUrl(ConfigurationSettings.AppSettings["QAT"]);
                drivertools.Manage().Window.Maximize();
                drivertools.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                IWebElement elelogin = drivertools.FindElement(By.Id("okta-signin-username"));
                elelogin.Clear();
                elelogin.SendKeys(ConfigurationSettings.AppSettings["userid"]);
                IWebElement elepassword = drivertools.FindElement(By.Id("okta-signin-password"));
                elepassword.SendKeys(ConfigurationSettings.AppSettings["pwd"]);
                IWebElement btnsubmit = drivertools.FindElement(By.Id("okta-signin-submit"));
                btnsubmit.Click();
                objbase.ImplicitwaitforPageload();

                Console.WriteLine("login page title : " + drivertools.Title);

                drivertools.SwitchTo().Window(drivertools.WindowHandles.Last());
                objbase.ImplicitwaitforPageload();
                IWebElement eldocdivparentclass = drivertools.FindElement(By.XPath("//div[@class='contextMenu']"));
                IWebElement eldocdivparentclasssub1 = eldocdivparentclass.FindElement(By.ClassName("icon-documents"));
                eldocdivparentclasssub1.Click();
                drivertools.SwitchTo().Window(drivertools.WindowHandles.Last());
                objbase.ImplicitwaitforDocumentload();

                IWebElement eledivsitenav = drivertools.FindElement(By.XPath("//div[@class='siteNav']"));
                IWebElement eletools = eledivsitenav.FindElement(By.Id("TOOLS"));

                toolsexecutor.ExecuteScript("arguments[0].click();", eletools);
                objbase.ImplicitwaitforPageload();

                IWebElement eleimpersonate = drivertools.FindElement(By.Id("User"));
                objbase.ImplicitwaitAdminload();
                eleimpersonate.SendKeys(ConfigurationSettings.AppSettings["ImpersonateUser"]);
                objbase.ImplicitwaitforDocumentload();
                IWebElement eleimpersonateupdate = drivertools.FindElement(By.Name("IMPERSONATE"));
                eleimpersonateupdate.Click();
               
                Console.WriteLine("Tools Page Title: "+" "+ drivertools.Title);
              //  Assert.AreEqual("Grosvenor Capital Management, L.P", drivertools.Title);
                Assert.AreEqual(ConfigurationSettings.AppSettings["toolsasserts"], drivertools.Title);

               // Assert.IsTrue(
                //drivertools.FindElement(By.CssSelector("button.Impersonate")).Submit();

            }
            catch (Exception extools)
            {
               // Console.WriteLine("TOOLS Exception:"+extools.Message.ToString());
                Assert.Fail("Exception:"+extools.Message.ToString());
            }

        }

    }
}
