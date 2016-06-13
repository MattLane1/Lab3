<%@ Page Title="Departments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Departments.aspx.cs" Inherits="Lab3.Departments" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8"></div>
            <h1>Departments List</h1>
            <a href="DepartmentDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus"></i> Add Department</a>
            <asp:GridView runat="server" CssClass="table table-bordered table-striped table-hover" ID="DepartmentsGridView" AutoGenerateColumns="false">
                <Columns>
                     <asp:BoundField runat="Server" DataField="DepartmentID" HeaderText="Department ID" Visible="true" />
                     <asp:BoundField runat="Server" DataField="Name" HeaderText="Department Name" Visible="true" />
                     <asp:BoundField runat="Server" DataField="Budget" HeaderText="Department Budget" DataFormatString="{0:c}" Visible="true" HtmlEncode="False" />
                    <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton ="true" ButtonType="Link"
                        ControlStyle-CssClass="btn btn-danger btn-sm" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>