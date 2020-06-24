using System;
using System.Diagnostics;

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
            int[] numberArray = {-1,-1,-1,2,2}; // Sorted numbers array to work with
            Console.Write("User array - { "); // Print the user supplied array
            for (int i = 0; i < numberArray.Length; i++)
            {
                Console.Write(numberArray[i]);
                Console.Write(" ");
            }
            Console.WriteLine("}");
            minSum(numberArray); // Call the method to adjust array and calculate the minimum sum
            // ##### End solution for Question 3

            solveQuestion4();
            solveQuestion5();
            solveQuestion6();
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

        private static void solveQuestion6()
        {

        }

    }
}
