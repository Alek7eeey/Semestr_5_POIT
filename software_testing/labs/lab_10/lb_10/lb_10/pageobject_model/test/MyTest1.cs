using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lb_10.pageobject_model.page;

namespace lb_10.pageobject_model.test
{
    [TestClass]
    public class Test1
    {
        private IWebDriver driver;
        private MainPage _mainPage;
        private SearchResultPage _searchResultPage;
        private FavoritesPage _favoritesPage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            _mainPage = new MainPage(driver);
            _searchResultPage = new SearchResultPage(driver);
            _favoritesPage = new FavoritesPage(driver);
        }

        [Test]
        public void Test()
        {
            _mainPage.Open();
            _mainPage.Search("Смартфон Apple iPhone 12 eSIM+SIM 64 ГБ, белый");


            _searchResultPage.LikeProduct();
            _searchResultPage.GoToFavorites();

            NUnit.Framework.Assert.IsTrue(_favoritesPage.IsProductInFavorites());
        }
    }
}
