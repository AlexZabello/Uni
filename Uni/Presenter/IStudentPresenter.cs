//-----------------------------------------------------------------------
// <copyright file="IStudentPresenter.cs" company="CompanyName">
//     ---
// </copyright>
//-----------------------------------------------------------------------
namespace Uni.Presenter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using DataLayer.Repository;

    /// <summary>
    /// Interface IStudentPresenter
    /// </summary>
    public interface IStudentPresenter
    {
        /// <summary>
        /// Gets or sets instance of IStudentRepository
        /// </summary>
        IStudentRepository StudentRepository { get; set; }

        IEnumerable<Uni.Models.StudentViewModel> GetStudents();
    }
}