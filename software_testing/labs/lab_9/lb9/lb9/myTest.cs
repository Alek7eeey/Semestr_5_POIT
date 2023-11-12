using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;

namespace lb9
{
    [TestClass]
    public class myTest
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

            driver.Navigate().GoToUrl("https://ozon.by/");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

            driver.FindElement(By.XPath("//*[@id=\"stickyHeader\"]/div[2]/div/div/form/div[1]/div[2]/input[1]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"stickyHeader\"]/div[2]/div/div/form/div[1]/div[2]/input[1]")).SendKeys("Смартфон Apple iPhone 12 eSIM+SIM 64 ГБ, белый");
            driver.FindElement(By.XPath("//*[@id=\"stickyHeader\"]/div[2]/div/div/form/div[1]/div[2]/input[1]")).SendKeys(Keys.Enter);

            driver.FindElement(By.XPath("//*[@id=\"paginatorContent\"]/div/div/div[1]/div[1]/a")).Click();

            driver.FindElement(By.XPath("//*[@id=\"layoutPage\"]/div[1]/div[3]/div[3]/div[2]/div[2]/div/div/div[2]/div/div/div[1]/div/div/div/div[1]/div/button")).Click();
            
            driver.FindElement(By.XPath("//*[@id=\"stickyHeader\"]/div[3]/a[2]")).Click();

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement element = driver.FindElement(By.XPath("//*[@id=\"layoutPage\"]/div[1]/div/div/div[2]/div[4]/div[1]/div/div/div[2]/div/div/div[2]"));
            }
            catch (NoSuchElementException)
            {
                // Ваш код, который выполнится, если элемент не найден
                Assert.Fail("Элемент не найден");
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
