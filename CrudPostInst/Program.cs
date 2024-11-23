using CrudPostInst.modul;
using CrudPostInst.service;

namespace CrudPostInst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void StartedProgram()
        {
            var postedres = new ServiceInst();
            while (true)
            {
                Console.WriteLine(DateTime.Now);
                Console.WriteLine("1.Addet id ");
                Console.WriteLine("2.Delete id");
                Console.WriteLine("3.update id");
                Console.WriteLine("4.Get all id");
                Console.WriteLine("5.Get by id");
                Console.WriteLine("6.Get most vied post ");
                Console.WriteLine("7.GetMostLikedPost");
                Console.WriteLine("8.GetMostCommentedPost");
                Console.WriteLine("9.GetPostsByComment");
                Console.WriteLine("Enter: ");
                var alternative = Console.ReadLine();
                if (alternative == "1")
                {
                    var postNew = new model();
                    Console.WriteLine();

                }


            }

        }
    }
}
