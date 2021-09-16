using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StringComparisons
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Setting up data");
            const string testString = "Hello world. How are you doing? This is a long string, so the hash method should have an easier time";
            var list = new List<string>();
            for (int i=0; i<1000000; i++)
            {
                // Creating string objects to prevent string interning
                list.Add("Hello world. How are you doing? This is a long string, so the hash method should have an easier time"+i);
            }

            Console.WriteLine("Running test");
            long timeNormal = 0;
            long timeHash = 0;
            Stopwatch stopwatch;
            for (int i=0; i<10; i++)
            {
                var equals = 0;

                // Normal
                stopwatch = Stopwatch.StartNew();
                foreach (var s in list)
                {
                    if (s == testString)
                    {
                        equals++;
                    }
                }
                stopwatch.Stop();
                timeNormal += stopwatch.ElapsedMilliseconds;

                // Hash
                stopwatch = Stopwatch.StartNew();
                var testStringhash = testString.GetHashCode();
                foreach (var s in list)
                {
                    if (s.GetHashCode() == testStringhash)
                    {
                        equals++;
                    }
                }
                stopwatch.Stop();
                timeHash += stopwatch.ElapsedMilliseconds;
            }

            Console.WriteLine("Time normal: " + timeNormal);
            Console.WriteLine("Time hash: " + timeHash);
        }
    }
}
