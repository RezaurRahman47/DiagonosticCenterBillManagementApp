using Diagnostic_Application.DAL;
using Diagnostic_Application.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diagnostic_Application.BLL;

namespace Diagnostic_Application.View {
    public partial class TestTypeSetupUI : System.Web.UI.Page {

        TestTypeManager testTypeManager = new TestTypeManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

            }

            DisplayAllTestType();
        }

        private void DisplayAllTestType()
        {
            List<TestType> testTypeList = testTypeManager.GetAllTestType();
            TestSetupGridView.DataSource = testTypeList;
            TestSetupGridView.DataBind();
        }

        /**
        * Clear Screen
        *-------------------------
        */
        private void ClearScreen() {
            TestTypeTextBox.Text = String.Empty;
        }

        protected void SaveButton_Click(object sender, EventArgs e) {

            TestType testType = new TestType();

            //collecting data
            testType.TestTypeName = TestTypeTextBox.Text;


            string message = testTypeManager.SaveTestType(testType);
            if (message == "success"){
                DisplayInfoMessage("Success! Test Type Created.", Color.ForestGreen);

            } else if (message == "failed"){
                DisplayInfoMessage("Failed! Try Again.", Color.DarkRed);

            } else if (message == "exists"){
                DisplayInfoMessage("Error! Test type already exists.", Color.Crimson);

            } else if (message == "empty")
            {
                DisplayInfoMessage("Empty! Please Insert Something.", Color.Crimson);
            }


            DisplayAllTestType();

        }


        private void DisplayInfoMessage(string text, Color color) {
            //Exists - Test Setup.
            InfoMessageLabel.Text = text;
            InfoMessageLabel.Visible = true;
            InfoMessageLabel.BackColor = color;
        }
    }
}