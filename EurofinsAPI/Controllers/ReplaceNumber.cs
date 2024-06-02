namespace EurofinsAPI.Controllers
{
    public class ReplaceNumber : IReplaceNumber
    {

        public object replaceNumber(int pNumber)
        {
            if (pNumber == 0)
            {
                return "Eurofins";
            }
            else if (pNumber == 3)
            {
                return "Three";
            } else if (pNumber == 5)
            {
                return "Five";
            }

            return pNumber;
        }

    }
}
