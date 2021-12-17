
namespace App.AxiosProvider   {

    /*Usuario*/
    export const UsuarioEliminar = (id) => axios.delete<DBEntity>("Usuario/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);
    export const UsuarioGuardar = (entity) => axios.post<DBEntity>("Usuario/Edit", entity).then(({ data }) => data);
    export const UsuarioLogin = (entity) => axios.post<DBEntity>("Login", entity).then(({ data }) => data);

    /*Cliente*/
    export const ClienteEliminar = (id) => axios.delete<DBEntity>("Cliente/Grid?handler=Delete&id=" + id).then(({ data }) => data);
    export const ClienteGuardar = (entity) => axios.post<DBEntity>("Cliente/Edit", entity).then(({ data }) => data);

    /*Categoria*/
    export const CategoriaEliminar = (id) => axios.delete<DBEntity>("Categoria/Grid?handler=Delete&id=" + id).then(({ data }) => data);
    export const CategoriaGuardar = (entity) => axios.post<DBEntity>("Categoria/Edit", entity).then(({ data }) => data);

    //export const CategoriaEliminar = (id) => ServiceApi.delete<DBEntity>("api/Categoria/" + id).then(({ data }) => data);
    //export const CategoriaGuardar = (entity) => ServiceApi.post<DBEntity>("api/Categoria", entity).then(({ data }) => data);
    //export const CategoriaActualizar = (entity) => ServiceApi.put<DBEntity>("api/Categoria", entity).then(({ data }) => data);

    /*Producto*/
    export const ProductoEliminar = (id) => axios.delete<DBEntity>("Producto/Grid?handler=Delete&id=" + id).then(({ data }) => data);
    export const ProductoGuardar = (entity) => axios.post<DBEntity>("Producto/Edit", entity).then(({ data }) => data);

    //export const ProductoEliminar = (id) => ServiceApi.delete<DBEntity>("api/Producto/" + id).then(({ data }) => data);
    //export const ProductoGuardar = (entity) => ServiceApi.post<DBEntity>("api/Producto", entity).then(({ data }) => data);
    //export const ProductoActualizar = (entity) => ServiceApi.put<DBEntity>("api/Producto", entity).then(({ data }) => data);

    /*Pedido*/
    export const PedidoEliminar = (id) => axios.delete<DBEntity>("Pedido/Grid?handler=Delete&id=" + id).then(({ data }) => data);
    export const PedidoGuardar = (entity) => axios.post<DBEntity>("Pedido/Edit", entity).then(({ data }) => data);
    
}
