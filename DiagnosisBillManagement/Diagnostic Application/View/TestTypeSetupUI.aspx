<%@ Page Language="C#" Title="Test Type" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="TestTypeSetupUI.aspx.cs" Inherits="Diagnostic_Application.View.TestTypeSetupUI" %>

<asp:Content ID="contentTestTypeSetup" ContentPlaceHolderID="MainContent" runat="server">

    <form id="TestSetupUI" class="form-horizontal" runat="server">
        <h3 class="title">Test Type Setup</h3>
        <asp:Label ID="InfoMessageLabel" CssClass="infoMessage" runat="server" Visible="false" Text=""></asp:Label>
        <div class="col-lg-8">
            <!-- type setup -->
            <div class="type-setup">
                <div class="form-group">
                    <asp:Label ID="TestTypeLabel" runat="server" class="col-sm-3 control-label" Text="Type Name"></asp:Label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TestTypeTextBox" name="TestTypeTextBox" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-3 col-sm-9">
                        <asp:Button ID="SaveButton" runat="server" class="btn btn-primary right" Text="Save" OnClick="SaveButton_Click" />
                    </div>
                </div>
            </div> 
            <!-- type setup -->
        </div>
        
        
        <asp:GridView ID="TestSetupGridView" CssClass="table table-bordered custom-table" runat="server" AutoGenerateColumns="False" AllowPaging="True">
            <Columns>
                <asp:TemplateField HeaderText="SL">
                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Type Name">
                    <ItemTemplate><%# Eval("TestTypeName") %></ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
    </form>
</asp:Content>