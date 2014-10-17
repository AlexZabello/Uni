//-----------------------------------------------------------------------
// <copyright file="ILoginModel.cs" company="CompanyName">
//     ---
// </copyright>
//-----------------------------------------------------------------------
namespace Uni.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Interface ILoginModel
    /// </summary>
    public interface ILoginModel
    {
        bool Login(string login, string password);
    }
}