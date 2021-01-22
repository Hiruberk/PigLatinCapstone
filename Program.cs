using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace PigLatinCapstone
{
    class Program
    {
        static void Main(string[] args)
        {

            //Nate Davis
            //C# .NET Full Time Day
            //Pig Latin Translator

            Console.WriteLine("Welcome to the Pig Latin Translator!\n");//Greeting that will not be repeated
            
            //The do while allows for a continuing operation upon user consent
            do
            {
                Console.WriteLine("\nPlease enter a line to be translated to Pig Latin: \n");
              
            
                string input = Console.ReadLine();//Takes the user input for the sentence
                
                VoidCheck(input);    

                string output = ToPigLatin(input);//Stores the translation after running through the Method

                    Console.WriteLine($"\n{output}");//Outputs that translation 

                    Console.WriteLine("\nWould you like to try another sentence? (y/n)\n");
                

            } while (Console.ReadLine().ToLower() == "y");// Boolean condition on whether they entered a upper or lower case Y

            Console.WriteLine("\nThank you for translating! Have a Good Night!\n");// Departing final statement outside of the loop
        }



























        static string ToPigLatin(string sentence)//Method to translate into PigLatin
        {
                
            string vowels = "AEIOUaeio";    //Delcaring my vowel check string
            string vowelsY = "AEIOUYaeioy"; //this is added under the assumption that if Y is starting the word it is a consonant 
                                                //otherwise it will be the vowel or another vowel will come before it

            var returnSentence = "";// making an empty string to fill later for the ouput

            //char[] punctuation = { '.', ',', '!', '?','"' };


                //This foreach is to cycle through each word in the sentence
                foreach (var word in sentence.Split())
                {
                    //Breaking the first word up into the first letter and the rest of the word
                    var firstLetter = word.Substring(0, 1);
                    var restOfWord = word.Substring(1, word.Length - 1);
                    var currentLetter = vowels.IndexOf(firstLetter, StringComparison.Ordinal);//Determines if the firstletter is a vowel or not

                    //If statement to determine whether the first letter is a vowel or a consonant  
                    //based upon the above currentletter variable (integer) where -1 is a fail of the vowel check

                    if (currentLetter == -1)
                    {
                        //declaring the first consonant of the word, the remainder which will hold the remainding portion of the word after the first letter
                        // and allows it to change its size after each iteration of the word foreach, so it can handle words of all sizes
                        //declaring count which holds the index for all the letters after the first letter from the orginial word.
                        string notVowel = firstLetter;
                        int count = 0;
                        StringBuilder remainder = new StringBuilder(notVowel);

                        //This foreach is for cycling through the letters to find the first vowel
                        foreach (char letter in restOfWord)
                        {
                            var restOfWord1 = restOfWord.Substring(count, restOfWord.Length - count);//This snips off the rest of the word after the current letter
                            var nextLetter = vowelsY.IndexOf(letter, StringComparison.Ordinal);//This will check against vowels string above that holds both upper and lower cases

                            if (nextLetter == -1)//This time it will not consider Y a consonant and allow for it to be treated a vowel
                            {
                                count++;
                                remainder.Append(letter);//adds the current letter in the loop to the end of the remainding portion of the word
                            }
                            else //If it is not a consonant it is a vowel
                            {
                                returnSentence += restOfWord1 + remainder + "ay ";//adss the unused portion of the word then the remainding portion that was sorted then adds the suffix for Pig Latin
                                break;//no need to continue through the rest of the letters once a vowel is found
                            }
                        }
                    }
                    else //the case of the first letter is vowel and adds the word with way to the remaining sentence
                    {
                        returnSentence += word + "way ";
                    }
                }
                return returnSentence; //sends back the full string or sentence that was translated
            
        }








        /// <summary>
        /// Checks the string input if it is void or empty, if it is not will continue to ask until a valid entry is given
        /// </summary>
        /// <param VoidCheck="input"></param>
        /// <returns>a non-void string</returns>
        static string VoidCheck(string input)
        {
            bool entry = false;
            do
            {
                if (string.IsNullOrEmpty(input) || input == "")
                {
                    Console.WriteLine("One cannot simply translate what does not exist. Give a real entry!");
                    input = Console.ReadLine();
                }
                else
                {
                    entry = true;
                }
            } while (entry == true);

            return input;
        }

    }
}
