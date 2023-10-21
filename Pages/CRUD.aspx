<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="WebBancoITM.Pages.CRUD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    CRUD
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
     
    </style>
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form runat="server" class="container mt-5">
        <div class="row">
            <!-- Sección Izquierda -->
            <div class="col-md-6">
                <div class="text-center mb-4">
                    <asp:Label runat="server" CssClass="h2" ID="lbltitulo">Formulario</asp:Label>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="mb-3">
                            <label class="form-label">ID de Usuario</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtIdUsuario"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="mb-3">
                            <label class="form-label">Nombre</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="tbnombre"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="mb-3">
                            <label class="form-label">Apellidos</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="tbapellidos"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="mb-3">
                            <label class="form-label">Valor de la Vivienda</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="tbvalorvivienda"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <asp:Button runat="server" CssClass="btn btn-primary btn-warning" ID="Button1" Text="Calcular" Visible="true" OnClick="BtnCalcular_Click" />
                        <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnCreate" Text="Create" Visible="false" OnClick="BtnCreate_Click" />
                        <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnUpdate" Text="Update" Visible="false" OnClick="BtnUpdate_Click" />
                        <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnDelete" Text="Delete" Visible="false" OnClick="BtnDelete_Click" />
                        <asp:Button runat="server" CssClass="btn btn-primary btn-dark" ID="BtnVolver" Text="Volver" Visible="true" OnClick="BtnVolver_Click" />
                    </div>
                </div>
            </div>

            <!-- Sección Derecha -->
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-6">
                        <div class="mb-3">
                            <label class="form-label">Porcentaje Cuota Inicial %</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="tbPorcentajeCuotaInicial"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="mb-3">
                            <label class="form-label">Valor Cuota Inicial</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="tbValorCuotaInicial"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6">
                        <div class="mb-3">
                            <label class="form-label">Tasa %</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="tbTasa" Text="1.15"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="mb-3">
                            <label class="form-label">Plazo (Meses)</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="tbPlazo" Text="240"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="mb-3">
                    <label class="form-label">Crédito</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="tbValorCredito"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Valor del Beneficio</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="tbValorBeneficio"></asp:TextBox>
                </div>

                <div class="row">
                 <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="mb-3">
                                                <label class="form-label">Cuota Sin Beneficio</label>
                                                <asp:TextBox runat="server" CssClass="form-control" ID="tbCuotaSinBeneficio"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="mb-3">
                                                <label class="form-label">Cuota Con Beneficio</label>
                                                <asp:TextBox runat="server" CssClass="form-control" ID="tbCuotaConBeneficio"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>


            <div class="col-md-12">
                <asp:Label runat="server" CssClass="text-danger" ID="lblMensajeError"></asp:Label>
            </div>
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
</asp:Content>
