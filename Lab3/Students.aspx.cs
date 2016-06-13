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
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //If loading page first time populate the grid
            if (!IsPostBack)
            {
                //Get Student Data
                this.GetStudents();
            }
        }

        /**
         * This method gets the student data from the database
         * @method GetStudents 
        */
        protected void GetStudents()
        {
            //connect to EF
            using (DefaultConnection db = new DefaultConnection())
            {
                //query the students table using EF and LINQ
                var Students = (from allStudents in db.Students
                                select allStudents);

                //bind the result to the GridView
                StudentsGridView.DataSource = Students.ToList();
                StudentsGridView.DataBind();
            }
        }
        /**
         * <summary>
         * This event handler deletes a student from the db useing EF
         * </summary>
         * 
         * @method StudentsGridView_RowDeleting
         * @param {object} sender
         * @param {GridViewDeleteEventArgs} e
         * @returns {void}
         */ 

        protected void StudentsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Store which row was clicked
            int selectedRow = e.RowIndex;

            //Get the selected ID
            int StudentID = Convert.ToInt32(StudentsGridView.DataKeys[selectedRow].Values["StudentID"]);

            //Use EF to find the selected student in the DB and remove it
            using (DefaultConnection db = new DefaultConnection())
            {//Create object opf student class and store the query string 
                Student deletedStudent = (from studentRecords in db.Students
                                          where studentRecords.StudentID == StudentID
                                          select studentRecords).FirstOrDefault();

                //Remove the selected Student from DB
                db.Students.Remove(deletedStudent);

                //Save the changes to the database
                db.SaveChanges();

                //Refresh the grid
                this.GetStudents();

            }
        }

        /*
         * This event allows paging for the Students Page
         */
        protected void StudentsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the new page number
            StudentsGridView.PageIndex = e.NewPageIndex;

            // Refresh the grid
            this.GetStudents();
        }
    }
}
