using System;
using System.Collections.Generic;

namespace Recursio
{
    public class Primer
    {
        public uint CallsAmount { get; private set; }

        public Primer() => ResetCounter();

        public void ResetCounter() => CallsAmount = 0;

        public SortedSet<uint> GetPrimes(uint number)
        {
            CallsAmount++;

            if (number == 0) throw new ArgumentException("0 has no prime dividers", "number");

            if (number == 1) return new SortedSet<uint> { 1 };

            uint center = (uint) Math.Floor(Math.Sqrt(number));
            
            var set = new SortedSet<uint>();

            for (uint i = 1; i <= center; i++)
            {
                if (number % i == 0)
                {
                    set.UnionWith(GetPrimes(i));
                }
            }

            if (set.Count == 1) set.Add(number);

            return set;
        }
    }
}
