using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeBox.Views.Employee.Qualifications
{
    public partial class Add : System.Web.UI.Page
    {

        private EmployeeBox.App_Code.EmployeeRepository _repository;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAdd_ServerClick(object sender, EventArgs e)
        {

            _repository = new EmployeeBox.App_Code.EmployeeRepository();

            EmployeeBox.ViewModels.ContextState contextStateOb = _repository.AddEducationalQualification(txtEducationalQualificationName.Value);
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