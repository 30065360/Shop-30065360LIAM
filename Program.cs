using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_30065360LIAM
{
    internal class Program
    {
        static string[] CLEAR_SCREEN = new string[] {           "====================================================================================================" };
        static string[] login_options = new string[] {          "====================     FOR MULTIPLE CHOICE PLEASE TYPE LETTER IN BRACKETS     ====================",
                                                                "",
                                                                "",
                                                                "        WELCOME TO THE shopping!",
                                                                "",
                                                                "",
                                                                "",
                                                                "        (C)REATE ACCOUNT",
                                                                "        (L)OGIN" };
        static string[] LOGIN = new string[] {                  "====================================================================================================",
                                                                "",
                                                                "",
                                                                "        LOGIN",
                                                                "",
                                                                "",
                                                                "",
                                                                "        USERNAME:" };
        static string[] CREATE_ACCOUNT = new string[] {         "====================================================================================================",
                                                                "",
                                                                "",
                                                                "        CREATE ACCOUNT",
                                                                "",
                                                                "",
                                                                "",
                                                                "        USERNAME:" };
        static string[] Account_Decision = new string[] {       "====================================================================================================",
                                                                "",
                                                                "        Balance: $",
                                                                "",
                                                                "        WHAT WOULD YOU LIKE TO DO:",
                                                                "",
                                                                "            (A)DD FUNDS TO WALLET",
                                                                "            (B)ROWSE CATALOG",
                                                                "            (V)EIW ITEMS IN INVENTORY" };
        static string[] ADD_FUNDS = new string[] {              "====================================================================================================",
                                                                "",
                                                                "        Balance: $",
                                                                "",
                                                                "",
                                                                "        INPUT NUMBER TO CHANGE FUNDS TO:" };
        static string[] ITEMS_IN_INVENTORY = new string[] {     "====================================================================================================",
                                                                "",
                                                                "",
                                                                "        INVENTORY:" };
        static string[] Category_1 = new string[] {             "====================     USE LEFT/RIGHT ARROWS TO SCROLL THROUGH CATEGORIES     ====================",
                                                                "",
                                                                "        Balance:",
                                                                "",
                                                                "        AMD CPUs:",
                                                                "",
                                                                "        (0): $385 - AMD Ryzen 5 5600X",
                                                                "        (1): $330 - AMD Ryzen 5 5600",
                                                                "        (2): $470 - AMD Ryzen 7 5700X",
                                                                "        (3): $320 - AMD Ryzen 5 5600G",
                                                                "        (4): $240 - AMD Ryzen 5 5500" };
        static string[] Category_2 = new string[] {             "====================     USE LEFT/RIGHT ARROWS TO SCROLL THROUGH CATEGORIES     ====================",
                                                                "",
                                                                "        Balance:",
                                                                "",
                                                                "        INTEL CPUs:",
                                                                "",
                                                                "        (0): $285 - Intel Core i5 12400F",
                                                                "        (1): $195 - Intel Core i5 10400F",
                                                                "        (2): $660 - Intel Core i7-12700K",
                                                                "        (3): $620 - Intel Core i7-12700KF",
                                                                "        (4): $950 - Intel Core i9-12900K" };
        static string[] Category_3 = new string[] {             "====================     USE LEFT/RIGHT ARROWS TO SCROLL THROUGH CATEGORIES     ====================",
                                                                "",
                                                                "        Balance:",
                                                                "",
                                                                "        GPUs:",
                                                                "",
                                                                "        (0): $390 - GEFORCE RTX 3050",
                                                                "        (1): $515 - GEFORCE RTX 3060",
                                                                "        (2): $780 - GEFORCE RTX 3070",
                                                                "        (3): $1095 - GEFORCE RTX 3080",
                                                                "        (4): $2345 - GEFORCE RTX 3090" };


        static void Main(string[] args)
        {
            string[][] login_info = new_login_info();


            /* login/create account section
             */
            gui_write_screen(login_options);

            ConsoleKey valid_key = ConsoleKey.A;
            string username = "";

            while (valid_key != ConsoleKey.C && valid_key != ConsoleKey.L)
            {
                valid_key = io_readkey(8, 11);
                switch (valid_key)
                {
                    // create account
                    case ConsoleKey.C:
                        gui_write_screen(CREATE_ACCOUNT);

                        username = io_readline(8, 8);
                        while (Array.IndexOf(login_info[0], username) != -1 || username.Length <= 3)
                        {
                            gui_write(8, 8, "USERNAME IS TAKEN!");
                            if (Array.IndexOf(login_info[0], username) != -1)
                            {
                                gui_write(8, 6, "USERNAME IS TAKEN!");
                            }
                            else if (username.Length <= 3)
                            {
                                gui_write(8, "USERNAME IS TOO SHORT!");
                            }
                            gui_clear_line(8);
                            username = io_readline(8, 8);
                            gui_clear_line(6);
                        }
                        store_new_login_info(username);
                        login_info = new_login_info();
                        break;


                    // login
                    case ConsoleKey.L:
                        gui_write_screen(LOGIN);

                        username = io_readline(8, 8);
                        while (Array.IndexOf(login_info[0], username) == -1)       // check if username is valid
                        {
                            gui_write(8, 6, "USERNAME IS INVALID!");
                            gui_clear_line(8);
                            username = io_readline(8, 8);
                            gui_clear_line(6);
                        }
                        break;


                    // invalid option
                    default:
                        gui_write(8, 10, "PLEASE INPUT A VALID KEY");
                        valid_key = io_readkey(8, 11);
                        break;
                }
            }
            int username_index = Array.IndexOf(login_info[0], username);
            int user_bal = Int32.Parse(login_info[1][username_index]);


            gui_write_screen(Account_Decision);
            gui_write(18, 2, user_bal.ToString());
            valid_key = ConsoleKey.Q;

            while (valid_key != ConsoleKey.B && valid_key != ConsoleKey.V)
            {
                valid_key = io_readkey(8, 11);
                switch (valid_key)
                {
                    // ADD FUNDS TO WALLET
                    case ConsoleKey.A:
                        gui_write_screen(ADD_FUNDS);
                        gui_write(18, 2, user_bal.ToString());

                        bool valid_input = Int32.TryParse(io_readline(8, 6), out user_bal);
                        
                        while (!valid_input)
                        {
                            gui_write(8, 4, "i said number dipshit");       // This line adds personality
                            gui_clear_line(6);
                            valid_input = Int32.TryParse(io_readline(8, 6), out user_bal);
                        }
                        lineChanger(user_bal.ToString(), username_index);

                        gui_write_screen(Account_Decision);
                        gui_write(18, 2, user_bal.ToString());
                        break;


                    // BROWSE CATALOG
                    case ConsoleKey.B:
                        break;


                    // VEIW ITEMS IN INVENTORY
                    case ConsoleKey.V:
                        gui_write_screen(ITEMS_IN_INVENTORY);

                        string[] user_items = System.IO.File.ReadAllText($"{Environment.CurrentDirectory}\\User Items\\{username}.txt").Split(new[] { Environment.NewLine }, StringSplitOptions.None);     // this line reads the users items from a file and stores it in user_items

                        foreach (string item in user_items)
                        {
                            gui_write(12, Array.IndexOf(user_items, item)+3, item);
                        }
                        Console.ReadLine();
                        break;


                    // invalid option
                    default:
                        gui_write(8, 10, "PLEASE INPUT A VALID KEY");
                        break;
                }
            }





        }



        /* function bellow was done by https://stackoverflow.com/questions/1971008/edit-a-specific-line-of-a-text-file-in-c-sharp
         * what it does is it reads all values in a file and edits a single line and then rewrites the file
         */
        static void lineChanger(string newText, int line_to_edit)
        {
            string[] arrLine = System.IO.File.ReadAllLines($"{Environment.CurrentDirectory}\\User Info\\user_balences.txt");
            arrLine[line_to_edit] = newText;
            System.IO.File.WriteAllLines($"{Environment.CurrentDirectory}\\User Info\\user_balences.txt", arrLine);
        }



        /* the functions bellow is for inputing a new
         * value into the password file and reading it
         * again
         */
        public static void store_new_login_info(string username)
        {
            System.IO.File.AppendAllText($"{Environment.CurrentDirectory}\\User Info\\usernames.txt", $"{Environment.NewLine}{username}");
            System.IO.File.AppendAllText($"{Environment.CurrentDirectory}\\User Info\\user_balences.txt", $"{Environment.NewLine}{50}");
            System.IO.File.AppendAllText($"{Environment.CurrentDirectory}\\User Items\\{username}.txt", "");
        }
        public static string[][] new_login_info()
        {
            string[] username = System.IO.File.ReadAllText($"{Environment.CurrentDirectory}\\User Info\\usernames.txt").Split(new[] { Environment.NewLine }, StringSplitOptions.None);     // reads the usernames from a file and stores in string variable
            string[] user_balance = System.IO.File.ReadAllText($"{Environment.CurrentDirectory}\\User Info\\user_balences.txt").Split(new[] { Environment.NewLine }, StringSplitOptions.None);     // reads the passwords from a file and stores in string variable


            return new string[][] { username, user_balance };
        }






        /* The functions below are for reading line
         * and reading key.
         */
        public static string io_readline(int x_pos, int y_pos)      //read line
        {
            Console.SetCursorPosition(x_pos, y_pos);
            string user_input = Console.ReadLine();
            Console.SetCursorPosition(0, 20);
            return user_input;
        }
        public static ConsoleKey io_readkey(int x_pos, int y_pos)      //read key
        {
            Console.SetCursorPosition(x_pos, y_pos);
            ConsoleKey user_input = Console.ReadKey().Key;
            Console.SetCursorPosition(0, 20);
            return user_input;
        }









        /* The functions below are for easily updating
         * to a new screen gui and writing to and existing screen
         */
        public static void gui_write_screen(string[] tbd)
        {
            string[] display = new string[20];
            display[19] = tbd[0];

            for (int i = 0; i < tbd.Length; i++)
            {
                display[i] = tbd[i];
                while (display[i].Length < 100)
                {
                    display[i] += " ";
                }
            }
            for (int i = tbd.Length; i < display.Length - 1; i++)
            {
                display[i] = "                                                                                                    ";
            }

            Console.SetCursorPosition(0, 0);
            foreach (string displayItem in display)
            {
                Console.WriteLine(displayItem);
            }
        }
        public static void gui_write(int x_pos, int y_pos, string message)
        {
            Console.SetCursorPosition(x_pos, y_pos);
            Console.WriteLine(message);
        }
        public static void gui_clear_line(int y_pos)
        {
            Console.SetCursorPosition(0, y_pos);
            Console.WriteLine("                                                                                                    ");
        }

    }
}
