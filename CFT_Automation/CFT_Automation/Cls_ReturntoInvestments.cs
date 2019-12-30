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
    public class Cls_ReturntoInvestments
    {


        IWebDriver returntoInvestments;
        Cft_Base objbase = new Cft_Base();

        [TestMethod]
        public void Validate_CFT_ReturntoInvestments()
        {

            returntoInvestments = objbase.InitiateDriver();

            
        }

    }
}
