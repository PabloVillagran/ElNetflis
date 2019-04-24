﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ElNetflis.frontEnds.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Nesflis</title>
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <script src="/Scripts/jquery.unobtrusive-ajax.js"></script> 
    <style>
        .carousel {
            margin-bottom: 0;
            padding: 0 40px 30px 40px;
        }
        /* The controlsy */
        .carousel-control {
            left: -12px;
            height: 40px;
            width: 40px;
            background: none repeat scroll 0 0 #222222;
            border: 4px solid #FFFFFF;
            border-radius: 23px 23px 23px 23px;
            margin-top: 90px;
        }

            .carousel-control.right {
                right: -12px;
            }
        /* The indicators */
        .carousel-indicators {
            right: 50%;
            top: auto;
            bottom: -10px;
            margin-right: -19px;
        }
        /* The colour of the indicators */
        .carousel-indicators li {
            background: #cecece;
        }

        .carousel-indicators .active {
            background: #428bca;
        }

        .center {
            margin-top: 50px;
        }

        .modal-header {
            padding-bottom: 5px;
        }

        .modal-footer {
            padding: 0;
        }

            .modal-footer .btn-group button {
                height: 40px;
                border-top-left-radius: 0;
                border-top-right-radius: 0;
                border: none;
                border-right: 1px solid #ddd;
            }

            .modal-footer .btn-group:last-child > button {
                border-right: 0;
            }
    </style>
    <script type="text/javascript">
        var peliculaActiva;

        function getPelicula(tempId, genero) {
            $.ajax({
                type: "POST",
                url: "index.aspx/GetPeliculaById",
                data: JSON.stringify({ "TempId": tempId , "Genero" : genero}),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    peliculaActiva = response.d;
                    fillAndShowModal(peliculaActiva.Nombre, peliculaActiva.Descripcion, peliculaActiva.PosterUrl);
                },
                failure: function (jqXHR, textStatus, errorThrown) {
                    alert("HTTP Status: " + jqXHR.status + "; Error Text: " + jqXHR.responseText);
                }
            });
        }

        function fillModal(nombre, descripcion, poster){
            $("#modalTitulo").text(nombre);
            $("#modalNombre").text(nombre);
            $("#modalDescripcion").text(descripcion);
            $("#modalImg").attr("src", poster);
            $("#modalVerPelicula").attr("onclick", "reemplazarBotonesModal()");
        }

        function showContinuarModal() {
            $("#modalVerPelicula").hide();
            $("#modalContinuarLuego").hide();
            $("#modalFinalizar").show();
            $("#detallesPelicula").modal("toggle");
        }

        function fillAndShowModal(nombre, descripcion, poster) {
            fillModal(nombre, descripcion, poster);
            $("#modalVerPelicula").show();
            $("#modalContinuarLuego").hide();
            $("#modalFinalizar").hide();
            $("#detallesPelicula").modal("toggle");
        }

        function reemplazarBotonesModal() {
            $("#modalVerPelicula").hide();
            $("#modalContinuarLuego").show();
            $("#modalFinalizar").show();
        }

        function continuarLuego() {
            $.ajax({
                type: "POST",
                url: "index.aspx/ContinuarLuego",
                data: {},
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    alert(response.d.Mensaje);
                    $("#thumbContinuar").attr("src", response.d.Cima.PosterUrl);
                    $("#linkContinuar").attr("onclick", "fillModal('" + response.d.Cima.Nombre + "','" + response.d.Cima.Descripcion + "','" + response.d.Cima.PosterUrl + "');showContinuarModal();");
                    $("#buttonContinuar").attr("onclick", "fillModal('" + response.d.Cima.Nombre + "','" + response.d.Cima.Descripcion + "','" + response.d.Cima.PosterUrl + "');showContinuarModal();");
                },
                failure: function (jqXHR, textStatus, errorThrown) {
                    alert("HTTP Status: " + jqXHR.status + "; Error Text: " + jqXHR.responseText);
                }
            });
        }

        function pilaVacia(){
            alert("No existen peliculas para reproducir.");
        }

        //deprecated!!
        function verPelicula(tempId, genero) {
            $.ajax({
                type: "POST",
                url: "index.aspx/VerPelicula",
                data: JSON.stringify({ "TempId": tempId, "Genero": genero }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    alert("procesado");
                },
                failure: function (jqXHR, textStatus, errorThrown) {
                    alert("HTTP Status: " + jqXHR.status + "; Error Text: " + jqXHR.responseText);
                }
            });
        }
    </script>
</head>
<body>
    <form runat="server" class="container">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
    </asp:ScriptManager>

         <div class="modal fade" id="detallesPelicula" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">cerrar</button>
                        <h4 class="modal-title" id="modalTitulo"></h4>
                        </div>
                    <div class="modal-body">
                        <div style="text-align:center;">
                            <img id="modalImg" src="#"/>
                            <h3 class="media-heading" id="modalNombre"></h3>
                        </div>
                        
                        <h5>Descripción: </h5>
                        <p id="modalDescripcion"></p>
                    </div>
                    <div class="modal-footer">
                        <div style="text-align:center;">
                            <button id="modalVerPelicula" type="button" class="btn btn-default">Ver película</button>
                            <button id="modalContinuarLuego" type="button" class="btn btn-default" data-dismiss="modal" onclick="continuarLuego();">Continuar luego.</button>
                            <button id="modalFinalizar" type="button" class="btn btn-default" data-dismiss="modal">Finalizar Película</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-6">
                <h4>Continuar viendo</h4>
                    <asp:Literal ID="continuarItem" runat="server"/>
                    <!--
                <div class="col-md-3">
                    <a href="#" class="thumbnail" onclick="pilaVacia()">
                        <img id="thumbContinuar" src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/>
                    </a>
                    <button id="Continuar" class="btn btn-primary" onclick="javascript:pilaVacia();">Continuar</button>
                </div>
                    -->
            </div>
            <div class="col-sm-6">
                <h4>Mi Lista</h4>
                <div class="col-md-3"><a href="#" class="thumbnail">
                    <img id="thumbCola" src="#" alt="Image" style="height: 222px;width: 150px;"/></a>
                </div>
                <button id="verDeCola" class="btn btn-primary" onclick="javascript:pilaVacia();">Ver película en cola</button>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <h2>Acción</h2>
                <div id="carAccion" class="carousel slide">
                    <asp:Literal runat="server" ID="carAccionIndicators"/>

                    <!-- Carousel items -->
                    <div class="carousel-inner">
                        <asp:Literal runat="server" ID="carAccionImages"/>
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
                    <asp:Literal runat="server" ID="carChildIndicators"/>

                    <!-- Carousel items -->
                    <div class="carousel-inner">
                        <asp:Literal runat="server" ID="carChildImages"/>
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
                    <asp:Literal runat="server" ID="carDramaIndicators"/>

                    <!-- Carousel items -->
                    <div class="carousel-inner">
                        <asp:Literal runat="server" ID="carDramaImages"/>
                    </div>
                        
                    <!--.carousel-inner-->
                    <a data-slide="prev" href="#carDrama" class="left carousel-control">‹</a>
                    <a data-slide="next" href="#carDrama" class="right carousel-control">›</a>
                </div>
                <!--.Carousel-->
            </div>
        </div>

       
    </form>
</body>
</html>
