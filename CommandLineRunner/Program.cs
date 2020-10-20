using ValtechQaExercise.Steps;

namespace CommandLineRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            PageObjectModelChecker checker = new PageObjectModelChecker(null);
            
            checker.ThenAllPageObjectElementsCanBeFoundOnAllBrowsers();
        }
    }
}
