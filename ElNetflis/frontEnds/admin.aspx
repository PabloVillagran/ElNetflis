<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="ElNetflis.frontEnds.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administración</title>
    <meta charset="utf-8" />

    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Agregar película
        <div class="form-group">
            <label for="tbNombre">Nombre</label>
            <asp:TextBox ID="tbNombre" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
            <div class="form-group">
                <label for="tbAutor">Autor</label>
                <asp:TextBox ID="tbAutor" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="tbYear">Año</label>
                <asp:TextBox ID="tbYear" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="ddGenero">Genero</label>
                <asp:DropDownList ID="ddGenero" runat="server" CssClass="form-control">
                    <asp:ListItem>Drama</asp:ListItem>
                    <asp:ListItem Value="Children">Niños</asp:ListItem>
                    <asp:ListItem Value="AccAventura">Acción Aventura</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="taDescripcion">Descripción</label>
                <textarea class="form-control" id="taDescripcion" rows="5" runat="server"></textarea>
            </div>
            <div class="form-group">
                <label for="tbPosterUrl">URL Poster</label>
                <asp:TextBox ID="tbPosterUrl" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="bAgregar" runat="server" CssClass="btn btn-primary" Text="Agregar" OnClick="bAgregar_Click" />
        </div>
        <div>
            Eliminar película
            <div class="form-group">
                <label for="ddCategoria">Categoría</label>
                <asp:DropDownList ID="ddCategoria" runat="server" CssClass="form-control">
                    <asp:ListItem Value=""></asp:ListItem>
                    <asp:ListItem Value="Children">Niños</asp:ListItem>
                    <asp:ListItem>Drama</asp:ListItem>
                    <asp:ListItem Value="AccAventura">Acción Aventura</asp:ListItem>
                </asp:DropDownList>
            </div>
                <div class="form-group">
                    <label for="ddPelicula">Película</label>
                    <asp:DropDownList ID="ddPelicula" runat="server">
                    </asp:DropDownList>
                </div>
                <asp:Button ID="bEliminar" runat="server" CssClass="btn btn-primary" Text="Eliminar" />
        </div>
    </form>
</body>
</html>
