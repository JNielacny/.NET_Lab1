namespace problem_plecakowy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the seed:");
            int seed = int.Parse(Console.ReadLine());
            ProblemPlecakowy problem = new ProblemPlecakowy(10, seed); // 10 przedmiotów
            Console.WriteLine(problem.ToString());

            var wynik = problem.Solve(50); // Przykładowa pojemność plecaka
            Console.WriteLine(wynik.ToString());
        }
    }
}
 