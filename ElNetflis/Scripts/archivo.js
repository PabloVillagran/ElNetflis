var peliculaActiva;

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

function getPelicula(tempId, genero) {
    $.ajax({
        type: "POST",
        url: "index.aspx/GetPeliculaById",
        data: JSON.stringify({ "TempId": tempId, "Genero": genero }),
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

function fillModal(nombre, descripcion, poster) {
    $("#modalTitulo").text(nombre);
    $("#modalNombre").text(nombre);
    $("#modalDescripcion").text(descripcion);
    $("#modalImg").attr("src", poster);
    $("#modalVerPelicula").attr("onclick", "reemplazarBotonesModal()");
}

function showContinuarModal() {
    $("#modalVerPelicula").hide();
    $("#modalAgregarALista").hide();
    $("#modalContinuarLuego").hide();
    $("#modalFinalizar").show();
    $("#modalFinalizar").attr("onclick", "popContinuar();");
    $("#detallesPelicula").modal("toggle");
}

function fillAndShowModal(nombre, descripcion, poster) {
    fillModal(nombre, descripcion, poster);
    $("#modalVerPelicula").show();
    $("#modalAgregarALista").show();
    $("#modalContinuarLuego").hide();
    $("#modalFinalizar").hide();
    $("#detallesPelicula").modal("toggle");
}

function reemplazarBotonesModal() {
    $("#modalVerPelicula").hide();
    $("#modalAgregarALista").hide();
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
            $("#modalFinalizar").attr("onclick", "popContinuar();");
        },
        failure: function (jqXHR, textStatus, errorThrown) {
            alert("HTTP Status: " + jqXHR.status + "; Error Text: " + jqXHR.responseText);
        }
    });
}

function popContinuar() {
    $.ajax({
        type: "POST",
        url: "index.aspx/PopContinuar",
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.d.Mensaje);
            if (response.d.Cima == null) {
                $("#linkContinuar").attr("onclick", "alert('Te recomendamos ver una película nueva');");
                $("#buttonContinuar").attr("onclick", "alert('Te recomendamos ver una película nueva');");
                $("#modalFinalizar").attr("onclick", "");
                $("#linkContinuar").attr("onclick", "pilaVacia();");
                $("#thumbContinuar").attr("src", "#");
                $("#buttonContinuar").attr("onclick", "pilaVacia();");
            } else {
                $("#thumbContinuar").attr("src", response.d.Cima.PosterUrl);
                $("#linkContinuar").attr("onclick", "fillModal('" + response.d.Cima.Nombre + "','" + response.d.Cima.Descripcion + "','" + response.d.Cima.PosterUrl + "');showContinuarModal();");
                $("#buttonContinuar").attr("onclick", "fillModal('" + response.d.Cima.Nombre + "','" + response.d.Cima.Descripcion + "','" + response.d.Cima.PosterUrl + "');showContinuarModal();");
            }
        },
        failure: function (jqXHR, textStatus, errorThrown) {
            alert("HTTP Status: " + jqXHR.status + "; Error Text: " + jqXHR.responseText);
        }
    });
}

function agregarACola() {
    $.ajax({
        type: "POST",
        url: "index.aspx/AgregarLista",
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.d.Mensaje);
            $("#thumbLista").attr("src", response.d.Cima.PosterUrl);
            $("#linkLista").attr("onclick", "fillModal('" + response.d.Cima.Nombre + "','" + response.d.Cima.Descripcion + "','" + response.d.Cima.PosterUrl + "');showListaModal();");
            $("#buttonLista").attr("onclick", "fillModal('" + response.d.Cima.Nombre + "','" + response.d.Cima.Descripcion + "','" + response.d.Cima.PosterUrl + "');showListaModal();");
        },
        failure: function (jqXHR, textStatus, errorThrown) {
            alert("HTTP Status: " + jqXHR.status + "; Error Text: " + jqXHR.responseText);
        }
    });
}

function sacarDeCola() {
    $.ajax({
        type: "POST",
        url: "index.aspx/SacarCola",
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.d.Mensaje);
            if (response.d.Cima == null) {
                $("#linkLista").attr("onclick", "alert('Te recomendamos agregar más películas.');");
                $("#buttonLista").attr("onclick", "alert('Te recomendamos agregar más películas.');");
                $("#modalFinalizar").attr("onclick", "");
                $("#linkLista").attr("onclick", "pilaVacia();");
                $("#thumbLista").attr("src", "#");
                $("#buttonLista").attr("onclick", "pilaVacia();");
            } else {
                $("#thumbLista").attr("src", response.d.Cima.PosterUrl);
                $("#linkLista").attr("onclick", "fillModal('" + response.d.Cima.Nombre + "','" + response.d.Cima.Descripcion + "','" + response.d.Cima.PosterUrl + "');showListaModal();");
                $("#buttonLista").attr("onclick", "fillModal('" + response.d.Cima.Nombre + "','" + response.d.Cima.Descripcion + "','" + response.d.Cima.PosterUrl + "');showListaModal();");
            }
        },
        failure: function (jqXHR, textStatus, errorThrown) {
            alert("HTTP Status: " + jqXHR.status + "; Error Text: " + jqXHR.responseText);
        }
    });
}

function buscarajax() {
    var b = $("#searchbar").val();
    if (b != "") {
        $.ajax({
            type: "POST",
            url: "index.aspx/Buscar",
            data: JSON.stringify({ "buscado": b }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var array = response.d;
                var spans = "";
                if (array != null) {
                    array.forEach(function (obj) {
                        spans += "<span onclick='getPelicula(" + obj.TmpId + ",\"" + obj.Genero + "\")'>" + obj.Nombre + "</span>";
                    });
                    $("#sugerencias").html(spans);
                }
            },
            failure: function (jqXHR, textStatus, errorThrown) {
                alert("HTTP Status: " + jqXHR.status + "; Error Text: " + jqXHR.responseText);
            }
        });
    } else {
        $("#sugerencias").html("");
    }
}

function showListaModal() {
    $("#modalVerPelicula").show();
    $("#modalAgregarALista").hide();
    $("#modalContinuarLuego").hide();
    $("#modalFinalizar").hide();
    $("#modalFinalizar").attr("onclick", "sacarDeCola();");
    $("#detallesPelicula").modal("toggle");
}

function pilaVacia() {
    alert("No existen peliculas para reproducir.");
}