string? choice;
string file = "characterData.txt";

do
{
    // ask user a question
    Console.WriteLine("1) View character data.");
    Console.WriteLine("2) Create character data file.");
    Console.WriteLine("Enter any other key to exit.");
    // input response
    choice = Console.ReadLine();

    if (choice == "1")
    {
        // read data from file
        if (File.Exists(file))
        {
            // read data from file
            StreamReader sr = new(file);
            while (!sr.EndOfStream)
            {
                string? line = sr.ReadLine();
                // convert string to array
                string[] arr = String.IsNullOrEmpty(line) ? [] : line.Split('|');
                
                // display array data
                Console.WriteLine("\nId: {0} \nName: {1} \nRelationship to Mario: {2}\n", arr[0], arr[1], arr[2]); 
            }
            sr.Close();
        }
        else
        {
            Console.WriteLine("File does not exist");
        }
    }
    else if (choice == "2")
    {
        // create file from data
        StreamWriter sw = new(file, true);
        int idNumber = 0;
        for (int i = 0; i < 3; i++)
        {
            
            // ask a question
            Console.WriteLine("Enter a character (Y/N)?");
            // input the response
            string? resp = Console.ReadLine()?.ToUpper();
            // if the response is anything other than "Y", stop asking
            if (resp != "Y") { break; }
            // prompt for character name
            Console.WriteLine("Which character are you adding?");
            // save the character name
            string? name = Console.ReadLine();
            // prompt for relation to Mario
            Console.WriteLine("What is " + name + "'s relation to Mario?");
            // save the relation response
            string? relation = Console.ReadLine();

            ++idNumber;

            sw.WriteLine("{0}|{1}|{2}", idNumber, name, relation);
        }
        sw.Close();
    }
} while (choice == "1" || choice == "2");


