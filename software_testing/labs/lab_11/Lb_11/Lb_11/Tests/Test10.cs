using Lb_11.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Lb_11.BrowserManager.BrowserManager;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Lb_11.Tests
{
    //searching IT jobs description
    [TestClass]
    public class Test10
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
            _itJobPage.ClickJob("//*[@id=\"__layout\"]/div/main/div[1]/div[1]/div[2]/div[2]/div[2]/div/div[1]/div[2]");
            Assert.IsTrue(_itJobPage.IsFoundJobDescription());
        }

        [TestCleanup]
        public void Cleanup()
        {
            QuitDriver();
        }
    }
}

