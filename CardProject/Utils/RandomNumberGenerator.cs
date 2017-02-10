using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CardProject.Utils
{
    public static class RandomNumberUtils
    {
        /// <summary>
        /// This retrieves a random int from a range.  This is a function because there
        /// are multiple ways to grab a random number, so this lets us iteratively improve our random
        /// number generator without affecting multiple places in code.
        /// </summary>
        /// <param name="startRange"></param>
        /// <param name="endRange"></param>
        /// <returns></returns>
        public static int GetRandomInt(int minValue, int maxValue)
        {

            //Instead of using the lame pseudo-random Random object, we're using the much better implementation
            //that's contained within the Cryptography library. 
            //Code found here: http://stackoverflow.com/questions/6111960/rngcryptoserviceprovider-generate-random-numbers-in-the-range-0-randommax

            var rng = RandomNumberGenerator.Create();

            byte[] rndBytes = new byte[4];
            rng.GetBytes(rndBytes);
            int rand = BitConverter.ToInt32(rndBytes, 0);
            const Decimal OldRange = (Decimal)int.MaxValue - (Decimal)int.MinValue;
            Decimal NewRange = maxValue - minValue;
            Decimal NewValue = ((Decimal)rand - (Decimal)int.MinValue) / OldRange * NewRange + (Decimal)minValue;
            return (int)NewValue;
           
        }
    }
}