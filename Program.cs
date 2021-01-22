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
                Console.WriteLine("Please enter a line to be translated to Pig Latin: \n");

                string input = Console.ReadLine();//Takes the user input for the sentence
                string output = ToPigLatin(input);//Outputs the translation after running through the Method
                
                Console.WriteLine(output);                             


                Console.WriteLine("Would you like to try another sentence? (y/n)");

            } while (Console.ReadLine().ToLower() == "y");

            Console.WriteLine("\nThank you for translating! Have a Good Night!\n");

            static string ToPigLatin(string sentence)//Method to translate into PigLatin
            {
                //Delcaring my vowel check string and making an empty string to fill later
                string vowels = "AEIOUYaeioy";
                var returnSentence = "";

                //This foreach is to cycle through each word in the sentence
                foreach (var word in sentence.Split())
                {
                    //Breaking the first word up into the first letter and the rest of the word
                    var firstLetter = word.Substring(0, 1);
                    var restOfWord = word.Substring(1, word.Length - 1);
                    var currentLetter = vowels.IndexOf(firstLetter, StringComparison.OrdinalIgnoreCase);//Determines if the firstletter is a vowel or not

                    //If statement to determine whether the first letter is a vowel or a consonant  
                    //based upon the above currentletter variable (integer) where -1 is a fail of the vowel check
                    if (currentLetter == -1)
                    {
                        string notVowel = firstLetter;
                        int count = 0;
                        StringBuilder remainder = new StringBuilder($"{notVowel}");

                        //This foreach is for cycling through the letters to find the first vowel
                        foreach (var letter in restOfWord)
                        {
                            var restOfWord1 = restOfWord.Substring(count, restOfWord.Length-count);
                            var nextLetter = vowels.IndexOf(letter, StringComparison.OrdinalIgnoreCase);
                            
                            if (nextLetter == -1) 
                            {
                                count++;
                                remainder.Append(letter);
                            }
                            else
                            {
                               Console.WriteLine($" restof word {restOfWord}");
                               returnSentence += restOfWord1 + remainder + "ay ";
                               break; 
                            }
                            

                        }
                        
                    }
                    else
                    {
                        returnSentence += word + "way ";
                    }
                }
                return returnSentence;
            }
        }
    }
}
