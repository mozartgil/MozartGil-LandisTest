using MeterModelBusiness;
using SwitchStateBusiness;
using EndpointBusiness;
using EndpointsListBusiness;
using IloogerBusiness;
using SerialNumberBusiness;

namespace Tester;

[TestClass]
public class UnitTest1
{
    /// <summary>
    /// Testing Serial Number Duplicity
    /// </summary>
    [TestMethod]
    public void TestValidatingEndpointSerialNumberDuplicity()
    {
        List<Endpoint> listEndpoints = new List<Endpoint>();
        EndpointsList endpoints = new EndpointsList(listEndpoints);
        ConsoleLogger logger = new ConsoleLogger();
        
        string endpointSerialNumber = "SN0001";
        MeterModelId meterModelId = MeterModelId.NSX1P3W;
        int meterNumber = 5;
        string meterFirmwareVersion = "FRW-1.1";
        SwitchState switchState = SwitchState.Armed;

        var endpoint = new Endpoint(
            endpointSerialNumber,
            meterModelId,
            meterNumber,
            meterFirmwareVersion,
            switchState
        );

        endpoints.AddEndpointToList(endpoint, logger);

        //Test Fail
        endpointSerialNumber = "SN0001";

        //Test Pass
        endpointSerialNumber = "SN0002";
        
        SerialNumber serialNumber = new SerialNumber(endpointSerialNumber);

        if (serialNumber.ValidatingEndpointSerialNumber(logger, endpoints))
            Assert.IsTrue(true);
        else
            Assert.IsTrue(false);
    }

    /// <summary>
    /// Testing Serial Number Emptiness
    /// </summary>
    [TestMethod]
    public void TestValidatingEndpointSerialNumberEmptiness()
    {
        List<Endpoint> listEndpoints = new List<Endpoint>();
        EndpointsList endpoints = new EndpointsList(listEndpoints);
        ConsoleLogger logger = new ConsoleLogger();
        
        //Test Fail
        string endpointSerialNumber = "";

        //Test Pass
        endpointSerialNumber = "SN001";

        SerialNumber serialNumber = new SerialNumber(endpointSerialNumber);

        if (serialNumber.ValidatingEndpointSerialNumber(logger, endpoints, true, false))
            Assert.IsTrue(true);
        else
            Assert.IsTrue(false);
    }

    /// <summary>
    /// Test adding a Endpoint
    /// </summary>
    [TestMethod]
    public void TestAddEndpointToList()
    {
        List<Endpoint> listEndpoints = new List<Endpoint>();
        EndpointsList endpoints = new EndpointsList(listEndpoints);
        ConsoleLogger logger = new ConsoleLogger();

        string endpointSerialNumber = "SN00002";
        MeterModelId meterModelId = MeterModelId.NSX1P3W;
        int meterNumber = 5;
        string meterFirmwareVersion = "FRW-1.1";
        SwitchState switchState = SwitchState.Armed;

        var endpoint = new Endpoint(
            endpointSerialNumber,
            meterModelId,
            meterNumber,
            meterFirmwareVersion,
            switchState
        );

        if (endpoints.AddEndpointToList(endpoint, logger))
            Assert.IsTrue(true);
        else
            Assert.IsTrue(false);
    }

    /// <summary>
    /// Test editing an Endpoint
    /// </summary>
    [TestMethod]
    public void TestEditEndpoint()
    {
        List<Endpoint> listEndpoints = new List<Endpoint>();
        EndpointsList endpoints = new EndpointsList(listEndpoints);
        ConsoleLogger logger = new ConsoleLogger();

        string endpointSerialNumber = "SN0001";
        MeterModelId meterModelId = MeterModelId.NSX1P3W;
        int meterNumber = 5;
        string meterFirmwareVersion = "FRW-1.1";
        SwitchState switchState = SwitchState.Armed;

        var endpoint = new Endpoint(
            endpointSerialNumber,
            meterModelId,
            meterNumber,
            meterFirmwareVersion,
            switchState
        );

        endpoints.AddEndpointToList(endpoint, logger);

        //Test Fail
        // endpointSerialNumber = "SN002";

        SerialNumber serialNumber = new SerialNumber(endpointSerialNumber);

        var returnedList = serialNumber.EditEndpoint(logger, endpoints);

        if (returnedList != null)
            Assert.IsTrue(true);
        else
            Assert.IsTrue(false);
    }

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
}