
using System;
using System.Collections.Generic;

namespace SDES
{
    public class SDesAlgorithm
    {
        public IList<byte> DecToButes(int value)
        {
            if (value < 0 || value > 1023)
            {
                throw new ArgumentException();
            }
            var result = new List<byte>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var stringButes = Convert.ToString(value, 2);
            for (int i = stringButes.Length - 1, j = 9; i >= 0; i--, j--)
            {
                result[j] = byte.Parse(stringButes[i].ToString());
            }
            return result;
        }

        public IList<byte> ToP10(IList<byte> key)
        {
            var result = new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            result[0] = key[2];
            result[1] = key[4];
            result[2] = key[1];
            result[3] = key[6];
            result[4] = key[3];
            result[5] = key[9];
            result[6] = key[0];
            result[7] = key[8];
            result[8] = key[7];
            result[9] = key[5];
            return result;
        }

        public IList<byte> ToP8(IList<byte> key)
        {
            var result = new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0/*, 0, 0*/ };
            result[0] = key[5];
            result[1] = key[2];
            result[2] = key[6];
            result[3] = key[3];
            result[4] = key[7];
            result[5] = key[4];
            result[6] = key[9];
            result[7] = key[8];
//            result[8] = key[5];
//            result[9] = key[9];
            return result;
        }

        public IList<byte> CyclicShift_One(IList<byte> key)
        {
            var result = new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            result[0] = key[1];
            result[1] = key[2];
            result[2] = key[3];
            result[3] = key[4];
            result[4] = key[0];
            result[5] = key[6];
            result[6] = key[7];
            result[7] = key[8];
            result[8] = key[9];
            result[9] = key[5];
            return result;
        }

        public IList<byte> CyclicShift_Two(IList<byte> key)
        {
            var result = new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            result[0] = key[2];
            result[1] = key[3];
            result[2] = key[4];
            result[3] = key[0];
            result[4] = key[1];
            result[5] = key[7];
            result[6] = key[8];
            result[7] = key[9];
            result[8] = key[5];
            result[9] = key[6];
            return result;
        }
    }

}
