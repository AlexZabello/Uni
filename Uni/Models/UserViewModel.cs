//-----------------------------------------------------------------------
// <copyright file="UserViewModel.cs" company="CompanyName">
//     ---
// </copyright>
//-----------------------------------------------------------------------
namespace Uni.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// User view model
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// Gets or sets user id
        /// </summary>
        public int UserId { get; set; }
        
        /// <summary>
        /// Gets or sets login
        /// </summary>
        public string Login { get; set; }
        
        /// <summary>
        /// Gets or sets user role id, may be null
        /// </summary>
        public int? UserRoleId { get; set; }

        /// <summary>
        /// Gets or sets user role
        /// </summary>
        public string UserRole { get; set; }
    }
}