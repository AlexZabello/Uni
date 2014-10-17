//-----------------------------------------------------------------------
// <copyright file="GroupViewModel.cs" company="CompanyName">
//     ---
// </copyright>
//-----------------------------------------------------------------------
namespace Uni.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Group view model
    /// </summary>
    public class GroupViewModel
    {
        /// <summary>
        /// Gets or sets GroupId
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Gets or sets Subject Name
        /// </summary>
        public string SubjectName { get; set; }
        
        /// <summary>
        /// Gets or sets Prof Name
        /// </summary>
        public string ProfName { get; set; }
    }
}