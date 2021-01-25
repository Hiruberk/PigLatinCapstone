using System;
using System.Linq;
using System.Text;


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

                if (string.IsNullOrEmpty(input) || input == " ")
                {
                    Console.WriteLine("One cannot simply translate what does not exist. Give a real entry!");
                    return;
                }
                else
                {
                    string output = ToPigLatin(input);//Stores the translation after running through the Method

                    Console.WriteLine($"\n{output}");//Outputs that translation 
                }

                Console.WriteLine("\nWould you like to try another sentence? (y/n)\n");

            } while (Console.ReadLine().ToLower() == "y");// Boolean condition on whether they entered a upper or lower case Y

            Console.WriteLine("\nThank you for translating! Have a Good Night!\n");// Departing final statement outside of the loop
        }



        static string ToPigLatin(string sentence)//Method to translate into PigLatin
        {
                
            string vowels = "AEIOUaeiou";    //Delcaring my vowel check string
            string vowelsY = "AEIOUYaeiouy"; //this is added under the assumption that if Y is starting the word it is a consonant 
                                            //otherwise it will be the vowel or another vowel will come before it

            string returnSentence = ""; // making an empty string to fill later for the ouput


            //This foreach is to cycle through each word in the sentence
            foreach (string word in sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                //Breaking the first word up into the first letter and the rest of the word
                string firstLetter = word.Substring(0, 1);
                string restOfWord = word.Substring(1, word.Length - 1);
                int currentLetter = vowels.IndexOf(firstLetter, StringComparison.Ordinal);//Determines if the firstletter is a vowel or not
                string punctuation = ".,!?;:";
                string punct = "";


                //If there is any punctuation or commas split it off to add later and store it
                if (ContainsPunct(word))
                {
                    punct = word.Substring(word.Length - 1, 1);//stores the punctuation for later

                    for (int i = 0; i < restOfWord.Length; i++)//runs through the word and deletes the end punctuation to avoid a double print of the punctuation
                    {
                        int isPunt = punctuation.IndexOf(restOfWord[i]);
                        restOfWord = restOfWord.Remove(restOfWord.Length-1,1);
                    }
                }
                
                //If there is number or special Chars. , do not translate 
                if (IsNumChar(word))
                {
                    returnSentence += word + " ";

                         //If statement to determine whether the first letter is a vowel or a consonant  
                }        //based upon the above currentletter variable (integer) where -1 is a fail of the vowel check
                else if (currentLetter == -1)
                {
                    //declaring the first consonant of the word, the remainder which will hold the remainding portion of the word after the first letter
                    //and allows it to change its size after each iteration of the word foreach, so it can handle words of all sizes
                    //declaring count which holds the index for all the letters after the first letter from the orginial word.
                    string notVowel = firstLetter;
                    int count = 0;
                    string remainder = word.Substring(0, 1);

                    //This foreach is for cycling through the letters to find the first vowel
                    foreach (char letter in restOfWord)
                    {
                        string restOfWord1 = restOfWord.Substring(count, restOfWord.Length - count);//This snips off the rest of the word after the current letter
                        int nextLetter = vowelsY.IndexOf(letter, StringComparison.Ordinal);//This will check against vowels string above that holds both upper and lower cases

                        if (nextLetter == -1)//This time it will not consider Y a consonant and allow for it to be treated a vowel
                        {
                            count++;
                            remainder += letter;//adds the current letter in the loop to the end of the remainding portion of the word
                        }
                        else //If it is not a consonant it is a vowel
                        {
                            returnSentence += restOfWord1 + remainder + "ay" + punct + " ";//adss the unused portion of the word then the remainding portion that was sorted then adds the suffix for Pig Latin
                            break;//no need to continue through the rest of the letters once a vowel is found
                        }
                    }
                }
                else //the case of the first letter is vowel and adds the word with way to the remaining sentence
                {
                    returnSentence += word + "way" + punct + " ";
                }
             }
               return returnSentence; //sends back the full string or sentence that was translated
        }

        /// <summary>
        /// Checks a string to see if it contains a list of numbers or special characters
        /// </summary>
        /// <param name="word"></param>
        /// <returns>Returns a true if it does contain numbers or special characters, false if it does not contain these</returns>
        public static bool IsNumChar(string word)
        {
            string numbersAndSpecialChar = "0123456789@#$%^&*()";
            bool value = false;

            //Loop every letter from word 
            for (int i = 0; i < word.Length; i++)
            {
                int isNumChar = numbersAndSpecialChar.IndexOf(word[i]);

                //Index will not be -1, if there is number or Special Char
                if (isNumChar != -1)
                {
                    value = true;
                }
            }

            //return the boolean value 
            return value;
        }

        /// <summary>
        /// Checks a string if it contains any punctuation.
        /// </summary>
        /// <param name="word"></param>
        /// <returns>Returns true if it contains any punctuation, returns false if there are none.</returns>
        public static bool ContainsPunct(string word)
        {
            string punct = ".,!?;:";//declaring the string of punctuation to search for
            bool value = false;

            for (int i=0; i < word.Length; i++)//This will run through all the letters in the input string and give a -1 if it is not found
            {
                int isPunt = punct.IndexOf(word[i]);

                if(isPunt != -1)
                {
                    value = true;
                }
            }

            return value;
        }

    }
}
