import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UsuarioService } from '../../services/usuario.service'
import { PersonaService } from '../../services/persona.service'

@Component({
  selector: 'usuario-form-mantenimiento',
  templateUrl: './usuario-form-mantenimiento.component.html',
  styleUrls: ['./usuario-form-mantenimiento.component.css']
})
export class UsuarioFormMantenimientoComponent implements OnInit {
    usuario: FormGroup;
    parametro: string = "";
    titulo: string = "";
    tipoUsuarios: any;
    personas: any;
    ver: boolean = true;

    constructor(private activateRoute: ActivatedRoute, private usuarioService: UsuarioService, private personaService: PersonaService, private router: Router) {
        this.usuario = new FormGroup({
            'idUsuario': new FormControl("0"),
            'nombreUsiario': new FormControl("", [Validators.required, Validators.maxLength(100)], this.noRepetirUsuario.bind(this)),
            'idPersona': new FormControl("", [Validators.required]),
            'idTipoUsuario': new FormControl("", [Validators.required]),
            'contra': new FormControl("", [Validators.required]),
            'contra2': new FormControl("", [Validators.required, this.validarContras.bind(this)])
        });
        this.activateRoute.params.subscribe(param => {
            this.parametro = param["id"];
            if (this.parametro == "nuevo") {
                this.ver = true;
            } else {
                this.ver = false;
                this.usuarioService.recuperarUsuario(this.parametro).subscribe(data => {
                    this.usuario.controls["idUsuario"].setValue(data.idUsuario);
                    this.usuario.controls["nombreUsiario"].setValue(data.nombreUsiario);
                    this.usuario.controls["idTipoUsuario"].setValue(data.idTipoUsuario);
                    this.usuario.controls["contra"].setValue("1");
                    this.usuario.controls["contra2"].setValue("1");
                    this.usuario.controls["idPersona"].setValue("1");
                });
            
            }
        })
    }
    guardarDatos() {
        if (this.usuario.valid == true) {
            this.usuarioService.guardarUsuario(this.usuario.value).subscribe(res => {
                this.router.navigate(["/mantenimiento-usuario"])
            })
        }
    }

    

    ngOnInit() {
        this.usuarioService.getTipoUsuario().subscribe(data => {
            this.tipoUsuarios=data
        });
        this.personaService.listarPersonaCombo().subscribe(data => {
            this.personas = data
        });
       
        if (this.parametro == "nuevo") {
            this.titulo = "Agregar Usuario";
        } else {
            this.titulo = "Editar Usuario";
        }

    }
    validarContras(control: FormControl) {
        if (control.value != "" && control.value != null) {
            if (this.usuario.controls["contra"].value != control.value) {
                return { noiguales: true};
            } else {
                return null;
            }
        }
    }
    noRepetirUsuario(control: FormControl) {
        var promesa = new Promise((resolve, reject) => {
            if (control.value != "" && control.value != null) {
                this.usuarioService.validarUsuario(this.usuario.controls['idUsuario'].value, control.value)
                    .subscribe(data => {
                        if (data == 1) {
                            resolve({ yaExiste: true });
                        } else {
                            resolve(null);
                        }
                    })
            }
        });
        return promesa;
    }
}
