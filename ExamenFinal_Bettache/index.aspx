<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ExamenFinal_Bettache.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="bootstrap/bootstrap.min.css" rel="stylesheet" />

    <script type="text/javascript">
    function updateImage() {
        var selectedValue = document.getElementById('<%= dltypeCarte.ClientID %>').value;
        var img = document.getElementById('imgCarte');
        
        if (selectedValue === "Master Card") {
            img.src = "/images/mastercard.png";
        } else if (selectedValue === "Visa") {
            img.src = "/images/visa.png";
        } else if (selectedValue === "American Express") {
            img.src = "/images/amex.png";
        } else {
           
            img.src = "/images/default.png";
        }
    }
    </script>



</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h1 class="text-center text-primary mb-4">Informations de la carte de crédit</h1>
            <br />
            <div class="mb-3">
                <label for="typeDeCarte" class="form-label">Type de carte: </label>
                <asp:DropDownList ID="dltypeCarte" runat="server" Width="200" onchange="updateImage()">
                    <asp:ListItem Text="Visa" Value="Visa" />
                    <asp:ListItem Text="Master Card" Value="Master Card" />
                    <asp:ListItem Text="American Express" Value="American Express" />
                </asp:DropDownList>
                <asp:Image ID="imgCarte" runat="server" ImageUrl="~/images/visa.png" CssClass="float-right custom-image" />
            </div>

            <div class="mb-3">
                <asp:Label ID="numerDeCarte" runat="server" Text="Numéro de la carte:"></asp:Label>
                <asp:TextBox ID="txtNumerCarte" runat="server" Width="400" CssClass="form-control" ></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label ID="Label1" runat="server" Text="Date d'expiration(MM/AAAA):"></asp:Label>
                <asp:TextBox ID="txtDate" runat="server" Width="400" CssClass="form-control" ></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label ID="Label2" runat="server" Text="Montant:"></asp:Label>
                <asp:TextBox ID="txtMontant" runat="server" Width="400" CssClass="form-control" ></asp:TextBox>
            </div>

            <asp:Button ID="btnValider" runat="server" Text="Valider" Class="btn btn-primary mb-2" OnClick="btnValider_Click" />
            <br />
            <br />
            <div class="text-center text-primary mb-4">
                <asp:Label ID="lblChamps" runat="server" Text="test" Font-Bold="True" Font-Size="Larger"></asp:Label>
            </div>

        </div>
    </form>
</body>
</html>
