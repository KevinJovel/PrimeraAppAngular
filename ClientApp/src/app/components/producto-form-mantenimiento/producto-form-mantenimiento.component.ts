import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { ProductoService } from '../../services/Producto.Service'
import { CategoriaService } from '../../services/categoria.service'
import { ActivatedRoute, Router } from '@angular/router'
@Component({
  selector: 'app-producto-form-mantenimiento',
  templateUrl: './producto-form-mantenimiento.component.html',
  styleUrls: ['./producto-form-mantenimiento.component.css']
})
export class ProductoFormMantenimientoComponent implements OnInit {
    producto: FormGroup;
    titulo: string;
    categorias: any;
    marcas: any;
    parametro: string;
    constructor(private productoService: ProductoService, private route: Router, private categoriaService: CategoriaService, private activateRoute: ActivatedRoute) {
        this.producto = new FormGroup({
            'idProducto': new FormControl("0"),
            'nombre': new FormControl("", [Validators.required, Validators.maxLength(100)]),
            'precio': new FormControl("0", [Validators.required]),
            'stock': new FormControl("0", [Validators.required]),
            'idMarca': new FormControl("0", [Validators.required]),
            'idCategoria': new FormControl("0", [Validators.required])
        });
        this.activateRoute.params.subscribe(parametro => {
            this.parametro = parametro["id"];
            if (this.parametro == "nuevo") {
                this.titulo = "Agregar Producto";
            } else {
                this.titulo = "Editar Producto";
            }
        });
    }

    ngOnInit() {
        this.productoService.listarMarcas().subscribe(res => this.marcas = res);
        this.categoriaService.getCategoria().subscribe(res => this.categorias = res);
        if (this.parametro != "nuevo") {
         
            this.productoService.obtenerProductoPorId(this.parametro).subscribe(data => {
             
                this.producto.controls["idProducto"].setValue(data.idProducto);
                this.producto.controls["nombre"].setValue(data.nombre);
                this.producto.controls["precio"].setValue(data.precio);
                this.producto.controls["stock"].setValue(data.stock);
                this.producto.controls["idMarca"].setValue(data.idMarca);
                this.producto.controls["idCategoria"].setValue(data.idCategoria);
            });
        }
    }
    guardarDatos() {
        if (this.producto.valid == true) {
            this.productoService.registrarProducto(this.producto.value)
                .subscribe(data => {
                    this.route.navigate(["/mantenimiento-producto"])
                });
        }
    }

}
