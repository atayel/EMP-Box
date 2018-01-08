using System;
using System.Collections.Generic;
using EmployeeBox.Models;
using EmployeeBox.ViewModels;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Web;

namespace EmployeeBox.App_Code
{
    public class EmployeeRepository
    {
        SqlConnection _db;
        SqlCommand _com;
        public EmployeeRepository()
        {
            _db = new SqlConnection(ConnectionClass._connection);
            _com = new SqlCommand();
            _com.Connection = _db;
            _com.CommandTimeout = 30;
        }

        internal void Dispose()
        {
            _db.Close();
            _db.Dispose();
        }

        #region Create_Functions
        internal ContextState AddEmployee(string NationalID, string Name, string BirthDate, string Address, string PhoneNumber, string Photo, string HireDate, string JoinDate, string QualificationID, string SubscriptionFee, string Year)
        {
            try
            {
                _com.CommandText = @"INSERT INTO Employees (NationalID, Name, BirthDate, Address, PhoneNumber, Photo, HireDate, JoinDate) VALUES (@NationalID,@Name,@BirthDate,@Address,@PhoneNumber,@Photo,@HireDate,@JoinDate);
                                    DECLARE @variableEmployeeID int = @@IDENTITY;
                                    INSERT INTO EmployeeEducationalQualifications (EmployeeID, QualificationID) VALUES (@variableEmployeeID,@QualificationID)
                                    INSERT INTO EmployeeSubscriptionFee (EmployeeID, Year, SubscriptionFee) VALUES (@variableEmployeeID,@Year,@SubscriptionFee)";

                _com.Parameters.AddWithValue("@NationalID", NationalID);
                _com.Parameters.AddWithValue("@Name", Name);
                _com.Parameters.AddWithValue("@BirthDate", DateTime.ParseExact(BirthDate, "dd/MM/yyyy", null));
                _com.Parameters.AddWithValue("@Address", Address);
                _com.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                _com.Parameters.AddWithValue("@Photo", Photo);
                _com.Parameters.AddWithValue("@HireDate", DateTime.ParseExact(HireDate, "dd/MM/yyyy", null));
                _com.Parameters.AddWithValue("@JoinDate", DateTime.ParseExact(JoinDate, "dd/MM/yyyy", null));
                _com.Parameters.AddWithValue("@QualificationID", QualificationID);
                _com.Parameters.AddWithValue("@Year", Year);
                _com.Parameters.AddWithValue("@SubscriptionFee", SubscriptionFee);
                _db.Open();
                _com.ExecuteNonQuery();
                _db.Close();
                return new ContextState
                {
                    State = true,
                    FunctionName = MethodBase.GetCurrentMethod().Name,
                    ClassName = GetType().Name
                };
            }
            catch (HttpException ex)
            {
                return new ContextState
                {
                    State = false,
                    FunctionName = MethodBase.GetCurrentMethod().Name,
                    ClassName = GetType().Name,
                    ErrorMessage = ex.Message,
                    ErrorCode = ex.GetHttpCode()
                };
            }
        }
        internal ContextState AddEducationalQualification(string EducationalQualificationName)
        {
            try
            {
                _com.CommandText = @"INSERT INTO EducationalQualifications (EducationalQualificationName) VALUES (@EducationalQualificationName)";

                _com.Parameters.AddWithValue("@EducationalQualificationName", EducationalQualificationName);
                _db.Open();
                _com.ExecuteNonQuery();
                _db.Close();
                return new ContextState
                {
                    State = true
                };
            }
            catch (Exception ex)
            {
                return new ContextState
                {
                    State = false,
                    ErrorMessage = ex.Message,
                };
            }
        }
        internal ContextState Create(EmployeeState model)
        {
            try
            {
                _com.CommandText = @"INSERT INTO EmployeeStates
                      (Name, Description)
                            VALUES     ('" + model.Name + "', '" + model.Description + "')";
                _db.Open();
                _com.ExecuteNonQuery();
                _db.Close();
                return new ContextState
                {
                    State = true,
                    FunctionName = MethodBase.GetCurrentMethod().Name,
                    ClassName = GetType().Name
                };
            }
            catch (HttpException ex)
            {
                return new ContextState
                {
                    State = false,
                    FunctionName = MethodBase.GetCurrentMethod().Name,
                    ClassName = GetType().Name,
                    ErrorMessage = ex.Message,
                    ErrorCode = ex.GetHttpCode()
                };
            }
        }

        #endregion

