import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FiltradoUauarioTipoUsuarioComponent } from './filtrado-uauario-tipo-usuario.component';

describe('FiltradoUauarioTipoUsuarioComponent', () => {
  let component: FiltradoUauarioTipoUsuarioComponent;
  let fixture: ComponentFixture<FiltradoUauarioTipoUsuarioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FiltradoUauarioTipoUsuarioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FiltradoUauarioTipoUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
