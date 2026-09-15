//namespace OOPASS_01
//{
//    //Q1
//    public struct DeliveryAddress
//    {
//        public string City;
//        public string Street;
//        public int BuildingNumber;

//        public DeliveryAddress(string city, string street, int buildingNumber)
//        {
//            City = city;
//            Street = street;
//            BuildingNumber = buildingNumber;
//        }

//        public string GetFullAddress()
//        {
//            return $"{BuildingNumber} {Street}, {City}";
//        }
//    }

//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            DeliveryAddress original =
//                new DeliveryAddress("Cairo", "Tahrir Street", 15);

//            DeliveryAddress copied = original;

//            copied.BuildingNumber = 20;
//            copied.Street = "Makram Ebeid Street";

//            Console.WriteLine($"Original Address: {original.GetFullAddress()}");
//            Console.WriteLine($"Copied Address: {copied.GetFullAddress()}");
//        }
//    }
//}