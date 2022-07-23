
namespace Business
{
    public class SerialNumber
    {
        public string? serialNumber { get; set; }

        public SerialNumber(string endpointSerialNumber)
        {
            this.serialNumber = endpointSerialNumber.ToUpper();
        }

        /// <summary>
        /// Validates an Endpoint Serial Number
        /// </summary>
        /// <returns></returns>
        public bool ValidatingEndpointSerialNumber(ILogger logger, EndpointsList Endpoints, bool isNullValidation = true, bool existingSerialNumberValidation = true)
        {
            //NULL OR WHITE?
            if (isNullValidation)
            {
                if (string.IsNullOrWhiteSpace(this.serialNumber))
                {
                    logger.Log(LogLevel.Error, $"Endpoint serial number can't be blank.");
                    
                    Console.WriteLine("--------------------------");
                    Console.Write("Inform a VALID Endpoint Serial Number: ");
                    return false;
                }
            }

            //VERIFYING IF SERIAL NUMBER IS ALREADY TAKEN
            if (existingSerialNumberValidation)
            {
                var existingSerialNumber = Endpoints.endpointsList.Where(endpoint => endpoint.serialNumber == this.serialNumber.ToUpper()).Count();

                if (existingSerialNumber > 0)
                {
                    logger.Log(LogLevel.Error, $"Endpoint serial number {serialNumber.ToUpper()} is already taken.");
                    
                    Console.WriteLine("--------------------------");
                    Console.Write("Inform another Endpoint Serial Number: ");
                    return false;
                }
            }
            
            return true;
        }

        /// <summary>
        /// EDIT Endpoint by its Serial Number
        /// </summary>
        public List<Endpoint> EditEndpoint(ILogger logger, EndpointsList Endpoints)
        {
            var endpointToEdit = Endpoints.endpointsList.Where(endpoint => endpoint.serialNumber == serialNumber.ToUpper()).ToList();

            if (endpointToEdit.Count() > 0)
                return endpointToEdit;

            logger.Log(LogLevel.Information, $"No Endpoint with the Serial Number {serialNumber.ToUpper()} was found.");
            Console.WriteLine("--------------------------");
            Console.WriteLine("");
            return null;
        }

        /// <summary>
        /// DETELE Endpoint by its Serial Number
        /// </summary>
        public void DeleteEndpoint(ILogger logger, EndpointsList Endpoints)
        {
            var keyOption = "1";
            var endpointsToDelete = Endpoints.endpointsList.Where(endpoint => endpoint.serialNumber == serialNumber.ToUpper()).ToList();

            if (endpointsToDelete.Count() > 0)
            {
                Console.WriteLine($"Are you sure you want to DELETE the Endpoint below?");

                endpointsToDelete.First().PrintEndpointInfo();

                Console.WriteLine($"Type 1 to CONFIRM");
                Console.WriteLine($"Type 2 to CANCEL");
                Console.Write("Option: ");
                keyOption = Console.ReadLine();
                Console.WriteLine("--------------------------");

                while (!InputValidations.CheckMenuInput(1, 2, keyOption))
                {
                    Console.WriteLine("");
                    Console.WriteLine("--------------------------");
                    logger.Log(LogLevel.Error, "Please choose a valid option!");
                    Console.WriteLine($"Type 1 to CONFIRM");
                    Console.WriteLine($"Type 2 to CANCEL");
                    Console.Write("Option: ");
                    keyOption = Console.ReadLine();
                    Console.WriteLine("--------------------------");
                }

                if (keyOption == "1")
                {
                    Endpoints.endpointsList.Remove(endpointsToDelete.First());

                    logger.Log(LogLevel.Information, "Endpoint deleted successfully!");
                    Console.WriteLine("--------------------------");

                    return;
                }

                logger.Log(LogLevel.Information, "Endpoint NOT deleted!");
                Console.WriteLine("--------------------------");

                return;
            }

            logger.Log(LogLevel.Information, $"No Endpoint with the Serial Number {serialNumber.ToUpper()} was found.");
            Console.WriteLine("--------------------------");
            Console.WriteLine("");
        }
    
        public void FindEndpointBySerialNumber(ILogger logger, EndpointsList Endpoints)
        {
            var foundEndpoints = Endpoints.endpointsList.Where(endpoint => endpoint.serialNumber == serialNumber.ToUpper()).ToList();

            if (foundEndpoints.Count() > 0)
            {
                foundEndpoints.First().PrintEndpointInfo();
                
                return;
            }

            logger.Log(LogLevel.Information, $"No Endpoint with the Serial Number {serialNumber.ToUpper()} was found.");
            Console.WriteLine("--------------------------");
            Console.WriteLine("");
        }
    }
}