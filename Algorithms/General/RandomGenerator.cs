namespace Algorithms.General
{
/*
You have a function GetOneOrZero() that generates 0 or 1 with the equal probability.
Write a function GetRandomValue() that generates a number between integer minValue and maxValue with equal probability. 
*/

    using System;
    using System.Collections.Generic;
    using System.Linq;
    class RandomGenerator
    {
        private static readonly Random Random = new Random();

        /// <summary> Function generates 0 or 1 with the equal probability </summary>
        private static int GetOneOrZero()
        {
            return Random.Next(2);
        }

        /// <summary> Function generates a number between "minValue" and "maxValue" with equal probability </summary>
        /// <param name="minValue">min value</param>
        /// <param name="maxValue">max value</param>
        /// <returns>random value</returns>  
        private static int GetRandomValue(int minValue, int maxValue)
        {
            List<int> valueList = Enumerable.Range(minValue, maxValue).ToList();
            while (valueList.Count != 1)
            {
                List<int> remainingValueList = valueList.Where(x => GetOneOrZero() == 1).ToList();
                if (remainingValueList.Any())
                {
                    valueList = remainingValueList;
                }
            }

            return valueList.First();
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(GetRandomValue(1, 200));
            }
            Console.ReadKey();
        }
    }
}
