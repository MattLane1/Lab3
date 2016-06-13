<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DepartmentDetails.aspx.cs" Inherits="Lab3.DepartmentDetails" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-3 col md-6">
                <h1>department details</h1>
                <h5>All fields are required</h5>
                <br />
                <div class="form-group">
                      <label class="control-label" for="DepartmentIDTextBox">Department ID</label>
                    <asp:TextBox  runat="server" CssClass="form-control" ID="DepartmentIDTextBox" placeholder="Department ID" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="DepartmentNameTextBox">Department Name</label>
                    <asp:TextBox  runat="server" CssClass="form-control" ID="DepartmentNameTextBox" placeholder="Department Name" required="true"></asp:TextBox>
                 </div>
                 <div class="form-group">
                      <label class="control-label" for="DepartmentBudgetTextBox">Department Budget</label>
                    <asp:TextBox  runat="server" CssClass="form-control" ID="DepartmentBudgetTextBox" placeholder="Department Budget" required="true"></asp:TextBox>
               </div>
                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server" 
                        UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click" />
                    <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="SaveButton_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
