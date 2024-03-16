using Microsoft.VisualBasic.FileIO;

namespace TitanicNameSpace;

public partial class Passengers()
{

    private static readonly string[][] readCSV_StringArray2D = new string[891][];
    
    public static string[][] GetData_Function()
    {

        SetData_Function();

        return readCSV_StringArray2D;

    }

    private static void SetData_Function()
    {

        string[]? readCSV_StringArray;

        TextFieldParser csvRead_TextFieldParser;

        int totalRow_Int = 0;

        try
        {

            if(File.Exists("local.csv"))File.Delete("local.csv");

            File.Copy("train.csv", "local.csv");

            csvRead_TextFieldParser = new("local.csv")
            {

                Delimiters = [","]

            };

            _ = csvRead_TextFieldParser.ReadFields();

            while((readCSV_StringArray = csvRead_TextFieldParser.ReadFields())!=null)
            {

                readCSV_StringArray2D[totalRow_Int] = new string[readCSV_StringArray.Length];

                readCSV_StringArray2D[totalRow_Int] = readCSV_StringArray;

                totalRow_Int++;
                
            }

            csvRead_TextFieldParser.Dispose();

        
        }catch (System.Exception csvRead_Exception)
        {
            
            System.Console.WriteLine(csvRead_Exception);

        } 

        File.Delete("local.csv");

    }

}