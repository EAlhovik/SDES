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
            var bytes = sDes.DecToBytes(642);
            var actualResult = new List<byte> { 1, 0, 1, 0, 0, 0, 0, 0, 1, 0 };
            CollectionAssert.AreEqual(actualResult, bytes.ToList());
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(ArgumentException))]
        public void IncorrectValues()
        {
            var sDes = new SDesAlgorithm();
            sDes.DecToBytes(1024);
            sDes.DecToBytes(-1);
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

        [TestMethod]
        public void GenerateKeys_Test()
        {
            var sDes = new SDesAlgorithm();
            sDes.GenerateKeys(642);

            var actualK1 = new List<byte> { 1, 0, 1, 0, 0, 1, 0, 0 };
            var actualK2 = new List<byte> { 0, 1, 0, 0, 0, 0, 1, 1 };
            CollectionAssert.AreEqual(actualK1, sDes.k1.ToList());
            CollectionAssert.AreEqual(actualK2, sDes.k2.ToList());
        }

        [TestMethod]
        public void GetDec_Test()
        {
            var sDes = new SDesAlgorithm();
            var actualResult = new List<byte> { 0, 1, 1, 1, 0, 1, 0, 0 };

            CollectionAssert.AreEqual(actualResult, sDes.StringToBytes("t").ToList());
        }

        [TestMethod]
        public void GetEnc_Test()
        {
            var sDes = new SDesAlgorithm();
            var actualResult = new List<byte> { 0, 1, 1, 1, 0, 1, 0, 0 };
            var stringBin = string.Join(string.Empty, actualResult);
            var dec = Convert.ToInt32(stringBin, 2);
            var text = char.ConvertFromUtf32(dec);
            CollectionAssert.AreEqual(actualResult, sDes.StringToBytes("t").ToList());
            Assert.AreEqual(text, "t");
        }

        [TestMethod]
        public void IP()
        {
            var sDes = new SDesAlgorithm();
            var actualResult = new List<byte> { 1, 1, 1, 0, 1, 0, 0, 0 };
            CollectionAssert.AreEqual(actualResult, sDes.ToIP(sDes.StringToBytes("t")).ToList());
        }

        [TestMethod]
        public void EP()
        {
            var sDes = new SDesAlgorithm();
            var actualResult = new List<byte> { 0, 1, 0, 0, 0, 0, 0, 1 };
            CollectionAssert.AreEqual(actualResult, sDes.EP(new List<byte> { 1, 0, 0, 0 }).ToList());
        }

        [TestMethod]
        public void XOR()
        {
            var sDes = new SDesAlgorithm();
            var param1 = new List<byte> { 0, 1, 0, 0, 0, 0, 0, 1 };
            var param2 = new List<byte> { 1, 0, 1, 0, 0, 1, 0, 0 };
            var actualResult = new List<byte> { 1, 1, 1, 0, 0, 1, 0, 1 };
            CollectionAssert.AreEqual(actualResult, sDes.XOR(param1, param2).ToList());
        }
        [TestMethod]
        public void SMatrix()
        {
            var sDes = new SDesAlgorithm();
            var param1 = new List<byte> { 1, 1, 1, 0, 0, 1, 0, 1 };
            var actualResult = new List<byte> { 1, 1, 0, 1 };
            CollectionAssert.AreEqual(actualResult, sDes.SMatrix(param1).ToList());
        }

        [TestMethod]
        public void P4()
        {
            var sDes = new SDesAlgorithm();
            var param1 = new List<byte> { 1, 1, 0, 1 };
            var actualResult = new List<byte> { 1, 1, 0, 1 };
            CollectionAssert.AreEqual(actualResult, sDes.P4(param1).ToList());
        }

        [TestMethod]
        public void SW()
        {
            var sDes = new SDesAlgorithm();
            var param1 = new List<byte> { 0, 0, 1, 1 };
            var param2 = new List<byte> { 1, 0, 0, 0 };
            var actualResult = new List<byte> { 1, 0, 0, 0, 0, 0, 1, 1 };
            CollectionAssert.AreEqual(actualResult, sDes.SW(param1, param2).ToList());
        }

        [TestMethod]
        public void XOR4()
        {
            var sDes = new SDesAlgorithm();
            var param1 = new List<byte> { 1, 1, 1, 0 };
            var param2 = new List<byte> { 1, 1, 0, 1 };
            var actualResult = new List<byte> { 0, 0, 1, 1 };
            CollectionAssert.AreEqual(actualResult, sDes.XOR(param1, param2).ToList());
        }

        [TestMethod]
        public void Fk()
        {
            var sDes = new SDesAlgorithm();
            var param1 = new List<byte> { 1, 1, 1, 0, 1, 0, 0, 0 };
            var param2 = new List<byte> { 1, 0, 1, 0, 0, 1, 0, 0 };
            var actualResult = new List<byte> {0, 0, 1, 1 };
            CollectionAssert.AreEqual(actualResult, sDes.Fk(param1, param2).ToList());
        }

        [TestMethod]
        public void MainTest()
        {
            var sDes = new SDesAlgorithm();
            sDes.GenerateKeys(642);

            var text = "t";

            var encrpt = sDes.Encript(text);
            var decr = sDes.Decript(encrpt);
            Assert.AreEqual(text, decr);
        }


    }
}
