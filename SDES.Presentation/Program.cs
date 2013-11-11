using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDES.Presentation
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
            Console.WriteLine("Enter text:");
            string text = Console.ReadLine();

            var o = EncriptText(sDes, text, k1, k2);

         //   DecriptText(sDes, o, k1, k2);

            Console.ReadKey();
        }

        private static void GenerateKeys(int key, SDesAlgorithm sDes, out IList<byte> k1, out IList<byte> k2)
        {
            sDes.GenerateKeys(key);
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

        private static string EncriptText(SDesAlgorithm sDes, string text, IList<byte> k1, IList<byte> k2)
        {
            var str = string.Empty;
            for (var i = 0; i < text.Count(); i++)
            {
                var o = sDes.Encript(text[i].ToString());
                str += o;

//                IList<byte> bytes = sDes.StringToBytes(text[i].ToString());
//              //  Console.WriteLine("Symbol: '{0}' to bytes: {1}", text[i], string.Join("", bytes));
//
//                var ip = sDes.ToIP(bytes);
//                Print("IP: {0}", ip);
//
//                var fk1 = sDes.Fk(ip, k1);
//                Print("Fk: {0}", fk1);
//
//                var sw = sDes.SW(fk1, ip.Skip(4).Take(4).ToList());
//                Print("SW: {0}", sw);
//
//                var fk2 = sDes.Fk(sw, k2);
//                Print("Fk: {0}", fk2);
//
//                var sw2 = sDes.SW(fk1, fk2);
//                Print("SW: {0}", sw2);
//
//                var ip_1 = sDes.ToIP_1(sw2);
//                Print("IP-1 {0}", ip_1);

           //     Console.WriteLine("Encrypt symbol: {0}", o);
            }
            return str;
        }
        private static void DecriptText(SDesAlgorithm sDes, string text, IList<byte> k1, IList<byte> k2)
        {
            for (var i = 0; i < 1; i++)
            {
                var o = sDes.Decript(text[i].ToString());
//
//                IList<byte> bytes = sDes.StringToBytes(text[i].ToString());
//                Console.WriteLine("Symbol: '{0}' to bytes: {1}", text[i], string.Join("", bytes));
//
//                var ip = sDes.ToIP(bytes);
//                Print("IP: {0}", ip);
//
//                var fk1 = sDes.Fk(ip, k2);
//                Print("Fk: {0}", fk1);
//
//                var sw = sDes.SW(fk1, ip.Skip(4).Take(4).ToList());
//                Print("SW: {0}", sw);
//
//                var fk2 = sDes.Fk(sw, k1);
//                Print("Fk: {0}", fk2);
//
//                var sw2 = sDes.SW(fk1, fk2);
//                Print("SW: {0}", sw2);
//
//                var ip_1 = sDes.ToIP_1(sw2);
//                Print("IP-1 {0}", ip_1);
//
//                Console.WriteLine("Decrypt symbol: {0}", o);
            }
        }

        private static void Print(string text, IList<byte> bytes)
        {
            Console.WriteLine(text, string.Join("", bytes));
        }
    }
}
