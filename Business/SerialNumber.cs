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
        /// <param name="endpointSerialNumber"></param>
        /// <param name="logger"></param>
        /// <param name="isNullValidation"></param>
        /// <param name="existingSerialNumberValidation"></param>
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

    }
}