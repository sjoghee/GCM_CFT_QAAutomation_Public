using System;
using System.Linq;
using System.Configuration;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
//using Robot;

using AutoIt;

namespace CFT_Automation
{
    [TestClass]
    public class Cft_LoginPage
    {
        IWebDriver driverlogin;

        Cft_Base objbase = new Cft_Base();
        IWebElement eletopdiv;

        [TestMethod]
        public void Validate_LoginPage()
        {
            try
            {
                
                driverlogin = objbase.InitiateDriver();
                IJavaScriptExecutor Loginexecutor = (IJavaScriptExecutor)driverlogin;
                driverlogin.Navigate().GoToUrl(ConfigurationSettings.AppSettings["QAT"]);
                driverlogin.Manage().Window.Maximize();
                driverlogin.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                IWebElement elelogin = driverlogin.FindElement(By.Id("okta-signin-username"));
                elelogin.Clear();
                elelogin.SendKeys(ConfigurationSettings.AppSettings["userid"]);
                IWebElement elepassword = driverlogin.FindElement(By.Id("okta-signin-password"));
                elepassword.SendKeys(ConfigurationSettings.AppSettings["pwd"]);
                IWebElement btnsubmit = driverlogin.FindElement(By.Id("okta-signin-submit"));
                btnsubmit.Click();
                objbase.ImplicitwaitforPageload();

                driverlogin.SwitchTo().Window(driverlogin.WindowHandles.Last());
                objbase.ImplicitwaitforPageload();

                IWebElement eleavblportfolio = driverlogin.FindElement(By.Id("availablePortfolios"));
                SelectElement selectportfolio = new SelectElement(eleavblportfolio);
                selectportfolio.SelectByText(ConfigurationSettings.AppSettings["PortfolioId"]);
                objbase.ImplicitwaitforPageload();

                Thread.Sleep(10000);
                IWebElement eledivdate = driverlogin.FindElement(By.XPath("//div[@class='page-content']"));
                IWebElement eledate = eledivdate.FindElement(By.Id("availableDates"));

              //  WebDriverWait wdwaitforreportdate = new WebDriverWait(driverlogin, TimeSpan.FromSeconds(60));
              //  wdwaitforreportdate.Until(ExpectedConditions.ElementToBeSelected(By.Id("availableDates")));

                SelectElement selectdate = new SelectElement(eledate);
                selectdate.SelectByValue(ConfigurationSettings.AppSettings["reportdate"]);
                objbase.ImplicitwaitforPageload();

                                              
                // Tab - Commentary

                bool reportsareaexists = objbase.validatelementexist(By.XPath("//div[@class='report-area']"));
                if(reportsareaexists)
                {

                    eletopdiv = driverlogin.FindElement(By.XPath("//div[@class='report-area']"));
                    IWebElement tabcommentary = eletopdiv.FindElement(By.Id("commentary-link"));
                    tabcommentary.Click();
                    Loginexecutor.ExecuteScript("scrollBy(0,475)");
                    //Console.Read();
                    objbase.ImplicitwaitforPageload();
                }

                // Tab - Allocation

                bool tabAllocationexists = objbase.validatelementexist(By.Id("allocation-link"));
                if (tabAllocationexists)
                {
                    IWebElement tabAllocation = eletopdiv.FindElement(By.Id("allocation-link"));
                    tabAllocation.Click();
                    objbase.ImplicitwaitforPageload();
                }

                // Tab - Statistics = 

                bool statisticsexists = objbase.validatelementexist(By.Id("statistics-link"));
                if (statisticsexists)
                {
                    IWebElement elestatistics = eletopdiv.FindElement(By.Id("statistics-link"));
                    elestatistics.Click();
                    objbase.ImplicitwaitforPageload();
                }

                // Tab - Returns
                bool returnsexists = objbase.validatelementexist(By.Id("returns-link"));
                if (returnsexists)
                {
                    IWebElement elereturns = eletopdiv.FindElement(By.Id("returns-link"));
                    elereturns.Click();
                    objbase.ImplicitwaitforPageload();
                    driverlogin.Quit();
                   
                }
                
                
                

            }
            catch(Exception exlogin)
            {
                Console.WriteLine("Login Page Exception Message:"+exlogin.Message.ToString());
            }
        }

