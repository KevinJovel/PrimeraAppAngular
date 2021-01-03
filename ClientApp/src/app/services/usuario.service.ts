import { Injectable,Inject } from '@angular/core';
import { Http } from '@angular/http'
import 'rxjs/add/operator/map'
import { Router} from '@angular/router'
@Injectable()
export class UsuarioService {
  urlBase: string = "";
  constructor(private http: Http, @Inject("BASE_URL") url: string, private router: Router) {
        this.urlBase = url;
    }
    public getUsuario() {
        return this.http.get(this.urlBase + "api/Usuario/listarUsuario").map(res => res.json());
    }
    public guardarUsuario(usuarioCLS) {
        return this.http.post(this.urlBase + "api/Usuario/guardarUsuario", usuarioCLS).map(res => res.json());
    }
    public getTipoUsuario(){
        return this.http.get(this.urlBase + "api/Usuario/listarTipoUsuario").map(res => res.json());
    }
    public getFiltrarUsuarioPorTipo(idTipo) {
        return this.http.get(this.urlBase + "api/Usuario/filtrarUsuarioPorTipo/" + idTipo).map(res => res.json());
    }
    public validarUsuario(idUsuario, nombre) {
        return this.http.get(this.urlBase + "api/Usuario/validaUsuario/" + idUsuario + "/" + nombre).map(res => res.json());

    }
    public recuperarUsuario(idUsuario) {
        return this.http.get(this.urlBase + "api/Usuario/RecuperarUsuario/" + idUsuario ).map(res => res.json());

    }
    public eliminarUsuario(idUsuario) {
        return this.http.get(this.urlBase + "api/Usuario/eliminarUsuario/" + idUsuario).map(res => res.json());

  }
  public login(usuario) {
    return this.http.post(this.urlBase + "api/Usuario/login",usuario).map(res => res.json());

  }
  public obtenervariableSesion() {
    return this.http.get(this.urlBase + "api/Usuario/validarSession").map(res => {
      var data = res.json();
      if (data.valor == "") {
        this.router.navigate(["/pagina-error-login"]);
        return false;
      } else {
        return true;
      }

    }

    );

  }
  public obtenerSesion() {
    return this.http.get(this.urlBase + "api/Usuario/validarSession").map(res => {
      var data = res.json();
      if (data.valor == "") {
        return false;
      } else {
        return true;
      }

    }

    );

  }
  public cerrarSesion() {
    return this.http.get(this.urlBase + "api/Usuario/CerrarSesion").map(res => res.json());

  }
  public listarPaginas() {
    return this.http.get(this.urlBase + "api/Usuario/listarPaginas").map(res => res.json());

  }
}
