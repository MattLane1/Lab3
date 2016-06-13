using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Using statements that are required to connect top EF database
using Lab3.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace Lab3
{
    public partial class Departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //If loading page first time populate the grid
            if (!IsPostBack)
            {
                Session["SortColumn"] = "DepartmentID"; // default sort column
                Session["SortDirection"] = "ASC";
                //Get Student Data
                this.GetDepartments();
            }
        }

        /**
         * This method gets the department data from the database
         * @method GetDepartments
        */
        protected void GetDepartments()
        {
            //connect to EF
            using (DefaultConnection db = new DefaultConnection())
            {
                string SortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                //query the Departments table using EF and LINQ
                var Departments = (from allDepartments in db.Departments
                                   select allDepartments);

                //bind the result to the GridView
                DepartmentsGridView.DataSource = Departments.AsQueryable().OrderBy(SortString).ToList();
                DepartmentsGridView.DataBind();
            }
        }

        protected void DepartmentsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Store which row was clicked
            int selectedRow = e.RowIndex;

            //Get the selected ID
            int selectedID = Convert.ToInt32(DepartmentsGridView.DataKeys[selectedRow].Values["DepartmentID"]);

            //Use EF to find the selected Departments in the DB and remove it
            using (DefaultConnection db = new DefaultConnection())
            {//Create object opf Departments class and store the query string 
                Department deletedDepartment = (from departmentRecords in db.Departments
                                          where departmentRecords.DepartmentID == selectedID
                                          select departmentRecords).FirstOrDefault();

                //Remove the selected Departments from DB
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

        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the new Page size
            DepartmentsGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);

            this.GetDepartments();
        }

        protected void DepartmentsGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            // get the column to sorty by
            Session["SortColumn"] = e.SortExpression;

            // Refresh the Grid
            this.GetDepartments();

            // toggle the direction
            Session["SortDirection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }

        protected void DepartmentsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header) // if header row has been clicked
                {
                    LinkButton linkbutton = new LinkButton();

                    for (int index = 0; index < DepartmentsGridView.Columns.Count - 1; index++)
                    {
                        if (DepartmentsGridView.Columns[index].SortExpression == Session["SortColumn"].ToString())
                        {
                            if (Session["SortDirection"].ToString() == "ASC")
                            {
                                linkbutton.Text = " <i class='fa fa-caret-up fa-lg'></i>";
                            }
                            else
                            {
                                linkbutton.Text = " <i class='fa fa-caret-down fa-lg'></i>";
                            }

                            e.Row.Cells[index].Controls.Add(linkbutton);
                        }
                    }
                }
            }
        }
    }
}