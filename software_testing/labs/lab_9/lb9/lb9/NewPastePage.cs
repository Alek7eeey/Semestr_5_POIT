using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace lb9
{
  

    public class NewPastePage
    {
        private IWebDriver driver;

        public NewPastePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetPasteURL()
        {
            IWebElement pasteURL = driver.FindElement(By.CssSelector("div.info-bar a"));
            return pasteURL.GetAttribute("href");
        }
    }

}
