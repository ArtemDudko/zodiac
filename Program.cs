//Artem Dudko - 2/3/23
//ECE264 - Lab 3
//Referneces:
/*
 * https://learn.microsoft.com/en-us/dotnet/api/system.datetime.subtract?view=net-7.0
 * https://stackoverflow.com/questions/4832468/getting-number-of-days-in-a-month#:~:text=To%20find%20the%20number%20of,days%20in%20a%20specified%20month.
 * https://stackoverflow.com/questions/41805583/set-the-year-in-a-datetime-object
 * https://www.tutorialsteacher.com/csharp/csharp-datetime
 */

using System.Linq.Expressions;
using System.Security.Cryptography;

namespace zodiac
{
    class Program
    {
        static void Main(string[] args)
        {

            //Variables
            string name;
            DateTime todayDate = DateTime.Today;
            DateTime userDate;

            
            if(GetYesNo("Would you like to use special date for today (y/n)? "))
                todayDate = GetDate("Please enter special date for 'today': ");


            while(GetYesNo("Would you like to get your Astrological Personality traits? "))
            {           //n exits program, y runs forever
                do          //Prompt:
                {
                    Console.Write("Enter Name: ");
                    name = Console.ReadLine();
                    userDate = GetDate("Enter your birth date: ");      //rejects out of range dates
                    if (todayDate <= userDate)          //get rid of any time travelers, since tomorrow's date would parse, but isn't what we need
                        Console.WriteLine("You must be born at least yesterday to use this program!");

                } while (todayDate <= userDate);

                //Response:
                Console.WriteLine("\nThank you, {0}. Based on the information provided, I can tell you the following:", name);
                GetAgeAndNextBday(userDate, todayDate);        
                GetSign(userDate);          //decided to keep it to one method since they both use some of the same variables
            }   
        }  

        static DateTime GetDate(string msg)
        {
            DateTime goodDate;            
            bool pass = false;
            Console.Write(msg);
            //keep trying until we get a date that parses
            do
            {                
                pass = DateTime.TryParse(Console.ReadLine(), out goodDate);
                if (pass == false)
                    Console.WriteLine("Invalid date. Please enter a valid date (mm/dd/yyyy): ");
            } while (pass == false);
            return goodDate;
        }

        static void GetSign(DateTime userBDay)
        {            
            // Zodiac personallity traits
            // Based on source:
            // http://nuclear.ucdavis.edu/~rpicha/personal/astrology/            
            string[] zodiacSign =
            {
                "Sagittarius",
                "Capricorn",
                "Aquarius",
                "Pisces",
                "Aries",
                "Taurus",
                "Gemini",
                "Cancer",
                "Leo",
                "Virgo",
                "Libra",
                "Scorpio"
            };

            string[] zodiacDescription =

                {
                // Sagittarius Nov 23-Dec 22
                "Optimistic and freedom-loving\nJovial and good-humored\n" +
                "Honest and straightforward\nIntellectual and philosophical\n\n" +
                "Blindly optimistic and careless\nIrresponsible and superficial\n" +
                "Tactless and restless\n",

                // Capricorn Dec 23-Jan 20
                "Practical and prudent\nAmbitious and disciplined\n" +
                "Patient and careful\nHumorous and reserved\n\n" +
                "Pessimistic and fatalistic\nMiserly and grudging\n",

                // Aquarius Jan 21-Feb 19
                "Friendly and humanitarian\nHonest and loyal\n" +
                "Original and inventive\nIndependent and intellectual\n\n" +
                "Intractable and contrary\nPerverse and unpredictable\n" +
                "Unemotional and detached\n",

                // Pisces Feb 20-Mar 20
                "Imaginative and sensitive\nCompassionate and kind\n" +
                "Selfless and unworldly\nIntuitive and sympathetic\n\n" +
                "Escapist and idealistic\nSecretive and vague\n" +
                "Weak-willed and easily led\n",

                // Aries Mar 21 - Apr 20                
                "Adventurous and energetic\nPioneering and courageous\n" +
                "Enthusiastic and confident\nDynamic and quick-witted\n\n" +
                "Selfish and quick-tempered\nImpulsive and impatient\n" +
                "Foolhardy and daredevil\n",

                // Taurus Apr 21-May 21
                "Patient and reliable\nWarmhearted and loving\n" +
                "Persistent and determined\nPlacid and security loving\n\n" +
                "Jealous and possessive\nResentful and inflexible\n" +
                "Self-indulgent and greedy\n",
 
                // Gemini May 22-Jun 21
                "Adaptable and versatile\nCommunicative and witty\n" +
                "Intellectual and eloquent\nYouthful and lively\n\n" +
                "Nervous and tense\nSuperficial and inconsistent\n" +
                "Cunning and inquisitive\n",

                // Cancer Jun 22-Jul 22
                "Emotional and loving\nIntuitive and imaginative\n" +
                "Shrewd and cautious\nProtective and sympathetic\n\n" +
                "Changeable and moody\nOveremotional and touchy\n" +
                "Clinging and unable to let go\n",

                // Leo  Jul 23-Aug 21
                "Generous and warmhearted\nCreative and enthusiastic\n" +
                "Broad-minded and expansive\nFaithful and loving\n\n" +
                "Pompous and patronizing\nBossy and interfering\n" +
                "Dogmatic and intolerant\n",

                // Virgo Aug 22-Sep 23
                "Modest and shy\nMeticulous and reliable\n" +
                "Practical and diligent\nIntelligent and analytical\n\n" +
                "Fussy and a worrier\nOvercritical and harsh\n" +
                "Conservative and perfectionist\n",

                // Libra Sep 24-Oct 23
                "Diplomatic and urbane\nRomantic and charming\n" +
                "Easygoing and sociable\nIdealistic and peaceable\n\n" +
                "Indecisive and changeable\nGullible and easily influenced\n" +
                "Flirtatious and self-indulgent\n",

                // Scorpio Oct 24-Nov 22             
                "Determined and forceful\nEmotional and intuitive\n" +
                "Powerful and passionate\nExciting and magnetic\n\n" +
                "Jealous and resentful\nCompulsive and obsessive\n" +
                "Secretive and obstinate\n"

                
                };
            //Dates less than this number mean the index matches the month
            //EX: Capricorn is Dec23-Jan20, zodiacEndDay[0] = 20, and values 21 and over for the day
            //correspond with the next zodiac sign for that month, so values over 20 for Jan would
            //be Aquarius
            int[] zodiacEndDay = { 20, 19, 20, 20, 21, 21, 22, 21, 23, 23, 22, 22 };
            //20 is the last day in Jan, is indexed at 0, and so on

            //if user birthday is in Jan, they are either Cap. or Aqua. depending on the day it ends
            //use zodiacEndDay to check with index, and either print this month's zodiac or next month's
            if (userBDay.Day <= zodiacEndDay[userBDay.Month - 1])
            {
                Console.WriteLine("You were born under the sign of {0}", zodiacSign[userBDay.Month]);
                Console.WriteLine("You have the following personality traits:\n\n{0}", zodiacDescription[userBDay.Month]);
            }
            else
            {
                Console.WriteLine("You were born under the sign of {0}", zodiacSign[(userBDay.Month + 1) % 12]);
                Console.WriteLine("You have the following personality traits:\n\n{0}",zodiacDescription[(userBDay.Month + 1) % 12]);
            }
            Console.WriteLine("NOTE: Source for Astrological/Zodiac personality traits\n" +
                "is http://nuclear.ucdavis.edu/~rpicha/personal/astrology/\n");
        }

