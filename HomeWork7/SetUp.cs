using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HomeWork7
{
    [SetUpFixture]
    public class SetUpFixture
    {
        public IWebDriver driver;
        
        [OneTimeSetUp]
        public void InitializeDriver()
        {
            var chromeOptions = new ChromeOptions();
        
            driver = new ChromeDriver(chromeOptions);
        }

        [OneTimeTearDown]
        public void Clean()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}