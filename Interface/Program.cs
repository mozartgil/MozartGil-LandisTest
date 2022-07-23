using Interface;
using Business;

class Program
{
    static void Main()
    {
        Console.Clear();
        
        var keyOption = "1";
        var logger = new ConsoleLogger();

        while (keyOption != "7")
        {
            PrintApplicationHeader();

            keyOption = MenuOption();

            if (keyOption == "1")
            {

            } //INSERT NEW ENDPOINT
            else if (keyOption == "6") // EXIT APPLICATION
            {
                keyOption = ExitingApplicationOption();
                
                //keyOption == 1 means the user choose to exit the application
                if (keyOption == "1")
                {
                    Console.Clear();
                    logger.Log(LogLevel.Information, "EXITING THE APPLICATION. THANK YOU!");
                    break;
                }

                Console.Clear();
            }
        }
    }

    /// <summary>
    /// Class to write Console Loggers
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        public void Log(LogLevel logLevel, string message)
        {
            Console.WriteLine($"{logLevel}: {message}");
            Console.WriteLine("");
        }
    }

    /// <summary>
    /// Just prints the application header.
    /// </summary>
    public static void PrintApplicationHeader()
    {
        Console.WriteLine("WELCOME TO MANAGING ENDPOINTS APPLICATION");
        Console.WriteLine("--------------------------");
    }

    /// <summary>
    /// Building MAIN MENU and getting user INPUT option
    /// </summary>
    /// <returns>User's INPUT</returns>
    public static string MenuOption()
    {
        var keyOption = "0";
        var logger = new ConsoleLogger();

        Console.WriteLine("Press 1 to INSERT a new Endpoint");
        Console.WriteLine("Press 2 to EDIT an existing Endpoint");
        Console.WriteLine("Press 3 to DELETE an existing Endpoint");
        Console.WriteLine("Press 4 to LIST all existing Endpoints");
        Console.WriteLine("Press 5 to FIND an existing Endpoint by its Serial Number");
        Console.WriteLine("Press 6 to EXIT the application");
        Console.WriteLine("--------------------------");
        Console.Write("Option: ");
        keyOption = Console.ReadLine();
        Console.WriteLine("--------------------------");

        while (!InputValidations.CheckMenuInput(1, 6, keyOption))
        {
            Console.WriteLine("");
            logger.Log(LogLevel.Error, "Please choose a valid option!");
            Console.WriteLine("Press 1 to INSERT a new Endpoint");
            Console.WriteLine("Press 2 to EDIT an existing Endpoint");
            Console.WriteLine("Press 3 to DELETE an existing Endpoint");
            Console.WriteLine("Press 4 to LIST all existing Endpoints");
            Console.WriteLine("Press 5 to FIND an existing Endpoint by its Serial Number");
            Console.WriteLine("Press 6 to EXIT the application");
            Console.WriteLine("--------------------------");
            Console.Write("Option: ");
            keyOption = Console.ReadLine();
            Console.WriteLine("--------------------------");
        }


        return keyOption;
    }

    //Builds the EXIT Application options
    public static string ExitingApplicationOption() 
    {
        var keyOption = "0";
        var logger = new ConsoleLogger();

        Console.WriteLine("Are you sure you want to exit the application?");
        Console.WriteLine("Press 1 to CONFIRM");
        Console.WriteLine("Press 2 to RETURN to MENU");
        Console.WriteLine("--------------------------");
        Console.Write("Option: ");
        keyOption = Console.ReadLine();
        Console.WriteLine("--------------------------");

        while (!InputValidations.CheckMenuInput(1, 2, keyOption))
        {
            Console.WriteLine("");
            logger.Log(LogLevel.Error, "Please choose a valid option!");
            Console.WriteLine("Press 1 to CONFIRM and exit the application");
            Console.WriteLine("Press 2 to RETURN to MENU");
            Console.WriteLine("--------------------------");
            Console.Write("Option: ");
            keyOption = Console.ReadLine();
            Console.WriteLine("--------------------------");
        }

        return keyOption;
    }
}