using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDES;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Key:");
            int key = int.Parse(s: Console.ReadLine());

            SDesAlgorithm sDes = new SDesAlgorithm();

            IList<byte> k1;
            IList<byte> k2;
            GenerateKeys(key, sDes, out k1, out k2);

            Console.WriteLine("");
//            Console.WriteLine("Enter text:");
//            string text = Console.ReadLine();
            string text = File.ReadAllText(@"./1.bin");


            Console.WriteLine("Please, switch case: 1 - Encrypt, 2 - Decrypt");
            var switchCase = Console.ReadLine();

            string result = string.Empty;
            switch (switchCase)
            {
                case "1":
                    result = EncriptText(sDes, text);
                    break;
                default:
                    result = DecryptText(sDes, text);
                    break;
            }
            File.WriteAllText(@"./1.bin", result);
            Console.ReadKey();
        }

        private static void GenerateKeys(int key, SDesAlgorithm sDes, out IList<byte> k1, out IList<byte> k2)
        {
            sDes.GenerateKeys(642);
            var bytes = sDes.DecToBytes(key);

            bytes = sDes.ToP10(bytes);
            Print("P10: {0}", bytes);

            bytes = sDes.CyclicShift_One(bytes);
            Print("Cyclin shift 1: {0}", bytes);

            k1 = sDes.ToP8(bytes);
            Print("K1: {0}", k1);

            bytes = sDes.CyclicShift_Two(bytes);
            Print("Cyclin shift {0}", bytes);

            k2 = sDes.ToP8(bytes);
            Print("K2: {0}", k2);
        }

        private static string EncriptText(SDesAlgorithm sDes, string text)
        {
            var str = string.Empty;
            for (var i = 0; i < text.Length; i++)
            {
                var o = sDes.Encript(text[i].ToString());
                str += o;
                }
            return str;
        }
        private static string DecryptText(SDesAlgorithm sDes, string text)
        {
            var str = string.Empty;
            for (var i = 0; i < text.Length; i++)
            {
                var o = sDes.Decript(text[i].ToString());
                str += o;
                }
            return str;
        }

        private static void Print(string text, IList<byte> bytes)
        {
          //  Console.WriteLine(text, string.Join("", bytes));
        }
    }

}
