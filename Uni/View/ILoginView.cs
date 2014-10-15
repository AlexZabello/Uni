using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uni.View
{
    public interface ILoginView : IView
    {
        string LoginName { get; set; }
        string Password { get; set; }
    }
}