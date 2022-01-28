const mostrarModal = (titulo = "¿Desea guardar los cambios?",
    texto ="Dar clic en si para confirmar") => {
    return Swal.fire({
        title: titulo,
        text: texto,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si'
    });
}

function pintar(url, campos, propiedadid, nombreController, popup = false, account = false) {
    var contenido = "";
    var tbody = document.getElementById("tbDatos");
    var nombreCampo;
    var objetoActual;
    $.get(url, function (data) {

        console.log(data);

        for (var i = 0; i < data.length; i++) {
            contenido += "<tr>";
            for (var j = 0; j < campos.length; j++) {
                nombreCampo = campos[j];
                objetoActual = data[i];
                contenido += "<td>" + objetoActual[nombreCampo] + "</td>";
            }
            contenido += "<td>";
            if (account == true) {
                contenido += `<a href="Account/AddAccount/${objetoActual[propiedadid]}">
                                <i class="fas fa-wallet btn btn-info"></i>
                              </a>`;
            }
            if (popup == false) {

                contenido += `<a href="${nombreController}/Edit/${objetoActual[propiedadid]}">
                                <i class="fas fa-edit btn btn-primary"></i>
                             </a>`;
            } else {
                //contenido += `<i class="fas fa-edit btn btn-primary"
                //                data-toggle="modal" data-target="#exampleModal"
                //                onclick="Abrir(${objetoActual[propiedadid]})">
                //              </i>`;
            }
            contenido += "</td>";
            contenido += "</tr>";
        }

        tbody.innerHTML = contenido;
        $("#table").DataTable();
    })
}

function correcto(title="Se eliminó correctamente") {
    Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: title,
        showConfirmButton: false,
        timer: 1500
    })
}

function error(title="Ocurrio un error") {
    Swal.fire({
        icon: 'error',
        title: title,
        text: 'Something went wrong!',
    })
}
