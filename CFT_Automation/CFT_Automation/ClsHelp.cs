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
    public class ClsHelp
    {

        Cft_Base objbase = new Cft_Base();
        IWebDriver cftdocumentsHelpdriver;

        [TestMethod]
        public void Validate_Help_MenU()
        {

            try
            {
                cftdocumentsHelpdriver = objbase.InitiateDriver();

                IJavaScriptExecutor cftexecutor = (IJavaScriptExecutor)cftdocumentsHelpdriver;
                cftdocumentsHelpdriver.Navigate().GoToUrl(ConfigurationSettings.AppSettings["QAT"]);
                cftdocumentsHelpdriver.Manage().Window.Maximize();
                cftdocumentsHelpdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                IWebElement elelogin = cftdocumentsHelpdriver.FindElement(By.Id("okta-signin-username"));
                elelogin.Clear();
                elelogin.SendKeys(ConfigurationSettings.AppSettings["userid"]);
                IWebElement elepassword = cftdocumentsHelpdriver.FindElement(By.Id("okta-signin-password"));
                elepassword.SendKeys(ConfigurationSettings.AppSettings["pwd"]);
                IWebElement btnsubmit = cftdocumentsHelpdriver.FindElement(By.Id("okta-signin-submit"));
                btnsubmit.Click();
                objbase.ImplicitwaitforPageload();

                cftdocumentsHelpdriver.SwitchTo().Window(cftdocumentsHelpdriver.WindowHandles.Last());
                objbase.ImplicitwaitforPageload();

                IWebElement eldocdivparentclass = cftdocumentsHelpdriver.FindElement(By.XPath("//div[@class='contextMenu']"));
                IWebElement eldocdivparentclasssub = eldocdivparentclass.FindElement(By.XPath("//span[contains(@class,'application documents')]"));
                IWebElement eldocdivparentclasssub1 = eldocdivparentclass.FindElement(By.ClassName("icon-documents"));
                eldocdivparentclasssub1.Click();
                cftdocumentsHelpdriver.SwitchTo().Window(cftdocumentsHelpdriver.WindowHandles.Last());
                objbase.ImplicitwaitforDocumentload();
                
                //  Help MEMU 7
                IWebElement elehelpmenu = cftdocumentsHelpdriver.FindElement(By.Id("HELP"));
                cftexecutor.ExecuteScript("arguments[0].click();", elehelpmenu);
                objbase.ImplicitwaitforDocumentload();

                // System Requirements

                IWebElement elesystemrequirement = cftdocumentsHelpdriver.FindElement(By.Name("System Requirements"));
                elesystemrequirement.Click();
                objbase.ImplicitwaitforDocumentload();
                cftexecutor.ExecuteScript("scrollBy(0,800)");

                // Recent

                IWebElement eleRecent = cftdocumentsHelpdriver.FindElement(By.Name("Home"));
                cftexecutor.ExecuteScript("arguments[0].click();", eleRecent);
                objbase.ImplicitwaitforDocumentload();

                // Documents Section

                IWebElement eledocuments = cftdocumentsHelpdriver.FindElement(By.Name("Documents"));
                cftexecutor.ExecuteScript("arguments[0].click();", eledocuments);
                objbase.ImplicitwaitforDocumentload();

                // Documents Section - Columns

                IWebElement eledocsectionColumns = cftdocumentsHelpdriver.FindElement(By.Name("Columns"));
                cftexecutor.ExecuteScript("arguments[0].click();", eledocsectionColumns);
                objbase.ImplicitwaitforDocumentload();

                // Documents Section - Download Multiple Documents

                IWebElement eleMultipleDocsection = cftdocumentsHelpdriver.FindElement(By.Name("Download Multiple Documents"));
                cftexecutor.ExecuteScript("arguments[0].click();", eleMultipleDocsection);
                objbase.ImplicitwaitforDocumentload();

                // Documents Section - Sort Documents

                IWebElement elesortsection = cftdocumentsHelpdriver.FindElement(By.Name("Sort Documents"));
                cftexecutor.ExecuteScript("arguments[0].click();", elesortsection);
                objbase.ImplicitwaitforDocumentload();

                // Documents Section - Filter Documents

                IWebElement elefilterdocs = cftdocumentsHelpdriver.FindElement(By.Name("Filter Documents"));
                cftexecutor.ExecuteScript("arguments[0].click();", elefilterdocs);
                objbase.ImplicitwaitforDocumentload();



            }
            catch(Exception exhelp)
            {
                Console.WriteLine("" + exhelp.Message.ToString());
            }

        }
        
    }
}
