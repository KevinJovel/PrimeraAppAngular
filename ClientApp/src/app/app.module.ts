/// <reference path="../main.ts" />
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
//im0ortar para trabajr con formularios
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgxPaginationModule } from 'ngx-pagination'
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
//registrar el componente creado
import { ButtonAgregar } from './components/button/button.component';
import { DiasSemana } from './components/diasSemana/dias.component';
import { TablaProductoComponent } from './components/tabla-producto/tabla-producto.component';
import { FiltradoProductoNombreComponent } from './components/filtrado-producto-nombre/filtrado-producto-nombre.component';
import { FiltradoProductoCategoriaComponent } from './components/filtrado-producto-categoria/filtrado-producto-categoria.component';
import { BuscadorProductoNombreComponent } from './components/buscador-producto-nombre/buscador-producto-nombre.component';
import { BuscadorProductoCategoriaComponent } from './components/buscador-producto-categoria/buscador-producto-categoria.component';
import { TablaPersonaComponent } from './components/tabla-persona/tabla-persona.component';
import { BuscadorPersonaNombreCompletoComponent } from './components/buscador-persona-nombre-completo/buscador-persona-nombre-completo.component';
import { FiltradoPersonaNombreCompletoComponent } from './components/filtrado-persona-nombre-completo/filtrado-persona-nombre-completo.component';
import { BuscadorUsuarioTipoUsuarioComponent } from './components/buscador-usuario-tipo-usuario/buscador-usuario-tipo-usuario.component';
import { FiltradoUauarioTipoUsuarioComponent } from './components/filtrado-uauario-tipo-usuario/filtrado-uauario-tipo-usuario.component';
import { TablaUsuarioComponent } from './components/tabla-usuario/tabla-usuario.component';
import { MantenimientoPersonaComponent } from './components/mantenimiento-persona/mantenimiento-persona.component';
import { PersonaFormMantenimientoComponent } from './components/persona-form-mantenimiento/persona-form-mantenimiento.component';
import { MantenimientoProductoComponent } from './components/mantenimiento-producto/mantenimiento-producto.component';
import { ProductoFormMantenimientoComponent } from './components/producto-form-mantenimiento/producto-form-mantenimiento.component';
//Servicios
import { ProductoService } from './services/Producto.Service'
import { CategoriaService } from './services/categoria.service'
import { PersonaService } from './services/persona.service'
import { UsuarioService } from './services/usuario.service'
//HTTP Module
import { HttpModule } from '@angular/http';
import { MantenimientoUsuarioComponent } from './components/mantenimiento-usuario/mantenimiento-usuario.component';
import { UsuarioFormMantenimientoComponent } from './components/usuario-form-mantenimiento/usuario-form-mantenimiento.component';
import { LoginComponent } from './components/login/login.component';
import { PaginaErrorLoginComponent } from './components/pagina-error-login/pagina-error-login.component';
import { PermisoErrorPaginaComponent } from './components/permiso-error-pagina/permiso-error-pagina.component';
import { SeguridadGuard } from './components/guards/seguridad.guard';
import { ComponenteBienvenidaComponent } from './components/componente-bienvenida/componente-bienvenida.component'

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ButtonAgregar,
    DiasSemana,
    TablaProductoComponent,
        FiltradoProductoCategoriaComponent,
        FiltradoProductoNombreComponent,
        BuscadorProductoNombreComponent,
        BuscadorProductoCategoriaComponent,
        TablaPersonaComponent,
        BuscadorPersonaNombreCompletoComponent,
        FiltradoPersonaNombreCompletoComponent,
        BuscadorUsuarioTipoUsuarioComponent,
        FiltradoUauarioTipoUsuarioComponent,
        TablaUsuarioComponent,
        MantenimientoPersonaComponent,
        PersonaFormMantenimientoComponent,
        MantenimientoProductoComponent,
        ProductoFormMantenimientoComponent,
        MantenimientoUsuarioComponent,
        UsuarioFormMantenimientoComponent,
        LoginComponent,
        PaginaErrorLoginComponent,
        PermisoErrorPaginaComponent,
        ComponenteBienvenidaComponent
  ],
    imports: [
    HttpModule,
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule, NgxPaginationModule,
    FormsModule, ReactiveFormsModule,
      RouterModule.forRoot([
        { path: '', component: HomeComponent, pathMatch: 'full' },
        { path: 'counter', component: CounterComponent, canActivate: [SeguridadGuard] },
        { path: 'fetch-data', component: FetchDataComponent, canActivate: [SeguridadGuard] },
        { path: 'filtradoPersonaNombreCompleto', component: FiltradoPersonaNombreCompletoComponent, canActivate: [SeguridadGuard] },
        { path: 'filtradoProductoCategoria', component: FiltradoProductoCategoriaComponent, canActivate: [SeguridadGuard] },
        { path: 'filtradoProductoNombre', component: FiltradoProductoNombreComponent, canActivate: [SeguridadGuard]},
        { path: 'filtradoUsuarioTipo', component: FiltradoUauarioTipoUsuarioComponent, canActivate: [SeguridadGuard]},
        { path: 'mantenimiento-persona', component: MantenimientoPersonaComponent, canActivate: [SeguridadGuard] },
        { path: 'persona-form-mantenimiento/:id', component: PersonaFormMantenimientoComponent, canActivate: [SeguridadGuard]  },
        { path: 'mantenimiento-producto', component: MantenimientoProductoComponent, canActivate: [SeguridadGuard] },
        { path: 'producto-form-mantenimiento/:id', component: ProductoFormMantenimientoComponent, canActivate: [SeguridadGuard]  },
        { path: 'mantenimiento-usuario', component: MantenimientoUsuarioComponent, canActivate: [SeguridadGuard] },
        { path: 'usuario-form-mantenimiento/:id', component: UsuarioFormMantenimientoComponent, canActivate: [SeguridadGuard] },
      { path: 'login', component: LoginComponent },
      { path: 'pagina-error-login', component: PaginaErrorLoginComponent },
        { path: 'pagina-error-permiso', component: PermisoErrorPaginaComponent },
        { path: 'componente-bienvenida', component: ComponenteBienvenidaComponent }
    ])
  ],
  providers: [ProductoService, CategoriaService, PersonaService, UsuarioService, SeguridadGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
