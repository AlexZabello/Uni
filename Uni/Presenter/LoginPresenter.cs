//-----------------------------------------------------------------------
// <copyright file="LoginPresenter.cs" company="CompanyName">
//     ---
// </copyright>
//-----------------------------------------------------------------------
namespace Uni.Presenter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Uni.Model;
    using Uni.View;

    /// <summary>
    /// Implementation Presenter for Login View
    /// </summary>
    public class LoginPresenter : Presenter<ILoginView>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="view">ILoginView instance</param>
        public LoginPresenter(ILoginView view) : base(view)
        {    
        }

        public bool Login()
        {
            LoginModel model = new LoginModel();
            return model.Login(View.LoginName, View.Password);
        }
    }
}