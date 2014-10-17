//-----------------------------------------------------------------------
// <copyright file="Students.aspx.cs" company="CompanyName">
//     ---
// </copyright>
//-----------------------------------------------------------------------
namespace Uni.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using DataLayer.Core;
    using DataLayer.Entity;
    using DataLayer.Repository;
    using Uni.Helpers;
    using Uni.Models;
    using Uni.Presenter;
    using Uni.View;

    /// <summary>
    /// Students Page
    /// </summary>
    public partial class Students : System.Web.UI.Page, IStudentView
    {
        /// <summary>
        /// Presenter field
        /// </summary>
        private StudentPresenter presenter;

        #region Implementation IStudentView

        /// <summary>
        /// Gets or sets first name
        /// </summary>
        public string FirstName
        {
            get
            {
                return fName.Text;
            }

            set
            {
                fName.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets last name
        /// </summary>
        public string LastName
        {
            get
            {
                return lName.Text;
            }
     
            set
            {
                lName.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets subject id
        /// </summary>
        public int? IdSubject
        {
            get
            {
                if (DDLSubject.SelectedValue != string.Empty)
                {
                    return Convert.ToInt32(DDLSubject.SelectedValue);
                }
                else
                {
                    return null;
                }
            }
         
            set
            {
                if (value.HasValue)
                {
                    DDLSubject.SelectedValue = value.Value.ToString();
                }
                else
                {
                    DDLSubject.SelectedValue = string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets or sets group id
        /// </summary>
        public int? IdGroup
        {
            get
            {
                if (DDLGroup.SelectedValue != string.Empty)
                {
                    return Convert.ToInt32(DDLGroup.SelectedValue);
                }
                else
                {
                    return null;
                }
            }
          
            set
            {
                if (value.HasValue)
                {
                    DDLGroup.SelectedValue = value.Value.ToString();
                }
                else
                {
                    DDLGroup.SelectedValue = string.Empty;
                }
            }
        }

        #endregion //Implementation IStudentView

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.presenter = new StudentPresenter(this, new Uni.Model.StudentModel());

                this.Repeater1.DataSource = this.presenter.GetStudents();
                this.Repeater1.DataBind();

                this.DDLSubject.DataSource = this.presenter.GetSubjects();
                this.DDLSubject.DataBind();
                this.DDLSubject.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                this.DDLSubject.SelectedIndex = 0;

                this.DDLGroup.DataSource = this.presenter.GetGroup();
                this.DDLGroup.DataBind();
                this.DDLGroup.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                this.DDLGroup.SelectedIndex = 0;
            }
        }

        protected void OnButtonSearch_Click(object sender, EventArgs e)
        {
            this.presenter = new StudentPresenter(this, new Uni.Model.StudentModel());
            this.Repeater1.DataSource = null;
            this.Repeater1.DataSource = this.presenter.GetStudents();
            this.Repeater1.DataBind();
        }
    }
}