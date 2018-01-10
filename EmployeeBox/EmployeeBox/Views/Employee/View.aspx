<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="EmployeeBox.Views.Employee.View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <!--Top header start-->

        <h3 class="ls-top-header">عرض موظف</h3>
        <!--Top header end -->

        <!--Top breadcrumb start -->
        <ol class="breadcrumb">
            <li><a href="/"><i class="fa fa-home"></i></a></li>
            <li><a href="List.aspx">الموظفين</a></li>
            <li class="active">عرض موظف</li>
        </ol>
        <!--Top breadcrumb start -->
    </div>

    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">عرض موظف
                </h4>
            </div>
            <div class="panel-body">
                <div class="row">
                    <asp:DetailsView runat="server" ID="employeeForm" CssClass="col-md-12"
                        AutoGenerateRows="False" EnableTheming="True" GridLines="None">
                        <Fields>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="form-group">
                                        <label class="col-md-1 control-label">الإسم</label>
                                        <div class="col-md-3">
                                            <input type="text" value='<%# DataBinder.Eval(Container, "DataItem.Name") %>'
                                                class="form-control" readonly />
                                        </div>

                                        <label class="col-md-1 control-label">الرقم القومى</label>
                                        <div class="col-md-3">
                                            <input type="text" value='<%# DataBinder.Eval(Container, "DataItem.NationalID") %>'
                                                class="form-control" readonly />
                                        </div>

                                        <label class="col-md-1 control-label">المؤهل التعليمي</label>
                                        <div class="col-md-3">
                                            <input type="text" value='<%# DataBinder.Eval(Container, "DataItem.EducationalQualificationName") %>'
                                                class="form-control" readonly />
                                        </div>
                                    </div>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Fields>

                        <Fields>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="form-group">
                                        <label class="col-md-1 control-label">تاريخ الميلاد</label>
                                        <div class="col-md-3">
                                            <input type="text" value='<%# DataBinder.Eval(Container, "DataItem.BirthDate") %>'
                                                class="form-control datePickerOnly" readonly />
                                        </div>

                                        <label class="col-md-1 control-label">تاريخ التعيين</label>
                                        <div class="col-md-3">
                                            <input type="text" value='<%# DataBinder.Eval(Container, "DataItem.HireDateFrom") %>'
                                                 class="form-control datePickerOnly" readonly />
                                        </div>

                                        <label class="col-md-1 control-label">تاريخ الإنضمام</label>
                                        <div class="col-md-3">
                                            <input type="text" value='<%# DataBinder.Eval(Container, "DataItem.joinDateFrom") %>'
                                                class="form-control datePickerOnly" readonly />
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Fields>

                        <Fields>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="form-group">
                                        <label class="col-md-1 control-label">العنوان</label>
                                        <div class="col-md-3">
                                            <input type="text" value='<%# DataBinder.Eval(Container, "DataItem.Address") %>'
                                                class="form-control" readonly />
                                        </div>
                                        <label class="col-md-1 control-label">رقم التليفون</label>
                                        <div class="col-md-3">
                                            <input type="text" value='<%# DataBinder.Eval(Container, "DataItem.PhoneNumber") %>'
                                                 class="form-control" readonly />
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Fields>

                        <Fields>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="form-group">
                                        <label class="col-md-1 control-label">الصورة الشخصية</label>
                                        <div class="col-md-3">
                                            <input type="text" value='<%# DataBinder.Eval(Container, "DataItem.Photo") %>'
                                                class="form-control" readonly />
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Fields>

                        <Fields>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="form-group">
                                        <label class="col-md-1 control-label">أجر الأشتراك</label>
                                        <div class="col-md-3">
                                            <input type="text" value='<%# DataBinder.Eval(Container, "DataItem.SubscriptionFee") %>'
                                                class="form-control" readonly />
                                        </div>

                                        <label class="col-md-1 control-label">السنة</label>
                                        <div class="col-md-1">
                                            <input type="text" value='<%# DataBinder.Eval(Container, "DataItem.Year") %>'
                                                class="form-control" readonly />
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Fields>
                    </asp:DetailsView>
                </div>
            </div>
        </div>
    </div>

    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    ملفات الموظف
                </h4>
            </div>
            <div class="panel-body">

            </div>
        </div>
    </div>

</asp:Content>
