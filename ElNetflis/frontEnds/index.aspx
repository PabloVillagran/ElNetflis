<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ElNetflis.frontEnds.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Nesflis</title>
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/Content/archivo.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <script src="/Scripts/jquery.unobtrusive-ajax.js"></script>
    <script type="text/javascript" src="/Scripts/archivo.js"></script>
</head>
<body>
    <nav class="row">
        <div class="container">

            <img src="/Img/logo.png" class="col-md-4" />
            <div id="custom-search-input" class="col-md-8">
                <input style="width:100%;" onkeyup="buscarajax();" type="text" class="search-query form-control" placeholder="Search" id="searchbar" />
                <div id="sugerencias" class="autoCompleteDiv">
                </div>
            </div>
        </div>
    </nav>
    <form runat="server" class="container">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
        </asp:ScriptManager>

        

        <div class="row">
            <div class="col-sm-6">
                <h4>Continuar viendo</h4>
                <asp:Literal ID="continuarItem" runat="server" />
            </div>
            <div class="col-sm-6">
                <h4>Mi Lista</h4>
                <asp:Literal ID="miListaItem" runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <h2>Acción</h2>
                <div id="carAccion" class="carousel slide">
                    <asp:Literal runat="server" ID="carAccionIndicators" />

                    <!-- Carousel items -->
                    <div class="carousel-inner">
                        <asp:Literal runat="server" ID="carAccionImages" />
                    </div>
                    <!--.carousel-inner-->
                    <a data-slide="prev" href="#carAccion" class="left carousel-control">‹</a>
                    <a data-slide="next" href="#carAccion" class="right carousel-control">›</a>
                </div>
                <!--.Carousel-->
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <h2>Niños</h2>
                <div id="carChild" class="carousel slide">
                    <asp:Literal runat="server" ID="carChildIndicators" />

                    <!-- Carousel items -->
                    <div class="carousel-inner">
                        <asp:Literal runat="server" ID="carChildImages" />
                    </div>
                    <!--.carousel-inner-->
                    <a data-slide="prev" href="#carChild" class="left carousel-control">‹</a>
                    <a data-slide="next" href="#carChild" class="right carousel-control">›</a>
                </div>
                <!--.Carousel-->
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <h2>Drama</h2>
                <div id="carDrama" class="carousel slide">
                    <asp:Literal runat="server" ID="carDramaIndicators" />

                    <!-- Carousel items -->
                    <div class="carousel-inner">
                        <asp:Literal runat="server" ID="carDramaImages" />
                    </div>

                    <!--.carousel-inner-->
                    <a data-slide="prev" href="#carDrama" class="left carousel-control">‹</a>
                    <a data-slide="next" href="#carDrama" class="right carousel-control">›</a>
                </div>
                <!--.Carousel-->
            </div>
        </div>

        <!--MODAL INFORMACIÓN-->
        <div class="modal fade" id="detallesPelicula" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">cerrar</button>
                        <h4 class="modal-title" id="modalTitulo"></h4>
                    </div>
                    <div class="modal-body">
                        <div style="text-align: center;">
                            <img id="modalImg" src="#" />
                            <h3 class="media-heading" id="modalNombre"></h3>
                        </div>

                        <h5>Descripción: </h5>
                        <p id="modalDescripcion"></p>
                    </div>
                    <div class="modal-footer">
                        <div style="text-align: center;">
                            <button id="modalVerPelicula" type="button" class="btn btn-default">Ver película</button>
                            <button id="modalAgregarALista" type="button" class="btn btn-default" data-dismiss="modal" onclick="agregarACola();">Agregar a Mi Lista</button>
                            <button id="modalContinuarLuego" type="button" class="btn btn-default" data-dismiss="modal" onclick="continuarLuego();">Continuar luego.</button>
                            <button id="modalFinalizar" type="button" class="btn btn-default" data-dismiss="modal">Finalizar Película</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--FIN MODAL INFORMACIÓN-->

    </form>
</body>
</html>