        #region Edit_Functions
        internal ContextState Edit(Employee model)
        {
            try
            {
                _com.CommandText = @"UPDATE    Employees
            SET NationalID = " + model.NationalID + " , Name ='" + model.Name + "', BirthDate = " + model.BirthDate
            + ", Address = '" + model.Address + "', PhoneNumber = " + model.PhoneNumber + ", Photo = '" + model.Photo
            + "', HireDate = " + model.HireDate + " , JoinDate = " + model.JoinDate + ", EmployeeStateLogID = " + model.EmployeeStateLogID
            + " WHERE (EmployeeID = " + model.EmployeeID + ")";
                return new ContextState
                {
                    State = true,
                    FunctionName = MethodBase.GetCurrentMethod().Name,
                    ClassName = GetType().Name
                };
            }
            catch (HttpException ex)
            {
                return new ContextState
                {
                    State = false,
                    FunctionName = MethodBase.GetCurrentMethod().Name,
                    ClassName = GetType().Name,
                    ErrorMessage = ex.Message,
                    ErrorCode = ex.GetHttpCode()
                };
            }
        }
        #endregion

        #region Delete_Functions
        internal ContextState Delete(Employee model)
        {
            try
            {
                _com.CommandText = @"DELETE FROM Employees
                WHERE     (EmployeeID = " + model.EmployeeID + ")";
                _db.Open();
                _com.ExecuteNonQuery();
                _db.Close();
                return new ContextState
                {
                    State = true,
                    FunctionName = MethodBase.GetCurrentMethod().Name,
                    ClassName = GetType().Name
                };
            }
            catch (HttpException ex)
            {
                return new ContextState
                {
                    State = false,
                    FunctionName = MethodBase.GetCurrentMethod().Name,
                    ClassName = GetType().Name,
                    ErrorMessage = ex.Message,
                    ErrorCode = ex.GetHttpCode()
                };
            }
        }
        #endregion

        #region Find_Functions
        internal Employee FindEmployeeById(int id)
        {
            var model = new Employee();
            _com.CommandText = @"SELECT     EmployeeID, NationalID, Name, BirthDate, Address,
                PhoneNumber, Photo, HireDate, JoinDate, EmployeeStateLogID FROM         Employees
                WHERE     (EmployeeID = " + id + ")";

            _db.Open();
            SqlDataReader _dr = _com.ExecuteReader(CommandBehavior.SingleRow);
            if (_dr.HasRows)
                while (_dr.Read())
                {
                    model.EmployeeID = Convert.ToInt32(_dr["EmployeeID"]);
                    model.Name = _dr["Name"].ToString();
                    model.NationalID = decimal.Parse(_dr["NationalID"].ToString());
                    model.BirthDate = DateTime.ParseExact(_dr["BirthDate"].ToString(), "dd/MM/yyyy", null);
                    model.Address = _dr["Address"].ToString();
                    model.PhoneNumber = decimal.Parse(_dr["PhoneNumber"].ToString());
                    model.Photo = _dr["Photo"].ToString();
                    model.HireDate = DateTime.ParseExact(_dr["HireDate"].ToString(), "dd/MM/yyyy", null);
                    model.JoinDate = DateTime.ParseExact(_dr["JoinDate"].ToString(), "dd/MM/yyyy", null);
                    model.EmployeeStateLogID = Convert.ToInt32(_dr["EmployeeStateLogID"].ToString());
                }

            _dr.Close();
            _db.Close();

            return model;
        }
        #endregion

        #region EmployeeList_Functions
        internal IEnumerable<Employee> EmployeesList(int? page = 1, int? pageSize = 10)
        {
            List<Employee> _list = new List<Employee>();
            _com.CommandText = @"SELECT     EmployeeID, NationalID, Name, BirthDate,
            Address, PhoneNumber, Photo, HireDate, JoinDate
            FROM         Employees
            WHERE     EmployeeID BETWEEN ((" + page + " -1 ) * " + pageSize + " + 1)  AND (" + page + " * " + pageSize + ")";
            _db.Open();
            SqlDataReader _dr = _com.ExecuteReader();
            if (_dr.HasRows)
                while (_dr.Read())
                {
                    _list.Add(new Employee
                    {
                        EmployeeID = Convert.ToInt32(_dr[0]),
                        NationalID = decimal.Parse(_dr[1].ToString()),
                        Name = _dr[2].ToString(),
                        BirthDate = Convert.ToDateTime(_dr[3].ToString()),
                        Address = _dr[4].ToString(),
                        PhoneNumber = decimal.Parse(_dr[5].ToString()),
                        Photo = _dr[6].ToString(),
                        HireDate = Convert.ToDateTime(_dr[7].ToString()),
                        JoinDate = Convert.ToDateTime(_dr[8].ToString())
                    });
                }

            _dr.Close();
            _db.Close();
            return _list;
        }

