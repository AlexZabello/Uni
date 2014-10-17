//-----------------------------------------------------------------------
// <copyright file="ILoginView.cs" company="CompanyName">
//     ---
// </copyright>
//-----------------------------------------------------------------------
namespace Uni.View
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Interface ILoginView based on IView
    /// </summary>
    public interface ILoginView : IView
    {
        /// <summary>
        /// Gets or sets login name
        /// </summary>
        string LoginName { get; set; }

        /// <summary>
        /// Gets or sets password
        /// </summary>
        string Password { get; set; }
    }
}