﻿using EmployeeBox.Models;
using EmployeeBox.ViewModels;
using System;
using System.Collections.Generic;

namespace EmployeeBox.Common.Factories
{
    interface IEmployeeRepository : IDisposable
    {
        ContextState Create(Employee model);
        ContextState Edit(Employee model);
        ContextState Delete(Employee model);
        IEnumerable<Employee> List(int? page = 1 , int? pageSize = 10);
        IEnumerable<Employee> List(string employeeName = null,decimal? nationalID = null,
            DateTime? hireDateFrom = null,DateTime? hireDateTo=null,
            DateTime? joinDateFrom = null,DateTime? joinDateTo = null,
            double? employeeShareFrom = 0,double? employeeShareTo = 0,
            int? employeeEducation = 0, int? page = 1, int? pageSize = 10);
        Employee Find(int id);
        bool IsExist(string emplyeeName = null, decimal? nationalID = null);
        IEnumerable<EducationalQualification> EducationalQualificationList();
    }
}
