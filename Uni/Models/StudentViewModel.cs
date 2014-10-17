//-----------------------------------------------------------------------
// <copyright file="StudentViewModel.cs" company="CompanyName">
//     ---
// </copyright>
//-----------------------------------------------------------------------
namespace Uni.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using DataLayer.Entity;

    /// <summary>
    /// Student view model for student page
    /// </summary>
    public class StudentViewModel
    {
        /// <summary>
        /// Gets or sets Student Id
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Gets or sets first name
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Gets or sets last name
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Gets or sets subject id
        /// </summary>
        public int SubjectId { get; set; }
        
        /// <summary>
        /// Gets or sets subject name
        /// </summary>
        public string SubjectName { get; set; }
        
        /// <summary>
        /// Gets or sets group id
        /// </summary>
        public int GroupId { get; set; }
        
        /// <summary>
        /// Gets or sets group name
        /// </summary>
        public string GroupName { get; set; }
        
        /// <summary>
        /// Gets or sets prof name
        /// </summary>
        public string ProfName { get; set; }
    }
}