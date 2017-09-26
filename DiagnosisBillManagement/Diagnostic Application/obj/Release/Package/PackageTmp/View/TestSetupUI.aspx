<%@ Page Language="C#" AutoEventWireup="true" Title="Test Setup" MasterPageFile="~/master.Master" CodeBehind="TestSetupUI.aspx.cs" Inherits="Diagnostic_Application.View.TestSetupUI" %>

<asp:Content ID="contentTestSetup" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" class="form-horizontal" runat="server">
        <h3 class="title">Test Setup</h3>
        <asp:Label ID="InfoMessageLabel" CssClass="infoMessage" runat="server" Visible="false" Text=""></asp:Label>
        <div class="col-lg-8">
            <!-- type setup -->
            <div class="type-setup">
                <div class="form-group">
                    <asp:Label ID="TestNameLabel" runat="server" CssClass="col-sm-3 control-label" Text="Test Name"></asp:Label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TestNameTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" CssClass="col-sm-3 control-label" Text="Fee"></asp:Label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="FeeTextBox" CssClass="form-control" runat="server"></asp:TextBox>      <b class="money-type">BDT</b>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" CssClass="col-sm-3 control-label" Text="Test Type"></asp:Label>
                    <div class="col-sm-9">
                        <asp:DropDownList CssClass="form-control" ID="TestTypeDropDownList" runat="server"></asp:DropDownList>
                    </div>
                </div>
                
                <div class="form-group">
                    <div class="col-sm-offset-3 col-sm-9">
                        <asp:Button ID="SaveButton" runat="server" CssClass="btn btn-primary right" Text="Save " OnClick="SaveButton_Click"/>
                    </div>
                </div>
            </div>
            <!-- type setup -->
        </div>
        
        
        <asp:GridView ID="TestSetupGridView" CssClass="table table-bordered custom-table" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="TestSetupGridView_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="SL">
                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Test Name">
                    <ItemTemplate><%# Eval("TestName") %></ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Fee">
                    <ItemTemplate><%# Eval("Fee") %></ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Type">
                    <ItemTemplate><%# Eval("Name") %></ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
    </form>
</asp:Content>
