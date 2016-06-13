﻿<%@ Page Title="Students" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="Lab3.Students" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8"></div>
            <h1>Student List</h1>
            <asp:GridView runat="server" CssClass="table table-bordered table-striped table-hover" ID="StudentsGridView" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField runat="Server" DataField="StudentID" HeaderText="Student ID" Visible="true" />
                     <asp:BoundField runat="Server" DataField="LastName" HeaderText="Last Name" Visible="true" />
                     <asp:BoundField runat="Server" DataField="FirstMidName" HeaderText="First Name" Visible="true" />
                     <asp:BoundField runat="Server" DataField="EnrollmentDate" HeaderText="Enrollment Date" Visible="true" 
                         DataFormatString="{0:MMM dd, yyyy}" />
                </Columns>
            </asp:GridView>
        </div>
    </div>



</asp:Content>
