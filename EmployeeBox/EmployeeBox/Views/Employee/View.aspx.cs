using EmployeeBox.App_Code;
using System;
using System.Web.UI;

namespace EmployeeBox.Views.Employee
{
    public partial class View : Page
    {
        private EmployeeRepository _repository;
        protected void Page_Load(object sender, EventArgs e)
        {
            _repository = new EmployeeRepository();
            var model = _repository.FindEmployeeById(Convert.ToInt32(Request.QueryString["id"]));
            employeeForm.DataSource = new object[] { model };
            DataBind();
        }
    }
}