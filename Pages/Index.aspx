<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebBancoITM.Pages.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            max-width: 1200px;
            margin: auto;
        }
        .banner-container {
            background-image: url('http://palamond1.sg-host.com/wp-content/uploads/2023/10/portada-scaled.jpg');
            background-size: center;
            background-position: center;
            height: 300px; /* Ajusta la altura del banner según tus necesidades */
        }

        .table-container {
            margin-top: 20px;
            text-align: center;
        }

        .table-container table {
            width: auto;
            margin: 0 auto;
            border-collapse: collapse;
        }

        .table-container th, .table-container td {
            border: 1px solid #dddddd;
            padding: 6px;
            text-align: left;
        }

        .table-container th {
            background-color: #f2f2f2;
        }

        .options-buttons {
            display: flex;
            justify-content: space-around;
        }

        .options-buttons button {
            padding: 6px 12px;
            font-size: 12px;
        }

        .options-header {
            font-size: 14px;
            font-weight: bold;
        }
    </style>

    <script type="text/javascript">
        // Función JavaScript que se ejecutará al hacer clic en el botón "Read"
        function onReadButtonClick() {

        }

        // Función JavaScript que se ejecutará al hacer clic en el botón "Update"
        function onUpdateButtonClick() {

        }

        // Función JavaScript que se ejecutará al hacer clic en el botón "Delete"
        function onDeleteButtonClick() {

        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="banner-container"></div>
    <form runat="server">
        <div class="container text-center">
            <h2>Listado de Registros</h2>
            <asp:Button runat="server" ID="BtnCreate" CssClass="btn btn-success" Text="Crear Nuevo Registro" OnClick="BtnCreate_Click" />
        </div>
        <div class="container table-container">
            <asp:GridView runat="server" ID="gvusuarios" CssClass="table table-bordered">
                <Columns>
                    <asp:TemplateField HeaderText="Opciones del administrador">
                        <ItemTemplate>
                            <div class="options-buttons">
                                <asp:Button runat="server" Text="Read" CssClass="btn btn-info btn-sm" ID="BtnRead" OnClick="BtnRead_Click" OnClientClick="onReadButtonClick();" />
                                <asp:Button runat="server" Text="Update" CssClass="btn btn-warning btn-sm" ID="BtnUpdate" OnClick="BtnUpdate_Click" OnClientClick="onUpdateButtonClick();" />
                                <asp:Button runat="server" Text="Delete" CssClass="btn btn-danger btn-sm" ID="BtnDelete" OnClick="BtnDelete_Click" OnClientClick="onDeleteButtonClick();" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="options-header" />
                <RowStyle CssClass="options-row" />
            </asp:GridView>
        </div>
    </form>
</asp:Content>
