namespace Gaussian_Elimination;

public interface IData
{

    private static List<int> relationSetsPrivate_IntList = [];
    
    private static List<string[][]> dataPrivate_StringList2D
    {
     
        set
        {

            dataPrivate_StringList2D = value;

        }
     
        get
        {

            return dataPrivate_StringList2D;

        }
        
    }

    private static List<string[][]> publicData_StringList2D
    {
        
        get
        {

            return dataPrivate_StringList2D;

        }
        
    }

    private static int ShowDataInfo_Function()
    {

        while(true){

            string[][] a = dataPrivate_StringList2D[0];

            string[][] dataLinks_String = [new string[relationSetsPrivate_IntList.Count]];
        
            for (int index_Int=0;index_Int<relationSetsPrivate_IntList.Count;index_Int++)
            {

                dataLinks_String[0][index_Int] += index_Int+": "+relationSetsPrivate_IntList[index_Int]+"\n";

            }

            (int dataIndex_Int,_,_) = IRead.KeyMenu_Function("Choose A Data ID:",dataLinks_String);

            foreach(string[] selectedData_StringArray2D in publicData_StringList2D[0])
            {

                System.Console.WriteLine(selectedData_StringArray2D);

            }

            return dataIndex_Int;
            
        }

    }

    public static string[][] GetDataString_Function(int matrixNumber_Int)
    {

        System.Console.WriteLine("Choose A Data ID:");

        ShowDataInfo_Function();


        if(!relationSetsPrivate_IntList.Contains(matrixNumber_Int)) return [["-1"]];

        return publicData_StringList2D[relationSetsPrivate_IntList.IndexOf(matrixNumber_Int)];

    }

    public static int[][] GetDataInt_Function(int matrixNumber_Int)
    {

        if(!relationSetsPrivate_IntList.Contains(matrixNumber_Int)) return [[-1]];

        // return publicData_StringList2D[relationSetsPrivate_IntList.IndexOf(matrixNumber_Int)];

        return[[]];
        
    }

    public static int MakeYourOwnData(bool symmetricRule_Bool)
    {

        bool accepted_Bool = false;

        int rowNumber_Int = 0;

        int columnNumber_Int = 0;

        int dataID_Int = 0;

        int dataIndex_Int = 0;

        string hint_String = "Use Arrow Keys: Up/Down For Number Of Rows | Left/Right For Number Of Columns";

        System.Console.WriteLine("Press Enter After Desired Dimensions:");

        while(!accepted_Bool)
        {

            Console.Clear();

            if(symmetricRule_Bool && rowNumber_Int != columnNumber_Int)
            {

                System.Console.WriteLine("Due To Issues Rows And Columns Are Not Equal, Seting Column Number To Row Number...");

                columnNumber_Int = rowNumber_Int;

                Thread.Sleep(500);
                
            }

            System.Console.WriteLine(rowNumber_Int+" "+columnNumber_Int+"\n"+hint_String);

            switch(Console.ReadKey().Key)
            {

                case ConsoleKey.UpArrow:
                {

                    if(symmetricRule_Bool && columnNumber_Int>1)columnNumber_Int--;

                    

                    if(rowNumber_Int>1)rowNumber_Int--;

                }break;

                case ConsoleKey.DownArrow:
                {

                    if(symmetricRule_Bool)columnNumber_Int++;

                    rowNumber_Int++;

                }break;

                case ConsoleKey.RightArrow:
                {

                    if(symmetricRule_Bool)rowNumber_Int++;

                    columnNumber_Int++;

                }break;

                case ConsoleKey.LeftArrow:
                {

                    if(symmetricRule_Bool && rowNumber_Int>1)rowNumber_Int--;

                    if(columnNumber_Int>1)columnNumber_Int--;

                }break;

                case ConsoleKey.End: return -1;

                case ConsoleKey.Enter:
                {

                    accepted_Bool = true;

                }break;

                default:break;

            }

        }        

        while(relationSetsPrivate_IntList.Contains(dataID_Int))dataID_Int++;

        relationSetsPrivate_IntList.Add(dataID_Int);

        dataIndex_Int = relationSetsPrivate_IntList.IndexOf(dataID_Int);

        dataPrivate_StringList2D.Add(new string[rowNumber_Int][]);

        for (int row_Int = 0; row_Int < rowNumber_Int; row_Int++)
        {

            dataPrivate_StringList2D[dataIndex_Int][row_Int] = new string[columnNumber_Int];

            for(int column_Int = 0 ; column_Int < columnNumber_Int ; column_Int++)
            {

                System.Console.WriteLine($"Enter Desired Value For The Element\nAddress (Zero-Based) Of Current Element: [Row: {row_Int}, Column:{column_Int}],");

                string? userElement_String = Console.ReadLine();

                dataPrivate_StringList2D[dataIndex_Int][row_Int][column_Int] = (userElement_String??="_");

            }
            
        }

        System.Console.WriteLine($"Done! The ID Of The Current Data Is = {dataID_Int}");

        return dataID_Int;

    }

