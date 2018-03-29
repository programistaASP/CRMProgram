using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMAplication.BussinesLogic
{
    public class CarLogin
    {
        public bool IsUserAuthorized()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
    }
}