using Lb_11.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Lb_11.BrowserManager.BrowserManager;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Lb_11.Tests
{
    //add product to favorites and then check if it is in favorites
    [TestClass]
    public class Test1
    {
        private MainPage _mainPage;
        private SearchResultPage _searchResultPage;
        private FavoritesPage _favoritesPage;

        [SetUp]
        public void Setup()
        {
            _mainPage = new MainPage(Driver);
            _searchResultPage = new SearchResultPage(Driver);
            _favoritesPage = new FavoritesPage(Driver);
        }

        [Test]
        public void Test()
        {
            _mainPage.Open();
            _mainPage.Search("Смартфон Apple iPhone 12 eSIM+SIM 64 ГБ, белый");

            _searchResultPage.LikeProduct();
            _searchResultPage.GoToFavorites();

            Assert.IsTrue(_favoritesPage.IsProductInFavorites());
        }

        [TestCleanup]
        public void Cleanup()
        {
            QuitDriver();
        }
    }
}
