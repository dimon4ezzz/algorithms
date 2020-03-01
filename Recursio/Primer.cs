using System;
using System.Collections.Generic;

namespace Recursio
{
    public class Primer
    {
        public bool Verbose { get; set; }

        public uint CallsAmount { get; private set; }

        public Primer() => ResetCounter();

        public void ResetCounter() => CallsAmount = 0;

        public SortedSet<uint> GetPrimes(uint number)
        {
            CallsAmount++;

            if (number == 0) throw new ArgumentException("0 has no prime dividers", "number");

            if (number == 1) return new SortedSet<uint> { 1 };

            uint center = (uint) Math.Ceiling(Math.Sqrt(number));
            Log($"`center` is {center}");
            
            var set = new SortedSet<uint>();

            for (uint i = 1; i <= center; i++)
            {
                Log($"`i` is {i}");
                if (number % i == 0)
                {
                    Log($"{number} is divide by {i}\tgo to next level");
                    set.UnionWith(GetPrimes(i));
                    LogEnumerator(set);
                }
            }

            if (set.Count == 1) set.Add(number);
            LogEnumerator(set);

            return set;
        }

        private void Log(string message)
        {
            if (Verbose) Console.WriteLine(message);
        }

        private void LogEnumerator<T>(IEnumerable<T> enumerator)
        {
            foreach (var i in enumerator)
            {
                Console.Write($"{i}\t");
            }

            Console.WriteLine();
        }
    }
}
