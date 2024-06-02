namespace EurofinsAPI.Controllers
{
    public class NumberChecker3Multiple : INumberChecker
    {

        public bool checkNumber(int number)
        {

            return number % 3 == 0;

        }

    }
}
