using lb_10.pageobject_model.page;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb_10.pageobject_model.test
{
    [TestClass]
    public class Test2
    {
        private IWebDriver driver;
        private PickUpPointPage _pickUpPointPage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            _pickUpPointPage = new PickUpPointPage(driver);
        }

        [Test]
        public void Test()
        {
            _pickUpPointPage.Open();
            _pickUpPointPage.Search("Минск, улица Бурдейного, 6к1");

            NUnit.Framework.Assert.IsTrue(_pickUpPointPage.isFound());
        }
    }
}
