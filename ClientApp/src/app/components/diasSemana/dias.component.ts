import { Component } from '@angular/core'
@Component({
    selector: "dias-semana",
    templateUrl: "./dias.component.html",
}
)
export class DiasSemana {
    nombre: string = "Kevin";
    cursos: string[] = ["LinQ", "PHP", "ASP.NET Core", "Angular"]
    persona: Object = {
        nombre: "Genesis",
        apellido: "Realegeño"
    }
    enlace: string= "https://www.facebook.com";

}
