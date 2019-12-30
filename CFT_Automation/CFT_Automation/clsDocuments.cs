using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;

namespace CFT_Automation
{
    [TestClass]
    public class clsDocuments
    {
        Cft_Base objbase = new Cft_Base();

        IWebDriver cftdocumentsdriver;
        

        [TestMethod]
        public void Validate_Documents_recent()
        {

            try
            {
                cftdocumentsdriver = objbase.InitiateDriver();

                IJavaScriptExecutor cftexecutor = (IJavaScriptExecutor)cftdocumentsdriver;
                cftdocumentsdriver.Navigate().GoToUrl(ConfigurationSettings.AppSettings["QAT"]);
                cftdocumentsdriver.Manage().Window.Maximize();
                cftdocumentsdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                IWebElement elelogin = cftdocumentsdriver.FindElement(By.Id("okta-signin-username"));
                elelogin.Clear();
                elelogin.SendKeys(ConfigurationSettings.AppSettings["userid"]);
                IWebElement elepassword = cftdocumentsdriver.FindElement(By.Id("okta-signin-password"));
                elepassword.SendKeys(ConfigurationSettings.AppSettings["pwd"]);
                IWebElement btnsubmit = cftdocumentsdriver.FindElement(By.Id("okta-signin-submit"));
                btnsubmit.Click();
                objbase.ImplicitwaitforPageload();

                cftdocumentsdriver.SwitchTo().Window(cftdocumentsdriver.WindowHandles.Last());
                objbase.ImplicitwaitforPageload();
                                
                IWebElement eldocdivparentclass = cftdocumentsdriver.FindElement(By.XPath("//div[@class='contextMenu']"));
                IWebElement eldocdivparentclasssub = eldocdivparentclass.FindElement(By.XPath("//span[contains(@class,'application documents')]"));
                IWebElement eldocdivparentclasssub1 = eldocdivparentclass.FindElement(By.ClassName("icon-documents"));
                eldocdivparentclasssub1.Click();
                cftdocumentsdriver.SwitchTo().Window(cftdocumentsdriver.WindowHandles.Last());
                objbase.ImplicitwaitforDocumentload();

                IWebElement eledivrecent = cftdocumentsdriver.FindElement(By.XPath("//div[@class='siteNav']"));
                IWebElement elerecent = eledivrecent.FindElement(By.Id("HOME"));
                cftexecutor.ExecuteScript("arguments[0].click();", elerecent);

               // elerecent.Click();
                objbase.ImplicitwaitforDocumentload();

                IWebElement divaccountstatement = cftdocumentsdriver.FindElement(By.XPath("//div[@class='xView']"));
                IWebElement lnkaccstatement = divaccountstatement.FindElement(By.LinkText("Account Statement - Final"));
                cftexecutor.ExecuteScript("arguments[0].click();", lnkaccstatement);
               // lnkaccstatement.Click();
                objbase.ImplicitwaitforPageload();
                cftdocumentsdriver.SwitchTo().Window(cftdocumentsdriver.WindowHandles.Last());
                cftdocumentsdriver.Manage().Window.Maximize();
                objbase.ImplicitwaitforPageload();
              //  IAlert altpop = cftdocumentsdriver.SwitchTo().Alert();
                //altpop.Accept();


                //cftdocumentsdriver.Quit();

            }
            catch (Exception recentex)
            {
                Console.WriteLine(""+recentex.Message.ToString());
            }
        }


