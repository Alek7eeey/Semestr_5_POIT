using Lb_11.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Lb_11.BrowserManager.BrowserManager;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Lb_11.Tests
{
    //searching IT jobs
    [TestClass]
    public class Test9
    {
        private MainPage _mainPage;
        private ITJobPage _itJobPage;

        [SetUp]
        public void Setup()
        {
            _mainPage = new MainPage(Driver);
            _itJobPage = new ITJobPage(Driver);
        }

        [Test]
        public void Test()
        {
            _mainPage.Open();
            _mainPage.ClickITJob();
            _itJobPage.InputCity("Минск");
            _itJobPage.EnterSave();
            _itJobPage.GoToCSharp();
            Assert.IsTrue(_itJobPage.IsFoundJob());
        }

        [TestCleanup]
        public void Cleanup()
        {
            QuitDriver();
        }
    }
}

