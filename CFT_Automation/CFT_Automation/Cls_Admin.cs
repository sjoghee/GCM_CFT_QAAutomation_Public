using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CFT_Automation
{
   [TestClass]
    public class Cls_Admin
    {
           
             IWebDriver driveradmin;
             Cft_Base objbase = new Cft_Base();

        [TestMethod]    
        public void validate_CFT_Admin()
            {
                try
                {
                    driveradmin = objbase.InitiateDriver();

                    IJavaScriptExecutor adminxecutor = (IJavaScriptExecutor)driveradmin;
                    driveradmin.Navigate().GoToUrl(ConfigurationSettings.AppSettings["QAT"]);
                    driveradmin.Manage().Window.Maximize();
                    driveradmin.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                    IWebElement elelogin = driveradmin.FindElement(By.Id("okta-signin-username"));
                    elelogin.Clear();
                    elelogin.SendKeys(ConfigurationSettings.AppSettings["userid"]);
                    IWebElement elepassword = driveradmin.FindElement(By.Id("okta-signin-password"));
                    elepassword.SendKeys(ConfigurationSettings.AppSettings["pwd"]);
                    IWebElement btnsubmit = driveradmin.FindElement(By.Id("okta-signin-submit"));
                    btnsubmit.Click();
                    objbase.ImplicitwaitforPageload();

                    driveradmin.SwitchTo().Window(driveradmin.WindowHandles.Last());
                    objbase.ImplicitwaitforPageload();
                    IWebElement eldocdivparentclass = driveradmin.FindElement(By.XPath("//div[@class='contextMenu']"));
                    IWebElement eldocdivparentclasssub1 = eldocdivparentclass.FindElement(By.ClassName("icon-documents"));
                    eldocdivparentclasssub1.Click();
                    driveradmin.SwitchTo().Window(driveradmin.WindowHandles.Last());
                    objbase.ImplicitwaitforDocumentload();

                    IWebElement eledivsitenav = driveradmin.FindElement(By.XPath("//div[@class='siteNav']"));
                    IWebElement eleadmin = eledivsitenav.FindElement(By.Id("ADMIN"));

                    adminxecutor.ExecuteScript("arguments[0].click();", eleadmin);
                    objbase.ImplicitwaitforPageload();

                    IWebElement eledivsubscritption = driveradmin.FindElement(By.XPath("//div[@class='dhx_tabbar_zone']"));
                    objbase.ImplicitwaitAdminload();
                   IList<IWebElement> elesubscription = eledivsubscritption.FindElements(By.Id("xbC1"));




                }
                catch(Exception exadmin)
                {

                }

            }
    }
}
