using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lb9
{
    [TestClass]
    public class PastebinTest3
    {
        private IWebDriver driver;
        private PastebinPage pastebinPage;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            pastebinPage = new PastebinPage(driver);
        }

        [TestMethod]
        public void CreateNewPasteTest()
        {

            driver.Navigate().GoToUrl("https://cloud.google.com/");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

            driver.FindElement(By.XPath("//*[@id=\"kO001e\"]/div[2]/div[1]/div/div[2]/div[2]/div[1]/form/div/input")).Click();
            driver.FindElement(By.XPath("//*[@id=\"kO001e\"]/div[2]/div[1]/div/div[2]/div[2]/div[1]/form/div/input")).SendKeys("Google Cloud Platform Pricing Calculator");
            driver.FindElement(By.XPath("//*[@id=\"kO001e\"]/div[2]/div[1]/div/div[2]/div[2]/div[1]/form/div/input")).SendKeys(Keys.Enter);

            driver.FindElement(By.XPath("//*[@id=\"___gcse_0\"]/div/div/div/div[5]/div[2]/div/div/div[1]/div[1]/div[1]/div[1]/div/a")).Click();


            driver.FindElement(By.XPath("//*[@id=\"mainForm\"]/div[2]/div/md-card/md-card-content/div/div[1]/form/div[1]/div[1]/md-input-container//*[@id=\"input_101\"]")).SendKeys("4");
            //driver.FindElement(By.XPath("//*[@id=\"input_99\"]")).SendKeys("4");

        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
