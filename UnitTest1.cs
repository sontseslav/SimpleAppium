using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using Assert = NUnit.Framework.Assert;

namespace SimpleAppium
{
    public class UnitTest1
    {
        IWebDriver driver;
        ChromeOptions options;
        [FindsBy(How = How.Name, Using = "q")]
        public IWebElement TxtSearch { get; set; }

        [Test]
        public void TestOnNexus()
        {
            options = new ChromeOptions();
            options.EnableMobileEmulation("Nexus 5");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://www.google.com");
            PageFactory.InitElements(driver, this);
            Assert.IsTrue(TxtSearch.Displayed);
        }

        [Test]
        public void TestOnIPhone()
        {
            options = new ChromeOptions();
            options.EnableMobileEmulation("iPhone 6");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://www.google.com");
            PageFactory.InitElements(driver, this);
            Assert.IsTrue(TxtSearch.Displayed);
        }

        [Test]
        public void TestAppium()
        {
            Dictionary<string, object> OptDic = new Dictionary<string, object>(); ;
            OptDic.Add("platformName", "Android");
            OptDic.Add("platformVersion", "7.0");
            OptDic.Add("deviceName", "Android Phone");
            OptDic.Add("browserName", "Chrome");
            ICapabilities options 
                = new DesiredCapabilities(OptDic);
            driver = new RemoteWebDriver(
                new System.Uri("http://127.0.0.1:4723/wd/hub"), options);
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Close();
                driver.Quit();
            }
        }
    }
}
