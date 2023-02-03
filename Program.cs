//Artem Dudko - 2/3/23
//ECE264 - Lab 3
//Referneces:
/*
 * https://learn.microsoft.com/en-us/dotnet/api/system.datetime.subtract?view=net-7.0
 * 
 */

using System.Linq.Expressions;

namespace zodiac
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            DateTime todayDate = DateTime.Today;
            DateTime todayTime = DateTime.Now;
            DateTime userDate = new DateTime(1969, 7, 20);
            int[] age = new int[3];


            //bool pass = false;
            //DateTime userBD;
            //Console.WriteLine(todayDate.ToString());    //returns start of day
            //Console.WriteLine(todayTime.ToString());
            //Console.WriteLine(userDate.ToString());

            //Console.WriteLine("Enter your birth date: ");

            if(GetYesNo("Would you like to get your Astrological Personlaity traits?"))
            {
                //Prompt:
                Console.WriteLine("Enter Name: ");
                name = Console.ReadLine();       
                userDate = GetDate("Enter your birth date: ");
                GetSign(userDate);

                //Respone:
                Console.WriteLine("Thank you, {0}.")
            }

            /*
            if(userDate.Day > todayDate.Day)
            {
                age[2] = 
            }

            if(userDate.Month > todayDate.Month)

            if(userDate.Year > todayDate.Year)*/











            //System.DateTime diff = todayDate.Subtract(testDate)
            //Console.WriteLine(testDate.ToString());



        }

        /*static bool GetDate(string date)
        {

            return 
        }*/

        static DateTime GetDate(string msg)
        {
            DateTime goodDate;
            bool pass = false;

            Console.WriteLine("Enter your birth date: ");

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
            //int index;
            // Zodiac personallity traits
            // Based on source:
            // http://nuclear.ucdavis.edu/~rpicha/personal/astrology/
            //Console.WriteLine("userBDay: {0}", userBDay);
            //userBDay.AddDays(20);
            //index = (userBDay.Month + 11) % 12;
            //Console.WriteLine("{0}", index);
            //Console.WriteLine("userBDay + 20: {0}", userBDay);

            string[] zodiacDescription =

                {
                // Sagittarius Nov 23-Dec 22
                "You are born under the sign of Sagittarius\n"+
                "You have the following personality traits:\n"+
                "Optimistic and freedom-loving\nJovial and good-humored\n" +
                "Honest and straightforward\nIntellectual and philosophical\n\n" +
                "Blindly optimistic and careless\nIrresponsible and superficial\n" +
                "Tactless and restless\n",

                // Capricorn Dec 23-Jan 20
                "You are born under the sign of Capricorn\n"+
                "You have the following personality traits:\n"+
                "Practical and prudent\nAmbitious and disciplined\n" +
                "Patient and careful\nHumorous and reserved\n\n" +
                "Pessimistic and fatalistic\nMiserly and grudging\n",

                // Aquarius Jan 21-Feb 19
                "You are born under the sign of Aquarius\n"+
                "You have the following personality traits:\n"+
                "Friendly and humanitarian\nHonest and loyal\n" +
                "Original and inventive\nIndependent and intellectual\n\n" +
                "Intractable and contrary\nPerverse and unpredictable\n" +
                "Unemotional and detached\n",

                // Pisces Feb 20-Mar 20
                "You are born under the sign of Pisces\n"+
                "You have the following personality traits:\n"+
                "Imaginative and sensitive\nCompassionate and kind\n" +
                "Selfless and unworldly\nIntuitive and sympathetic\n\n" +
                "Escapist and idealistic\nSecretive and vague\n" +
                "Weak-willed and easily led\n",

                // Aries Mar 21 - Apr 20                
                "You are born under the sign of Aries\n"+
                "You have the following personality traits:\n"+
                "Adventurous and energetic\nPioneering and courageous\n" +
                "Enthusiastic and confident\nDynamic and quick-witted\n\n" +
                "Selfish and quick-tempered\nImpulsive and impatient\n" +
                "Foolhardy and daredevil\n",

                // Taurus Apr 21-May 21
                "You are born under the sign of Taurus\n"+
                "You have the following personality traits:\n"+
                "Patient and reliable\nWarmhearted and loving\n" +
                "Persistent and determined\nPlacid and security loving\n\n" +
                "Jealous and possessive\nResentful and inflexible\n" +
                "Self-indulgent and greedy\n",
 
                // Gemini May 22-Jun 21
                "You are born under the sign of Gemini\n"+
                "You have the following personality traits:\n"+
                "Adaptable and versatile\nCommunicative and witty\n" +
                "Intellectual and eloquent\nYouthful and lively\n\n" +
                "Nervous and tense\nSuperficial and inconsistent\n" +
                "Cunning and inquisitive\n",

                // Cancer Jun 22-Jul 22
                "You are born under the sign of Cancer\n"+
                "You have the following personality traits:\n"+
                "Emotional and loving\nIntuitive and imaginative\n" +
                "Shrewd and cautious\nProtective and sympathetic\n\n" +
                "Changeable and moody\nOveremotional and touchy\n" +
                "Clinging and unable to let go\n",

                // Leo  Jul 23-Aug 21
                "You are born under the sign of Leo\n"+
                "You have the following personality traits:\n"+
                "Generous and warmhearted\nCreative and enthusiastic\n" +
                "Broad-minded and expansive\nFaithful and loving\n\n" +
                "Pompous and patronizing\nBossy and interfering\n" +
                "Dogmatic and intolerant\n",

                // Virgo Aug 22-Sep 23
                "You are born under the sign of Virgo\n"+
                "You have the following personality traits:\n"+
                "Modest and shy\nMeticulous and reliable\n" +
                "Practical and diligent\nIntelligent and analytical\n\n" +
                "Fussy and a worrier\nOvercritical and harsh\n" +
                "Conservative and perfectionist\n",

                // Libra Sep 24-Oct 23
                "You are born under the sign of Libra\n"+
                "You have the following personality traits:\n"+
                "Diplomatic and urbane\nRomantic and charming\n" +
                "Easygoing and sociable\nIdealistic and peaceable\n\n" +
                "Indecisive and changeable\nGullible and easily influenced\n" +
                "Flirtatious and self-indulgent\n",

                // Scorpio Oct 24-Nov 22
                "You are born under the sign of Scorpio\n"+
                "You have the following personality traits:\n"+
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
            if (userBDay.Day <= zodiacEndDay[userBDay.Month - 1])
                Console.WriteLine(zodiacDescription[userBDay.Month]);
            else
                Console.WriteLine(zodiacDescription[(userBDay.Month + 1) % 12]);

            Console.WriteLine("NOTE: Source for Astrological/Zodiac personality traits\n" +
                "is http://nuclear.ucdavis.edu/~rpicha/personal/astrology/");
            
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














