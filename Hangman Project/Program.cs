using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // game start page

        title_screen:
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "theme.wav";
            player.PlayLooping();
            Console.ForegroundColor = ConsoleColor.Red;
        Console.SetWindowSize(100, 15);

            // hangman screen

        Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("----------------██░-██--▄▄▄-------███▄----█---▄████--███▄-▄███▓-▄▄▄-------███▄----█----------------");
            Console.WriteLine("---------------▓██░-██▒▒████▄-----██-▀█---█--██▒-▀█▒▓██▒▀█▀-██▒▒████▄-----██-▀█---█----------------");
            Console.WriteLine("---------------▒██▀▀██░▒██--▀█▄--▓██--▀█-██▒▒██░▄▄▄░▓██----▓██░▒██--▀█▄--▓██--▀█-██▒---------------");
            Console.WriteLine("---------------░▓█-░██-░██▄▄▄▄██-▓██▒--▐▌██▒░▓█--██▓▒██----▒██-░██▄▄▄▄██-▓██▒--▐▌██▒---------------");
            Console.WriteLine("---------------░▓█▒░██▓-▓█---▓██▒▒██░---▓██░░▒▓███▀▒▒██▒---░██▒-▓█---▓██▒▒██░---▓██░---------------");
            Console.WriteLine("----------------▒-░░▒░▒-▒▒---▓▒█░░-▒░---▒-▒--░▒---▒-░-▒░---░--░-▒▒---▓▒█░░-▒░---▒-▒----------------");
            Console.WriteLine("----------------▒-░▒░-░--▒---▒▒-░░-░░---░-▒░--░---░-░--░------░--▒---▒▒-░░-░░---░-▒░---------------");
            Console.WriteLine("----------------░--░░-░--░---▒------░---░-░-░-░---░-░------░-----░---▒------░---░-░----------------");
            Console.WriteLine("----------------░--░--░------░--░---------░-------░--------░---------░--░---------░----------------");
            Console.WriteLine("--------------------------------------Made-By-Darim-And-Mustafa------------------------------------");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                        Press Enter To Begin                                       ");
            Console.ReadLine();

            // user chooses which hangman to play (user made or computer generated)

            game_chooser:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            string input;
            Random rnd = new Random();
            int random = rnd.Next(0, 4);
            Boolean comp = false;
            Boolean user = false;
            string word = "potato";
            Console.WriteLine();
            Console.WriteLine("  Would you like to:");
            Console.WriteLine("   1. Use computer generated words.");
            Console.WriteLine("   2. Create and play with user made words.");
            Console.WriteLine("   3. Exit game.");
            Console.WriteLine("   (input the number)");
            input = Convert.ToString(Console.ReadLine());

            // runs through user option

            if (input == "1")
            {

            // user chooses which topic to play

            topic_chooser:
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("  Choose a topic:");
                Console.WriteLine("   1. Food.");
                Console.WriteLine("   2. Science.");
                Console.WriteLine("   3. Countries.");
                Console.WriteLine("   4. Sentences (hard).");
                Console.WriteLine("   5. Go back.");
                Console.WriteLine("   (input the number)");
                input = Convert.ToString(Console.ReadLine());

                string[] computer = new string[5];

                // runs through user option

                if (input == "1")
                {
                    computer[0] = "potato";
                    computer[1] = "tomato";
                    computer[2] = "rice";
                    computer[3] = "burger";
                    computer[4] = "pasta";
                    comp = true;
                    word = computer[random];
                }
                else if (input == "2")
                {
                    computer[0] = "chemistry";
                    computer[1] = "physics";
                    computer[2] = "biology";
                    computer[3] = "astronomy";
                    computer[4] = "anthropology";
                    comp = true;
                    word = computer[random];
                }
                else if (input == "3")
                {
                    computer[0] = "canada";
                    computer[1] = "united states of america";
                    computer[2] = "russia";
                    computer[3] = "france";
                    computer[4] = "germany";
                    comp = true;
                    word = computer[random];
                }
                else if (input == "4")
                {
                    computer[0] = "hello this program is nice";
                    computer[1] = "this sentence is pointless";
                    computer[2] = "whay deos tihs stence heva so muhc eorrs";
                    computer[3] = "school may be fun";
                    computer[4] = "this is a very long sentence to test how good you are at hangman";
                    comp = true;
                    word = computer[random];
                }
                else if (input == "5")
                {
                    comp = false;
                    goto game_chooser;
                }

                    // if incorrect is entered

                else
                {
                    Console.WriteLine("  Incorrect input. Press enter to try again.");
                    Console.ReadLine();
                    goto topic_chooser;
                }
            }
            else if (input == "2")
            {
                user = true; 
                goto game;
            }
            else if (input == "3")
            {
                goto end_screen;
            }

                // if incorrect is entered

            else
            {
                Console.WriteLine("  Incorrect input. Press enter to try again.");
                Console.ReadLine();
                goto game_chooser;
            }

            // begins the game with what user chose

            game:
            Console.SetWindowSize(99, 35);
            Console.ForegroundColor = ConsoleColor.Yellow;

            // games variables made

            char guess;
            char checker;
            Boolean sohaib = false;
            int incorrect = 0;
            int guess_number = 0;
            Boolean head = false;
            Boolean body = false;
            Boolean arm1 = false;
            Boolean arm2 = false;
            Boolean leg1 = false;
            Boolean leg2 = false;
            Boolean lose = false;
            Boolean win = false;
            int corrects = 0;
            guess_number = 0;
            Console.Clear();

            // determines if user chose user made or computer generated words

            if (user == true)
            {
                Console.WriteLine("  Input the word.");
                input = Convert.ToString(Console.ReadLine());
                input = input.ToLower();
            }
            else if (comp == true)
            {
                input = word;
            }

            char[] name = input.ToCharArray();
            char[] blanks = new char[name.Length];
            char[] guesses = new char[1000];
            Boolean[] darim = new Boolean[name.Length];
            
            // creates blanks

            for (int i = 0; i < blanks.Length; i++)
            {
                blanks[i] = '_';
            }

            // prints out the hangman module

            hangman:
            if (incorrect == 1) { head = true; }
            if (incorrect == 2) { body = true; }
            if (incorrect == 3) { arm1 = true; head = false; }
            if (incorrect == 4) { arm2 = true; arm1 = false; }
            if (incorrect == 5) { leg1 = true; }
            if (incorrect == 6) { leg2 = true; leg1 = false; }
            if (incorrect == 7) { lose = true; }
            if (lose == true) { for (int i = 0; i < name.Length; i++) { blanks[i] = name[i]; } }

            Console.Clear();
            Console.WriteLine("        ____________");
            Console.WriteLine("        |          |");
            if (head == true)
            {
                Console.WriteLine("        |         (.)");
            }
            if (arm1 == true)
            {
                Console.WriteLine("        |       __(.)");
            }
            if (arm2 == true)
            {
                Console.WriteLine("        |       __(.)__");
            }
            if (body == true)
            {
                Console.WriteLine("        |          |");
                Console.WriteLine("        |          -");
            }
            if (leg1 == true)
            {
                Console.WriteLine("        |         |");
            }
            if (leg2 == true)
            {
                Console.WriteLine("        |         | |");
            }
            Console.WriteLine("        |");
            Console.WriteLine("        |");
            Console.WriteLine("        |");
            Console.WriteLine("        |");
            Console.WriteLine("        |");
            Console.WriteLine("  ______|______");

            // prints out the words with what has been guessed

            Console.WriteLine();
            for (int i = 0; i < blanks.Length; i++)
            {
                Console.Write(blanks[i] + " ");
            }

            // after hangman printed determines whether the user has won or lost yet

            if (win == true)
            {
                System.Media.SoundPlayer cool = new System.Media.SoundPlayer();
                cool.SoundLocation = "win.wav";
                cool.Play();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("  Good job you won.");
                corrects = 0;
                Console.WriteLine("  Press enter to title screen.");
                Console.ReadLine();
                goto title_screen;
            }

            if (lose == true)
            {
                System.Media.SoundPlayer suck = new System.Media.SoundPlayer();
                suck.SoundLocation = "hang.wav";
                suck.Play();
                Console.WriteLine("  Was the word.");
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  You lose. Press enter to return to title screen.");
                Console.ReadLine();
                Console.Clear();
                incorrect = 0;
                goto title_screen;
            }

            // user guesses letters here

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  Guess a character:");

            sohaibious:
                input = Convert.ToString(Console.ReadLine());
                input = input.ToLower();

            // checks if user entered something other than a character

                if (!char.TryParse(input, out guess))
                {
                    Console.WriteLine("   Put in a single character.");
                    goto sohaibious;
                }

                guesses[guess_number] = guess;

            // checks if user entered a character that has already been put in

                for (int i = 0; i < name.Length; i++)
                {
                    if (i == guess_number)
                    {
                        i++;
                    }
                    if (guess == guesses[i])
                    {
                        Console.WriteLine("  You have already entered this character. Input a different one.");
                        guesses[i] = guesses[i + 1];
                        if (guess_number > 0)
                        {
                            guess_number--;
                        }
                        goto sohaibious;
                    }
                }

                guess_number++;

            // checks if entered letter matches any letter in the word

                for (int i = 0; i < name.Length; i++)
                {
                    checker = Convert.ToChar(name[i]);
                    if (guess == checker)
                    {
                        darim[i] = true;
                        blanks[i] = guess;
                        sohaib = true;
                    }
                }

            // goes through to output if letter matched a letter in the word or not

                if (sohaib == true)
                {
                    sohaib = false;
                    for (int i = 0; i < darim.Length; i++)
                    {
                        if (darim[i] == true)
                        {
                            corrects++;
                        }
                    }
                    if (corrects == darim.Length)
                    {
                        win = true;
                        for (int ii = 0; ii < name.Length; ii++) { blanks[ii] = name[ii]; }
                    }
                    corrects = 0;
                    goto hangman;
                }
                else
                {
                    Console.WriteLine("  " + input + " was not one of the characters.");
                    incorrect++;
                    Console.WriteLine("  Press enter to try again.");
                    Console.ReadLine();
                    goto hangman;
                }

            // prints out exit screen if user chooses to exit

            end_screen:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetWindowSize(99, 15);

                Console.Clear();
                Console.WriteLine("---------------------------------------------------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------------------------------------------------");
                Console.WriteLine("----------------██░-██--▄▄▄-------███▄----█---▄████--███▄-▄███▓-▄▄▄-------███▄----█----------------");
                Console.WriteLine("---------------▓██░-██▒▒████▄-----██-▀█---█--██▒-▀█▒▓██▒▀█▀-██▒▒████▄-----██-▀█---█----------------");
                Console.WriteLine("---------------▒██▀▀██░▒██--▀█▄--▓██--▀█-██▒▒██░▄▄▄░▓██----▓██░▒██--▀█▄--▓██--▀█-██▒---------------");
                Console.WriteLine("---------------░▓█-░██-░██▄▄▄▄██-▓██▒--▐▌██▒░▓█--██▓▒██----▒██-░██▄▄▄▄██-▓██▒--▐▌██▒---------------");
                Console.WriteLine("---------------░▓█▒░██▓-▓█---▓██▒▒██░---▓██░░▒▓███▀▒▒██▒---░██▒-▓█---▓██▒▒██░---▓██░---------------");
                Console.WriteLine("----------------▒-░░▒░▒-▒▒---▓▒█░░-▒░---▒-▒--░▒---▒-░-▒░---░--░-▒▒---▓▒█░░-▒░---▒-▒----------------");
                Console.WriteLine("----------------▒-░▒░-░--▒---▒▒-░░-░░---░-▒░--░---░-░--░------░--▒---▒▒-░░-░░---░-▒░---------------");
                Console.WriteLine("----------------░--░░-░--░---▒------░---░-░-░-░---░-░------░-----░---▒------░---░-░----------------");
                Console.WriteLine("----------------░--░--░------░--░---------░-------░--------░---------░--░---------░----------------");
                Console.WriteLine("--------------------------------------Made-By-Darim-And-Mustafa------------------------------------");
                Console.WriteLine("---------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                         Press Enter To Exit                                       ");

                Console.ReadLine();
        }
    }
}
