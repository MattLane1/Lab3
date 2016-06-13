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

        protected void DepartmentsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Store which row was clicked
            int selectedRow = e.RowIndex;

            //Get the selected ID
            int selectedID = Convert.ToInt32(DepartmentsGridView.DataKeys[selectedRow].Values["DepartmentID"]);

            //Use EF to find the selected student in the DB and remove it
            using (DefaultConnection db = new DefaultConnection())
            {//Create object opf student class and store the query string 
                Department deletedDepartment = (from departmentRecords in db.Departments
                                          where departmentRecords.DepartmentID == selectedID
                                          select departmentRecords).FirstOrDefault();

                //Remove the selected Student from DB
                db.Departments.Remove(deletedDepartment);

                //Save the changes to the database
                db.SaveChanges();

                //Refresh the grid
                this.GetDepartments();
            }
        }

        /*
       * This event allows paging for the Departments Page
       */
        protected void DepartmentsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the new page number
            DepartmentsGridView.PageIndex = e.NewPageIndex;

            // Refresh the grid
            this.GetDepartments();
        }
    }
}