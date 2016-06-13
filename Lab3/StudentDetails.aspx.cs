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
    public partial class StudentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            //Redirect back to Students page
            Response.Redirect("Students.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            //Use EF to connect to the server
            using (DefaultConnection db = new DefaultConnection())
            {
                // Use the student model to create a new student object and save the new record
                Student newStudent = new Student();

                // add data to the new student record
                newStudent.LastName = LastNameTextBox.Text;
                newStudent.FirstMidName = FirstNameTextBox.Text;
                newStudent.EnrollmentDate = Convert.ToDateTime(EnrollmentDateTextBox.Text);

                // use LINQ and ADO.NET to add a student into the database
                db.Students.Add(newStudent);

                //Save changes
                db.SaveChanges();

                //Redirect back to the updated students page
                Response.Redirect("~/Students.aspx");
            }
        }
    }
}