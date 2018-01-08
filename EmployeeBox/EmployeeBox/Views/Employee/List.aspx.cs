using EmployeeBox.App_Code;
using EmployeeBox.ViewModels;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeBox.Views.Employee
{
    public partial class List : Page
    {
        private EmployeeRepository _repository;
        private CommonRepository _common;

        #region Form_Events
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmployeeShareFrom.Attributes["type"] = "number";
            txtEmployeeShareTo.Attributes["type"] = "number";

            _repository = new EmployeeRepository();
            _common = new CommonRepository();

            if (!Page.IsPostBack)
            {
                PopulateTable();

                employeeEducationList.DataSource = _repository.SelectEducationalQualification();
                employeeEducationList.DataValueField = "EducationalQualificationID";
                employeeEducationList.DataTextField = "EducationalQualificationName";
                employeeEducationList.DataBind();
                employeeEducationList.Items.Insert(0, new ListItem("أختر المؤهل التعليمي", "0"));
            }
        }
        #endregion

        #region Button_Events
        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            var _employee = new EmployeeViewModel();

            if (!string.IsNullOrEmpty(txtName.Value))
                _employee.Name = txtName.Value;

            if (!string.IsNullOrEmpty(txtNationalID.Value))
                _employee.NationalID = decimal.Parse(txtNationalID.Value.ToString());

            if (!string.IsNullOrEmpty(txtHireDateFrom.Value))
                _employee.HireDateFrom = DateTime.ParseExact(txtHireDateFrom.Value, "dd/MM/yyyy", null);

            if (!string.IsNullOrEmpty(txtHireDateTo.Value))
                _employee.HireDateFrom = DateTime.ParseExact(txtHireDateTo.Value, "dd/MM/yyyy", null);

            if (!string.IsNullOrEmpty(txtJoinDateFrom.Value))
                _employee.JoinDateFrom = DateTime.ParseExact(txtJoinDateFrom.Value, "dd/MM/yyyy", null);

            if (!string.IsNullOrEmpty(txtJoinDateTo.Value))
                _employee.JoinDateTo = DateTime.ParseExact(txtJoinDateTo.Value, "dd/MM/yyyy", null);

            if (!string.IsNullOrEmpty(txtEmployeeShareFrom.Value))
                _employee.EmployeeShareFrom = double.Parse(txtEmployeeShareFrom.Value);

            if (!string.IsNullOrEmpty(txtEmployeeShareTo.Value))
                _employee.EmployeeShareTo = double.Parse(txtEmployeeShareTo.Value);

            if (employeeEducationList.Value != "0")
                _employee.EducationalQualifications = Convert.ToInt32(employeeEducationList.Value);


            PopulateTable(1, 3, _employee.Name, _employee.NationalID,
                          _employee.HireDateFrom, _employee.HireDateTo, _employee.JoinDateFrom, _employee.JoinDateTo,
                          _employee.EmployeeShareFrom, _employee.EmployeeShareTo, _employee.EducationalQualifications);
        }
        #endregion

        #region Popualte_Table_With_Rows
        private void PopulateTable(int? page = 1, int? pageSize = 10, string employeeName = null,
            decimal? nationalID = default(decimal?),
            DateTime? hireDateFrom = default(DateTime?), DateTime? hireDateTo = default(DateTime?),
            DateTime? joinDateFrom = default(DateTime?), DateTime? joinDateTo = default(DateTime?),
            double? employeeShareFrom = default(double?), double? employeeShareTo = default(double?),
            int? employeeEducation = 0)
        {
            dt.DataSource = _repository.EmployeeList(page,pageSize, employeeName,nationalID,hireDateFrom,
                hireDateTo,joinDateFrom,joinDateTo,employeeShareFrom,employeeShareTo,employeeEducation);
            dt.CurrentPageIndex = 0;
            dt.DataBind();
        }
        #endregion

        #region DataTable_Events
        protected void dt_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dt.CurrentPageIndex = e.NewPageIndex;
            PopulateTable(e.NewPageIndex);
        }

        protected void dt_SortCommand(object source, DataGridSortCommandEventArgs e)
        {

        }
        #endregion
    }
}