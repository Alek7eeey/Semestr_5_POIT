using Lab_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        Calculator calculator = new Calculator();
        private long currentSum = 0;
        private long saveSum = 0;
        private bool plus = false;
        private bool minus = false;
        private bool mult = false;
        private bool del = false;
        private bool ost = false;

        [TestMethod]
        public void TestCase1()
        {
            //5+6
            plus = true;
            currentSum = 5;
            calculator.MakeOpeartionStr(ref currentSum, "6", ref plus, ref minus, ref del, ref mult, ref ost);
            Assert.AreEqual(11, currentSum);
        }

        [TestMethod]
        public void TestCase2()
        {
            //28-4
            minus = true;
            currentSum = 28;
            calculator.MakeOpeartionStr(ref currentSum, "4", ref plus, ref minus, ref del, ref mult, ref ost);
            Assert.AreEqual(24, currentSum);
        }

        [TestMethod]
        public void TestCase3()
        {
            //4*9
            mult = true;
            currentSum = 4;
            calculator.MakeOpeartionStr(ref currentSum, "9", ref plus, ref minus, ref del, ref mult, ref ost);
            Assert.AreEqual(36, currentSum);
        }

        [TestMethod]
        public void TestCase4()
        {
            //224/9
            del = true;
            currentSum = 224;
            calculator.MakeOpeartionStr(ref currentSum, "9", ref plus, ref minus, ref del, ref mult, ref ost);
            Assert.AreEqual(24, currentSum);
        }

        [TestMethod]
        public void TestCase5()
        {
            //224%9
            ost = true;
            currentSum = 224;
            calculator.MakeOpeartionStr(ref currentSum, "9", ref plus, ref minus, ref del, ref mult, ref ost);
            Assert.AreEqual(8, currentSum);
        }

        [TestMethod]
        public void TestCase6()
        {
            //224/0
            del = true;
            currentSum = 224;
            var ex = Assert.ThrowsException<Exception>(() => calculator.MakeOpeartionStr(ref currentSum, "0", ref plus, ref minus, ref del, ref mult, ref ost));
            Assert.AreEqual("division by zero", ex.Message);
        }

        [TestMethod]
        public void TestCase7()
        {
            //224%0
            ost = true;
            currentSum = 224;
            var ex = Assert.ThrowsException<Exception>(() => calculator.MakeOpeartionStr(ref currentSum, "0", ref plus, ref minus, ref del, ref mult, ref ost));
            Assert.AreEqual("division by zero", ex.Message);
        }

        [TestMethod]
        public void TestCase8()
        {
            //224+''
            plus = true;
            currentSum = 224;
            var ex = Assert.ThrowsException<Exception>(() => calculator.MakeOpeartionStr(ref currentSum, "", ref plus, ref minus, ref del, ref mult, ref ost));
            Assert.AreEqual("Ничего не введено!", ex.Message);
        }

        [TestMethod]
        public void TestCase9()
        {
            //224+'asdsa'
            plus = true;
            currentSum = 224;
            var ex = Assert.ThrowsException<FormatException>(() => calculator.MakeOpeartionStr(ref currentSum, "asdsa", ref plus, ref minus, ref del, ref mult, ref ost));
            Assert.AreEqual("Входная строка имела неверный формат.", ex.Message);
        }

        [TestMethod]
        public void TestCase10()
        {
            //336/9*5 == 186 (но т.к. long округляет, то 185)
            del = true;
            currentSum = 336;
            calculator.MakeOpeartionStr(ref currentSum, "9", ref plus, ref minus, ref del, ref mult, ref ost);
            del = false;
            mult = true;
            calculator.MakeOpeartionStr(ref currentSum, "5", ref plus, ref minus, ref del, ref mult, ref ost);
            Assert.AreEqual(185, currentSum);
        }
    }
}