        static void GetAgeAndNextBday(DateTime userBDay, DateTime todayDate)
        {
            //Leap Day stuff to avoid out of range exception
            //this adds to age array, if not leap day then adds a 0, doing nothing
            int leapCheckMonth = 0;
            int leapCheckDay = 0;
            if ((userBDay.Month == 2) && (userBDay.Day == 29))
            {
                leapCheckMonth = 1;
                leapCheckDay = 28;
            }

            //Calculate age
            //age[] array     0=years, 1=months, 2=days
            double[] age = { 0, 0, 0 };    
            int daysDiff = DateTime.DaysInMonth(userBDay.Year, userBDay.Month);            
            
            //First find difference between all times before tallying them up
            age[0] = todayDate.Year - userBDay.Year;
            age[1] = todayDate.Month - userBDay.Month;
            age[2] = todayDate.Day - userBDay.Day;

            //Subtraction Operations with dates, carry over days and months if there's not enough
            //Case 1, the general case, is if age has no negatives

            if (age[2] < 0)
            {
                age[1]--;
                age[2] = age[2] + daysDiff;
            }

            if (age[1] < 0)       //Case 2, only months are negative
            {
                age[0]--;
                age[1] = age[1] + 12;
            }

            
/*
            if ((todayDate.Month == userBDay.Month) && (todayDate.Day < userBDay.Day))      //Case 3, bday later in the same month
            {
                age[0]--;
                age[1] = age[1] + 11;
                age[2] = age[2] + daysDiff;
            }
            else if (todayDate.Day < userBDay.Day)      //Case 4, earlier month but later day of the month, no need to change years since it also goes thru case 2
            {
                
            }*/
            
            Console.WriteLine("You are {0} year(s), {1} month(s), and {2} day(s) old", age[0], age[1], age[2]);



            //Next BDay Algorithm   
            //Compare dates to see if the next bday will happen this year or next year, also catches Leap Year bug
            //Leap days automatically jump to next day as per handout for calculations
            DateTime nextBDay = new DateTime(todayDate.Year + 1, userBDay.Month + leapCheckMonth, userBDay.Day - leapCheckDay);
            DateTime nextBDayCheck = new DateTime(todayDate.Year, userBDay.Month + leapCheckMonth, userBDay.Day - leapCheckDay);

            //Easiest method I could find of tallying total days without incessant looping:
            //the time span holds total days, including the different days in each month
            System.TimeSpan daysLeft;      
            if (nextBDayCheck < todayDate)      //if the month/day is earlier than todayDate, count into next year
                daysLeft = nextBDay.Subtract(todayDate);
            else                                //if bday is later in the same year, count same year
                daysLeft = nextBDayCheck.Subtract(todayDate);
            Console.WriteLine("There are {0} days until your next birthday", daysLeft.Days);
        }        

        //GET YES/NO OR Y/N RESPONSE. RETURN TRUE FOR YES/Y, FALSE FOR NO/N
        static bool GetYesNo(string prompt)
        {
            string[] valid = { "YES", "Y", "NO", "N" };
            string ans;
            ans = GetString(prompt, valid, "?Invalid response, please reenter");
            return (ans == "YES" || ans == "Y");

        }

        //Universal get string with prompt, valid values, and error message
        static string GetString(string prompt, string[] valid, string error)
        {
            //prompt = user prompt, valid = array of valid responses
            //error = msg to display on invalid entry
            //all strings returned upper case. all valid[] entries must be in upper case
            string response;
            bool OK = false;
            do
            {
                Console.Write(prompt);
                response = Console.ReadLine().ToUpper();
                foreach (string s in valid) if (response == s.ToUpper()) OK = true;
                if (!OK) Console.WriteLine(error);

            } while (!OK);
            return response;
        }
    }
}














