//Clase Js - Controlador de la vista SendMessage.cshtml

//Define el nombre de la clase Js
function SendMessageController() {
    this.ViewName = "SendMessage";
    this.ApiService = "Message"

    //Metodo que inicializa la vista.
    this.InitView = function () {
        console.log("Message view init");

        //Asiganacion del evente create
        $("#btnSend").click(function () {
            var view = new SendMessageController();
            view.Send();
        })

        $("#btnUpdate").click(function () {
            var view = new SendMessageController();
            view.Update();
        })

        $("#btnDelete").click(function () {
            var view = new SendMessageController();
            view.Delete();
        })

        //Se invoca la funcion de carga de la tabla.
        this.LoadTable();

    }
        this.Send = function () {
            //Crear un DTO Para el Mensaje
            var Msj = {};
            Msj.From = $("#txtFor").val();
            Msj.To = $("#txtTo").val();
            Msj.Text = $("#txtText").val();
            Msj.DateTime = $("#txtDate").val();
           
            var ctrlAction = new ControlActions();
            var serviceToCreate = this.ApiService + "/Create";

            //Envia el Msj - Hace el Request en el API 
            ctrlAction.PostToAPI(serviceToCreate, Msj, function () {

                console.log("Send Data to the API");
             
            });

            console.log("Msj --> " + JSON.stringify(Msj));
    }
    this.Update = function () {
        var Msj = {};

        Msj.Id = $("#txtId").val();
        Msj.From = $("#txtFor").val();
        Msj.To = $("#txtTo").val();
        Msj.Text = $("#txtText").val();

        var ctrlAction = new ControlActions();
        var serviceToCreate = this.ApiService + "/Update";

        //Envia el Msj - Hace el Request en el API 
        ctrlAction.PutToAPI(serviceToCreate, Msj, function () {

            console.log("Update Data to the API");

        });

        console.log("Msj --> " + JSON.stringify(Msj));
    }


    this.Delete = function () {
        var MsjData = {};
        MsjData = this.ctrlAction.GetDataForm('frmEdition')

        //Hace el delete al create
        this.ctrlActions.DeleteToAPI(this.service, MsjData);
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
        columns[1] = { 'data': 'from' };
        columns[2] = { 'data': 'to' };
        columns[3] = { 'data': 'text' };
        columns[4] = { 'data': 'createdDate' };
        columns[5] = { 'data': 'wordsNumber' };

        $('#TblMessages').dataTable({
            "ajax": {
                "url": urlSevice,
                "dataSrc": ""
            },
            "columns": columns
        });

        $('#TblMessages tbody').on('click', 'tr', function () {

            //Fila
            var row = $(this).closest('tr');

            //Dta de la fila de la tabla
            var data = $('#TblMessages').DataTable().row(row).data();

            $("#txtFor").val(data.From);
            $("#txtTo").val(data.To);
            $("#txtText").val(data.Text);

        })
    }

 }


//Instanciamiento inicial de la clase.
//Siempre se ejecuta al finalizar la carga de la página.
//Document: Hace referencia al contenido del HTML
$(document).ready(function () {
    var view = new SendMessageController();
    view.InitView();
});