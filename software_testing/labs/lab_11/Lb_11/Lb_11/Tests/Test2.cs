using Lb_11.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Lb_11.BrowserManager.BrowserManager;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Lb_11.Tests
{
    //find pick up point in Minsk
    [TestClass]
    public class Test2
    {
        private PickUpPointPage _pickUpPointPage;

        [SetUp]
        public void Setup()
        {
            _pickUpPointPage = new PickUpPointPage(Driver);
        }

        [Test]
        public void Test()
        {
            _pickUpPointPage.Open();
            _pickUpPointPage.Search("Минск");

            Assert.IsTrue(_pickUpPointPage.isFound());
        }

        [TestCleanup]
        public void Cleanup()
        {
            QuitDriver();
        }
    }
}
