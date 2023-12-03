using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using static Lb_11.Log.Log;

namespace Lb_11.Pages
{
    internal class ITJobPage : PageBase.PageBase
    {
        public ITJobPage(IWebDriver driver) : base(driver)
        {
        }

        public void InputCity(string message)
        {
            IWebElement searchInput = Driver.FindElement(By.XPath("//*[@id=\"__layout\"]/div/div[1]/div/div/div[2]/div/div[1]/div/input"));
            searchInput.Click();
            searchInput.SendKeys(message);
            Info("Input city = " + message);
            searchInput.Click();
        }

        public void EnterSave()
        {
            Driver.FindElement(By.XPath("//*[@id=\"__layout\"]/div/div[1]/div/div/div[2]/button")).Click();
            Info("Cllick save city for job.");
        }

        public void GoToCSharp()
        {
            Driver.FindElement(By.XPath("//*[@id=\"__layout\"]/div/main/div[2]/div/div/div/a[2]")).Click();
            Info("Go to CSharp region.");
        }

        public bool IsFoundJob()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                IWebElement element = Driver.FindElement(By.XPath("//*[@id=\"__layout\"]/div/main/div[1]/div[2]/div[2]/div[3]/div/div[1]/div[2]"));
                Info("Job is found.");
                return true;
            }
            catch (NoSuchElementException)
            {
                Info("Job is not found.");
                return false;
            }
        }

        public void ClickJob(string vocation)
        {
            Driver.FindElement(By.XPath(vocation)).Click();
            Info("Go to vocation.");
            // Получаем идентификаторы всех открытых окон
            List<string> windowHandles = new List<string>(Driver.WindowHandles);

            // Переключаемся на последнее открытое окно (новую страницу)
            Driver.SwitchTo().Window(windowHandles[windowHandles.Count - 1]);
        }

        public bool IsFoundJobDescription()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                IWebElement element = Driver.FindElement(By.XPath("//*[@id=\"__layout\"]/div/main/div[1]/div[1]/div[1]/div[3]"));
                Info("Job description is found.");
                return true;
            }
            catch (NoSuchElementException)
            {
                Info("Job description is not found.");
                return false;
            }
        }
    }

}
