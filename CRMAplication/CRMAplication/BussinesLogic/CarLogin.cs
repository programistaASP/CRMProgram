using CRMAplication.Interfaces;
using System.Web;

namespace CRMAplication.BussinesLogic
{
    public class CarLogin: ICarLogin
    {
        public bool IsUserAuthorized()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
    }
}