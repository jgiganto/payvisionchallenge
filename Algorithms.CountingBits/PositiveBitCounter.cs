// <copyright file="PositiveBitCounter.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Algorithms.CountingBits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PositiveBitCounter
    {     
        public IEnumerable<int> Count(long numberToConvert)
        {
            if(numberToConvert < 0)
            {
                throw new ArgumentException("Numbers to convert must to be greater than zero");
            }

            List<int> binaryNumbers = new List<int>();   
        
            int indexOfBit = 0;
            int PositiveBitsAcumulator = 0;

            while (numberToConvert > 0)
            {
                if (IsOdd(numberToConvert) == true)
                {
                    binaryNumbers.Add(indexOfBit);
                    PositiveBitsAcumulator++;
                }

                numberToConvert /= 2;
                indexOfBit++;
            }

            binaryNumbers.Insert(0, PositiveBitsAcumulator);

            return binaryNumbers.AsEnumerable();           
        }

        private static bool IsOdd(long value)
        {
            return value % 2 != 0;
        }
    }   
}
