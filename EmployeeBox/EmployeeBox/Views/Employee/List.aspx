<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="EmployeeBox.Views.Employee.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <!--Top header start-->
        <h3 class="ls-top-header">الموظفين</h3>
        <!--Top header end -->

        <!--Top breadcrumb start -->
        <ol class="breadcrumb">
            <li><a href="/"><i class="fa fa-home"></i></a></li>
            <li class="active">الموظفين</li>
        </ol>
        <!--Top breadcrumb start -->
    </div>
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">بحث متقدم</h3>
                <ul class="panel-control">
                    <li><a class="minus" href="javascript:void(0)"><i class="fa fa-minus"></i></a></li>
                    <li><a class="refresh" href="javascript:void(0)"><i class="fa fa-refresh"></i></a></li>
                    <li><a class="close-panel" href="javascript:void(0)"><i class="fa fa-times"></i></a></li>
                </ul>
            </div>

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
                        <label class="col-md-3 control-label">تاريخ التعيين من </label>
                        <div class="col-md-3">
                            <input type="text" id="txtHireDateFrom" runat="server" class="form-control datePickerOnly" />
                        </div>

                        <label class="col-md-3 control-label">تاريخ التعيين إلى </label>
                        <div class="col-md-3">
                            <input type="text" id="txtHireDateTo" runat="server" class="form-control datePickerOnly" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-md-3 control-label">تاريخ الإنضمام من </label>
                        <div class="col-md-3">
                            <input type="text" id="txtJoinDateFrom" runat="server" class="form-control datePickerOnly" />
                        </div>

                        <label class="col-md-3 control-label">تاريخ الإنضمام إلى </label>
                        <div class="col-md-3">
                            <input type="text" id="txtJoinDateTo" runat="server" class="form-control datePickerOnly" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-md-3 control-label">حصة الموظف من</label>
                        <div class="col-md-3">
                            <input type="text" id="txtEmployeeShareFrom" min="0" runat="server" class="form-control"  />
                        </div>
                        <label class="col-md-3 control-label">حصة الموظف الى</label>
                        <div class="col-md-3">
                            <input type="text" id="txtEmployeeShareTo" min="0" runat="server" class="form-control"  />
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <input type="reset" id="btnReset" class="btn btn-danger pull-right" value="إلغاء" />
                    <input type="submit" id="btnSearch" runat="server" onserverclick="btnSearch_ServerClick" class="btn btn-primary pull-right" value="بحث" />
                </div>
            </div>
        </div>
    </div>

    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">عرض</h3>
                <ul class="panel-control">
                    <li><a class="minus" href="javascript:void(0)"><i class="fa fa-minus"></i></a></li>
                    <li><a class="refresh" href="javascript:void(0)"><i class="fa fa-refresh"></i></a></li>
                    <li><a class="close-panel" href="javascript:void(0)"><i class="fa fa-times"></i></a></li>
                </ul>
            </div>

            <div class="panel-body">
                <div class="table-responsive ls-table">
                    <asp:DataGrid AllowPaging="True"
                         runat="server" ID="dt" AllowSorting="True"
                        OnPageIndexChanged="dt_PageIndexChanged"
                         OnSortCommand="dt_SortCommand" CssClass="table table-bordered table-striped ls-animated-table"
                        PagerStyle-CssClass="ls-button-group demo-btn ls-table-pagination" AutoGenerateColumns="False" PageSize="10">
                        <Columns>
                            <asp:TemplateColumn HeaderText="المسلسل">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EmployeeID") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EmployeeID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="الإسم">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="صورة الموظف">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Photo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Photo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="المؤهل الوظيفى">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EducationalQualificationName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EducationalQualificationName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="تاريخ التعيين">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.HireDate") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.HireDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="تاريخ الإشتراك">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.JoinDate") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.JoinDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="الصلاحيات">
                                <ItemTemplate>
                                    <a href="View.aspx?id=<%# DataBinder.Eval(Container, "DataItem.EmployeeID") %>" data-value='<%# DataBinder.Eval(Container, "DataItem.EmployeeID") %>' title="عرض" class="btn btn-xs btn-success"><i class="fa fa-eye"></i></a>
                                    <a href="Edit.aspx?id=<%# DataBinder.Eval(Container, "DataItem.EmployeeID") %>" data-value='<%# DataBinder.Eval(Container, "DataItem.EmployeeID") %>' title="تعديل"  class="btn btn-xs btn-warning"><i class="fa fa-pencil-square-o"></i></a>
                                    <a href="Delete.aspx?id=<%# DataBinder.Eval(Container, "DataItem.EmployeeID") %>" data-value='<%# DataBinder.Eval(Container, "DataItem.EmployeeID") %>' title="حذف" class="btn btn-xs btn-danger"><i class="fa fa-minus"></i></a>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False" />
                        <PagerStyle Mode="NumericPages" PageButtonCount="5" HorizontalAlign="Center"
                             Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
                    </asp:DataGrid>
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
