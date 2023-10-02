

//var token = getCookie("Token");
var token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJNaUFwcFN1YmplY3RDbGFpbSIsIm5hbWVpZCI6IjgiLCJyb2xlIjoiMiIsIm5iZiI6MTY5NjE5NzYzNiwiZXhwIjoxNjk4Nzg5NjM2LCJpYXQiOjE2OTYxOTc2MzZ9.CjzM1Bp92BnVtW_qx8IaxXW85w4QgN79ZsrFF2f9dmjqkdRB85P1n9sQd8I9Ia2WL_CcdvHixkfMXDkw4VV4AA"
let table = new DataTable('#usuarios', {
    
    ajax: {
        url: `https://localhost:7255/User/GetAll`,
        dataSrc: "data.items",
        
        headers: { "Authorization": "Bearer " + token }
    },
   
    columns: [
        { data: 'codUsuario', title: 'Codigo de Usuario' },
        { data: 'nombre', title: 'Nombre' },
        { data: 'dni', title: 'DNI' },
        { data: 'roleId', title: 'Role' },
        {
            data: function (data) {
                var botones =
                    `<td><a href='javascript:EditarUsuario(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square editarUsuario"></i></td>` +
                    `<td><a href='javascript:EliminarUsuario(${JSON.stringify(data)})'><i class="fa-solid fa-trash eliminarUsuario"></i></td>`
                return botones;
            }
        }

    ]
});


function AgregarUsuario() {
    $.ajax({
        type: "GET",
        url: "/Usuarios/UsuariosAddPartial",
        data: "",
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#usuariosAddPartial').html(resultado);
            $('#usuarioModal').modal('show');
        }

    });
}

function EditarUsuario(data) {
    debugger
    $.ajax({
        type: "POST",
        url: "/Usuarios/UsuariosAddPartial",
        data: JSON.stringify(data),
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#usuariosAddPartial').html(resultado);
            $('#usuarioModal').modal('show');
        }

    });
}

function EliminarUsuario(data) {
    $.ajax({
        type: "GET",
        url: "/Usuarios/EliminarUsuario",
        data: JSON.stringify(data),
        'dataType': "html",
        success: function (resultado) {

        }

    });
}