        [TestMethod]
        public void Validate_All_reports()
        {
            try
            {
                cftdocumentsdriver = objbase.InitiateDriver();

                IJavaScriptExecutor cftexecutor = (IJavaScriptExecutor)cftdocumentsdriver;
                cftdocumentsdriver.Navigate().GoToUrl(ConfigurationSettings.AppSettings["QAT"]);
                cftdocumentsdriver.Manage().Window.Maximize();
                cftdocumentsdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                IWebElement elelogin = cftdocumentsdriver.FindElement(By.Id("okta-signin-username"));
                elelogin.Clear();
                elelogin.SendKeys(ConfigurationSettings.AppSettings["userid"]);
                IWebElement elepassword = cftdocumentsdriver.FindElement(By.Id("okta-signin-password"));
                elepassword.SendKeys(ConfigurationSettings.AppSettings["pwd"]);
                IWebElement btnsubmit = cftdocumentsdriver.FindElement(By.Id("okta-signin-submit"));
                btnsubmit.Click();
                objbase.ImplicitwaitforPageload();

                cftdocumentsdriver.SwitchTo().Window(cftdocumentsdriver.WindowHandles.Last());
                objbase.ImplicitwaitforPageload();

                IWebElement eldocdivparentclass = cftdocumentsdriver.FindElement(By.XPath("//div[@class='contextMenu']"));
                IWebElement eldocdivparentclasssub = eldocdivparentclass.FindElement(By.XPath("//span[contains(@class,'application documents')]"));
                IWebElement eldocdivparentclasssub1 = eldocdivparentclass.FindElement(By.ClassName("icon-documents"));
                eldocdivparentclasssub1.Click();
                cftdocumentsdriver.SwitchTo().Window(cftdocumentsdriver.WindowHandles.Last());
                objbase.ImplicitwaitforDocumentload();

                // All reports

                IWebElement eleallid = cftdocumentsdriver.FindElement(By.Id("DOCUMENTS"));
                cftexecutor.ExecuteScript("arguments[0].click();", eleallid);
                //eleallid.Click();
                objbase.ImplicitwaitforDocumentload();

              
                //GROSVENOR FUND

                IWebElement eletopdivgrovfund = cftdocumentsdriver.FindElement(By.XPath("//div[@class='dhx_tabbar_zone']"));
                IList<IWebElement>  elegrovfund = eletopdivgrovfund.FindElements(By.XPath("//div[@class='dhx_tab_element dhx_tab_element_inactive']"));
                cftexecutor.ExecuteScript("arguments[0].click();", elegrovfund[0]);
                objbase.ImplicitwaitforDocumentload();
                
                // SPECIAL REPORTS

                cftexecutor.ExecuteScript("arguments[0].click();", elegrovfund[1]);
                objbase.ImplicitwaitforDocumentload();

                // OTHERS

                cftexecutor.ExecuteScript("arguments[0].click();", elegrovfund[2]);
                objbase.ImplicitwaitforDocumentload();

                cftdocumentsdriver.Quit();

               

              //  IWebElement elespecialreports = eletopdivgrovfund.FindElement(By.XPath("//div[@class='']));

            }
            
            catch (Exception exall)
            {
                Console.WriteLine(""+exall.Message.ToString());
            }
        
        }

        [TestMethod]
        public void Documents_ReportTracking()
        {
           
            try
            {
                cftdocumentsdriver = objbase.InitiateDriver();

                IJavaScriptExecutor cfttrackingxecutor = (IJavaScriptExecutor)cftdocumentsdriver;
                cftdocumentsdriver.Navigate().GoToUrl(ConfigurationSettings.AppSettings["QAT"]);
                cftdocumentsdriver.Manage().Window.Maximize();
                cftdocumentsdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                IWebElement elelogin = cftdocumentsdriver.FindElement(By.Id("okta-signin-username"));
                elelogin.Clear();
                elelogin.SendKeys(ConfigurationSettings.AppSettings["userid"]);
                IWebElement elepassword = cftdocumentsdriver.FindElement(By.Id("okta-signin-password"));
                elepassword.SendKeys(ConfigurationSettings.AppSettings["pwd"]);
                IWebElement btnsubmit = cftdocumentsdriver.FindElement(By.Id("okta-signin-submit"));
                btnsubmit.Click();
                objbase.ImplicitwaitforPageload();

                cftdocumentsdriver.SwitchTo().Window(cftdocumentsdriver.WindowHandles.Last());
                objbase.ImplicitwaitforPageload();
                IWebElement eldocdivparentclass = cftdocumentsdriver.FindElement(By.XPath("//div[@class='contextMenu']"));
                IWebElement eldocdivparentclasssub1 = eldocdivparentclass.FindElement(By.ClassName("icon-documents"));
                eldocdivparentclasssub1.Click();
                cftdocumentsdriver.SwitchTo().Window(cftdocumentsdriver.WindowHandles.Last());
                objbase.ImplicitwaitforDocumentload();

                IWebElement elereporttrackingtop = cftdocumentsdriver.FindElement(By.XPath("//div[@class='siteNav']"));
                IWebElement elereporttracking = elereporttrackingtop.FindElement(By.Id("LOGGING"));
                cfttrackingxecutor.ExecuteScript("arguments[0].click();", elereporttracking);

                IWebElement eledivtopsforreportssubmenu = cftdocumentsdriver.FindElement(By.XPath("//div[@class='dhx_tabbar_zone']"));
                IList<IWebElement> lisfoftrackingsubmenus = eledivtopsforreportssubmenu.FindElements(By.XPath("//div[@class='dhx_tab_element dhx_tab_element_inactive']"));


               // Documents error

                cfttrackingxecutor.ExecuteScript("arguments[0].click();", lisfoftrackingsubmenus[0]);
                objbase.ImplicitwaitforDocumentload();

              //  Documents Usage 

                cfttrackingxecutor.ExecuteScript("arguments[0].click();", lisfoftrackingsubmenus[1]);
                objbase.ImplicitwaitforDocumentload();
              
              //  Documents Deleted

                cfttrackingxecutor.ExecuteScript("arguments[0].click();", lisfoftrackingsubmenus[2]);
                objbase.ImplicitwaitforDocumentload();


            }
            catch(Exception exreporttracking)
            {
                Console.WriteLine("" + exreporttracking.Message.ToString());
            }

        }

       
    }
}