        internal IEnumerable<Employee> EmployeesList(string employeeName = null,
            decimal? nationalID = default(decimal?),
            DateTime? hireDateFrom = default(DateTime?), DateTime? hireDateTo = default(DateTime?),
            DateTime? joinDateFrom = default(DateTime?), DateTime? joinDateTo = default(DateTime?),
            double? employeeShareFrom = default(double?), double? employeeShareTo = default(double?),
            int? employeeEducation = 0, int? page = 1, int? pageSize = 10)
        {
            var _query = @"SELECT     Employees.EmployeeID, Employees.NationalID, Employees.Name, Employees.BirthDate, Employees.Address, Employees.PhoneNumber, Employees.Photo, Employees.HireDate, 
                      Employees.JoinDate, EducationalQualifications.EducationalQualificationName, EmployeeShares.PersonalShare
FROM         Employees LEFT JOIN
                      EmployeeEducationalQualifications ON Employees.EmployeeID = EmployeeEducationalQualifications.EmployeeID LEFT JOIN
                      EducationalQualifications ON EmployeeEducationalQualifications.EducationalQualificationID = EducationalQualifications.EducationalQualificationID LEFT JOIN
                      EmployeeShares ON Employees.EmployeeID = EmployeeShares.EmployeeID
            WHERE     Employees.EmployeeID BETWEEN ((" + page + " -1 ) * " + pageSize + " +1)  AND (" + page + " * " + pageSize + ")";

            if (employeeName != string.Empty)
                _query += @" AND ( Employees.Name LIKE '%" + employeeName + "%' )";

            if (nationalID > 0)
                _query += @" AND ( Employees.NationalID  LIKE %" + nationalID + "% )";

            if (hireDateFrom != null && hireDateTo != null)
                _query += @" AND ( Employees.HireDate >= '" + hireDateFrom + "' AND  Employees.HireDate <= '" + hireDateTo + "')";
            else if (hireDateFrom != null && hireDateTo == null)
                _query += @" AND ( Employees.HireDate >= '" + hireDateFrom + "')";

            if (joinDateFrom != null && joinDateTo != null)
                _query += @" AND ( Employees.JoinDate >= '" + joinDateFrom + "' AND  Employees.JoinDate <= '" + joinDateTo + "')";
            else if (joinDateFrom != null && joinDateTo == null)
                _query += @"AND ( Employees.JoinDate >= '" + joinDateFrom + "')";

            if (employeeEducation > 0)
                _query += @" AND (EducationalQualifications.EducationalQualificationID = " + employeeEducation + ")";

            if (employeeShareFrom > 0 && employeeShareTo > 0)
                _query += @"AND     (EmployeeShares.PersonalShare >=  " + employeeShareFrom + " AND EmployeeShares.PersonalShare <= " + employeeShareTo + ")";
            else if (employeeShareFrom > 0 && employeeShareTo <= 0)
                _query += @" AND     (EmployeeShares.PersonalShare >=  " + employeeShareFrom + ")";

            List<Employee> _list = new List<Employee>();
            _com.CommandText = _query;
            _db.Open();
            SqlDataReader _dr = _com.ExecuteReader();
            if (_dr.HasRows)
                while (_dr.Read())
                {
                    _list.Add(new Employee
                    {
                        EmployeeID = Convert.ToInt32(_dr[0]),
                        NationalID = decimal.Parse(_dr[1].ToString()),
                        Name = _dr[2].ToString(),
                        BirthDate = Convert.ToDateTime(_dr[3].ToString()),
                        Address = _dr[4].ToString(),
                        PhoneNumber = decimal.Parse(_dr[5].ToString()),
                        Photo = _dr[6].ToString(),
                        HireDate = Convert.ToDateTime(_dr[7].ToString()),
                        JoinDate = Convert.ToDateTime(_dr[8].ToString())
                    });
                }

            _dr.Close();
            _db.Close();
            return _list;
        }
        #endregion

