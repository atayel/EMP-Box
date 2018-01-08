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
            if (!Page.IsPostBack)
            {
                _repository = new EmployeeRepository();

                //Load data into employeeEducation dropdownlist
                employeeEducationList.DataSource = _repository.SelectEducationalQualification();
                employeeEducationList.DataValueField = "EducationalQualificationID";
                employeeEducationList.DataTextField = "EducationalQualificationName";
                employeeEducationList.DataBind();
                employeeEducationList.Items.Insert(0, new ListItem("أختر المؤهل التعليمي", "0"));

                //Load data into subscriptionFeeYears dropdownlist
                for (int i = DateTime.Now.Year; i >= DateTime.Now.Year - 10; i--)
                {
                    subscriptionFeeYears.Items.Add(i.ToString());
                }
            }
        }

        protected void btnAdd_ServerClick(object sender, EventArgs e)
        {
            _repository = new EmployeeRepository();

            ContextState contextStateOb = _repository.AddEmployee(txtNationalID.Value, txtName.Value,
                txtBirthDate.Value, txtAddress.Value, txtPhoneNumber.Value, txtPhoto.Value, txtHireDate.Value,
                txtJoinDate.Value, employeeEducationList.Value,txtSubscriptionFee.Value,subscriptionFeeYears.Value);
            if (contextStateOb.State)
            {
                //Response.Write("Employee has been added  sucssefly.");
                Response.Redirect("~/Views/Employee/list.aspx");
            }
            else
            {
                Response.Write(contextStateOb.ErrorMessage);
            }
        }
    }
}
