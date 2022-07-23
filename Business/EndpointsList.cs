namespace Business
{
    public class EndpointsList
    {
        public List<Endpoint> endpointsList;

        public EndpointsList(List<Endpoint> endpointsList) 
        {
            this.endpointsList = endpointsList;
        }

        public void AddEndpointToList(Endpoint endpoint) => endpointsList.Add(endpoint);

        public bool HasAnyEndpoint(ILogger logger)
        {
            if (endpointsList.Count <= 0)
            {
                logger.Log(LogLevel.Error, $"We don't have any Endpoint registered in our database.");
                Console.WriteLine("");
                return false;
            }

            return true;
        }

        public void ListiAllEndpoints()
        {
            Console.WriteLine("LIST of Endpoints");
            Console.WriteLine("------------------");

            foreach (var endpoint in endpointsList)
            {
                endpoint.PrintEndpointInfo();
            }

            Console.WriteLine($"Total of {endpointsList.Count} Endpoints");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("");
        }
    }
}