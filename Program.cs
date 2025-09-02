// See https://aka.ms/new-console-template for more information
using System.Data;

Console.WriteLine("Hello, World!");
//ask for input
Console.WriteLine("Enter 1 to create data file");
Console.WriteLine("Enter 2 ro parse data file");
Console.WriteLine("Enter anything else to quit");

string? resp = Console.ReadLine();

if (resp == "1")
{
    //create data file
    //ask question
    Console.WriteLine("How many weeks of data is needed?");
    //input the response (convert to int)
    int weeks = Convert.ToInt32(Console.ReadLine());
    //determine start and end date
    DateTime today = DateTime.Now;
    //we want full weeks sunday-saturday
    DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
    //subtract # of weeks from endDate to get startDate
    DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
    //random number generator
    Random rnd = new();

    //loop for the desired number of weeks
    while (dataDate < dataEndDate)
    {
        //7 days in a week
        int[] hours = new int[7];
        for (int i = 0; i < hours.Length; i++)
        {
            //generate random number between 4-12 inclusive
            hours[i] = rnd.Next(4, 13);
        }
        // M/d/yyyy,#/#/#/#/#/#/#
        Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
        dataDate = dataDate.AddDays(7);
    }
}
else if (resp == "2")
{

}
