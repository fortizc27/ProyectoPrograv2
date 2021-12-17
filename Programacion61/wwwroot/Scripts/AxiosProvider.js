"use strict";
var App;
(function (App) {
    var AxiosProvider;
    (function (AxiosProvider) {
        /*Usuario*/
        AxiosProvider.UsuarioEliminar = function (id) { return axios.delete("Usuario/Grid?handler=Eliminar&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.UsuarioGuardar = function (entity) { return axios.post("Usuario/Edit", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.UsuarioLogin = function (entity) { return axios.post("Login", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        /*Cliente*/
        AxiosProvider.ClienteEliminar = function (id) { return axios.delete("Cliente/Grid?handler=Delete&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.ClienteGuardar = function (entity) { return axios.post("Cliente/Edit", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        /*Categoria*/
        AxiosProvider.CategoriaEliminar = function (id) { return axios.delete("Categoria/Grid?handler=Delete&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.CategoriaGuardar = function (entity) { return axios.post("Categoria/Edit", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        //export const CategoriaEliminar = (id) => ServiceApi.delete<DBEntity>("api/Categoria/" + id).then(({ data }) => data);
        //export const CategoriaGuardar = (entity) => ServiceApi.post<DBEntity>("api/Categoria", entity).then(({ data }) => data);
        //export const CategoriaActualizar = (entity) => ServiceApi.put<DBEntity>("api/Categoria", entity).then(({ data }) => data);
        /*Producto*/
        AxiosProvider.ProductoEliminar = function (id) { return axios.delete("Producto/Grid?handler=Delete&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.ProductoGuardar = function (entity) { return axios.post("Producto/Edit", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        //export const ProductoEliminar = (id) => ServiceApi.delete<DBEntity>("api/Producto/" + id).then(({ data }) => data);
        //export const ProductoGuardar = (entity) => ServiceApi.post<DBEntity>("api/Producto", entity).then(({ data }) => data);
        //export const ProductoActualizar = (entity) => ServiceApi.put<DBEntity>("api/Producto", entity).then(({ data }) => data);
        /*Pedido*/
        AxiosProvider.PedidoEliminar = function (id) { return axios.delete("Pedido/Grid?handler=Delete&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.PedidoGuardar = function (entity) { return axios.post("Pedido/Edit", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
    })(AxiosProvider = App.AxiosProvider || (App.AxiosProvider = {}));
})(App || (App = {}));
//# sourceMappingURL=AxiosProvider.js.map