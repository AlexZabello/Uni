using DataLayer.Core;
using DataLayer.Entity;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uni.Helpers;
using Uni.Models;
using Uni.Presenter;
using Uni.View;

namespace Uni.Pages
{
    public partial class Students : System.Web.UI.Page, IStudentView
    {
        StudentPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                presenter = new StudentPresenter(this);

                Repeater1.DataSource = presenter.GetStudents();
                Repeater1.DataBind();

                DDLSubject.DataSource = presenter.GetSubjects();
                DDLSubject.DataBind();
                DDLSubject.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                DDLSubject.SelectedIndex = 0;

                DDLGroup.DataSource = presenter.GetGroup();
                DDLGroup.DataBind();
                DDLGroup.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                DDLGroup.SelectedIndex = 0;
            }
        }

        protected void bSearch_Click(object sender, EventArgs e)
        {
            presenter = new StudentPresenter(this);
            Repeater1.DataSource = null;
            Repeater1.DataSource = presenter.GetStudents();
            Repeater1.DataBind();
        }

        #region Implementation IStudentView

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
                    DDLSubject.SelectedValue = "";
                }
            }
        }

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
                    DDLGroup.SelectedValue = "";
                }
            }
        }

        #endregion //Implementation IStudentView
    }
}