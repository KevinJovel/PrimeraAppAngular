import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UsuarioService } from '../../services/usuario.service';
import { Router } from '@angular/router';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  usuario: FormGroup;
  error: boolean = false;
  urlBase: string = "";
  constructor(private usuarioService: UsuarioService, private router: Router, @Inject("BASE_URL") url: string) {
    this.urlBase = url;
    this.usuario = new FormGroup({
      'nombreUsiario': new FormControl("", Validators.required),
      'contra': new FormControl("", Validators.required)
      })
  }

  ngOnInit() {
  }
  login() {
    if (this.usuario.valid == true) {
      this.usuarioService.login(this.usuario.value).subscribe(res => {
        if (res == 1) {
          this.error = true;
        } else {
          this.error = false;
          // this.router.navigate(["./"]);
          window.location.href = this.urlBase + "componente-bienvenida";
        }
      })
      }
  }

}
