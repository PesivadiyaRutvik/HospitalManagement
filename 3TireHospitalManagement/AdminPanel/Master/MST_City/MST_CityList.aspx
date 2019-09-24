<%@ Page Title="" Language="C#" MasterPageFile="~/Default/AdminMaster.master" AutoEventWireup="true" CodeFile="MST_CityList.aspx.cs" Inherits="AdminPanel_MST_MST_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container" style="padding-top: 50px;">
        <div class="row">
            <div class="col-md-12">
                <h1>City List</h1>
            </div>
            <div class="col-md-12">
                <asp:HyperLink ID="hlCityAdd" runat="server" Text="Add New City" NavigateUrl="~/AdminPanel/City/CityAddEdit.aspx" CssClass="btn btn-outline-primary" />
                <asp:Label ID="lblMessege" runat="server"></asp:Label>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12" style="overflow-x: auto;">
                <br />
                <asp:Label runat="server" ID="lblMessage" EnableViewState="false" Style="color: red" />
                <br />
                <asp:GridView ID="gvCity" runat="server" AutoGenerateColumns="false" CssClass="table table-dark table-striped" OnRowCommand="GvCity_ItermCommand">
                    <Columns>
                        <asp:BoundField DataField="CityID" HeaderText="City ID" />
                        <asp:BoundField DataField="CityName" HeaderText="City Name" />
                        <asp:BoundField DataField="CreationDate" HeaderText="Creation date" />
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-outline-success btn-sm" NavigateUrl='<%# "~/AdminPanel/Master/MST_City/MST_CityAddEdit.aspx?CityID=" + Eval("CityID").ToString().Trim() %>'></asp:HyperLink>

                                <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-outline-danger btn-sm" Text="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("CityID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>


            </div>

        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

