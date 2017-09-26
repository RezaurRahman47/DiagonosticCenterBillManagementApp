using Diagnostic_Application.DAL;
using Diagnostic_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diagnostic_Application.BLL {
    public class TestTypeManager {

        TestTypeGetway _testTypeGetway = new TestTypeGetway();


        public string SaveTestType(TestType testType){

            if (testType.TestTypeName == string.Empty)
            {
                return "empty";
            }

            //Check Unique Type
            bool isSutdentExist = _testTypeGetway.IsTestTypeExists(testType);
            if (isSutdentExist){
                return "exists";
            }


            int rowAffected = _testTypeGetway.SaveTestType(testType);
            if (rowAffected > 0)
            {
                return "success";

            }else{
                return "failed";
            }

        }


        public List<TestType> GetAllTestType()
        {
            return _testTypeGetway.GetAllType();
        }

    }
}