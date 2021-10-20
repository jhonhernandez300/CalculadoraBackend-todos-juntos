import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators, FormControl} from '@angular/forms';
import { ServicioSettings } from '../data/servicio-settings';
import { Colaborador } from '../data/colaborador';
import { Area } from '../data/area';
import { DataService } from '../data/data.service';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { AriaDescriber } from '@angular/cdk/a11y';
import { timer } from 'rxjs';

@Component({
  selector: 'app-registrar-colaborador',
  templateUrl: './registrar-colaborador.component.html',
  styleUrls: ['./registrar-colaborador.component.css']
})
export class RegistrarColaboradorComponent implements OnInit {
  hoy: Date = new Date();

  colaborador: Colaborador = {
    numeroDeIndentificacion: null,
    nombres: null,
    apellidos: null,
    direccion: null,
    email: null,
    telefono: null,
    salario: null,
    fk_Area: null,    
    fechaDeIngreso: null,
    sexo: null,
    codigoInterno: null
  };

  // area: Area = {
  //   id: null,
  //   nombre: null
  // };

  // areas: Area[] = [
  //   areas: Area[] = [
  //   {
  //     id: 1,
  //     nombre: "Contabilidad"
  //   },
  //   {
  //     id: 2,
  //     nombre: "Sistemas"
  //   }
  // ];

  myForm: FormGroup;    
  submitted = false;    
  elCodigoInterno: string;  

  constructor(private formBuilder: FormBuilder, private dataService: DataService) { }
    
  iniciarFormulario(){
      this.myForm = new FormGroup({        
        numeroDeIndentificacion: new FormControl(this.colaborador.numeroDeIndentificacion, [Validators.required, Validators.minLength(4), Validators.maxLength(30)]),
        nombres: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(30)]),
        apellidos: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(30)]),
        direccion: new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(30)]),
        email: new FormControl('', [Validators.minLength(4), Validators.maxLength(30)]),
        telefono: new FormControl('', [Validators.minLength(7), Validators.maxLength(15)]),        
        salario: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(5)]),            
        // area: new FormControl(''),                   
        fechaDeIngreso: new FormControl('', [Validators.required]),
        sexo: new FormControl('', [Validators.required]),
        codigoInterno: new FormControl(this.colaborador.codigoInterno)
      });
  }

  

  ngOnInit() {    
    this.dataService.getCodigoInterno().subscribe(
      //result => console.log('success ', result),
      result => this.elCodigoInterno = result,
      error => console.log('error ', error)
    );

    // this.dataService.obtenerAreas().subscribe(
    //   //result => console.log('success ', result),
    //   result => this.areas = result,
    //   error => console.log('error ', error)
    // );

    this.iniciarFormulario();       
    // timer(50).subscribe(() => {
    //   this.areas = [
    //     {
    //       id: 1,
    //       nombre: 'Berge',
    //     },
    //     {
    //       id: 1,
    //       nombre: 'Seen',
    //     },
    //   ];
    // });
  }

  onSelect(id: any): void{
    console.log('id ', id);
  }

  onSubmit() {
    this.submitted = true;

    if (this.myForm.invalid) {
      alert ('Error')
      return      
    }
    this.dataService.RegistrarColaborador(this.myForm.value).subscribe(              
                 result => console.log('success ', result),                 
                 error => console.log('error ', error)                 
             );    
             
  }  
}
