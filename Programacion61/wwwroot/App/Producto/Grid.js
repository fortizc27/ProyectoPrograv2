"use strict";
var ProductoGrid;
(function (ProductoGrid) {
    function OnClickDelete(id) {
        ComfirmAlert("Desea eliminar el registro?", "Eliminar", "warning", "#3085d6", "d33").then(function (result) {
            if (result.isConfirmed) {
                /*Message animation to indicate deletion is in progress*/
                Loading.fire("Eliminacion en proceso");
                //Call the Axios Service
                App.AxiosProvider.ProductoEliminar(id).then(function (data) {
                    /*Closes the loading animation*/
                    Loading.close();
                    /*If no error exist*/
                    if (data.CodeError == 0) {
                        /*Message indicating the file was successfully deleted*/
                        Toast.fire({ title: "Registro eliminado exitosamente!", icon: "success" }).then(function () { return window.location.reload(); });
                    }
                    else {
                        Toast.fire({ title: data.MsgError, icon: "error" });
                    }
                });
            }
        });
    }
    ProductoGrid.OnClickDelete = OnClickDelete;
    //Gives HTML Table search, pagination, etc. features.
    $("#GridView").DataTable();
})(ProductoGrid || (ProductoGrid = {}));
//# sourceMappingURL=Grid.js.map