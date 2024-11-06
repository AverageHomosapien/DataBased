using Databased;

MemoryManager memoryManager = new MemoryManager();

Console.WriteLine("Enter your house details below:");

Console.WriteLine("Please enter your house address:");
string address = Console.ReadLine();

Console.WriteLine("Please enter your number of bedrooms:");
int bedrooms = int.Parse(Console.ReadLine());

Console.WriteLine("Please enter your number of bathrooms:");
int bathrooms = int.Parse(Console.ReadLine());

HouseDetails details = new HouseDetails()
{
    Address = address,
    Bathrooms = bathrooms,
    Bedrooms = bedrooms,
};

memoryManager.Save(details);

byte[] retrievedObject = memoryManager.Get();

HouseDetails t = memoryManager.ParseClass<HouseDetails>();

Console.WriteLine("Address: " + t.Address);
Console.WriteLine("Bathrooms: " + t.Bathrooms);
Console.WriteLine("Bedrooms: " + t.Bedrooms);

//memoryManager.Save(details);