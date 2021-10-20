import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultarColaboradorComponent } from './consultar-colaborador.component';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { DataService } from '../data/data.service';

describe('ConsultarColaboradorComponent', () => {
  let component: ConsultarColaboradorComponent;
  let fixture: ComponentFixture<ConsultarColaboradorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConsultarColaboradorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsultarColaboradorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  describe('ContactsService', () => {
    beforeEach(() => {
      TestBed.configureTestingModule({
        imports: [ HttpClientTestingModule ],    
        providers: [ DataService ]
      });
    });
  
    describe('getContacts', () => {  
      let contactService: DataService;
      let httpTestingController: HttpTestingController;
      let mockContact: any;
  
      beforeEach(() => {
        contactService = TestBed.inject(DataService);
        httpTestingController = TestBed.inject(HttpTestingController);      
        mockContact =   {
          "id": 2,
          "numeroDeIndentificacion": 33,
          "nombres": "James",
          "apellidos": "Rodriguez",
          "direccion": "Carrera 210",
          "email": "jr@gmail.com",
          "telefono": "456258741",
          "salario": 2000,
          "fechaDeIngreso": "2021-02-02T00:00:00",
          "sexo": "Masculino",
          "codigoInterno": "91c83f31-ecd5-4da9-81f2-47c972b1ab8e"
        };
      });
  
      it('should GET a list of contacts', () => {
        contactService.ConsultarColaboradorPorIdentificación(33).subscribe((colaboradores) => {    
          expect(colaboradores[0]).toEqual(mockContact);
        });
  
        // const request = httpTestingController.expectOne('app/contacts');
        const request = httpTestingController.expectOne('api/ConsultarColaboradorPorIdentificacion');        
        request.flush([mockContact]);    
        httpTestingController.verify();    
      });
    });
  });
});
