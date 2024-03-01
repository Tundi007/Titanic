using System.Text.RegularExpressions;

namespace TitanicNameSpace;

public partial class Passengers()
{
    
    public static bool[] passengerAlive_BoolArray;

    private static string[] passengerName_StringArray;

    private static string[] passengerGender_String;

    private static int[] passengerAge_String;

    private static int[] passengerFamilyNumber_Int;

    private static int[] passengerSiblingNumber_Int;

    private static int currentPassenger_Int = 0;

    public static void Initialize_Function()
    {

        StreamReader readData_StreamReader = new StreamReader("train.txt");

        string? data_String;

        

        while((data_String = readData_StreamReader.ReadLine()) != null)
        {

            if(IsAlive_GeneratedRegex().Match(data_String).Value == "0")
            {

                passengerAlive_BoolArray[currentPassenger_Int] = false;

            }else
            {

                passengerAlive_BoolArray[currentPassenger_Int] = true;
                
            }

        }

    }

    [GeneratedRegex(@".*\,")]
    private static partial Regex IsAlive_GeneratedRegex();

    [GeneratedRegex(@"[^,]*")]
    private static partial Regex Data_GeneratedRegex();

}