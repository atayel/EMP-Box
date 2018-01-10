using System;

namespace EmployeeBox.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }

        public decimal? NationalID { get; set; }

        public string Name { get; set; }

        public string Photo { get; set; }

        public string Address { get; set; }

        public decimal? PhoneNumber { get; set; }

        public DateTime? HireDateFrom { get; set; }

        public DateTime? HireDateTo { get; set; }

        public DateTime? JoinDateFrom { get; set; }

        public DateTime? JoinDateTo { get; set; }

        public DateTime? BirthDate { get; set; }

        public int? Year { get; set; }

        public double? EmployeeShareFrom { get; set; }

        public double? EmployeeShareTo { get; set; }

        public int? EducationalQualifications { get; set; }

        public string EducationalQualificationName { get; set; }

        public decimal? SubscriptionFee { get; set; }

    }
}