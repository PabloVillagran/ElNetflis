<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ElNetflis.frontEnds.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Nesflis</title>
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
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
</head>
<body>
    <form runat="server" class="container">
        <div class="row">
            <div class="col-sm-6">
                <h4>Continuar viendo</h4>
                <div class="col-md-3"><a href="#" class="thumbnail">
                    <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                <asp:Button ID="Continuar" runat="server" Text="Continuar" CssClass="btn btn-primary" OnClick="Continuar_Click" />
            </div>
            <div class="col-sm-6">
                <h4>Mi Lista</h4>
                <div class="col-md-3"><a href="#" class="thumbnail">
                    <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <h2>Acción</h2>
                <div id="carAccion" class="carousel slide">

                    <asp:Literal runat="server" ID="carAccionIndicators"/>

                    <!--
                    <ol class="carousel-indicators">
                        <li data-target="#carAccion" data-slide-to="0" class="active"></li>
                        <li data-target="#carAccion" data-slide-to="1"></li>
                        <li data-target="#carAccion" data-slide-to="2"></li>
                    </ol> 
                    -->

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

                    <ol class="carousel-indicators">
                        <li data-target="#carChild" data-slide-to="0" class="active"></li>
                        <li data-target="#carChild" data-slide-to="1"></li>
                        <li data-target="#carChild" data-slide-to="2"></li>
                    </ol>

                    <!-- Carousel items -->
                    <div class="carousel-inner">

                        <div class="item active">
                            <div class="row">
                                <div class="col-md-3"><a href="#" class="thumbnail">
                                    <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                                <div class="col-md-3"><a href="#" class="thumbnail">
                                    <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                                <div class="col-md-3"><a href="#" class="thumbnail">
                                    <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                                <div class="col-md-3"><a href="#" class="thumbnail">
                                    <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                            </div>
                            <!--.row-->
                        </div>
                        <!--.item-->

                        <div class="item">
                            <div class="row">
                                <div class="col-md-3"><a href="#" class="thumbnail">
                                    <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                                <div class="col-md-3"><a href="#" class="thumbnail">
                                    <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                                <div class="col-md-3"><a href="#" class="thumbnail">
                                    <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                                <div class="col-md-3"><a href="#" class="thumbnail">
                                    <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                            </div>
                            <!--.row-->
                        </div>
                        <!--.item-->

                        <div class="item">
                            <div class="row">
                                <div class="col-md-3"><a href="#" class="thumbnail">
                                    <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                                <div class="col-md-3"><a href="#" class="thumbnail">
                                    <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                                <div class="col-md-3"><a href="#" class="thumbnail">
                                    <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                                <div class="col-md-3"><a href="#" class="thumbnail">
                                    <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                            </div>
                            <!--.row-->
                        </div>
                        <!--.item-->

                    </div>
                    <!--.carousel-inner-->
                    <a data-slide="prev" href="#carChild" class="left carousel-control">‹</a>
                    <a data-slide="next" href="#carChild" class="right carousel-control">›</a>
                </div>
                <!--.Carousel-->
            </div>
            <div class="row">
                <div class="col-md-12">
                    <h2>Drama</h2>
                    <div id="carDrama" class="carousel slide">

                        <ol class="carousel-indicators">
                            <li data-target="#carDrama" data-slide-to="0" class="active"></li>
                            <li data-target="#carDrama" data-slide-to="1"></li>
                            <li data-target="#carDrama" data-slide-to="2"></li>
                        </ol>

                        <!-- Carousel items -->
                        <div class="carousel-inner">

                            <div class="item active">
                                <div class="row">
                                    <div class="col-md-3"><a href="#" class="thumbnail">
                                        <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                                    <div class="col-md-3"><a href="#" class="thumbnail">
                                        <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                                    <div class="col-md-3"><a href="#" class="thumbnail">
                                        <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                                    <div class="col-md-3"><a href="#" class="thumbnail">
                                        <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                                </div>
                                <!--.row-->
                            </div>
                            <!--.item-->

                            <div class="item">
                                <div class="row">
                                    <div class="col-md-3"><a href="#" class="thumbnail">
                                        <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                                    <div class="col-md-3"><a href="#" class="thumbnail">
                                        <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                                    <div class="col-md-3"><a href="#" class="thumbnail">
                                        <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                                    <div class="col-md-3"><a href="#" class="thumbnail">
                                        <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                                </div>
                                <!--.row-->
                            </div>
                            <!--.item-->

                            <div class="item">
                                <div class="row">
                                    <div class="col-md-3"><a href="#" class="thumbnail">
                                        <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                                    <div class="col-md-3"><a href="#" class="thumbnail">
                                        <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                                    <div class="col-md-3"><a href="#" class="thumbnail">
                                        <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                                    <div class="col-md-3"><a href="#" class="thumbnail">
                                        <img src="http://lorempixel.com/150/222/" alt="Image" style="max-width: 100%;"/></a></div>
                                </div>
                                <!--.row-->
                            </div>
                            <!--.item-->

                        </div>
                        <!--.carousel-inner-->
                        <a data-slide="prev" href="#carDrama" class="left carousel-control">‹</a>
                        <a data-slide="next" href="#carDrama" class="right carousel-control">›</a>
                    </div>
                    <!--.Carousel-->
                </div>
            </div>
        </div>
    </form>
</body>
</html>
