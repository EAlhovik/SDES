using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDES.Test
{
    [TestClass]
    public class SDesAlgorithmTest
    {
        [TestMethod]
        public void DecToBin()
        {
            var sDes = new SDesAlgorithm();
            var bytes = sDes.DecToButes(642);
            var actualResult = new List<byte> {1, 0, 1, 0, 0, 0, 0, 0, 1, 0};
            CollectionAssert.AreEqual(actualResult, bytes.ToList());
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(ArgumentException))]
        public void IncorrectValues()
        {
            var sDes = new SDesAlgorithm();
            sDes.DecToButes(1024);
             sDes.DecToButes(-1);
        }

        [TestMethod]
        public void P10_Test()
        {
            var sDes = new SDesAlgorithm();
            var butes = new List<byte> { 1, 0, 1, 0, 0, 0, 0, 0, 1, 0 };
            var actualResult = new List<byte> { 1, 0, 0, 0, 0, 0, 1, 1, 0, 0 };
            CollectionAssert.AreEqual(actualResult, sDes.ToP10(butes).ToList());
        }

        [TestMethod]
        public void P8_Test()
        {
            var sDes = new SDesAlgorithm();
            var butes = new List<byte> { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 };
            var actualResult = new List<byte> { 1, 0, 1, 0, 0, 1, 0, 0 };
            CollectionAssert.AreEqual(actualResult, sDes.ToP8(butes).ToList());
        }

        [TestMethod]
        public void P8_Test2()
        {
            var sDes = new SDesAlgorithm();
            var butes = new List<byte> { 0, 0, 1, 0, 0, 0, 0, 0, 1, 1 };
            var actualResult = new List<byte> { 0, 1, 0, 0, 0, 0, 1, 1 };
            CollectionAssert.AreEqual(actualResult, sDes.ToP8(butes).ToList());
        }

        [TestMethod]
        public void CyclicShift_One_Test()
        {
            var sDes = new SDesAlgorithm();
            var butes = new List<byte> { 1, 0, 0, 0, 0, 0, 1, 1, 0, 0 };
            var actualResult = new List<byte> { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 };
            CollectionAssert.AreEqual(actualResult, sDes.CyclicShift_One(butes).ToList());
        }

        [TestMethod]
        public void CyclicShift_Two_Test()
        {
            var sDes = new SDesAlgorithm();
            var butes = new List<byte> { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 };
            var actualResult = new List<byte> { 0, 0, 1, 0, 0, 0, 0, 0, 1, 1 };
            CollectionAssert.AreEqual(actualResult, sDes.CyclicShift_Two(butes).ToList());
        }
    }
}
