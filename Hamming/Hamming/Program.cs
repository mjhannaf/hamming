using System;
using System.Collections.Generic;

namespace Hamming
{
    internal class Program
    {
        public static int n;
        public static List<int> stack = new List<int>();

        private static void Main(string[] args)
        {
            // Get the n value
            Console.Write("Enter n: ");
            n = int.Parse(Console.ReadLine());


            // Get top limit
            Console.Write("\nEnter power: ");
            int pow = int.Parse(Console.ReadLine());

            // Get file write location
            Console.Write("Enter path for output file: ");
            string filePath = Console.ReadLine();

            var file = new System.IO.StreamWriter(filePath);


            double top = Math.Pow(10, pow);
            double count = 0;

            for (int i = 1; i <= top; i++)
            {
                isHammingNumber(i, 2);
                if (stack.Count > 0)
                {
                    ++count;
                    file.WriteLine(i);
                    stack.Clear();
                }
            }

            file.WriteLine(count + " elements");
            file.Close();
        }

        public static void isHammingNumber(int num, int divisor)
        {
            if (num == 1)
            {
                stack.Add(num);
            }
            if (num%divisor == 0)
            {
                if (num <= n)
                {
                    stack.Add(divisor);
                }
                isHammingNumber(num/divisor, 2);
                return;
            }
            if (divisor < n)
            {
                isHammingNumber(num, ++divisor);
            }
        }
    }
}