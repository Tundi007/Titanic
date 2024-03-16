using System.Security.Cryptography;
using Microsoft.VisualBasic.FileIO;

namespace TitanicNameSpace;

public partial class Passengers()
{

    private static readonly string[][] readCSV_StringArray2D = [];
    
    public static string[][] GetData_Function()
    {

        return readCSV_StringArray2D;

    }

    public static void Initialize_Function()
    {

        SetData_Function();

    }

    private static void SetData_Function()
    {

        string[]? readCSV_StringArray;

        TextFieldParser csvRead_TextFieldParser = new(new StreamReader(""));

        int totalRow_Int = 0;
        
        try
        {

            File.Copy("train.csv", "local.csv");

            csvRead_TextFieldParser = new("local.csv");

        
        }catch (System.Exception csvRead_Exception)
        {
            
            System.Console.WriteLine(csvRead_Exception);

        }

        _ = csvRead_TextFieldParser.ReadFields();

        while((readCSV_StringArray = csvRead_TextFieldParser.ReadFields())!=null)
        {

            readCSV_StringArray2D[totalRow_Int] = readCSV_StringArray;

            totalRow_Int++;
            
        }

        try
        {

            csvRead_TextFieldParser.Dispose();

            File.Delete("local.csv");

        }
        catch (System.Exception deleteLocalCsv_Exception)
        {
            
            System.Console.WriteLine(deleteLocalCsv_Exception);

        }        

    }

}