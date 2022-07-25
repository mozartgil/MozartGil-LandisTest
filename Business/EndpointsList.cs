using EndpointBusiness;
using IloogerBusiness;

namespace EndpointsListBusiness;

public class EndpointsList
{
    public List<Endpoint> endpointsList;

    public EndpointsList(List<Endpoint> endpointsList) 
    {
        this.endpointsList = endpointsList;
    }

    public bool AddEndpointToList(Endpoint endpoint, ILogger logger)
    {
        try
        {
            endpointsList.Add(endpoint);

            logger.Log(LogLevel.Information, "Endpoint ADDED successfully!");
            // System.Console.WriteLine($"************************************************************");
            // System.Console.WriteLine($"Endpoints list has {Endpoints.endpointsList.Count} endpoints");
            // System.Console.WriteLine($"************************************************************");
            // System.Console.WriteLine($"");
            return true;
        }
        catch (System.Exception ex)
        {
            logger.Log(LogLevel.Error, ex.Message);
            return false;
        }
        
    }

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