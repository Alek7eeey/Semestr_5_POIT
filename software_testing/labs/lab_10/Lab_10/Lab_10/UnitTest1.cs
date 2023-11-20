using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;

namespace Lab_10
{
    [TestClass]
    public class myTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
        }

        [TestMethod]
        public void CreateNewPasteTest()
        {

            driver.Navigate().GoToUrl("https://ozon.by/");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

            driver.FindElement(By.XPath("//*[@id=\"stickyHeader\"]/div[2]/div/div/form/div[1]/div[2]/input[1]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"stickyHeader\"]/div[2]/div/div/form/div[1]/div[2]/input[1]")).SendKeys("Смартфон Apple iPhone 12 eSIM+SIM 64 ГБ, белый");
            driver.FindElement(By.XPath("//*[@id=\"stickyHeader\"]/div[2]/div/div/form/div[1]/div[2]/input[1]")).SendKeys(Keys.Enter);

            //driver.FindElement(By.XPath("//*[@id=\"paginatorContent\"]/div/div/div[1]/div[1]/a")).Click();

            //driver.FindElement(By.Id("select2-postform-expiration-container")).Click();

            driver.FindElement(By.XPath("//*[@id=\"paginatorContent\"]/div/div/div[1]/div[2]/div/button")).Click(); //ставим лайк

            driver.FindElement(By.XPath("//*[@id=\"stickyHeader\"]/div[3]/a[1]")).Click();

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement element = driver.FindElement(By.XPath("//*[@id=\"layoutPage\"]/div[1]/div[2]/div/div[2]/div[5]/div/div/div/div"));
            }
            catch (NoSuchElementException)
            {
                // Ваш код, который выполнится, если элемент не найден
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Элемент не найден");
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}