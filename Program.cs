using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_30065360LIAM
{
    internal class Program
    {
        static string[] login_options = new string[] {          "====================     FOR MULTIPLE CHOICE PLEASE TYPE LETTER IN BRACKETS     ====================",
                                                                "",
                                                                "",
                                                                "        WELCOME TO THE PASSWORD LOCKED NOTEPAD!",
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
        static string[] CLEAR_SCREEN = new string[] {           "====================================================================================================" };
        static string[] LINESELECTION_SCREEN = new string[] {   "======     ENTER = SELECT LINE - +/- = LINE - ESC = SAVE AND EXIT - UP/DOWN = CHANGE LINE     ======" };
        static string[] LINE_EDIT_SCREEN = new string[] {       "========================     ENTER = CONFIRM LINE - ESC = SAVE AND EXIT     ========================" };
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
                                gui_write(8, 6, "USERNAME IS TOO SHORT!");
                            }
                            gui_clear_line(8);
                            username = io_readline(8, 8);
                            gui_clear_line(6);
                        }
                        store_new_login_info(username);
                        break;


                    // login
                    case ConsoleKey.L:
                        gui_write_screen(LOGIN);

                        username = io_readline(8, 8);
                        while (Array.IndexOf(login_info[0], username) == -1)       // check if username is valid then checks if the username index = the password index
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
            Console.WriteLine(username);
        }





        /* the functions bellow is for inputing a new
         * value into the password file and reading it
         * again
         */
        public static void store_new_login_info(string username)
        {
            System.IO.File.AppendAllText($"{Environment.CurrentDirectory}\\User Info\\usernames.txt", $"{Environment.NewLine}{username}");
            System.IO.File.AppendAllText($"{Environment.CurrentDirectory}\\User Info\\user_balences.txt", $"{Environment.NewLine}{50}");
        }
        public static string[][] new_login_info()
        {
            string[] username = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\User Info\\usernames.txt").Split(new[] { Environment.NewLine }, StringSplitOptions.None);     // reads the usernames from a file and stores in string variable
            string[] user_balance = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\User Info\\user_balences.txt").Split(new[] { Environment.NewLine }, StringSplitOptions.None);     // reads the passwords from a file and stores in string variable


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
