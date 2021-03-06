<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WfmVehiculoNuevo.aspx.cs" Inherits="Presentacion.WebForms.Administracion.Vehiculos.WfmVehiculoNuevo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     
    <table align="center">
        <tr>
            <td colspan="2">
                <h3 align="center"><strong>Vehículo Nuevo</strong></h3>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table style="height: 35px; width: 98%;">
                    <tr>
                        <td>
                            <asp:ImageButton ID="imbNuevo" runat="server" Width="32px" Height="32px" ImageUrl="~/images/Nuevo.png" CausesValidation="false" />
                            <asp:LinkButton ID="lnkNuevo" runat="server" CausesValidation="false">Nuevo</asp:LinkButton>
                        </td>
                        <td>
                            <asp:ImageButton ID="imbGuardar" runat="server" Width="32px" Height="32px" ImageUrl="~/images/guardar.png" />
                            <asp:LinkButton ID="lnkGuardar" runat="server">Guardar</asp:LinkButton>
                        </td>
                        <td>
                            <asp:ImageButton ID="imgRegresar" runat="server" Width="32px" Height="32px" ImageUrl="~/images/regresar.png" CausesValidation="false" />
                            <asp:LinkButton ID="lnkRegresar" runat="server" CausesValidation="false">Vehículos</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>

        </tr>

        <tr>
            <td>
                <asp:Label ID="lblIdTitulo" runat="server" Text="Id"></asp:Label>
            </td>
            <td style="width: 419px">
                <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td style="width: 419px">&nbsp;</td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblPlacaAnterior" runat="server" Text="Placa Anterior"></asp:Label>
            </td>
            <td style="width: 419px">
                <asp:TextBox ID="txtplacaAnterior" runat="server" Width="314px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtplacaAnterior" ErrorMessage="Placa Anterior campo obligatorio" Style="color: #FF0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td style="width: 419px">&nbsp;</td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblPlacaActual" runat="server" Text="Placa Actual"></asp:Label>
            </td>
            <td style="width: 419px">
                <asp:TextBox ID="txtplacaActual" runat="server" Width="314px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtplacaActual" ErrorMessage="Placa Actual campo obligatorio" Style="color: #FF0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td style="width: 419px">&nbsp;</td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblchasis" runat="server" Text="chasis"></asp:Label>
            </td>
            <td style="width: 419px">
                <asp:TextBox ID="txtChasis" runat="server" Width="314px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtChasis" ErrorMessage="Chasis campo obligatorio" Style="color: #FF0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td style="width: 419px">&nbsp;</td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblMotor" runat="server" Text="Motor"></asp:Label>
            </td>
            <td style="width: 419px">
                <asp:TextBox ID="txtMotor" runat="server" Width="314px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMotor" ErrorMessage="Motor campo obligatorio" Style="color: #FF0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td style="width: 419px">&nbsp;</td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblFechaCompra" runat="server" Text="Fecha Compra"></asp:Label>
            </td>
            <td style="width: 419px">
                <asp:TextBox ID="txtFechaCompra" runat="server" Width="314px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFechaCompra" ErrorMessage="Fecha compra campo obligatorio" Style="color: #FF0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td style="width: 419px">&nbsp;</td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblNpasajeros" runat="server" Text="No. pasajeros"></asp:Label>
            </td>
            <td style="width: 419px">
                <asp:TextBox ID="txtNpasajeros" runat="server" Width="314px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNpasajeros" ErrorMessage="Pasajeros campo obligatorio" Style="color: #FF0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td style="width: 419px">&nbsp;</td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblCombustible" runat="server" Text="Combustible"></asp:Label>
            </td>
            <td style="width: 419px">
                <asp:DropDownList ID="ddlCombustrible" runat="server" Height="23px" Width="323px"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlCombustrible" ErrorMessage="Combustible campo obligatorio" Style="color: #FF0000" InitialValue="0">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td style="width: 419px">&nbsp;</td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblTonelaje" runat="server" Text="Tonelaje"></asp:Label>
            </td>
            <td style="width: 419px">
                <asp:TextBox ID="txtTonelaje" runat="server" Width="314px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtTonelaje" ErrorMessage="Tonelaje campo obligatorio" Style="color: #FF0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td style="width: 419px">&nbsp;</td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblObservacion" runat="server" Text="Obervacion"></asp:Label>
            </td>
            <td style="width: 419px">
                <asp:TextBox ID="txtObservacion" runat="server" TextMode="MultiLine" Width="318px" Height="28px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td style="width: 419px">&nbsp;</td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblYear" runat="server" Text="Año"></asp:Label>
            </td>
            <td style="width: 419px">
                <asp:DropDownList ID="ddlYear" runat="server" Height="21px" Width="323px"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlYear" ErrorMessage="Año campo obligatorio" Style="color: #FF0000" InitialValue="0">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td style="width: 419px">&nbsp;</td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblCilindraje" runat="server" Text="Cilindraje"></asp:Label>
            </td>
            <td style="width: 419px">
                <asp:TextBox ID="txtlblCilindraje" runat="server" Width="314px" Height="18px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtlblCilindraje" ErrorMessage="Cilindraje campo obligatorio" Style="color: #FF0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td style="width: 419px">&nbsp;</td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblTipo" runat="server" Text="Tipo"></asp:Label>
            </td>
            <td style="width: 419px">
                <asp:DropDownList ID="ddlTipo" runat="server" Height="20px" Width="323px"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlTipo" ErrorMessage="Tipo campo obligatorio" Style="color: #FF0000" InitialValue="0">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td style="width: 419px">&nbsp;</td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblcolor" runat="server" Text="Color"></asp:Label>
            </td>
            <td style="width: 419px">
                <asp:DropDownList ID="ddlColor" runat="server" Height="21px" Width="323px"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlColor" ErrorMessage="Color campo obligatorio" Style="color: #FF0000" InitialValue="0">*</asp:RequiredFieldValidator>
            </td>
            
                <tr>
                    <td>&nbsp;</td>
                    <td style="width: 419px">&nbsp;</td>
                </tr>

                <td>
                    <asp:Label ID="lblModelo" runat="server" Text="Modelo"></asp:Label>
                </td>
                <td style="width: 419px">
                    <asp:DropDownList ID="ddlModelo" runat="server" Height="27px" Width="323px"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlModelo" ErrorMessage="Modelo campo obligatorio" Style="color: #FF0000" InitialValue="0">*</asp:RequiredFieldValidator>
                </td>
            </tr>

        <tr>
            <td>&nbsp;</td>
            <td style="width: 419px">&nbsp;</td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblPais" runat="server" Text="Pais"></asp:Label>
            </td>
            <td style="width: 419px">
                <asp:DropDownList ID="ddlPais" runat="server" Height="36px" Width="323px"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlPais" ErrorMessage="País campo obligatorio" Style="color: #FF0000" InitialValue="0">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td style="width: 419px">&nbsp;</td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblClase" runat="server" Text="Clase"></asp:Label>
            </td>
            <td style="width: 419px">
                <asp:DropDownList ID="ddlClase" runat="server" Height="35px" Width="323px"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddlClase" ErrorMessage="Clase campo obligatorio" Style="color: #FF0000" InitialValue="0">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td style="width: 419px">&nbsp;</td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td style="width: 419px">&nbsp;</td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblMensaje" runat="server" Text="Mensaje"></asp:Label>
            </td>
            <td style="width: 419px">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

                <asp:ValidationSummary ID="ValidationSummary1" runat="server" Style="color: #FF0000" ShowMessageBox="True" />

            </td>
        </tr>

    </table>
</asp:Content>
