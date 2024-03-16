namespace TitanicNameSpace;

public class Proccess
{

    private static string[][] data_StringArray2D = [];

    public static void Initialize_Function()
    {

        data_StringArray2D = Passengers.GetData_Function();

    }

    public static void Question_Function(int question_Int)
    {

        System.Console.WriteLine($"Answer For: {question_Int}");

        switch (question_Int)
        {

            case 1: Answer1(); break;

            case 2: Answer2(); break;

            case 3: Answer3(); break;

            case 4: Answer4(); break;

            case 5: Answer5(); break;

            case 6: Answer6(); break;

            case 7: Answer7(); break;

            case 8: Answer8(); break;

            case 9: Answer9(); break;

            default: System.Console.WriteLine("False Input"); break;

        }

    }

    private static void Answer1()//possibility of finding a man in survivors
    {

        float survivors_Int = 0;

        float menInSurvivors_Int = 0;
        
        for(int row_Int = 0; row_Int < data_StringArray2D.Length; row_Int++)
        {

            if(data_StringArray2D[row_Int][0].Trim() == "1")
            {

                survivors_Int++;

                if(data_StringArray2D[row_Int][3].Trim()=="male")
                {

                    menInSurvivors_Int++;

                }

            }
            
        }

        System.Console.WriteLine($"Chance Of Finiding A Man In Survivors: {menInSurvivors_Int/survivors_Int}");

    }

    private static void Answer2()//possibility of finding a kid (age<12) in survivors
    {

        float survivors_Int = 0;

        float kidsInSurvivors_Int = 0;
        
        for (int row_Int = 0; row_Int < data_StringArray2D.Length; row_Int++)
        {

            if(data_StringArray2D[row_Int][0].Trim() == "1")
            {

                survivors_Int++;

                if(int.TryParse(data_StringArray2D[row_Int][4].Trim(),out int age_Int) & age_Int<12)
                {

                    kidsInSurvivors_Int++;

                }

            }
            
        }

        System.Console.WriteLine($"Chance Of Finiding A Kid In Survivors: {kidsInSurvivors_Int/survivors_Int}");

    }

    private static void Answer3()//possibility of finding lone passenger in survivors
    {

        float survivors_Int = 0;

        float lonerInSurvivors_Int = 0;

        for (int row_Int = 0; row_Int < data_StringArray2D.Length; row_Int++)
        {

            if(data_StringArray2D[row_Int][0].Trim() == "1")
            {

                survivors_Int++;

                if(int.TryParse(data_StringArray2D[row_Int][5].Trim(),out int sibling_Int) & sibling_Int == 0 &
                    int.TryParse(data_StringArray2D[row_Int][6].Trim(),out int parch_Int) & parch_Int == 0)
                        lonerInSurvivors_Int++;

            }
            
        }

        System.Console.WriteLine($"Chance Of Finiding A Loner In Survivors: {lonerInSurvivors_Int/survivors_Int}");

    }

    private static void Answer4()//survival chance of men
    {

        float men_Int = 0;

        float survivedMen_Int = 0;
        
        for (int row_Int = 0; row_Int < data_StringArray2D.Length; row_Int++)
        {

            if(data_StringArray2D[row_Int][3].Trim() == "male")
            {

                men_Int++;

                if(data_StringArray2D[row_Int][0].Trim()=="1")
                {
                    
                    survivedMen_Int++;

                }

            }
            
        }

        System.Console.WriteLine($"Chance Of Survivng As A Man: {survivedMen_Int/men_Int}");

    }

    private static void Answer5()//survival chance of kids(age<12)
    {

        float kids_Int = 0;

        float survivedKids_Int = 0;
        
        for (int row_Int = 0; row_Int < data_StringArray2D.Length; row_Int++)
        {
            
            if(float.TryParse(data_StringArray2D[row_Int][4].Trim(),out float age_Int) & age_Int<12)
            {

                kids_Int++;

                if(data_StringArray2D[row_Int][0].Trim()=="1")
                {
                    
                    survivedKids_Int++;

                }

            }
            
        }

        System.Console.WriteLine($"Chance Of Survivng As A Kid: {survivedKids_Int/kids_Int}");
        
    }

