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

//memoryManager.Save(details);