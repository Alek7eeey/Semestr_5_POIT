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
    public class PastebinTest1
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
            pastebinPage.OpenPage("https://pastebin.com");
     
            driver.FindElement(By.Id("postform-text")).SendKeys("git config --global user.name  \"New Sheriff in Town\"" + "\ngit reset $(git commit - tree HEAD ^{ tree} -m \"Legacy code\") "
                + "\ngit push origin master --force");

            pastebinPage.SetExpiration("10 Minutes");
            pastebinPage.SetBash();

      

            driver.FindElement(By.Id("postform-name")).SendKeys("how to gain dominance among developers");
            driver.FindElement(By.XPath("//*[@id=\"w0\"]/div[5]/div[1]/div[10]/button")).Click();
            // Добавьте здесь проверки на успешное создание пасты, например, проверку URL или отображение уведомления.
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
