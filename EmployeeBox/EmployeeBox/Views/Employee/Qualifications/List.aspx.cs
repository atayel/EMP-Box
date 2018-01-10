using EmployeeBox.App_Code;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeBox.Views.Employee.Qualifications
{
    public partial class List : Page
    {
        private EmployeeRepository _repository;

        #region Page_Events
        protected void Page_Load(object sender, EventArgs e)
        {
            _repository = new EmployeeRepository();
            if(!Page.IsPostBack)
            {
                PopulateTable();
            }
        }
        #endregion

        #region Buttons_Events
        protected void btnSearch_ServerClick(object sender,EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Value))
                PopulateTable(1, 10, txtName.Value);
        }
        #endregion

        #region DataTable_Methods
        protected void dt_SortCommand(object source, DataGridSortCommandEventArgs e)
        {

        }

        protected void dt_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dt.CurrentPageIndex = e.NewPageIndex;
            PopulateTable(e.NewPageIndex);
        }
        #endregion

        #region PopulateTable_Method
        private void PopulateTable(int? page = 1, int? pageSize = 10,string EducationalQualificationName = null)
        {
            dt.DataSource = _repository.SelectEducationalQualification(page, pageSize, EducationalQualificationName);
            dt.CurrentPageIndex = 0;
            dt.DataBind();
        }
        #endregion
    }
}