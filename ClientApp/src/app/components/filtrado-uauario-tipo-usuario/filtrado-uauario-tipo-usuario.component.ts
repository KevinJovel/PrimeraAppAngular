import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service';
@Component({
  selector: 'app-filtrado-uauario-tipo-usuario',
  templateUrl: './filtrado-uauario-tipo-usuario.component.html',
  styleUrls: ['./filtrado-uauario-tipo-usuario.component.css']
})
export class FiltradoUauarioTipoUsuarioComponent implements OnInit {
    usuarios: any;
    constructor(private usuarioService: UsuarioService) { }

  ngOnInit() {
  }
    filtrar(tipoUsuario) {
        if (tipoUsuario.value == "") {
            this.usuarioService.getUsuario().subscribe(data => this.usuarios = data);
        } else {
            this.usuarioService.getFiltrarUsuarioPorTipo(tipoUsuario.value).subscribe(data => this.usuarios = data);
        }
    }

}
