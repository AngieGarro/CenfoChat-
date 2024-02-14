//Clase Js - Controlador de la vista CreateUsers.cshtml

//Define el nombre de la clase Js
function CreateUserController() {
    this.ViewName = "CreateUsers";
    this.ApiService = "UserClient"

    //Metodo que inicializa la vista.
    this.InitView = function () {
        console.log("User view init");

        //Asiganacion del evente create

        $("#btnCreate").click(function () {
            var view = new CreateUserController();
            view.Create();
        })
        $("#btnUpdate").click(function () {
            var view = new CreateUserController();
            view.Update();
        })

        $("#btnDelete").click(function () {
            var view = new CreateUserController();
            view.Delete();
        })

        //Se invoca la funcion de carga de la tabla.
        this.LoadTable();
    }

    this.Create = function () {
        //Crear un DTO de user
        var user = {};
        user.Name = $("#txtNameUser").val();
        user.LastName = $("#txtLastName").val();
        user.Email = $("#txtEmail").val();   
        user.PhoneNumber = $("#txtPhoneNumber").val();
        user.BirthDate = $("#txtBirthDate").val();
        user.OwnedBy = "CenfoChat-APG";
      
        var ctrlAction = new ControlActions();
        var serviceToCreate = this.ApiService + "/Create";

        //Crea el usuario - Hace el Request en el API 
        ctrlAction.PostToAPI(serviceToCreate, user, function () {
            console.log("Data enviada al API");
        });

        console.log("User --> " + JSON.stringify(user));
    }

    this.Update = function () {
        var user = {};
        user.Id = $("#txtId").val();
        user.Name = $("#txtNameUser").val();
        user.LastName = $("#txtLastName").val();
        user.Email = $("#txtEmail").val();
        user.PhoneNumber = $("#txtPhoneNumber").val();
    
        var ctrlAction = new ControlActions();
        var serviceToCreate = this.ApiService + "/Update";

        //Envia el Msj - Hace el Request en el API 
        ctrlAction.PutToAPI(serviceToCreate, user, function () {

            console.log("Update Data to the API");

        });

        console.log("User --> " + JSON.stringify(Msj));
    }


    this.Delete = function () {
        var UserData = {};
        MsjData = this.ctrlAction.GetDataForm('frmEdition')

        //Hace el delete al create
        this.ctrlActions.DeleteToAPI(this.service, UserData);
        //Refresca la tabla
        this.ReloadTable();
    }


    //Display Table
    this.LoadTable = function () {

        ctrlAction = new ControlActions();

        //Url Retrieve All
        var urlSevice = ctrlAction.GetUrlApiService(this.ApiService + "/RetrieveAll");

        //Columnas de extracción de JSON.
        var columns = [];
        columns[0] = { 'data': 'Id' };
        columns[1] = { 'data': 'Name' };
        columns[2] = { 'data': 'LastName' };
        columns[3] = { 'data': 'Email' };
        columns[4] = { 'data': 'PhoneNumber' };
        columns[5] = { 'data': 'BirthDate' };
        columns[6] = { 'data': 'OwnedBy' };

        $('#TblUsers').dataTable({
            "ajax": {
                "url": urlSevice,
                "dataSrc": ""
            },
            "columns": columns
        });

        $('#TblUsers tbody').on('click', 'tr', function () {

            //Fila
            var row = $(this).closest('tr');

            //Dta de la fila de la tabla
            var data = $('#TblUsers').DataTable().row(row).data();

            $("#txtNameUser").val(data.Name);
            $("#txtLastName").val(data.LastName);
            $("#txtEmail").val(data.Email);
            $("#txtPhoneNumber").val(data.PhoneNumber);
            $("#txtBirthDate").val(data.BirthDate);
            $("CenfoChat-APG").val(data.OwnedBy);
        })
    }

}
    
  
//Instanciamiento inicial de la clase.
//Siempre se ejecuta al finalizar la carga de la página.
//Document: Hace referencia al contenido del HTML
$(document).ready(function () {
    var view = new CreateUserController();
    view.InitView();
});
