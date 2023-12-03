using Lb_11.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Lb_11.BrowserManager.BrowserManager;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Lb_11.Tests
{
    //add product to basket and then check if it is in basket
    [TestClass]
    public class Test3
    {
        private MainPage _mainPage;
        private SearchResultPage _searchResultPage;
        private BasketPage _basketPage;

        [SetUp]
        public void Setup()
        {
            _mainPage = new MainPage(Driver);
            _searchResultPage = new SearchResultPage(Driver);
            _basketPage = new BasketPage(Driver);
        }

        [Test]
        public void Test()
        {
            _mainPage.Open();
            _mainPage.Search("Коллекционные семена томата Кас 21");

            _searchResultPage.AddToBasket();
            _searchResultPage.GoToBasket();

            Assert.IsTrue(_basketPage.IsProductInBasket());
        }

        [TestCleanup]
        public void Cleanup()
        {
            QuitDriver();
        }
    }
}
