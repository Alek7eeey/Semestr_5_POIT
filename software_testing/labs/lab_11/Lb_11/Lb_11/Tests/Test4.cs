using Lb_11.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Lb_11.BrowserManager.BrowserManager;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Lb_11.Tests
{
    //find product
    [TestClass]
    public class Test4
    {
        private MainPage _mainPage;
        private SearchResultPage _searchResultPage;

        [SetUp]
        public void Setup()
        {
            _mainPage = new MainPage(Driver);
            _searchResultPage = new SearchResultPage(Driver);
        }

        [Test]
        public void Test()
        {
            _mainPage.Open();
            _mainPage.Search("Беспроводные наушники PRO с микрофоном для и Андроид, tws, bluetooth.");

            Assert.IsTrue(_searchResultPage.isFound());
        }

        [TestCleanup]
        public void Cleanup()
        {
            QuitDriver();
        }
    }
}
