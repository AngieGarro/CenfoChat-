//Clase Js - Controlador de la vista Room.cshtml

//Define el nombre de la clase Js
function RoomController() {
    this.ViewName = "Room";
    this.ApiService = "Room"

    //Metodo que inicializa la vista.
    this.InitView = function () {
        console.log("Room view init");

        //Asiganacion del evente create
        $("#btnSend").click(function () {
            var view = new RoomController();
            view.Create();
        })

        $("#btnUpdate").click(function () {
            var view = new RoomController();
            view.Update();
        })

        $("#btnDelete").click(function () {
            var view = new RoomController();
            view.Delete();
        })

        //Se invoca la funcion de carga de la tabla.
        this.LoadTableRoom();
    }

    this.Create = function () {
        //Crear un DTO Para el Room
        var Room = {};
        Room.RoomName = $("#txtRName").val();
        Room.Description = $("#txtRDescript").val();
        Room.RoomCreator = $("#txtRCreator").val();
        Room.Status = $("#txtRStatus").val();
        Room.CountUser = $("#txtRCount").val();
        Room.RoomTheme = $("#txtRTheme").val();
        Room.ImageUrl = $("#txtRImage").val();

        var ctrlAction = new ControlActions();
        var serviceToCreate = this.ApiService + "/Create";

        //Envia el Msj - Hace el Request en el API 
        ctrlAction.PostToAPI(serviceToCreate, Room, function () {

            console.log("Send Data to the API");

        });

        console.log("Room --> " + JSON.stringify(Msj));
    }
    this.Update = function () {
        var Room = {};

        Room.Id = $("#txtId").val();
        Room.RoomName = $("#txtRName").val();
        Room.Description = $("#txtRDescript").val();
        Room.Status = $("#txtRStatus").val();
        Room.CountUser = $("#txtRCount").val();
        Room.RoomTheme = $("#txtRTheme").val();
        Room.ImageUrl = $("#txtRImage").val();


        var ctrlAction = new ControlActions();
        var serviceToCreate = this.ApiService + "/Update";

        //Envia el Msj - Hace el Request en el API 
        ctrlAction.PutToAPI(serviceToCreate, Room, function () {

            console.log("Update Data to the API");

        });

        console.log("Room --> " + JSON.stringify(Msj));
    }


    this.Delete = function () {
        var RoomData = {};
        RoomData = this.ctrlAction.GetDataForm('frmEdition')

        //Hace el delete al create
        this.ctrlActions.DeleteToAPI(this.service, RoomData);
        //Refresca la tabla
        this.ReloadTable();
    }


    //Display Table
    this.LoadTableRoom = function () {

        ctrlAction = new ControlActions();

        //Url Retrieve All
        var urlSevice = ctrlAction.GetUrlApiService(this.ApiService + "/RetrieveAll");

        //Columnas de extracción de JSON.
        var columns = [];
        columns[0] = { 'data': 'Id' };
        columns[1] = { 'data': 'RoomName' };
        columns[2] = { 'data': 'Description' };
        columns[3] = { 'data': 'RoomCreator' };
        columns[4] = { 'data': 'CreatedDate' };
        columns[5] = { 'data': 'UserName' };
        columns[6] = { 'data': 'Status' };
        columns[7] = { 'data': 'CountUser' };
        columns[8] = { 'data': 'RoomTheme' };
        columns[9] = { 'data': 'ImageUrl' };
        columns[10] = { 'data': 'UltimateDate' };

        $('#TblRooms').dataTable({
            "ajax": {
                "url": urlSevice,
                "dataSrc": ""
            },
            "columns": columns
        });

        $('#TblRooms tbody').on('click', 'tr', function () {

            //Fila
            var row = $(this).closest('tr');

            //Dta de la fila de la tabla
            var data = $('#TblRooms').DataTable().row(row).data();


        })
    }

    this.LoadTableUser() = function () {

        ctrlAction = new ControlActions();

        //Url Retrieve All users
        var urlSevice = ctrlAction.GetUrlApiService(this.ApiService + "/RetrieveAllUsers");

        //Columnas de extracción de JSON.
        var columns = [];
        columns[0] = { 'data': 'Id' };
        columns[1] = { 'data': 'Name' };
        columns[2] = { 'data': 'LastName' };
        columns[3] = { 'data': 'Email' };
        columns[4] = { 'data': 'PhoneNumber' };
        columns[5] = { 'data': 'BirthDate' };
        columns[6] = { 'data': 'OwnedBy' };

        $('#TblUsersSC').dataTable({
            "ajax": {
                "url": urlSevice,
                "dataSrc": ""
            },
            "columns": columns
        });

        $('#TblUsersSC tbody').on('click', 'tr', function () {

            //Fila
            var row = $(this).closest('tr');

            //Dta de la fila de la tabla
            var data = $('#TblUsersSC').DataTable().row(row).data();


        })
    }
}


//Instanciamiento inicial de la clase.
//Siempre se ejecuta al finalizar la carga de la página.
//Document: Hace referencia al contenido del HTML
$(document).ready(function () {
    var view = new RoomController();
    view.InitView();
});