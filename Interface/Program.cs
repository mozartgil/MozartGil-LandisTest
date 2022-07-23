
using Business;

namespace Interface
{
    class Program
    {
        public static List<Endpoint> ListEndpoints = new List<Endpoint>();
        public static EndpointsList Endpoints = new EndpointsList(ListEndpoints);
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
                    InsertNewEndpoint(); //INSERT NEW ENDPOINT
                else if (keyOption == "2") // EDIT AN EXISTING ENDPOINT
                    EditEndpoint();    
                else if (keyOption == "3") // DELETE AN EXISTING ENDPOING
                    DeleteEndpoint();    
                else if (keyOption == "4") // LIST ALL ENDPOINTS
                    ListAllEndpoints();
                else if (keyOption == "5") // FIND A ENDPOINT BY SERIAL NUYMBER
                    FindEndpointBySerialNumber();
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

            public void LogWrite(LogLevel logLevel, string message)
            {
                Console.Write($"{logLevel}: {message}");
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

        /// <summary>
        /// Builds the EXIT Application options
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// BUILDS a Meter Model MENU
        /// </summary>
        /// <returns>Valid Meter Model</returns>
        public static MeterModelId MeterModelMenu()
        {
            var logger = new ConsoleLogger();

            //---- METER MODEL ----
            Console.WriteLine("For Meter Model");
            Console.WriteLine("--------------------------");

            GetMeterModelMenuList();

            Console.Write("Option: ");
            string meterModeOption = Console.ReadLine();
            
            while (!InputValidations.CheckMenuInput(16, 19, meterModeOption))
            {
                Console.WriteLine("");
                logger.Log(LogLevel.Error, "Please choose a valid option!");
                
                GetMeterModelMenuList();
                
                Console.Write("Option: ");
                meterModeOption = Console.ReadLine();
            }
            MeterModelId meterModelId = (MeterModelId)int.Parse(meterModeOption);
            Console.WriteLine("--------------------------");
            Console.WriteLine("");

            return meterModelId;
        }

        /// <summary>
        /// Retrieving MeterModel ID and Names for MENU
        /// </summary>
        public static void GetMeterModelMenuList()
        {
            foreach (var item in Enum.GetNames(typeof(MeterModelId)))
            {
                var modelName = item.ToString();
                var modelId = (int)Enum.Parse(typeof(MeterModelId), item);

                Console.WriteLine($"Type {modelId} for Meter Model {modelName}");
            }
        }

        /// <summary>
        /// BUILDS a Meter Number MENU
        /// </summary>
        /// <returns>Valid Meter Model</returns>
        public static int MeterNumberMenu()
        {
            var logger = new ConsoleLogger();

            //---- METER NUMBER ----
            Console.Write("Inform the Meter Number: ");
            string userMeterNumber = Console.ReadLine();

            while (!InputValidations.CheckMenuInput(1, int.MaxValue, userMeterNumber))
            {
                Console.WriteLine("");
                logger.LogWrite(LogLevel.Error, "Please inform a VALID Meter Number: ");
                userMeterNumber = Console.ReadLine();
            }
            int meterNumber = int.Parse(userMeterNumber);
            Console.WriteLine("--------------------------");
            Console.WriteLine("");

            return meterNumber;
        }

        /// <summary>
        /// BUILDS a Firmware Version MENU
        /// </summary>
        /// <returns>Valid Firmware Version</returns>
        public static string FrimwareVersionMenu()
        {
            //---- FIRMWARE VERSION ----
            Console.Write("Inform the Firmware Version: ");
            string meterFirmwareVersion = Console.ReadLine();
            Console.WriteLine("--------------------------");
            Console.WriteLine("");

            return meterFirmwareVersion;
        }

        /// <summary>
        /// BUILDS a Swithc State MENU
        /// </summary>
        /// <returns>Valid Switch State</returns>
        public static SwitchState SwitchStateMenu()
        {
            var logger = new ConsoleLogger();

            //---- SWITCH STATE ----
            Console.WriteLine("For Switch State");
            Console.WriteLine("--------------------------");

            GetSwitchStatesMenuList();

            Console.Write("Option: ");
            string switchStateOption = Console.ReadLine();

            while (!InputValidations.CheckMenuInput(0, 2, switchStateOption))
            {
                Console.WriteLine("");
                logger.Log(LogLevel.Error, "Please choose a valid option!");
                
                GetSwitchStatesMenuList();

                Console.Write("Option: ");
                switchStateOption = Console.ReadLine();
            }
            SwitchState switchState = (SwitchState)int.Parse(switchStateOption);
            Console.WriteLine("--------------------------");
            Console.WriteLine("");

            return switchState;
        }

        /// <summary>
        /// Retrieving Switch State ID and Names for MENU
        /// </summary>
        public static void GetSwitchStatesMenuList()
        {
            foreach (var item in Enum.GetNames(typeof(SwitchState)))
            {
                var modelName = item.ToString();
                var modelId = (int)Enum.Parse(typeof(SwitchState), item);

                Console.WriteLine($"Type {modelId} for {modelName}");
            }
        }

        /// <summary>
        /// CASE 1: INSERTING NEW ENDPOINT
        /// </summary>
        public static void InsertNewEndpoint()
        {
            //CASE 1: INSERT a new Endpoint
            var logger = new ConsoleLogger();

            Console.Clear();
            Console.WriteLine("INSERTING NEW Endpoint");
            Console.WriteLine("--------------------------");
            Console.Write("Inform the Endpoint Serial Number: ");
            SerialNumber endpointSerialNumber = new SerialNumber(Console.ReadLine());
            Console.WriteLine("");

            MeterModelId meterModelId = MeterModelMenu();

            int meterNumber = MeterNumberMenu();

            string meterFirmwareVersion = FrimwareVersionMenu();

            SwitchState switchState = SwitchStateMenu();

            // string endPointSerialNumber = "SN00002";
            // MeterModelId meterModelId = MeterModelId.NSX1P3W;
            // int meterNumber = 5;
            // string meterFirmwareVersion = "FRW-1.1";
            // SwitchState switchState = SwitchState.Armed;

            while (!endpointSerialNumber.ValidatingEndpointSerialNumber(logger, Endpoints))
            {
                endpointSerialNumber.serialNumber = Console.ReadLine();
                Console.WriteLine("");
            }

            var endPoint = new Endpoint(
                endpointSerialNumber.serialNumber,
                meterModelId,
                meterNumber,
                meterFirmwareVersion,
                switchState
            );

            Endpoints.AddEndpointToList(endPoint);

            logger.Log(LogLevel.Information, "Endpoint ADDED successfully!");
            // System.Console.WriteLine($"************************************************************");
            // System.Console.WriteLine($"Endpoints list has {Endpoints.endpointsList.Count} endpoints");
            // System.Console.WriteLine($"************************************************************");
            // System.Console.WriteLine($"");

        }

        /// <summary>
        /// CASE 2: EDITING AN ENDPOINT
        /// </summary>
        public static void EditEndpoint()
        {
            var logger = new ConsoleLogger();

            Console.Clear();

            if (Endpoints.HasAnyEndpoint(logger))
            {
                Console.WriteLine("EDITING Endpoint");
                Console.WriteLine("--------------------------");
                Console.Write("Inform the Endpoint Serial Number to EDIT: ");
                SerialNumber endpointSerialNumber = new SerialNumber(Console.ReadLine());
                Console.WriteLine("");

                // string endPointSerialNumber = "123";
                while (!endpointSerialNumber.ValidatingEndpointSerialNumber(logger, Endpoints, true, false))
                {
                    endpointSerialNumber.serialNumber = Console.ReadLine();
                    Console.WriteLine("");
                }

                var endpointToEdit = endpointSerialNumber.EditEndpoint(logger, Endpoints);

                if (endpointToEdit != null)
                {
                    endpointToEdit.First().switchState = SwitchStateMenu();

                    logger.Log(LogLevel.Information, "Endpoint updated successfully!");
                    Console.WriteLine("--------------------------");
                }

            }
        }

        /// <summary>
        /// CASE 3: DELETING AN ENDPOINT
        /// </summary>
        public static void DeleteEndpoint()
        {
            var logger = new ConsoleLogger();

            Console.Clear();

            if (Endpoints.HasAnyEndpoint(logger))
            {
                Console.WriteLine("DELETING Endpoint");
                Console.WriteLine("--------------------------");
                Console.Write("Inform the Endpoint Serial Number to DELETE: ");
                SerialNumber endpointSerialNumber = new SerialNumber(Console.ReadLine());
                Console.WriteLine("--------------------------");
                Console.WriteLine("");

                
                while (!endpointSerialNumber.ValidatingEndpointSerialNumber(logger, Endpoints, true, false))
                {
                    endpointSerialNumber.serialNumber = Console.ReadLine();
                    Console.WriteLine("");
                }

                endpointSerialNumber.DeleteEndpoint(logger, Endpoints);
            }
        }

        /// <summary>
        /// CASE 4: LISTING ALL ENDPOINTS
        /// </summary>
        public static void ListAllEndpoints()
        {
            var logger = new ConsoleLogger();

            Console.Clear();

            if (Endpoints.HasAnyEndpoint(logger))
            {
                Endpoints.ListiAllEndpoints();

                return;
            }
        }
    
        /// <summary>
        /// CASE 5: FIND A ENDPOINT BY SERIAL NUMBER
        /// </summary>
        public static void FindEndpointBySerialNumber()
        {
            var logger = new ConsoleLogger();
            
            Console.Clear();

            if (Endpoints.HasAnyEndpoint(logger))
            {
                Console.WriteLine("FINDING an Endpoint");
                Console.WriteLine("--------------------------");
                Console.Write("Inform the Endpoint Serial Number to FIND: ");
                SerialNumber endpointSerialNumber = new SerialNumber(Console.ReadLine());
                Console.WriteLine("--------------------------");
                Console.WriteLine("");

                while (!endpointSerialNumber.ValidatingEndpointSerialNumber(logger, Endpoints, true, false))
                {
                    endpointSerialNumber.serialNumber = Console.ReadLine();
                    Console.WriteLine("");
                }

                endpointSerialNumber.FindEndpointBySerialNumber(logger, Endpoints);

                return;
            }
        }
    }
}
