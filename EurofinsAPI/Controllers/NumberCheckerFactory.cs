using Microsoft.AspNetCore.Mvc.Formatters;

namespace EurofinsAPI.Controllers
{
    public class NumberCheckerFactory
    {

        public INumberChecker getCheckerType(string pCheckType)
        {
            if (pCheckType == null)
            {
                return null;
            }
            if (pCheckType.ToUpper().Equals("3"))
            {
                return new NumberChecker3Multiple();
            }
            if (pCheckType.ToUpper().Equals("5"))
            {
                return new NumberChecker5Multiple();
            }
            return null;

        }
    }
}
