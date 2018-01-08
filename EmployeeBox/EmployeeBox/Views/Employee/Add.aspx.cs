using EmployeeBox.App_Code;
using EmployeeBox.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeBox.Views.Employee
{
    public partial class Add : System.Web.UI.Page
    {
        private EmployeeRepository _repository;
        protected void Page_Load(object sender, EventArgs e)
        {
            _repository = new EmployeeRepository();

            //Load employeeEducation dropdownlist
            employeeEducationList.DataSource = _repository.selectEducationalQualification();
            employeeEducationList.DataValueField = "EducationalQualificationID";
            employeeEducationList.DataTextField = "EducationalQualificationName";
            employeeEducationList.DataBind();
        }
        protected void btnAdd_ServerClick(object sender, EventArgs e)
        {
            _repository = new EmployeeRepository();

            ContextState contextStateOb = _repository.AddEmployee(txtNationalID.Value, txtName.Value, txtBirthDate.Value, txtAddress.Value, txtPhoneNumber.Value, txtPhoto.Value, txtHireDate.Value, txtJoinDate.Value);
            if (contextStateOb.State)
            {
                Response.Write("Employee has been added  sucssefly.");
            }
            else
            {
                Response.Write(contextStateOb.ErrorMessage);
            }
        }
    }
}