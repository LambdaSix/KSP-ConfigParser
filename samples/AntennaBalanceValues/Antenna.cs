using FileHelpers;

namespace AntennaBalanceValues
{

/*
    PART
	{
		name = bluedog_agenaProbeCore
		module = Part
		author = CobaltWolf
		entryCost = 2800
		cost = 1000
		category = Pods
		subcategory = 0
		title = Belle TRU Telemetry Response Unit
		manufacturer = Bluedog Design Bureau
		mass = 0.1

		MODULE
		{
			name = ModuleDataTransmitter
			antennaType = INTERNAL
			packetInterval = 1.0
			packetSize = 2
			packetResourceCost = 12.0
			requiredResource = ElectricCharge
			antennaPower = 5000
			optimumRange = 2500
			packetFloor = .1
			packetCeiling = 5
		}
    }
 */

    [DelimitedRecord(",")]
    public class Antenna
    {
        public string Folder;
        public string FileName;
        public string Name;
		public string Title;
        public string Author;
        public string Manufacturer;
		public string Category;
		public string EntryCost;
		public string PartCost;
		public string Mass;
		
		public string AntennaType;
		public string PacketInterval;
		public string PacketSize;
		public string PacketResourceCost;
		public string AntennaPower;
		public string OptimumRange;
		public string PacketeFloor;
		public string PacketCeiling;
    }
}