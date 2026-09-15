//namespace OOPASS_01
//{
//    //    //Q1
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



//    //Q2
//    public struct Shipment
//    {
//        private string _trackingCode;
//        private string _description;
//        private double _weight;
//        private decimal _deliveryFee;

//        public string TrackingCode
//        {
//            get
//            {
//                return _trackingCode;
//            }
//        }

//        public string Description
//        {
//            get
//            {
//                return _description;
//            }
//            set
//            {
//                if (!string.IsNullOrWhiteSpace(value))
//                {
//                    _description = value;
//                }
//            }
//        }

//        public double Weight
//        {
//            get
//            {
//                return _weight;
//            }
//            set
//            {
//                if (value > 0)
//                {
//                    _weight = value;
//                }
//            }
//        }

//        public decimal DeliveryFee
//        {
//            get
//            {
//                return _deliveryFee;
//            }
//            private set
//            {
//                if (value > 0)
//                {
//                    _deliveryFee = value;
//                }
//            }
//        }

//        public DeliveryAddress Destination { get; set; }

//        public decimal EstimatedCost
//        {
//            get
//            {
//                return DeliveryFee + ((decimal)Weight * 5);
//            }
//        }

//        public Shipment(string trackingCode)
//        {
//            _trackingCode = trackingCode;
//            _description = "Unknown";
//            _weight = 1;
//            _deliveryFee = 50;
//            Destination = new DeliveryAddress("Unknown", "Unknown", 0);
//        }

//        public Shipment(
//            string trackingCode,
//            string description,
//            double weight,
//            decimal deliveryFee,
//            DeliveryAddress destination)
//        {
//            _trackingCode =
//                string.IsNullOrWhiteSpace(trackingCode)
//                ? "Unknown"
//                : trackingCode;

//            _description =
//                string.IsNullOrWhiteSpace(description)
//                ? "Unknown"
//                : description;

//            _weight =
//                weight > 0
//                ? weight
//                : 1;

//            _deliveryFee =
//                deliveryFee > 0
//                ? deliveryFee
//                : 50;

//            Destination = destination;
//        }



//        //Q3

//        public void UpdateDeliveryFee(decimal newFee)
//        {
//            if (newFee > 0)
//            {
//                DeliveryFee = newFee;
//            }
//        }

//        public void PrintShipment()
//        {
//            Console.WriteLine($"Tracking Code: {TrackingCode}");
//            Console.WriteLine($"Description: {Description}");
//            Console.WriteLine($"Weight: {Weight} KG");
//            Console.WriteLine($"Delivery Fee: {DeliveryFee} EGP");
//            Console.WriteLine($"Destination: {Destination.GetFullAddress()}");
//            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
//        }
//    }




//    // Q5

//    public struct DeliveryCenter
//    {
//        private Shipment[] _shipments;

//        public DeliveryCenter(int capacity)
//        {
//            _shipments = new Shipment[capacity];
//        }

//        // Integer Indexer
//        public Shipment this[int index]
//        {
//            get
//            {
//                if (index >= 0 && index < _shipments.Length)
//                {
//                    return _shipments[index];
//                }

//                return default;
//            }

//            set
//            {
//                if (index >= 0 && index < _shipments.Length)
//                {
//                    _shipments[index] = value;
//                }
//            }
//        }

//        // String Indexer
//        public Shipment this[string trackingCode]
//        {
//            get
//            {
//                for (int i = 0; i < _shipments.Length; i++)
//                {
//                    if (_shipments[i].TrackingCode == trackingCode)
//                    {
//                        return _shipments[i];
//                    }
//                }

//                return default;
//            }
//        }

//        public bool AddShipment(Shipment shipment)
//        {
//            for (int i = 0; i < _shipments.Length; i++)
//            {
//                if (_shipments[i].TrackingCode == null)
//                {
//                    _shipments[i] = shipment;
//                    return true;
//                }
//            }

//            return false;
//        }
//    }











//    internal class Program
//    {
//        static void Main(string[] args)
//        {



//            // Q6

//            DeliveryCenter center = new DeliveryCenter(10);

//            for (int i = 1; i <= 3; i++)
//            {
//                Console.WriteLine($"Enter Shipment {i} Data");

//                Console.Write("Tracking Code: ");
//                string trackingCode = Console.ReadLine();

//                Console.Write("Description: ");
//                string description = Console.ReadLine();

//                Console.Write("Weight: ");
//                double weight = double.Parse(Console.ReadLine());

//                Console.Write("Delivery Fee: ");
//                decimal deliveryFee = decimal.Parse(Console.ReadLine());

//                Console.Write("City: ");
//                string city = Console.ReadLine();

//                Console.Write("Street: ");
//                string street = Console.ReadLine();

//                Console.Write("Building Number: ");
//                int buildingNumber = int.Parse(Console.ReadLine());

//                DeliveryAddress address =
//                    new DeliveryAddress(city, street, buildingNumber);

//                Shipment shipment =
//                    new Shipment(
//                        trackingCode,
//                        description,
//                        weight,
//                        deliveryFee,
//                        address);

//                if (center.AddShipment(shipment))
//                {
//                    Console.WriteLine("Shipment added successfully.");
//                }
//                else
//                {
//                    Console.WriteLine("Delivery center is full.");
//                }

//                Console.WriteLine();
//            }


//            // Print the three shipments
//            Console.WriteLine("--- All Shipments ---");

//            for (int i = 0; i < 3; i++)
//            {
//                center[i].PrintShipment();
//            }


//            // Search by tracking code
//            Console.Write("Enter a tracking code to search: ");
//            string searchCode = Console.ReadLine();

//            Shipment foundShipment = center[searchCode];

//            if (foundShipment.TrackingCode != null)
//            {
//                Console.WriteLine(
//                    $"Shipment found: {foundShipment.TrackingCode} - {foundShipment.Description}");
//            }
//            else
//            {
//                Console.WriteLine("Shipment not found.");
//            }


//            // Struct copy test
//            Console.WriteLine();
//            Console.WriteLine("--- Struct Copy Test ---");

//            DeliveryAddress original =
//                new DeliveryAddress("Cairo", "Tahrir Street", 15);

//            DeliveryAddress copied = original;

//            copied.BuildingNumber = 20;
//            copied.Street = "Makram Ebeid Street";

//            Console.WriteLine(
//                $"Original Address: {original.GetFullAddress()}");

//            Console.WriteLine(
//                $"Copied Address: {copied.GetFullAddress()}");
//        }
//    }
//}




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