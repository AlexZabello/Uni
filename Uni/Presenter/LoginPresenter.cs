using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uni.Model;
using Uni.View;

namespace Uni.Presenter
{
    public class LoginPresenter : Presenter<ILoginView>
    {
        public LoginPresenter(ILoginView view): base(view)
        {    
        }

        public bool Login()
        {
            LoginModel model = new LoginModel();
            return model.Login(view.LoginName, view.Password);
        }
    }
}