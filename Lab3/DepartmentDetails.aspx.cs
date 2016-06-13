using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Using Statements required for EF DB access
using Lab3.Models;
using System.Web.ModelBinding;

namespace Lab3
{
    public partial class DepartmentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            //Redirect back to Students page
            Response.Redirect("~Departments.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            //Use EF to connect to the server
            using (DefaultConnection db = new DefaultConnection())
            {
                // Use the student model to create a new student object and save the new record
                Department newDepartment = new Department();

                // add data to the new student record
                newDepartment.DepartmentID = Convert.ToInt32(DepartmentIDTextBox.Text);
                newDepartment.Name = DepartmentNameTextBox.Text;
                newDepartment.Budget = Convert.ToInt32(DepartmentBudgetTextBox.Text);

                // use LINQ and ADO.NET to add a student into the database
                db.Departments.Add(newDepartment);

                //Save changes
                db.SaveChanges();

                //Redirect back to the updated students page
                Response.Redirect("~/Departments.aspx");
            }
        }
    }
}