namespace TitanicNameSpace;

public class MyMain
{

    public static void Main(string[] args)
    {

        ConsoleKeyInfo userInput_ConsoleKeyInfo;
        
        for(int question_Int = 1; question_Int <10;question_Int++)
        {

            Proccess.Question_Function(question_Int);

            System.Console.WriteLine("Press Any Key To Continue");

            Console.ReadKey();
            
        }

        System.Console.WriteLine("Press Related Number To The Questions To Show Them Again, Otherwise Press \"esc\" To Exit");

        while((userInput_ConsoleKeyInfo = Console.ReadKey()).Key!=ConsoleKey.Escape)
        {

            Console.Clear();            

            System.Console.WriteLine("Press Related Number To The Questions To Show Them Again, Otherwise Press \"esc\" To Exit");

            if(int.TryParse(userInput_ConsoleKeyInfo.ToString(),out int userNumber_Int))
                Proccess.Question_Function(userNumber_Int);

        }
        
    }

}