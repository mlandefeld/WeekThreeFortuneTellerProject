using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FortuneTeller.WeekThree
{
    class ProjectDay
    {
        
        public string[] getInputs()
        {
            
            string a = getInput("What is your first name? ", "letters");
            string b = getInput("What is your last name? ", "letters");
            string c = getInput("How old are you? ", "numbers");
            string d = getInput("What month were you born? ", "months");
            string e = getInput("What is your favorite ROYGBIV color? Enter \"Help\" if you don't know what ROYGBIV is.", "colors");
            string f = getInput("How many siblings do you have? ", "numbers");
           
            string[] input = new string[6];
            input[0] = a;
            input[1] = b;
            input[2] = c;
            input[3] = d;
            input[4] = e;
            input[5] = f;

            return input;
        }

        /// <summary>
        ///  This function writes a question to the console, retrieves the users input, and then validates it against certain parameters
        /// </summary>
        /// <param name="question"></param>
        /// <param name="validationType"></param>
        /// <returns>
        ///     Returns a string array of validated answers to questions
        /// </returns>
        public string getInput(string question, string validationType)
        {
            Console.WriteLine(question);
            string input = (Console.ReadLine());
            while (true)
            {
                if (input.Equals("quit", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("Nobody likes a quitter...");
                    Environment.Exit(0);
                }
                if (input.Equals("restart", StringComparison.CurrentCultureIgnoreCase))
                {
                    throw new Exception();
                }
                if (validationType == "numbers")
                {
                    if (!Regex.IsMatch(input, @"^[0-9]+$"))
                    {
                        Console.WriteLine("Your input didn't validate! Try again!");
                        input = Console.ReadLine();
                    }
                    else
                    {
                        break;
                    }
                }
                else if (validationType == "letters")
                {
                    if (!Regex.IsMatch(input, @"^[a-zA-Z]+$"))
                    {
                        Console.WriteLine("Your input didn't validate! Try again!");
                        input = Console.ReadLine();
                    }
                    else
                    {
                        break;
                    }
                }
                else if (validationType == "months")
                {
                    if (!isValidMonth(input))
                    {
                        Console.WriteLine("Your input didn't validate! Try again! ");
                        input = Console.ReadLine();
                    }
                    else
                    {
                        break;
                    }
                }
                else if (validationType == "colors")
                {
                    if (!isValidColor(input))
                    {
                        if (input.Equals("help", StringComparison.CurrentCultureIgnoreCase))
                        {
                            Console.WriteLine("Choose: \nRed\nOrange\nYellow\nGreen\nBlue\nIndigo\nViolet");
                            input = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Your input didn't validate! Try again! Enter \"Help\" if you don't know what ROYGBIV is.");
                            input = Console.ReadLine();
                        }

                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    return "error!";
                }
            }

            return input;
        }

        /// <summary>
        /// This function checks to make sure that the input is a valid color.
        /// </summary>
        /// <param name="color"></param>
        /// <returns>
        /// returns true or false
        /// </returns>
        public bool isValidColor(string color)
        {
            string[] colors = new string[7];
            colors[0] = "red";
            colors[1] = "orange";
            colors[2] = "yellow";
            colors[3] = "green";
            colors[4] = "blue";
            colors[5] = "indigo";
            colors[6] = "violet";

            if (colors.Contains(color.ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This function checks to make sure the input is a valid month.
        /// </summary>
        /// <param name="month"></param>
        /// <returns>
        /// returns true or false
        /// </returns>
        public bool isValidMonth(string month)
        {
            string[] months = new string[12];
            months[0] = "january";
            months[1] = "february";
            months[2] = "march";
            months[3] = "april";
            months[4] = "may";
            months[5] = "june";
            months[6] = "july";
            months[7] = "august";
            months[8] = "september";
            months[9] = "october";
            months[10] = "november";
            months[11] = "december";

            if (months.Contains(month.ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This function gets predicted bank amount based on letters in the month that are in the input firstname or lastname. 
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="birthMonth"></param>
        /// <returns>
        /// returns amount in bank.
        /// </returns>
        public string getPredictedBankAmount(string firstname, string lastname, string birthMonth)
        {
            char firstLetter = birthMonth[0];
            char secondLetter = birthMonth[1];
            char thirdLetter = birthMonth[2];

            if (firstname.IndexOf(firstLetter.ToString(), StringComparison.CurrentCultureIgnoreCase) >=0  | lastname.IndexOf(firstLetter.ToString(), StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                return "$10";
            }
            else if(firstname.IndexOf(secondLetter.ToString(), StringComparison.CurrentCultureIgnoreCase) >= 0 | lastname.IndexOf(secondLetter.ToString(), StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                return "$100,000,000";
            }
            else if (firstname.IndexOf(thirdLetter.ToString(), StringComparison.CurrentCultureIgnoreCase) >= 0 | lastname.IndexOf(thirdLetter.ToString(), StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                return "$5,000";
            }
            else
            {
                return "$0";
            }
        }

        /// <summary>
        /// This function checks if input is even or odd
        /// </summary>
        /// <param name="ageInput"></param>
        /// <returns>
        /// This function returns years to retirement.
        /// </returns>
        public int getPredictedRetirement(string ageInput)
        {
            int age = int.Parse(ageInput);
            if (age % 2 == 1)
            {
                return 10;
            }

            else
            {
                return 60;
            }
        }

        /// <summary>
        /// This function gets predicted location based on user input for number of siblings
        /// </summary>
        /// <param name="siblings"></param>
        /// <returns>
        /// This function returns location 
        /// </returns>
        public string getPredictedLocation(string siblings)
        {
            int numSiblings = int.Parse(siblings);
            if (numSiblings == 0)
            {
                return "New Zealand";
            }
            else if (numSiblings == 1)
            {
                return "Oklahoma";
            }

            else if (numSiblings == 2)
            {
                return "the North Pole";
            }

            else if (numSiblings >= 3)
            {
                return "Cleveland";
            }
            else
            {
                return "You need to enter a valid number!";
            }
        }

        /// <summary>
        /// This function gets predicted transportation based on user input for their favorite character 
        /// </summary>
        /// <param name="favoriteColor"></param>
        /// <returns>
        /// this function returns type of transportation
        /// </returns>
        public string getPredictedTransportation(string favoriteColor)
        {
            if (favoriteColor.Equals("red", StringComparison.CurrentCultureIgnoreCase))
            {
                return "rowboat!";
            }
            else if (favoriteColor.Equals("orange", StringComparison.CurrentCultureIgnoreCase))
            {
                return "skateboard!";
            }
            else if (favoriteColor.Equals("yellow", StringComparison.CurrentCultureIgnoreCase))
            {
                return "motorcycle!";
            }
            else if (favoriteColor.Equals("green", StringComparison.CurrentCultureIgnoreCase))
            {
                return "batmobile!";
            }
            else if (favoriteColor.Equals("blue", StringComparison.CurrentCultureIgnoreCase))
            {
                return "parachute!";
            }
            else if (favoriteColor.Equals("indigo", StringComparison.CurrentCultureIgnoreCase))
            {
                return "helicopter!";
            }
            else if (favoriteColor.Equals("violet", StringComparison.CurrentCultureIgnoreCase))
            {
                return "ferarri!";
            }
            else
            {
                return " ";
            }
        }

        /// <summary>
        /// This function makes the first letter of the input uppercase
        /// </summary>
        /// <param name="s"></param>
        /// <returns>
        /// this function returns a string with an uppercase first letter
        /// </returns>
        public string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        /// <summary>
        /// This function writes the intro for the program to the console, retrieves the users input, writes the players fortune to the console, and asks player if they want to play again. 
        /// </summary>
        public void Project()
        {
            Console.WriteLine("Welcome to the the Amazing and Incredibly Accurate Forture telling machine!");
            Console.WriteLine("If the game gets to be too much for you, enter \"Quit\" at any time, or if you wish to restart the game at any time, enter \"Restart\".");

            while (true)
            {

                string[] input = getInputs();

                string bankAmount = getPredictedBankAmount(input[0], input[1], input[3]);

                string retiredAge = getPredictedRetirement(input[2]).ToString();

                string location = getPredictedLocation(input[5]);

                string transportation = getPredictedTransportation(input[4]);

                Console.WriteLine(UppercaseFirst(input[0]) + " " + UppercaseFirst(input[1]) + " will retire in "  +  retiredAge + " years with " + bankAmount + " in the bank, a vacation home in " + location + ", and a "+ transportation);

                Console.WriteLine("Would you like to try again? \"Yes\" or \"No\"");
                string g = Console.ReadLine().ToLower();
               

                if (g == "no")
                {
                    Console.WriteLine("Thank you for playing!");
                    break;
                }
                else if (g == "yes")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("You chose wrong. Good bye!");
                    break;
                }
                

            }
       
        }
       
    }
}
