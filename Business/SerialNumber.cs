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
        /// <param name="existingSNValidation"></param>
        /// <returns></returns>
        public bool ValidatingEndpointSerialNumber(ILogger logger, bool isNullValidation = true, bool existingSNValidation = true)
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
            
            return true;
        }

    }
}