        #region EducationalQualificationList_Functions
        internal IEnumerable<EducationalQualification> EducationalQualificationList(int? page = 1, int? pageSize = 10)
        {
            List<EducationalQualification> _list = new List<EducationalQualification>();
            _com.CommandText = @"SELECT     EducationalQualifications.EducationalQualificationID, EducationalQualifications.EducationalQualificationName, Employees.Name, Employees.Photo, Employees.HireDate
FROM         EducationalQualifications INNER JOIN
                      EmployeeEducationalQualifications ON EducationalQualifications.EducationalQualificationID = EmployeeEducationalQualifications.EducationalQualificationID INNER JOIN
                      Employees ON EmployeeEducationalQualifications.EmployeeID = Employees.EmployeeID
            WHERE     EducationalQualifications.EducationalQualificationID BETWEEN ((" + page + " -1 ) * " + pageSize + " + 1)  AND (" + page + " * " + pageSize + ")";
            _db.Open();
            SqlDataReader _dr = _com.ExecuteReader();
            if (_dr.HasRows)
                while (_dr.Read())
                {
                    _list.Add(new EducationalQualification
                    {
                        EducationalQualificationID = Convert.ToInt32(_dr[0]),
                        EducationalQualificationName = _dr[1].ToString()
                    });
                }

            _dr.Close();
            _db.Close();
            return _list;
        }

        internal IEnumerable<EducationalQualification> EducationalQualificationList(string educationalQualificationName = null,
            string employeeName = null, int? page = 1, int? pageSize = 10)
        {
            var _query = @"SELECT     Employees.EmployeeID, Employees.NationalID, Employees.Name, Employees.BirthDate, Employees.Address, Employees.PhoneNumber, Employees.Photo, Employees.HireDate, 
                      Employees.JoinDate, Employees.EmployeeStateLogID, EducationalQualifications.EducationalQualificationName, EmployeeShares.PersonalShare
FROM         Employees LEFT JOIN
                      EmployeeEducationalQualifications ON Employees.EmployeeID = EmployeeEducationalQualifications.EmployeeID LEFT JOIN
                      EducationalQualifications ON EmployeeEducationalQualifications.EducationalQualificationID = EducationalQualifications.EducationalQualificationID LEFT JOIN
                      EmployeeShares ON Employees.EmployeeID = EmployeeShares.EmployeeID
            WHERE     Employees.EmployeeID BETWEEN ((" + page + " -1 ) * " + pageSize + " +1)  AND (" + page + " * " + pageSize + ")";

            if (employeeName != string.Empty)
                _query += @" AND ( Employees.Name LIKE '%" + employeeName + "%' )";

            if (educationalQualificationName != string.Empty)
                _query += @" AND ( EducationalQualifications.EducationalQualificationName LIKE '%" + educationalQualificationName + "%' )";

            List<EducationalQualification> _list = new List<EducationalQualification>();
            _com.CommandText = _query;
            _db.Open();
            SqlDataReader _dr = _com.ExecuteReader();
            if (_dr.HasRows)
                while (_dr.Read())
                {
                    _list.Add(new EducationalQualification
                    {
                    });
                }

            _dr.Close();
            _db.Close();
            return _list;
        }

        internal IEnumerable<EducationalQualification> EducationalQualificationList()
        {
            List<EducationalQualification> _list = new List<EducationalQualification>();
            _com.CommandText = @"SELECT     EducationalQualificationID, EducationalQualificationName
FROM         EducationalQualifications";
            _db.Open();
            SqlDataReader _dr = _com.ExecuteReader();
            if (_dr.HasRows)
                while (_dr.Read())
                {
                    _list.Add(new EducationalQualification
                    {
                        EducationalQualificationID = Convert.ToInt32(_dr[0]),
                        EducationalQualificationName = _dr[1].ToString()
                    });
                }

            _dr.Close();
            _db.Close();
            return _list;
        }
        public DataTable selectEducationalQualification()
        {
            SqlDataAdapter dataAd = new SqlDataAdapter("SELECT EducationalQualificationID, EducationalQualificationName FROM EducationalQualifications", _db);
            DataTable dt = new DataTable();
            dataAd.Fill(dt);
            return dt;
        }
        #endregion

        #region IsExist_Functions
        internal bool IsEmployeeExist(string emplyeeName = null, decimal? nationalID = default(decimal?))
        {
            bool _exist = false;
            var model = new Employee();
            _com.CommandText = @"SELECT     EmployeeID, NationalID, Name, BirthDate, Address,
                PhoneNumber, Photo, HireDate, JoinDate, EmployeeStateLogID FROM         Employees
                WHERE     (NationalID = " + nationalID + " AND Name = '" + emplyeeName + "')";

            _db.Open();
            SqlDataReader _dr = _com.ExecuteReader(CommandBehavior.SingleRow);
            if (_dr.HasRows)
                _exist = true;

            _dr.Close();
            _db.Close();
            return _exist;
        }
        #endregion
    }
}