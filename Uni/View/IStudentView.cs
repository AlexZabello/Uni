//-----------------------------------------------------------------------
// <copyright file="IStudentView.cs" company="CompanyName">
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
    /// Interface IStudentView based on IView
    /// </summary>
    public interface IStudentView : IView
    {
        /// <summary>
        /// Gets or sets first name
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name
        /// </summary>
        string LastName { get; set; }
        
        /// <summary>
        /// Gets or sets subject id
        /// </summary>
        int? IdSubject { get; set; }
        
        /// <summary>
        /// Gets or sets group id
        /// </summary>
        int? IdGroup { get; set; }
    }
}