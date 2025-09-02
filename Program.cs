// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
//ask for input
Console.WriteLine("Enter 1 to create data file");
Console.WriteLine("Enter 2 ro parse data file");
Console.WriteLine("Enter anything else to quit");

string? resp = Console.ReadLine();

if (resp == "1")
{
    Console.WriteLine("How many weeks of data is needed?");
    //input the response (convert to int)
    int weeks = Convert.ToInt32(Console.ReadLine());
}
else if (resp == "2")
{

}
