using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

namespace Gaussian_Elimination;
public partial interface IFile
{

    private static int currentTextFile_Int = 1;

    public static void File_Function()
    {        //"How Do You Want To Proceed? (use arrow keys or select on numpad)" , [["1. Enter Code Manually","1. Enter Address","Return"]]

        while(true){

            switch(Console.ReadKey().Key) //could ask twice for column (first enter row, then column; to select sth in a matrix idk)
            {

                case ConsoleKey.D1:
                {
                
                    if(WriteToFile_Function())
                    {
                        
                        GetDataCSV_Function(CurrentLocalFile_Function());

                    }
                
                }return;
                
                case ConsoleKey.D2:
                {

                    UserFileAddress_Function();

                }return;

                case ConsoleKey.D3:
                {

                    GetDataCSV_Function(CurrentLocalFile_Function());

                }return;

                case ConsoleKey.Escape | ConsoleKey.End: return;

                default:
                {
                    
                    System.Console.WriteLine("undefined action or key / something went wrong");

                }break;

            }

        }
        
    }

    public static string CurrentLocalFile_Function()
    {

        return "local"+currentTextFile_Int+".txt";

    }

    public static string CurrentCSVFile_Function()
    {

        File.Copy(CurrentLocalFile_Function(),"local"+currentTextFile_Int+".csv");

        return "local"+currentTextFile_Int+".csv";

    }

    private static void NextLocalFile_Function()
    {

        while(File.Exists(CurrentLocalFile_Function()))currentTextFile_Int++;

    }

    public static bool CheckLocalFile_Function(int localFileNumber_Int , bool changeLocalFile_Bool)
    {

        if(File.Exists("local"+localFileNumber_Int+".txt"))
        {

            if(changeLocalFile_Bool)if(File.Exists("local"+localFileNumber_Int+".txt"))currentTextFile_Int = localFileNumber_Int;;
        
            return true;
            
        }

        return false;

    }

    public static string [][] GetDataCSV_Function(string inputAddress_String)
    {

        return ReadCSV_Function(inputAddress_String);

        // return SystemReadCSV_Function(inputAddress_String);

    }

    private static void UserFileAddress_Function() //currently only for csv files
    {

        string userAddress_String = "";

        string hint_String = "Enter Your Address:";

        while(!File.Exists(userAddress_String) && !TxtRegex_Class().IsMatch(userAddress_String))
        {

            string exitCode_String = RandomNumberGenerator.GetInt32(65535).ToString();

            Console.Clear();
            
            System.Console.WriteLine(hint_String);

            hint_String = "Please Enter A Valid Address:";

            userAddress_String = IRead.KeyToLine_Function(exitCode_String);

            if(userAddress_String == exitCode_String) return;

        }
        
        NextLocalFile_Function();

        ReadCSV_Function(userAddress_String);

        try
        {

            File.Copy(userAddress_String, "local.txt");
            
        }
        catch (Exception copyToLocal_Exception)
        {

            System.Console.WriteLine(copyToLocal_Exception);
            
        }

        System.Console.WriteLine("Success");

    }

    private static bool WriteToFile_Function() //could input "int" to decide which local file to use and used repeatedly to get lots of data
    {

        string localFiles_String = CurrentLocalFile_Function();

        FileInfo[] appData_FileInfo = [];

        try
        {

            appData_FileInfo[currentTextFile_Int] = new(localFiles_String);

        }
        catch (System.Exception fileInfo_Exception)
        {
            
            System.Console.WriteLine(fileInfo_Exception);

        }

        NextLocalFile_Function();

        if(!TxtRegex_Class().IsMatch(appData_FileInfo[currentTextFile_Int].FullName))return false;

        StreamWriter storeData_StreamWriter = new("");

        if(appData_FileInfo[currentTextFile_Int].Exists)
        {

            try
            {

                appData_FileInfo[currentTextFile_Int].Delete();

            }
            catch (System.Exception deleteLocal_Exception)
            {
                
                System.Console.WriteLine(deleteLocal_Exception);
            }
            
        }

        try
        {

            appData_FileInfo[currentTextFile_Int].Create();

            storeData_StreamWriter = appData_FileInfo[currentTextFile_Int].AppendText();
            
        }
        catch (System.Exception createText_Exception)
        {

            System.Console.WriteLine(createText_Exception);
        
        }

        while(true)
        {

            string exitCode_String = RandomNumberGenerator.GetInt32(65535).ToString();

            string inputLine_String = IRead.KeyToLine_Function(exitCode_String);

            if(inputLine_String == exitCode_String)
            {

                try
                {

                    storeData_StreamWriter.Dispose();

                }
                catch (System.Exception disposeWriter_Exception)
                {
                    
                    System.Console.WriteLine(disposeWriter_Exception);
                    
                }
                
                if(appData_FileInfo[currentTextFile_Int].Exists)
                {

                    try
                    {

                        appData_FileInfo[currentTextFile_Int].Delete();

                    }
                    catch (System.Exception deleteLocal_Exception)
                    {
                        
                        System.Console.WriteLine(deleteLocal_Exception);
                    }
                    
                }
            
                return false;
                
            }

            if(inputLine_String.Contains(exitCode_String))
            {
                
                inputLine_String = inputLine_String.Replace(exitCode_String, null);

                try
                {

                    storeData_StreamWriter.WriteLine(inputLine_String);
    
                    storeData_StreamWriter.Dispose();

                }
                catch (System.Exception writeFile_Exception)
                {
                    
                    System.Console.WriteLine(writeFile_Exception);
                }

                return true;
            
            }

            try
            {

                storeData_StreamWriter.WriteLine(inputLine_String);

            }
            catch (System.Exception writeFile_Exception)
            {
                
                System.Console.WriteLine(writeFile_Exception);

            }

        }

    }    

