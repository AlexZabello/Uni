using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uni.Model
{
    public interface ILoginModel
    {
        bool Login(string login, string pass);
    }
}