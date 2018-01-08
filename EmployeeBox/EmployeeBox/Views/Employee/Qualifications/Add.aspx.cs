using EmployeeBox.App_Code;
using EmployeeBox.ViewModels;
using System;
using System.Web.UI;

namespace EmployeeBox.Views.Employee.Qualifications
{
    public partial class Add : Page
    {

        private EmployeeRepository _repository;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAdd_ServerClick(object sender, EventArgs e)
        {

            _repository = new EmployeeRepository();

            ContextState contextStateOb = _repository.AddEducationalQualification(txtEducationalQualificationName.Value);
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