    private static void Answer6()//survival chance of lone passengers
    {

        float loners_Int = 0;

        float survivedLoners_Int = 0;
        
        for (int row_Int = 0; row_Int < data_StringArray2D.Length; row_Int++)
        {
            
            if(int.TryParse(data_StringArray2D[row_Int][5].Trim(),out int siblings_Int) & siblings_Int == 0 &
                int.TryParse(data_StringArray2D[row_Int][6].Trim(),out int parch_Int) & parch_Int == 0)
            {

                loners_Int++;

                if(data_StringArray2D[row_Int][0].Trim()=="1")
                {
                    
                    survivedLoners_Int++;

                }

            }
            
        }

        System.Console.WriteLine($"Chance Of Survivng As A Man: {survivedLoners_Int/loners_Int}");
        
    }

    private static void Answer7()//women vs. men survival chance
    {

        float passenger_Int = 0;

        float survivedMen_Int = 0;

        float survivedWomen_Int = 0;
        
        for (int row_Int = 0; row_Int < data_StringArray2D.Length; row_Int++)
        {

            passenger_Int++;

            if(data_StringArray2D[row_Int][0].Trim()=="1")
            {

                if(data_StringArray2D[row_Int][3].Trim() == "male")
                {
                    
                    survivedMen_Int++;

                }

                if(data_StringArray2D[row_Int][3].Trim() == "female")
                {
                    
                    survivedWomen_Int++;

                }

            }
            
        }

        System.Console.WriteLine($"Chance Of Survivng As A Man: {survivedMen_Int/passenger_Int}, Chance Of Survivng As A Woman: {survivedWomen_Int/passenger_Int}\nRatio Of Survivng Women Per Men: {survivedWomen_Int/passenger_Int}");
        
    }

    private static void Answer8()//adults vs. kids survival chance
    {

        float survivors_Int = 0;

        float survivedKids_Int = 0;

        float survivedAdults_Int = 0;
        
        for (int row_Int = 0; row_Int < data_StringArray2D.Length; row_Int++)
        {

            survivors_Int++;

            if(data_StringArray2D[row_Int][0].Trim()=="1")
            {

                if(int.TryParse(data_StringArray2D[row_Int][4].Trim(),out int age_Int) & age_Int<12)
                    survivedKids_Int++;else
                        survivedAdults_Int++;

            }
            
        }

        System.Console.WriteLine($"Chance Of Survivng As An Adult: {survivedAdults_Int/survivors_Int}, Chance Of Survivng As A Kid: {survivedKids_Int/survivors_Int}\nRatio Of Survivng Kids Per Adults: {survivedKids_Int/survivedAdults_Int}");
        
    }

    private static void Answer9()//passengers w/ companion(s) vs. lone passengers survival chance
    {

        float survivors_Int = 0;

        float lonerSurvivors_Int = 0;

        float withCompanoin_Int = 0;

        for (int row_Int = 0; row_Int < data_StringArray2D.Length; row_Int++)
        {

            survivors_Int++;

            if(data_StringArray2D[row_Int][0].Trim() == "1")
            {

                if(int.TryParse(data_StringArray2D[row_Int][5].Trim(),out int sibling_Int) & sibling_Int == 0 &
                    int.TryParse(data_StringArray2D[row_Int][6].Trim(),out int parch_Int) & parch_Int == 0)
                            lonerSurvivors_Int++;else
                                withCompanoin_Int++;

            }
            
        }

        System.Console.WriteLine($"Chance Of Survivng As A Loner: {lonerSurvivors_Int/survivors_Int}, Chance Of Survivng While Having Companions: {withCompanoin_Int/survivors_Int}\nRatio Of Survivng People w/ Company Per Loners: {lonerSurvivors_Int/withCompanoin_Int}");

    }

}