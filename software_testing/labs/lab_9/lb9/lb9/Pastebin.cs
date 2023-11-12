using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb9
{
    public class PastebinPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public PastebinPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void OpenPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void SetCode(string code)
        {
            IWebElement codeTextArea = driver.FindElement(By.Id("postform-text"));
            codeTextArea.SendKeys(code);
        }

        public void SetExpiration(string expiration)
        {
            driver.FindElement(By.Id("select2-postform-expiration-container")).Click();
            driver.FindElement(By.XPath("//li[text()='10 Minutes']")).Click();

        }
        public void SetBash()
        {
            driver.FindElement(By.Id("select2-postform-format-container")).Click();
            driver.FindElement(By.XPath("//li[text()='Bash']")).Click();
        }

        public void SetPasteName(string name)
        {
            IWebElement pasteNameInput = driver.FindElement(By.Id("postform-name"));
            pasteNameInput.SendKeys(name);
            driver.FindElement(By.XPath("//*[@id=\"w0\"]/div[5]/div[1]/div[10]/button")).Click();
        }

        public void CreateNewPaste()
        {
            IWebElement createButton = driver.FindElement(By.Id("submit"));
            createButton.Click();
        }
    }
}