        [TestMethod]
        public void ValidateSeleniumHQ()
        {

            try
            {
                driverlogin = objbase.InitiateDriver();
                driverlogin.Navigate().GoToUrl("https://www.seleniumhq.org/");
                driverlogin.Manage().Window.Maximize();
                objbase.ImplicitwaitforPageload();
                IWebElement eledownload = driverlogin.FindElement(By.LinkText("Download"));
                eledownload.Click();
                objbase.ImplicitwaitforDocumentload();
                IWebElement eelversion = driverlogin.FindElement(By.LinkText("3.141.59"));
                objbase.ImplicitwaitforPageload();
                eelversion.Click();
                objbase.ImplicitwaitforPageload();

                driverlogin.SwitchTo().ActiveElement();
                      
            
               

                //driverlogin.FindElement(By.

              // AutoItX.WinWaitActive("Downloads","",1);
             //  AutoItX.ControlClick("Downloads", "", "Open", " ", 1);

              

               
            
            
              //  string filedownload = string.Empty;
             //   AutoItX.Run("DownloadServerFromIE.exe", @"C:\AutoIT\", 2);

              /*  AutoItX.WinWaitActive("Notification", "", 1);
                AutoItX.Sleep(10);
                AutoItX.ControlClick("DirectUIHWND", "", "Open", " ", 1);*/

            //    AutoItX.ControlFocus("DirectUIHWND", "", "");
              
                AutoItX.Sleep(5);
              //  driverlogin.Quit();

             //   AutoItX.WinWaitActive("Open");
            //  AutoItX.Run(@"""C:\Program Files (x86)\AutoIt3\AutoIt3.exe"" /DownloadServerFromIE.exe", @"C:\AutoIT\", 1);
                
                                
               



            }
            catch (Exception winalert)
            {
                Console.WriteLine("Error Message:" + winalert.Message.ToString());
            }
        }


        [TestMethod]
        public void ValidateAnalyticReport()
        {
            try
            {
                driverlogin = objbase.InitiateDriver();
                IJavaScriptExecutor Loginexecutor = (IJavaScriptExecutor)driverlogin;
                driverlogin.Navigate().GoToUrl(ConfigurationSettings.AppSettings["QAT"]);
                driverlogin.Manage().Window.Maximize();
                driverlogin.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                IWebElement elelogin = driverlogin.FindElement(By.Id("okta-signin-username"));
                elelogin.Clear();
                elelogin.SendKeys(ConfigurationSettings.AppSettings["userid"]);
                IWebElement elepassword = driverlogin.FindElement(By.Id("okta-signin-password"));
                elepassword.SendKeys(ConfigurationSettings.AppSettings["pwd"]);
                IWebElement btnsubmit = driverlogin.FindElement(By.Id("okta-signin-submit"));
                btnsubmit.Click();
                objbase.ImplicitwaitforPageload();

                driverlogin.SwitchTo().Window(driverlogin.WindowHandles.Last());
                objbase.ImplicitwaitforPageload();

                IWebElement eleavblportfolio = driverlogin.FindElement(By.Id("availablePortfolios"));
                SelectElement selectportfolio = new SelectElement(eleavblportfolio);
                selectportfolio.SelectByText(ConfigurationSettings.AppSettings["PortfolioId"]);
                objbase.ImplicitwaitforPageload();

                objbase.ImplicitwaitforPageload();
                IWebElement eledivdate = driverlogin.FindElement(By.XPath("//div[@class='page-content']"));
                IWebElement eledate = eledivdate.FindElement(By.Id("availableDates"));

                SelectElement selectdate = new SelectElement(eledate);
                selectdate.SelectByValue(ConfigurationSettings.AppSettings["reportdate"]);
                objbase.ImplicitwaitforPageload();

                IWebElement eledivanalyticalcls = driverlogin.FindElement(By.XPath("//div[@class='investorBalance']"));
                IWebElement eledivanalyticalclssub = eledivanalyticalcls.FindElement(By.XPath("//div[@class='pm-packet-button']"));
                eledivanalyticalclssub.Click();
                objbase.ImplicitwaitforPageload();
                
                driverlogin.SwitchTo().Window(driverlogin.WindowHandles.Last());
                driverlogin.Manage().Window.Maximize();
                objbase.Implicitwaitforreport();
                driverlogin.Quit();
                
                   
            }
            catch (Exception ex)
            {
                Console.WriteLine(""+ex.Message.ToString());
            }

        }



    }

}

