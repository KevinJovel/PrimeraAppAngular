import { Injectable,Inject } from '@angular/core';
import { Http } from '@angular/http'
import 'rxjs/add/operator/map'
@Injectable()

export class ProductoService {
    urlBase: string = "";
    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        //UrlBase tiene el nombre del dominio
        this.urlBase = baseUrl;
    }
    public getProducto() {
        return this.http.get(this.urlBase + "api/Producto/listarProductos").map(res => res.json());
    }
    public getFiltroProductoPorNombre(nombre){
    return this.http.get(this.urlBase + "api/Producto/listarProductosPorNombre/"+nombre).map(res => res.json());
    }
    public getFiltroProductoPorCategoria(cat) {
        return this.http.get(this.urlBase + "api/Producto/listarProductosPorCetegoria/" + cat).map(res => res.json());
    }
    public obtenerProductoPorId(idProducto) {
        return this.http.get(this.urlBase + "api/Producto/obtenerProductoPorId/" + idProducto).map(res => res.json());
    }
    public listarMarcas() {
        return this.http.get(this.urlBase + "api/Producto/listarMarcas").map(res => res.json());
    }
    public eliminarProducto(idProducto) {
        return this.http.get(this.urlBase + "api/Producto/eliminarProducto/" + idProducto).map(res => res.json());
    }
    public registrarProducto(ProductoCLS) {
        return this.http.post(this.urlBase + "api/Producto/registrarProducto", ProductoCLS).map(res => res.json());
    }
}
