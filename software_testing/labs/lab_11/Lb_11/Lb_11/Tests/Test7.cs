using Lb_11.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Lb_11.BrowserManager.BrowserManager;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Lb_11.Tests
{
    //searching in catalog and searching product
    [TestClass]
    public class Test7
    {
        private MainPage _mainPage;
        private SearchResultPage _searchResultPage;
        private ProductPage _productPage;

        [SetUp]
        public void Setup()
        {
            _mainPage = new MainPage(Driver);
            _searchResultPage = new SearchResultPage(Driver);
            _productPage = new ProductPage(Driver);
        }

        [Test]
        public void Test()
        {
            _mainPage.Open();
            _mainPage.ClickCatalog();
            _mainPage.HoverOverFishingAndHunterSection();
            _mainPage.ClickSection();

            Assert.IsTrue(_searchResultPage.isFound());
        }

        [TestCleanup]
        public void Cleanup()
        {
            QuitDriver();
        }
    }
}
