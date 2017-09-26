<%@ Page Language="C#" Title="Type Wise Report" MasterPageFile="../master.Master"  AutoEventWireup="true" CodeBehind="TestWiseReport.aspx.cs" Inherits="Diagnostic_Application.View.TestWiseReport" %>


<asp:Content ID="contentTestWiseReport" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" class="form-horizontal" runat="server">
        <h3 class="title">Test Wise Report</h3>
        <asp:Label ID="InfoMessageLabel" CssClass="infoMessage" runat="server" Visible="false" Text=""></asp:Label>
        <div class="col-lg-8">
            <!-- type setup -->
            <div class="type-setup">
                <div class="form-group">
                    <asp:Label ID="TestTypeLabel" runat="server" class="col-sm-3 control-label" Text="From Date"></asp:Label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="FormDateTextBox" TextMode="Date" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" class="col-sm-3 control-label" Text="To Date"></asp:Label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="ToDateTextBox" TextMode="Date" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-sm-offset-3 col-sm-9">
                        <asp:Button ID="ShowButton" runat="server" class="btn btn-primary right" Text="Show" OnClick="ShowButton_Click" />
                    </div>
                </div>
            </div>
            <!-- type setup -->
        </div>
        
        <div class="row">
            <div class="col-lg-12">
                <asp:GridView 
                    ID="TestWiseReportGridView" 
                    CssClass="table table-bordered custom-table" 
                    HorizontalAlign="Center" 
                    runat="server" 
                    AutoGenerateColumns="False" 
                    EmptyDataText="No data available." 
                    BackColor="White" 
                    BorderColor="#CC9966" 
                    BorderStyle="None" 
                    BorderWidth="1px" 
                    CellPadding="3" 

                    ShowFooter="True" OnRowDataBound="TestWiseReportGridView_RowDataBound">
                    
                        <Columns>
                            <asp:TemplateField HeaderText="SL">
                                <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Test Name" DataField="TestName" />
                            <asp:BoundField HeaderText="Total Test" DataField="TotalCount" />
                            <asp:BoundField HeaderText="Total Amount (TK)" DataField="TotalFee" />
                        </Columns>
                        <FooterStyle BackColor="#008B8B" Font-Bold="True" ForeColor="#000000" />
                        <HeaderStyle BackColor="#008B8B" Font-Bold="True" ForeColor="#000000" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#000000" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#000000" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                    </asp:GridView>

            </div>
        </div>
        
        
        
        <div class="row">
            <div class="col-lg-12">
                <asp:Button ID="PdfButton" runat="server" cssClass="btn btn-primary right" Text="PDF" OnClick="PdfButton_Click" />
                    
            </div>
        </div>

    </form>
</asp:Content>