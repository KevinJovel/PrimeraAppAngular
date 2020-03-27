import { Component, OnInit } from '@angular/core';
//importar el servicio
import { ProductoService } from '../../services/Producto.Service'
@Component({
  selector: 'tabla-producto',
  templateUrl: './tabla-producto.component.html',
  styleUrls: ['./tabla-producto.component.css']
})
export class TablaProductoComponent implements OnInit {
    productos: any;
    cabeceras: string[] = ["ID", "Nombre", "Precio", "Stock", "Nombre Categoria"]
    constructor(private producto: ProductoService) { }
    //Todo lo que vaya aqui se va a ejecutar cuando cargue la pagina
    ngOnInit() {
        this.producto.getProducto().subscribe(
            data => this.productos = data
        );
  }

}
