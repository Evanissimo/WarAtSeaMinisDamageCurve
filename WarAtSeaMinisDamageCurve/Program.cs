﻿using System;

namespace WarAtSeaMinisDamageCurve
{
    /// <summary>
    /// This program is my first attempt at solving a niggling problem i have had with an old axis and allies spinoff: War at Sea Miniatures.
    ///  A ships gunnery value determines the number of D6 to roll to determine hits. Each 1-3 is 0 hits, a 4 or 5 is 1 hit, and a 6 is 2 hits.
    /// </summary>
    class Program
    {
        
        static int atkVal;
        static int[] results;
        static void Main(string[] args)
        {
            
            atkVal = Convert.ToInt32(Console.ReadLine());
            results = new int[atkVal * 2 + 1];
            

            // initialize results array
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = 0;
            }
            double finalDice = calculateMax();
            for (int i = 0; i <= finalDice; i++)
            {
                tallyAmount(convertFromBase10to6(i));
            }
            printArray(results);
        }

        /// <summary>
        /// This method uses the static number of attack dice to roll to determine the maximum value in base 10 to count to. Esentially converting a series of 5's in base 6 to base 10.
        /// </summary>
        /// <returns>The maximum value to count to in base 10.</returns>
        static double calculateMax()
        {
            double maxValue = 0;
            for (double i = 0; i < atkVal; i++)
            {
                double power = Convert.ToDouble(i);
                maxValue += 5*Math.Pow(6 , power);
                // Console.WriteLine("this is being added in" + Math.Pow(6, power));
            }
            return maxValue;
        }
        /// <summary>
        /// This method uses the Modulus method to convert from base 10 to base 6.
        /// </summary>
        /// <param name="toConvert">This is the number in base 10 to convert</param>
        /// <returns>A base 6 number</returns>
        static int convertFromBase10to6(int toConvert)
        {
            int converted = 0;
            int remainder = 1;
            int place = 1;
            // i hate do while loops, ok
            while(toConvert!= 0)
            { 
                remainder = toConvert % 6 * place;
                toConvert = toConvert / 6;
                
                
                // Console.WriteLine("I am currently at " + place + " adding " + remainder + " to " + converted);
                converted += remainder;
                place = place * 10;
            }
            
            return converted;

        }

        /// <summary>
        /// This method tallies the current number of hits for the current dice values in results, then increments the 
        /// </summary>
        static void tallyAmount(int dice)
        {
            String diceWord = dice.ToString();
            
            int result = 0;
            foreach(char i in diceWord)
            {
                switch (i)
                {
                    default:
                        break;
                    case '3':
                        result++;
                        break;
                    case '4':
                        result++;
                        break;
                    case '5':
                        result += 2;
                        break;
                }
            }
            // Console.Out.WriteLine("We are evaluating the hits for a roll of" + diceWord);
            // Console.Out.WriteLine("The result was" + result);
            results[result]++;
            
        }

        /// <summary>
        ///  This Method prints out an array of ints.
        /// </summary>
        /// <param name="toPrint">The array to be printed to console</param>
        static void printArray(int[] toPrint)
        {
            foreach(int i in toPrint)
            {
                Console.Write(i);
                Console.Write(',');
            }
            Console.WriteLine("-");
        }
       
    }
}
