"use strict";
var PedidoEdit;
(function (PedidoEdit) {
    var Entity = $("#AppEdit").data('entity');
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit",
            Entity: Entity
        },
        methods: {
            Save: function () {
                if (BValidateData(this.Formulario)) {
                    Loading.fire("Guardando");
                    App.AxiosProvider.PedidoGuardar(this.Entity).then(function (data) {
                        Loading.close();
                        /*If no error exist*/
                        if (data.CodeError == 0) {
                            /*Message indicating the file was successfully deleted*/
                            Toast.fire({ title: "Pedido almaceno exitosamente!", icon: "success" }).then(function () { return window.location.href = "Pedido/Grid"; });
                        }
                        else {
                            Toast.fire({ title: data.MsgError, icon: "error" });
                        }
                    });
                }
                else {
                    Toast.fire({ title: "Todos los campos son requeridos" });
                }
            }
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("#AppEdit");
})(PedidoEdit || (PedidoEdit = {}));
//# sourceMappingURL=Edit.js.map