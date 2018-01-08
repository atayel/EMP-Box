<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="EmployeeBox.Views.Employee.Qualifications.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <!--Top header start-->
        <h3 class="ls-top-header">أضافة مؤهل وظيفي</h3>
        <!--Top header end -->

        <!--Top breadcrumb start -->
        <ol class="breadcrumb">
            <li><a href="/"><i class="fa fa-home"></i></a></li>
            <li class="active">الموظفين</li>
            <li class="active">أضافة مؤهل</li>
        </ol>
        <!--Top breadcrumb start -->
    </div>
    <div class="col-md-12">
        <div class="panel">
            <div class="panel-body">
                <div class="row">
                    <div class="form-group">
                        <label class="col-md-1 control-label">أسم المؤهل الدراسي</label>
                        <div class="col-md-3">
                            <input type="text" id="txtEducationalQualificationName" runat="server" class="form-control" />
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
</asp:Content>
