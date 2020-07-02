using System;
using System.Collections.Generic;
using System.Linq;
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
            solveQuestion3();
            solveQuestion4();
            solveQuestion5();
            solveQuestion6();
        }


        private static void solveQuestion1()
        {
            try
            {
                //Instantiate dictionary object
                Dictionary<int, int> NumberDictionary = new Dictionary<int, int>();  

                //variables
                int numberToFind;  
                string foundKeys = "";

                //Add numbers to the dictionary
                NumberDictionary.Add(1, 1);
                NumberDictionary.Add(2, 2);
                NumberDictionary.Add(3, 3);
                NumberDictionary.Add(4, 2);
                NumberDictionary.Add(5, 1);
                NumberDictionary.Add(6, 3);
                NumberDictionary.Add(7, 4);
                NumberDictionary.Add(8, 2);
                NumberDictionary.Add(9, 1);
                NumberDictionary.Add(10, 5);
                NumberDictionary.Add(11, 4);

                //Prompt for integer 1-5
                Console.WriteLine("The dictionary contains numbers 1-5. Enter the integer to search in the dictionary to find the keys");
                numberToFind = Convert.ToInt16(Console.ReadLine());

                //Call method to search dictionary for number entered. Return the string of corresponding keys
                foundKeys = findKeys(NumberDictionary, numberToFind);

                //Display results
                Console.WriteLine();
                if (foundKeys == "")
                {
                    Console.WriteLine("The number " + numberToFind + " is NOT contained in the dictionary of numbers");
                }
                else
                {
                    Console.WriteLine("The number " + numberToFind + " is contained at keys " + foundKeys + "]");
                }

            }
            catch (Exception ex)
            {
                //Show error message for incorrect entry
                Console.WriteLine("You did not enter an integer between 1 and 5. " + ex.Message);
            }
        }

        private static string findKeys (Dictionary<int, int> NumberDictionary1, int numberToSearch)
        {
            //Prompt for integer 1-5
            string strKeys = "";
            
            foreach (KeyValuePair<int, int> element in NumberDictionary1)
            {
                if (numberToSearch == element.Value)
                {
                    if (strKeys == "")
                    {
                        strKeys = "[" + element.Key;
                    }
                    else
                    {
                        strKeys = strKeys + ", " + element.Key;
                    }
                }
            }
            return strKeys;
        }

        private static void solveQuestion2()
        {
            Console.WriteLine("!!!!!!!!!!!!!  Solving Question#2  !!!!!!!!!!!!!!");
            Console.WriteLine("****  Please Enter a Sentence below for Reverse String Operation *****");
            string reverseString = " ";
            String inputString = Console.ReadLine();                       // Input string read from the console
            Console.WriteLine("Input Entered String  : " + inputString);   // Write input string to the console 

            reverseString = StringReverse(inputString);                   // Call custom built function to reverse the string
            Console.WriteLine("Output Reverse String : " + reverseString); // Write output reverse string to the console                        
        }

        private static void solveQuestion3()
        {
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
            try
            {
                string sStart; //Variable to hold string from user entry
                Console.WriteLine("Enter a string and the application will return the characters by the frequency they occur.");
                //Read console entry into string variable
                sStart = Console.ReadLine();
                //Instantiate dictionary, will store the ascii value of the character in the key field and the count of character in the value
                Dictionary<int, int> CharacterCountDictionary = new Dictionary<int, int>();
                //Declare variables used in method              
                int i = 1;
                int ascii;
                
                foreach (char c in sStart)
                {
                    //Loop converts characters to ascii value and enters in the dictionary.
                    ascii = c;
                    if (CharacterCountDictionary.ContainsKey(ascii))
                    {
                        //Character ascii value already exists in the dictionary, update the count by one
                        CharacterCountDictionary[ascii] = CharacterCountDictionary[ascii] + 1;
                    }
                    else
                    {
                        //Character ascii value doesn't exist in the dictionary so add    
                        CharacterCountDictionary.Add(ascii, i);
                    }
                }
                
                //Display resulting string from method
                Console.WriteLine(buildString(CharacterCountDictionary));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please enter a string of characters" + ex.Message);
            }
        }

        private static string buildString(Dictionary<int, int> CharacterCountDictionary1)
        {
            string sResult = "";
            int i;
            //Sort the dictionary in decending order on the value field which contains the number of times the character appears in the string
            foreach (KeyValuePair<int, int> element in CharacterCountDictionary1.OrderByDescending(key => key.Value))
            {
                //Value converted from ascii to and loops through count of characters building the output string sResult
                i = 1;
                while (i <= element.Value)
                {
                    char c = Convert.ToChar(element.Key);
                    sResult = sResult + c;
                    i++;
                }

            }
            return sResult;
        }

        private static void solveQuestion5()
        {

            Console.WriteLine("!!!!!!!!!!!!!  Solving Question#5  !!!!!!!!!!!!!!");

            int[] nums1 = new int[] { };
            int[] nums2 = new int[] { };

            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!   Enter First numeric array of elements separated by a comma (,)    !!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            try
            {
                nums1 = Array.ConvertAll(Console.ReadLine().Trim().Split(','), Convert.ToInt32);
            }
            catch (Exception e)
            {
                Console.WriteLine("Input must be Integer values separated by comma (,)" + e.Message);

            }

            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("!!!!!!   Enter Second numeric array of elements separated by a comma (,)   !!!!!!!!");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");


            try
            {
                nums2 = Array.ConvertAll(Console.ReadLine().Trim().Split(','), Convert.ToInt32);
            }
            catch (Exception e)
            {
                Console.WriteLine("Input must be Integer values separated by comma (,)" + e.Message);

            }


            //--------------Solution 1-------------

            int[] intersection = Intersect1(nums1, nums2);          // Call solution-1 methond  by passing two arrays to determine intersection


            //--------------Solution 2-------------


            int[] intersection2 = Intersect2(nums1, nums2);        // Call solution-2 methond  by passing two arrays to determine intersection                    

        }

        private static void solveQuestion6()
        {
            // ##### Start solution for Question 6
            Console.WriteLine("##### Solving Question 6.");
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
                else // If this character is in the map already => a[i] = a[j]
                {
                    int previousIndex = keepTrack.GetValueOrDefault(currentChar); // This gives us the previous position in the array
                    // If the difference is at most k => (i-j) <= k
                    if(Math.Abs(k) >= Math.Abs(previousIndex - currentIndex))
                    {
                        Console.WriteLine(previousIndex + " and " + currentIndex + " have the match such that a[i] = a[j] and (i-j) <= " + k);
                        return true; // We found it, so we return withoutchecking further
                    }
                    else // Update the dictionary to store the most recent position for character 
                    {
                        keepTrack.Remove(currentChar);
                        keepTrack.Add(currentChar, currentIndex);
                    }
                }
            }
            return false; // We didn't find anything satisfyng the condition
        }


        //Method Solution for Question: 2  to Reverse a string
        public static string StringReverse(string s)             // Function declaration for performing reverse string operation
        {

            String finalString = "";
            String tempVar = "";
            string indWord = "";


            string[] stringWords = s.Split(' ');         // Split the string into Array of words

            for (int i = 0; i < stringWords.Length; i++)   // Perform the loop for number of words in the string
            {
                indWord = "";
                tempVar = stringWords[i];
                for (int j = 0; j < stringWords[i].Length; j++)           //perform the loop for each letter in each word of the string
                {
                    tempVar = stringWords[i].Substring(stringWords[i].Length - j - 1, 1);   //get the letters from the end to start of the word
                    indWord = indWord + tempVar;                                         // concatenate the letters in reverse 
                }
                finalString = finalString + indWord + " ";       //concatenate the words with reverse string above
            }

            return finalString;                                 //return the reverse string to the main method
        }

        //End of Method - Solution for Question: 2






        //Method Solution-1 for Question: 5  (Returns intersection of two arrays)
        /*This algorithm follows the Quasilinear time  time complexity. There are two nested loops that goes through two arrays.As the number of elements in each element increase the number
         * of times the loop increases. This is O(n*m).
         */
        public static int[] Intersect1(int[] nums1, int[] nums2)    // Method declaration for Solution-1 finding array intersection
        {
            Array.Sort(nums1);                                      // Sort First array nums1
            Array.Sort(nums2);                                      // Sort Second array nums2

            int k = 0;
            int outArrSize = 0;
            int prevElement = 0;
            int procDup = 0;
            int compDup = 0;
            if (nums1.Length < nums2.Length)                       // Check for smaller size array to assign it's size to the output intersection array
            {
                outArrSize = nums1.Length;
                int[] tempArry = nums2;                            //Below three lines rearranges nums1 and nums2 array contents based on their sizes
                nums2 = nums1;
                nums1 = tempArry;
            }
            else
                outArrSize = nums2.Length;

            int[] outArr = new int[outArrSize];                 // Define output array for holding intersection elements

            Console.Write("Intersection from Solution-1 : [");
            foreach (int value1 in nums1)                       // Peform this for loop operation for each element in nums1 array
            {
                if (prevElement == value1)
                {
                    procDup++;
                    compDup = procDup;
                }
                else
                {
                    procDup = 0;
                    compDup = 0;
                }

                for (int i = 0; i < nums2.Length; i++)              // Perform this for loop operation for each element in nums2 array
                {
                    if (value1 == nums2[i])                     // If element of first array is equal to element of second array                        
                    {
                        if (compDup == 0)
                        {

                            if ((i <= nums1.Length) && (k != 0))    // If i is less than first array length or not first value in output array then seperate teh element with a comma(,)
                                Console.Write(",");
                            outArr[k] = value1;                     // populate output array with intersection element
                            Console.Write(value1);
                            k++;                                    // Increment the output array index number
                            i = nums2.Length;                       // assign value of nums2 length to i to exit the loop
                        }
                        else
                            compDup--;

                    }

                }
                prevElement = value1;
            }
            Console.WriteLine("]");
            Array.Resize(ref outArr, k);                      // Resize the array only to the size of actual intersection elements.
            return outArr;                                    // Return output array with intersection elements


        }

        //End of Method - Solution-1 for Question: 5


        //Method Solution-2 for Question: 5 (Returns intersection of two arrays)
        /*This algorithm follows the linear time complexity. There is one loop in this method, as the number of intersection elements increase the number
         * of times the loop increases. This is also referred as O(n).
         */
        public static int[] Intersect2(int[] nums1, int[] nums2)          // Method declaration for Solution-2 finding array intersection
        {
            int k = 0;
            int outArrSize = 0;

            if (nums1.Length < nums2.Length)                          // Check for smaller size array to assign it's size to the output intersection array
            {
                outArrSize = nums1.Length;
                int[] tempArry = nums2;                                //Below three lines rearranges nums1 and nums2 array contents based on their sizes 
                nums2 = nums1;
                nums1 = tempArry;
            }
            else
                outArrSize = nums2.Length;

            int[] outArr = new int[outArrSize];                       // Define output array for holding intersection elements

            HashSet<int> hsnums1 = new HashSet<int>(nums1);           // Declare hashset and assign first array nums1 to it


            Console.Write("Intersection from Solution-2 : [");
            for (int i = 0; i < nums2.Length; i++)                    // Perform this for loop operation for each element in nums2 array
                if (hsnums1.Contains(nums2[i]))
                {
                    if ((i <= nums1.Length) && (k != 0))              // If i is less than first array length or not first value in output array then seperate teh element with a comma(,)
                        Console.Write(",");
                    Console.Write(nums2[i]);
                    outArr[k] = nums2[i];                             // populate output array with intersection element
                    k++;                                              // Increment the output array index number 
                }

            Console.Write("]");

            Array.Resize(ref outArr, k);                              // Resize the array only to the size of actual intersection elements.
            return outArr;                                            // Return output array with intersection elements

        }
        //End of Method - Solution-2 for Question: 5

    }
}  