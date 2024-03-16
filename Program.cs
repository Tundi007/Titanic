namespace TitanicNameSpace;

public class MyMain
{

    public static void Main(string[] args)
    {

        Proccess.Initialize_Function();
        
        for(int question_Int = 1; question_Int <10;question_Int++)
        {

            Console.Clear();            

            Proccess.Question_Function(question_Int);

            System.Console.WriteLine("Press Any Key To Continue");

            Console.ReadKey();

            Console.Clear();
                        
        }

        for(int question_Int = 1; question_Int <10;question_Int++)
        {           

            Proccess.Question_Function(question_Int);

            System.Console.WriteLine();
                        
        }
        
    }

}