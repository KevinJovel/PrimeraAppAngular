import { Component, OnInit, Input } from '@angular/core';
//importar el servicio
import { ProductoService } from '../../services/Producto.Service'
@Component({
  selector: 'tabla-producto',
  templateUrl: './tabla-producto.component.html',
  styleUrls: ['./tabla-producto.component.css']
})
export class TablaProductoComponent implements OnInit {
    @Input() productos: any;
    @Input() isMantenimiento = false;
    p: number = 1;
    cabeceras: string[] = ["ID", "Nombre", "Precio", "Stock", "Nombre Categoria"]
    constructor(private producto: ProductoService) { }
    //Todo lo que vaya aqui se va a ejecutar cuando cargue la pagina
    ngOnInit() {
        this.producto.getProducto().subscribe(
            data => this.productos = data        );
    }
    eliminarProducto(idProducto,nombre) {
        if (confirm("Esta seguro de eliminar el registro: "+nombre) == true) {
            this.producto.eliminarProducto(idProducto).subscribe(res => {
                this.producto.getProducto().subscribe(
                    data => this.productos = data);
            });
        }
    }

}
