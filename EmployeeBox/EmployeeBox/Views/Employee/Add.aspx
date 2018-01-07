<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="EmployeeBox.Views.Employee.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <!--Top header start-->

        <h3 class="ls-top-header">أضافة موظف</h3>
        <!--Top header end -->

        <!--Top breadcrumb start -->
        <ol class="breadcrumb">
            <li><a href="/"><i class="fa fa-home"></i></a></li>
            <li class="active">الموظفين</li>
            <li class="active">أضافة موظف</li>
        </ol>
        <!--Top breadcrumb start -->
    </div>
    <div class="col-md-12">
        <div class="panel">
            <div class="panel-body">
                <div class="row">
                    <div class="form-group">
                        <label class="col-md-1 control-label">الإسم</label>
                        <div class="col-md-3">
                            <input type="text" id="txtName" runat="server" class="form-control" />
                        </div>

                        <label class="col-md-1 control-label">الرقم القومى</label>
                        <div class="col-md-3">
                            <input type="text" id="txtNationalID" runat="server" class="form-control" min="00000000000000" max="99999999999999" />
                        </div>


                        <label class="col-md-1 control-label">المؤهل التعليمي</label>
                        <div class="col-md-3">
                            <select id="employeeEducationList" runat="server" class="demo-default selectized selectList">
                            </select>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-md-3 control-label">تاريخ الميلاد</label>
                        <div class="col-md-3">
                            <input type="text" id="txtBirthDate" runat="server" class="form-control datePickerOnly" />
                        </div>

                        <label class="col-md-3 control-label">تاريخ التعيين</label>
                        <div class="col-md-3">
                            <input type="text" id="txtHireDate" runat="server" class="form-control datePickerOnly" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-md-3 control-label">تاريخ الإنضمام</label>
                        <div class="col-md-3">
                            <input type="text" id="txtJoinDate" runat="server" class="form-control datePickerOnly" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-md-3 control-label">العنوان</label>
                        <div class="col-md-3">
                            <input type="text" id="txtAddress" min="0" runat="server" class="form-control" />
                        </div>
                        <label class="col-md-3 control-label">رقم التليفون</label>
                        <div class="col-md-3">
                            <input type="text" id="txtPhoneNumber" min="0" runat="server" class="form-control" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-md-3 control-label">الصورة</label>
                        <div class="col-md-3">
                            <input type="text" id="txtPhoto" min="0" runat="server" class="form-control" />
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <input type="reset" id="btnReset" class="btn btn-danger pull-right" value="إلغاء" />
                    <input type="submit" id="btnAdd" runat="server" onserverclick="btnAdd_ServerClick" class="btn btn-primary pull-right" value="أضافة" />
                </div>
            </div>
        </div>
    </div>

    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            $('.selectList').selectize();

            $('.datePickerOnly').datetimepicker({
                timepicker: false,
                datepicker: true,
                mask: '',
                format: 'd/m/Y'
            });
        });
    </script>
</asp:Content>
