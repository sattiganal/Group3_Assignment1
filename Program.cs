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
            //testReverse();
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
                foundKeys = targetRange(NumberDictionary, numberToFind);
                //Display results
                Console.WriteLine();
                Console.WriteLine(foundKeys);

            }
            catch (Exception ex)
            {
                //Show error message for incorrect entry
                Console.WriteLine("You did not enter an integer between 1 and 5. " + ex.Message);
            }
        }

        private static string targetRange(Dictionary<int, int> NumberDictionary1, int numberToSearch)
        {
            //Prompt for integer 1-5
            string strKeys = "";
            int intLast = 0;
            int intCount = 0;

            foreach (KeyValuePair<int, int> element in NumberDictionary1)
            {
                if (numberToSearch == element.Value)
                {
                    if (strKeys == "")
                    {
                        strKeys = "[" + element.Key;
                        intCount++;
                    }
                    else
                    {
                        intLast = element.Key;
                        intCount++;
                    }
                }
            }
                        
            //Build return console string based on if the number exists, if it only appears once or more times in the dictionary.
            if (strKeys == "")
            {
                strKeys = "The number " + numberToSearch + " is NOT contained in the dictionary of numbers";
            }
            else
            {
                if (intLast == 0)
                {
                    strKeys = "The number " + numberToSearch + " is contained only at key " + strKeys + "]";
                }
                else
                {
                    strKeys = "The number " + numberToSearch + " appears " + intCount + " times in the dictionary with the first and last key being " + strKeys + ", " + intLast + "]";
                }
                
            }
            return strKeys;
        }

        private static void solveQuestion2()
        {

        

            //TODO : Wait for Professor's response
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
            Console.WriteLine("Please input numbers of your choice seperated by comma (,) in sorted order.");
            int[] numberArray = {}; // Sorted numbers array to work with
            try
            {
                numberArray = Array.ConvertAll(Console.ReadLine().Trim().Split(','), Convert.ToInt32);
                Console.Write("User array - { "); // Print the user supplied array
                for (int i = 0; i < numberArray.Length; i++)
                {
                    Console.Write(numberArray[i]);
                    Console.Write(" ");
                }
                Console.WriteLine("}");

                int minimumArraySum = minSum(numberArray); // Call the method to adjust array and calculate the minimum sum
                Console.WriteLine("Array sum is " + minimumArraySum);
                Console.WriteLine("");
            }
            catch(Exception eX)
            {
                Console.WriteLine("Input should be a number array." + eX.Message);
            }
            // ##### End solution for Question 3
        }

        // This function sequentially reads an array (size n) replacing elements if needed and  
        // calculating the sum, both of which take contant time. 
        // Hence the time complexity of this function is O(n).
        public static int minSum(int[] numberArray)
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

            return minimumArraySum;
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
                Console.WriteLine(FreqSort(CharacterCountDictionary));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please enter a string of characters" + ex.Message);
            }
        }

        private static string FreqSort(Dictionary<int, int> CharacterCountDictionary1)
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
            //TODO : Intersection1 --> look at the method for TODO
            //TODO : Intersection2 --> Hashset may not work. Example run array1=4,4,6,6,9 array1=4,4,4

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
            char[] charArray = {}; // Character array
            int k = -1; // Index to search for
            try
            {
                // Read the user supplied characters.
                Console.WriteLine("Please input characters of your choice seperated by comma (,).");
                charArray = Array.ConvertAll(Console.ReadLine().Trim().Split(','), Convert.ToChar);
                Console.Write("User array - { "); // Print the user supplied array
                for (int i = 0; i < charArray.Length; i++)
                {
                    Console.Write(charArray[i]);
                    Console.Write(" ");
                }
                Console.WriteLine("}");

                // Read user supplied index
                Console.WriteLine("Please choose an array index.");
                k = Convert.ToInt32(Console.ReadLine());

                // Check for a[i] = a[j] such that (i-j) <= k
                Console.WriteLine(new Program().ContainsDuplicate(charArray, k));
                Console.WriteLine("");
            }
            catch(Exception eX)
            {
                Console.WriteLine("Invalid input format." + eX.Message);
            }
            // ##### End solution for Question 6
        }

        // This function sequentially reads an array (size n) and adds/removes elements from a dictionary
        // which take contant time. Hence the time complexity of this function is O(n).
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

           
            String temp = "";   
            string finalString = "";
            int arraySize = 0;

            for (int i= 1; i<= s.Length; i++){                               //Perform loop until for each character in the input string
                temp =   temp + s.Substring(s.Length - i, 1);                //move characters from input string in reverse order into temp variable
                if (s.Substring(s.Length - i, 1) == " ")               // when there is a space encounterd in the string increment arraysize variable that is used to declare array size
                    arraySize++;                                   
            }
            arraySize++;                                        //increment array size variable for the last word in the sentence

            string[] stringWord = new string[arraySize];          // Declare array with size to hold each word of the sentence

            int k = 0;
            int newWordStartLoc = 0;
            
            for (int i = 0; i < temp.Length; i++)                //perform loop until the length of the input string
            {
               
                if ((temp.Substring(i, 1) == " ") || (temp.Length == i + 1) )      //if a space is encountered or last word of the sentence
                {
                    
                    if ((k==0) & (temp.Length == i + 1))                        // if there is only one word in the input string
                        stringWord[k] = temp.Substring(newWordStartLoc, i - newWordStartLoc + 1);  //format the word and assign to an array 
                    else
                    if (temp.Length == i + 1)                                    // if it is last word in the sentence
                        stringWord[k] = temp.Substring(newWordStartLoc + 1 , i - newWordStartLoc );   //format the word and assign it to an array
                    else if (k==1)                                                                     // if it is second word in the sentence
                      stringWord[k] = temp.Substring(newWordStartLoc , i - newWordStartLoc + 1 );   //format the word and assign it to an array
                    else
                        stringWord[k] = temp.Substring(newWordStartLoc, i - newWordStartLoc);       //for any other word in the sentence,format the word and assign it to an array   

                    if ((k == 1) & (temp.Length == i + 1))              //if there are only two words in the sentence then format the string as below
                        finalString = stringWord[k] + " " + finalString;
                    else
                        finalString = stringWord[k] + finalString;
                    newWordStartLoc = i;                                    //To identify the start location of next word
                    
                    k++;                                                  //increment array counter
                }
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

                if (value1 >= nums2[0])        //Check if the element of first array is greater than or equal to first element of second array, we don't need to loop if condition fails
                {
              
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
                outArrSize = nums2.Length;                          //Assigns output array size equal to smallest size of the array

            int[] outArr = new int[outArrSize];                    //Output Array is declared with size of smallest array of the two input arrays.


            var dictionary2 = nums2.Select((value, index) => new { index, value })         //Convert second array into Dictionary key will be the index and value will be the element
                      .ToDictionary(pair => pair.index, pair => pair.value);


            Console.Write("Intersection from Solution-2 : [");

            foreach (int value1 in nums1)                         //for each elment in array1 perform the loop
            {
                if (dictionary2.ContainsValue(value1))            //if the dictionary contains the value of array1 element 
                {
                    if (k != 0)              // if not first value in output array then seperate the element with a comma(,)
                        Console.Write(",");
                    outArr[k] = value1;           //populate output array with intersection element
                    Console.Write(outArr[k]);     //print the intersection value to console
                    k++;                          //increment the index of output array
                    dictionary2.Remove(dictionary2.First(kvp => kvp.Value == value1).Key);   //remove the first occurance of the element from dictionary2 once it is processed
                }                
            }
            Console.WriteLine("]");

            Array.Resize(ref outArr, k);                              // Resize the array only to the size of actual intersection elements.            
            return outArr;                                            // Return output array with intersection elements

        }
        //End of Method - Solution-2 for Question: 5


        public static void testReverse()
        {
            Console.WriteLine("enter test string : ");
            String input = Console.ReadLine();
            String[] inputWordsArray = splitOnSpace(input);
            char[] charsInWord = { };
            var reversedInput = new List<string>();
            foreach (String word in inputWordsArray)
            {
                charsInWord = word.ToCharArray();
                reverseCharArray(charsInWord, 0);
                reversedInput.Add(new String(charsInWord));
            }

            foreach(String s in reversedInput)
            {
                Console.Write(s);
                Console.Write(" ");
            }
        }

        public static String[] splitOnSpace(String sentence)
        {
            var wordsArray = new List<string>();
            if (sentence.Contains(" "))
            {
                int prevIndex = -1;
                for (int i = 0; i < sentence.Length; i++)
                {
                    if (char.IsWhiteSpace(sentence[i]))
                    {
                        String word = sentence.Substring(prevIndex + 1, (i - (prevIndex + 1)));
                        wordsArray.Add(word);
                        prevIndex = i;
                    }
                }
                wordsArray.Add(sentence.Substring(prevIndex));
            }
            else
            {
                wordsArray.Add(sentence);
            }
            return wordsArray.ToArray();
        }

        public static void reverseCharArray(char[] charArray, int startIndex)
        {
            if (startIndex >= charArray.Length / 2)
            {
                return ;
            }
            char temp = charArray[startIndex];
            charArray[startIndex] = charArray[charArray.Length - 1 - startIndex];
            charArray[charArray.Length - 1 - startIndex] = temp;
            reverseCharArray(charArray, ++startIndex);
        }
    }

}  