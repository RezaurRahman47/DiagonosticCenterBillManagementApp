using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diagnostic_Application.BLL;
using Diagnostic_Application.Models;

namespace Diagnostic_Application.View {
    
    public partial class TestSetupUI : System.Web.UI.Page {

        TestSetupManager testSetupManager = new TestSetupManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){
                LoadAllTestType();
            }

            LoadAllTestSetup();
        }

        private void LoadAllTestSetup()
        {
            List<TestSetupViewModel> allTestSetupList = testSetupManager.GetAllTestSetup();
            TestSetupGridView.DataSource = allTestSetupList;
            TestSetupGridView.DataBind();
        }


        public void LoadAllTestType(){
            List<TestType> allTestTypes = testSetupManager.GetAllTestType();
            TestTypeDropDownList.DataSource = allTestTypes;
            TestTypeDropDownList.DataTextField = "TestTypeName";
            TestTypeDropDownList.DataValueField = "Id";
            TestTypeDropDownList.DataBind();

            TestTypeDropDownList.Items.Insert(0, "---SELECT---");
        }

        protected void SaveButton_Click(object sender, EventArgs e){
            TestSetup testSetup = new TestSetup();

            if (TestNameTextBox.Text == string.Empty
                || FeeTextBox.Text == string.Empty
                || TestTypeDropDownList.SelectedIndex == 0
            )
            {
                DisplayInfoMessage("Empty! Fields are Required.", Color.DarkRed);
                return;
            }

            testSetup.TestName = TestNameTextBox.Text;
            testSetup.Fee = Convert.ToDecimal(FeeTextBox.Text);
            testSetup.TestTypeId = Convert.ToInt32(TestTypeDropDownList.SelectedValue);

            string message = testSetupManager.SaveTestSetup(testSetup);

            if (message == "success"){
                DisplayInfoMessage("Success! Test Setup Created.", Color.ForestGreen);

            }else if (message == "failed"){
                DisplayInfoMessage("Failed! Test Setup Problem", Color.DarkRed);

            }
            else if (message == "exists"){
                DisplayInfoMessage("Error! Test Name Already Exists.", Color.DarkRed);

            }

            LoadAllTestSetup();

        }

        private void DisplayInfoMessage(string text, Color color){
            //Exists - Test Setup.
            InfoMessageLabel.Text = text;
            InfoMessageLabel.Visible = true;
            InfoMessageLabel.BackColor = color;
        }

        protected void TestSetupGridView_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            testSetupManager.GetAllTestSetup();
            TestSetupGridView.PageIndex = e.NewPageIndex;
            TestSetupGridView.DataBind();
        }
    }
}