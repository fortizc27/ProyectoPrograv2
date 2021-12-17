"use strict";
var CategoriaEdit;
(function (CategoriaEdit) {
    var Entity = $("#AppEdit").data('entity');
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit",
            Entity: Entity
        },
        methods: {
            ClienteServicio: function (entity) {
                console.log(entity);
                if (entity.IdCategoria == null) {
                    return App.AxiosProvider.CategoriaGuardar(entity);
                }
                else {
                    return App.AxiosProvider.CategoriaGuardar(entity);
                }
            },
            Save: function () {
                if (BValidateData(this.Formulario)) {
                    Loading.fire("Guardando");
                    App.AxiosProvider.CategoriaGuardar(this.Entity).then(function (data) {
                        Loading.close();
                        /*If no error exist*/
                        if (data.CodeError == 0) {
                            /*Message indicating the file was successfully deleted*/
                            Toast.fire({ title: "Registro almaceno exitosamente!", icon: "success" }).then(function () { return window.location.href = "Categoria/Grid"; });
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
})(CategoriaEdit || (CategoriaEdit = {}));
//# sourceMappingURL=Edit.js.map