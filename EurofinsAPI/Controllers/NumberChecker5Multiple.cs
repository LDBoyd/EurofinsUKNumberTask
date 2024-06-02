namespace EurofinsAPI.Controllers
{
    public class NumberChecker5Multiple : INumberChecker
    {

        public bool checkNumber(int number)
        {

            return number % 5 == 0;

        }

    
    }
}
