import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { PersonaService } from '../../services/persona.service'
import { Router, ActivatedRoute } from '@angular/router'

@Component({
  selector: 'app-persona-form-mantenimiento',
  templateUrl: './persona-form-mantenimiento.component.html',
  styleUrls: ['./persona-form-mantenimiento.component.css']
})
export class PersonaFormMantenimientoComponent implements OnInit {
    persona: FormGroup;
    titulo: string;
    parametro: string;
    constructor(private personaService: PersonaService, private route: Router, private activateRoute: ActivatedRoute) {
        this.persona = new FormGroup({
            'idPersona': new FormControl("0"),
            'nombre': new FormControl("", [Validators.required, Validators.maxLength(100)]),
            'aPaterno': new FormControl("", [Validators.required, Validators.maxLength(150)]),
            'aMaterno': new FormControl("", [Validators.required, Validators.maxLength(150)]),
            'telefono': new FormControl("", [Validators.required, Validators.maxLength(10)]),
            'correo': new FormControl("", [Validators.required, Validators.maxLength(150), Validators.pattern("^[^@]+@[^@]+\.[a-zA-Z]{2,}$")]),
            'fechaNacimiento': new FormControl("", [Validators.required])
        }
        );
        this.activateRoute.params.subscribe(parametro => {
            this.parametro = parametro["id"];
            if (this.parametro == "nuevo") {
                this.titulo = "Agregar Persona";
            } else {
                this.titulo = "Editar Persona";
            }
        });

    }
    ngOnInit() {
        //programa la recuperacion de datos: nunca en el metodo
        if (this.parametro != "nuevo") {
            this.personaService.recuperarPersona(this.parametro).subscribe(param => {
                //aqui se sacan los valores
                this.persona.controls["idPersona"].setValue(param.idPersona);
                this.persona.controls["nombre"].setValue(param.nombre);
                this.persona.controls["aPaterno"].setValue(param.aPaterno);
                this.persona.controls["aMaterno"].setValue(param.aMaterno);
                this.persona.controls["telefono"].setValue(param.telefono);
                this.persona.controls["correo"].setValue(param.correo);
                this.persona.controls["fechaNacimiento"].setValue(param.fechaCadena);
            
            });
        }

  }
    guardarDatos() {
      
        //siempre tiene que estar valido antes de agregar o editar
        if (this.persona.valid == true) {
            var fechaNac = this.persona.controls["fechaNacimiento"].value.split("-");
            var anio = fechaNac[0];
            var mes = fechaNac[1];
            var dia = fechaNac[2];
            this.persona.controls["fechaNacimiento"].setValue(mes + "/" + dia + "/" + anio);
                this.personaService.agregarPersona(this.persona.value).subscribe(data => { this.route.navigate(["/mantenimiento-persona"]) });
          
        }
    }

}
