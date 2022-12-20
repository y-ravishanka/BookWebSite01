namespace BookSiteServer.Services
{
    internal class Calculation : ICalculation
    {
        void ICalculation.DisplayExceptions(string title, string message)
        {
            Console.WriteLine("\n" + title + " : \n###-------\n" + message + "\n");
        }
    }
}
