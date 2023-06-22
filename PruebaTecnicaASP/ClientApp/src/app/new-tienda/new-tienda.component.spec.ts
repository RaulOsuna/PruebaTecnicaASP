import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewTiendaComponent } from './new-tienda.component';

describe('NewTiendaComponent', () => {
  let component: NewTiendaComponent;
  let fixture: ComponentFixture<NewTiendaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewTiendaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewTiendaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
