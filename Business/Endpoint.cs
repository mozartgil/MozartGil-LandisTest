namespace Business
{
    public class Endpoint : SerialNumber
    {
        public MeterModelId meterModelId { get; set; }
        public int meterNumber { get; set; }
        public string? meterFirmwareVersion { get; set; }
        public SwitchState switchState { get; set; }

        public Endpoint(string? endpointSerialNumber, MeterModelId meterModelId, int meterNumber, string? meterFirmwareVersion, SwitchState switchState) : base(endpointSerialNumber)
        {
            this.meterModelId = meterModelId;
            this.meterNumber = meterNumber;
            this.meterFirmwareVersion = meterFirmwareVersion.ToUpper();
            this.switchState = switchState;
        }

        public void PrintEndpointInfo()
        {
            Console.WriteLine($"Endpoint SN: {base.serialNumber}");
            Console.WriteLine($"Meter Model ID: {meterModelId}");
            Console.WriteLine($"Meter Number: {meterNumber}");
            Console.WriteLine($"Meter Firmware Version: {meterFirmwareVersion}");
            Console.WriteLine($"Switch State: {switchState}");
            Console.WriteLine("--------------------------");
            Console.WriteLine("");
        }
    }
}