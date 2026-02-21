
namespace CTMS.Services
{
    public class GeneralService
    {
        public static void FetchUserInputGeneric<T>(ref T? t, string MSG) where T : IParsable<T>
        {
            Console.WriteLine(MSG);
            while (true)
            {
                string? userInput = Console.ReadLine();
                if (T.TryParse(userInput, null, out t)) break;
                else Console.WriteLine("Enter Valid Format of Input");
            }
        }
    }
}