    public static List<string[][]> GetAllDataSets_Function()
    {

        return publicData_StringList2D;

    }

    public static void InitializeData_Function(int thisFIle_Int)
    {

        if(relationSetsPrivate_IntList.Contains(thisFIle_Int))
        {

            System.Console.WriteLine("Data Already Exists!");
            
            return;
            
        }

        if(!SetDataCSVPrivate_Function(thisFIle_Int))
        {

            System.Console.WriteLine("File Doesn't Exist!");

            return;

        }

    }

    private static bool SetDataCSVPrivate_Function(int thisFIle_Int)
    {

        if(IFile.CheckLocalFile_Function(thisFIle_Int,true))return false;

        relationSetsPrivate_IntList.Add(thisFIle_Int);

        dataPrivate_StringList2D[relationSetsPrivate_IntList.IndexOf(thisFIle_Int)] = IFile.GetDataCSV_Function(IFile.CurrentLocalFile_Function());
        
        return true;

    }

    public static void RefreshCSVData_Function(int thisFIle_Int)
    {

        if(!IFile.CheckLocalFile_Function(thisFIle_Int,true))
        {

            System.Console.WriteLine("File Doesn't Exist!");
            
            return;
            
        }

        if(RefreshDataCSVPrivate_Function(thisFIle_Int))
        {
            
            System.Console.WriteLine("Data Refreshed!");

            return;
            
        }

        switch(Console.ReadKey().Key)
        {

            case ConsoleKey.Y:
            {

                InitializeData_Function(thisFIle_Int);

            }return;

            default:break;
            
        }
        
        System.Console.WriteLine("Created New Data Due To Lack Of Refrence To The Destination File");

    }
    
    private static bool RefreshDataCSVPrivate_Function(int thisFIle_Int)
    {

        if(!relationSetsPrivate_IntList.Contains(thisFIle_Int))return false;

        dataPrivate_StringList2D[relationSetsPrivate_IntList.IndexOf(thisFIle_Int)] = IFile.GetDataCSV_Function(IFile.CurrentLocalFile_Function());

        return true;
        
    }

    public static void DeleteData_Function(int thisFIle_Int)
    {

        if(DerefrenceCSVPrivate_Function(thisFIle_Int))
        {

            System.Console.WriteLine("Data Has Been Removed");

            return;

        }

        System.Console.WriteLine("Data Not Found");

    }

    private static bool DerefrenceCSVPrivate_Function(int thisFIle_Int)
    {

        if(!relationSetsPrivate_IntList.Contains(thisFIle_Int)) return false;

        dataPrivate_StringList2D.RemoveAt(relationSetsPrivate_IntList.IndexOf(thisFIle_Int));

        relationSetsPrivate_IntList.Remove(thisFIle_Int);

        return true;

    }

}