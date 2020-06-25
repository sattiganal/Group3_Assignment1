using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Group3_Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Assignment 1 from Group 3");
            solveQuestion1();
            solveQuestion2();

            // ##### Start solution for Question 3
            Console.WriteLine("##### Solving Question 3");
            int[] numberArray = { -1, -1, -1, 2, 2 }; // Sorted numbers array to work with
            Console.Write("User array - { "); // Print the user supplied array
            for (int i = 0; i < numberArray.Length; i++)
            {
                Console.Write(numberArray[i]);
                Console.Write(" ");
            }
            Console.WriteLine("}");
            minSum(numberArray); // Call the method to adjust array and calculate the minimum sum
            Console.WriteLine("");
            // ##### End solution for Question 3

            solveQuestion4();
            solveQuestion5();

            // ##### Start solution for Question 6
            Console.WriteLine("##### Solving Question 6");
            char[] charArray = {'k','y','k','k'}; // Character array
            int k = 1; // 
            Console.Write("User array - { "); // Print the user supplied array
            for (int i = 0; i < charArray.Length; i++)
            {
                Console.Write(charArray[i]);
                Console.Write(" ");
            }
            Console.WriteLine("}");
            // Check for a[i] = a[j] such that (i-j) <= k
            Console.WriteLine(new Program().ContainsDuplicate(charArray, k));
            Console.WriteLine("");
            // ##### End solution for Question 6
        }


        private static void solveQuestion1()
        {

        }

        private static void solveQuestion2()
        {

        }

        
        private static void minSum(int[] numberArray)
        {
            int minimumArraySum = 0; // We will store the sum in this

            // Loop through the array adjusting and calculating the sum 
            for(int i=0; i<numberArray.Length; i++)
            {
                // If this is the first element, no adjustment is needed as it's a sorted array.
                // If the current number in the array is same as / less than (possible if more than 2 consecutive eleents are same) 
                // previous one, an adjustment is needed to keep the array distinct.
                // Adjust by incrementing the previous number in array by one and assign to current position in the array.
                if(i > 0 && numberArray[i] <= numberArray[i-1])
                {
                    numberArray[i] = numberArray[i-1]+1;
                }
                minimumArraySum += numberArray[i]; // Add to sum
            }

            // Print the adjusted array
            Console.Write("Modified array - { ");
            for (int i = 0; i < numberArray.Length; i++)
            {
                Console.Write(numberArray[i]);
                Console.Write(" ");
            }
            Console.WriteLine("}");

            // Print the minimum sum
            Console.WriteLine("Array sum is " + minimumArraySum);
        }

        private static void solveQuestion4()
        {

        }

        private static void solveQuestion5()
        {

        }

        public bool ContainsDuplicate(char[] arr, int k)
        {
            // We will hold the characters (key) with their positions (value) in the dictionary
            Dictionary<char, int> keepTrack = new Dictionary<char, int>();
            // Loop through the character array
            for(int currentIndex=0; currentIndex < arr.Length; currentIndex++)
            {
                char currentChar = arr[currentIndex];
                if(!keepTrack.ContainsKey(currentChar)) // If this character isn't in the map already
                {
                    keepTrack.Add(currentChar, currentIndex); // Add to the map
                }
                else // If this character isn't in the map already => a[i] = a[j]
                {
                    int previousIndex = keepTrack.GetValueOrDefault(currentChar); // This gives us the previous position in the array
                    // If the difference is at most k => (i-j) <= k
                    if(Math.Abs(k) >= Math.Abs(previousIndex - currentIndex))
                    {
                        Console.WriteLine(previousIndex + " and " + currentIndex + " have the match such that a[i] = a[j] and (i-j) <= " + k);
                        return true; // We found it, so we return withoutchecking further
                    }
                    else // Update the distionary to store the most recent position for character 
                    {
                        keepTrack.Remove(currentChar);
                        keepTrack.Add(currentChar, currentIndex);
                    }
                }
            }
            return false; // We didn't find anything satisfyng the condition
        }

    }
}
