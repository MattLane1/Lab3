using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Using statements that are required to connect top EF database
using Lab3.Models;
using System.Web.ModelBinding;

namespace Lab3
{
    public partial class Departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //If loading page first time populate the grid
            if (!IsPostBack)
            {
                //Get Student Data
                this.GetDepartments();
            }
        }

        /**
         * This method gets the department data from the database
         * @method GetStudents 
        */
        protected void GetDepartments()
        {
            //connect to EF
            using (DefaultConnection db = new DefaultConnection())
            {
                //query the students table using EF and LINQ
                var Departments = (from allDepartments in db.Departments
                                   select allDepartments);

                //bind the result to the GridView
                DepartmentsGridView.DataSource = Departments.ToList();
                DepartmentsGridView.DataBind();
            }
        }
    }
}