    private static string[][] ReadCSV_Function(string inputAddress_String)
    {

        string[][] data_StringJArray = [];        

        int rowNumber_Int = 1;

        string? line_String = "";

        StreamReader readLocalText_StreamReader = new("");

        try
        {

            File.Copy(inputAddress_String, CurrentLocalFile_Function());

            readLocalText_StreamReader = new(inputAddress_String);        

            line_String = readLocalText_StreamReader.ReadLine();

        
        }catch (System.Exception readLine_Exception)
        {
            
            System.Console.WriteLine(readLine_Exception);

        }

        while(!string.IsNullOrEmpty(line_String))
        {

            string[][] tempData_StringJArray = new string[rowNumber_Int][];

            MatchCollection elements_MatchCollection = ReadCSVRegex_Class().Matches(line_String);

            {

                int numberOfElements_Int = 0;

                foreach (Match matched_Match in elements_MatchCollection)
                {

                    numberOfElements_Int++;
                    
                }
                
                tempData_StringJArray[rowNumber_Int-1] = new string[numberOfElements_Int];

                numberOfElements_Int = 0;

                foreach (Match element_Match in elements_MatchCollection)
                {

                    string element_String = element_Match.Value.Replace(",",null).Trim();

                    if(string.IsNullOrWhiteSpace(element_String)) element_String = "_";

                    tempData_StringJArray[rowNumber_Int-1][numberOfElements_Int] = element_Match.Value;

                    numberOfElements_Int++;
                    
                }
            
            }

            for(int count_int = 0 ; count_int < rowNumber_Int - 2 ; count_int++)
            {

                tempData_StringJArray[count_int] = data_StringJArray[count_int];

            }

            rowNumber_Int++;

            data_StringJArray = tempData_StringJArray;

            try
            {

                line_String = readLocalText_StreamReader.ReadLine();

            }
            catch (System.Exception readLine_Exception)
            {
                
                System.Console.WriteLine(readLine_Exception);
                
            }

        }

        try
        {

            readLocalText_StreamReader.Dispose();

        }
        catch (System.Exception disposeWriter_Exception)
        {
            
            System.Console.WriteLine(disposeWriter_Exception);

        }

        return data_StringJArray;

    }

    private static string[][] SystemReadCSV_Function(string inputAddress_String)
    {

        TextFieldParser csvRead_TextFieldParser = new(new StreamReader(""));

        int totalRow_Int = 0;

        string[][] readCSV_StringArray2D = [];

        try
        {

            File.Copy(inputAddress_String, CurrentLocalFile_Function());

            csvRead_TextFieldParser = new(CurrentLocalFile_Function());

        
        }catch (System.Exception csvRead_Exception)
        {
            
            System.Console.WriteLine(csvRead_Exception);

        }

        while((readCSV_StringArray2D[totalRow_Int] = csvRead_TextFieldParser.ReadFields())!=null)
        {

            totalRow_Int++;
            
        }

        if(readCSV_StringArray2D==null)
        {

            return [[""]];

        }

        readCSV_StringArray2D??=[[""]];

        return readCSV_StringArray2D;

    }



    [GeneratedRegex(@".*\.txt$")]
    
    private static partial Regex TxtRegex_Class();

    [GeneratedRegex(@"(?<Element>,?[^,]+|,?\s*)|(?<NA>.*)?")]

    private static partial Regex ReadCSVRegex_Class();

}