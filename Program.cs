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

                //Loop through dictionary and build string with keys for matching values
                foreach (KeyValuePair<int, int> element in NumberDictionary)
                {
                    if (numberToFind == element.Value)
                    {
                        if (foundKeys == "")
                        {
                            foundKeys = "[" + element.Key;
                        }
                        else
                        {
                            foundKeys = foundKeys + ", " + element.Key;
                        }
                    }
                }

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
                string sResult = "";

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
                //Sort the dictionary in decending order on the value field which contains the number of times the character appears in the string
                foreach (KeyValuePair<int, int> element in CharacterCountDictionary.OrderByDescending(key => key.Value))
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
                //Display resulting string
                Console.WriteLine(sResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please enter a string of characters" + ex.Message);
            }
        }

        private static void solveQuestion5()
        {

        }

        private static void solveQuestion6()
        {
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


        public static string StringReverse(string s)          // Function declaration for performing reverse string operation
        {

            int n = 1;
            int p = 0;
            int x = 0;
            String finalString = "";
            String tempVar = " ";
            for (int i = 0; i < s.Length; i++)                      // Perform the loop for length of input string times
            {
                if (s.Substring(i, 1) == " ")                       // For every space in the sentence increment the counter n to know how many words are in the sentence
                    n++;
            }
            String[] indWords = new string[n];                     // Use the above counter n to declare the String array size
            for (int i = 0; i < s.Length; i++)                     // Pefrome the loop until the length of input string times.
            {
                if ((s.Substring(i, 1) == " ") || (i == (s.Length - 1)))     // When space is encountered in the sentence or last word of the sentence
                {
                    if (i == (s.Length - 1))                         //if last byte in the sentence
                        tempVar = s.Substring(x, i - x + 1) + " ";   // assign temp variable with last word appending a space
                    else if (x == 0)                                   // For the first word of the sentence don't count the space
                        tempVar = s.Substring(x, i - x);
                    else                                            // if not last byte in the sentence or first word
                        tempVar = s.Substring(x, i - x + 1);        // assign temp variable with the word in the sentence

                    for (int j = 0; j < tempVar.Length; j++)        // perform the loop until the length of tempVar .i.e. length of a word in the sentence 
                    {
                        indWords[p] = indWords[p] + tempVar.Substring(tempVar.Length - j - 1, 1);  //populate array occurance with each reverse word from the sentence
                    }
                    finalString = finalString + indWords[p];   // Concatenate each reversed word from the sentence into finalString variable
                    p++;                                       // increment the array
                    x = i + 1;                                 // counter to process next word .i.e. index of next word in the sentence)
                }

            }
            return finalString;                              //return the reverse string to the main method
        }

    }
}
