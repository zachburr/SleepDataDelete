// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");
//ask for input
Console.WriteLine("Enter 1 to create data file");
Console.WriteLine("Enter 2 to parse data file");
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
    //create file
    StreamWriter sw = new("data.txt");

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
        sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
        dataDate = dataDate.AddDays(7);
    }
    sw.Close();
}
else if (resp == "2")
{
    string? file = "data.txt";
    if (File.Exists(file))
    {
        StreamReader sr = new(file);
        while (!sr.EndOfStream)
        {
            string? line = sr.ReadLine();
            if (!string.IsNullOrEmpty(line))//checks to make sure the file isant empty
            {
                string[] arr = line.Split(',');//creates an array splitting everything from the , back
                DateTime date = DateTime.Parse(arr[0]); //assigns the date to the array
                Console.WriteLine("{0,3}", $"Week of {date:MMM, dd, yyyy}");//reformats the date


                string[] sleepTimes = arr[1].Split('|');//splits the second array
                string[] days = { "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa" };//creates and array of abbreviated days

                for (int i = 0; i < days.Length; i++)//loop through days array
                {
                    Console.Write("{0,3}", days[i]);//formats the days
                }
                Console.WriteLine();//new line

                for (int i = 0; i < days.Length; i++)//loop through days array just adds -- this time
                {
                    Console.Write("{0,3}", "--");//formats --
                }
                Console.WriteLine();//new line

                for (int i = 0; i < sleepTimes.Length; i++) //loops through sleepTimes array
                {
                    Console.Write("{0,3}", sleepTimes[i]);//formats sleep times
                }
                Console.WriteLine();//new line
                Console.WriteLine();
                




            }


        }
        sr.Close();
    }
}
