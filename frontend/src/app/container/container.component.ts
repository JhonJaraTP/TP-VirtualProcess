import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { RequestService } from 'src/app/services/request.service'
import * as Jquery from 'jquery';

@Component({
  selector: 'app-container',
  templateUrl: './container.component.html',
  styleUrls: ['./container.component.css']
})
export class ContainerComponent implements OnInit {

  ListBusiness: any[] = [];
  ListBusiness1: any[] = [
    {Id: '1',Id_PersonalData: '123456789',Id_KindOfPerson: '1',Name_KindOfPerson: 'PersonaNarutal',NameBusiness: 'Empresa jhon1',Adress: 'calle falsa 123',Id_Municipality: '12',Name_Municipality: 'cundinamarca',Phone: '3234567890'},
    {Id: '2',Id_PersonalData: '123456789',Id_KindOfPerson: '1',Name_KindOfPerson: 'Juridica',NameBusiness: 'Empresa jhon2',Adress: 'calle falsa 1234',Id_Municipality: '13',Name_Municipality: 'cundinamarca-f',Phone: '3234567890'}
  ];
  DataUSer: any[] = [
    {Id: '1',ID_Type_Document: '1',Name_Type_Document: 'CC',NIT: '123456789',NameBusiness: 'Pruebas',FirstName: 'Jhon',MiddleName: 'Alex',FirstLastName: 'Rodriguez',SecondLastName: 'Acevedo',Email: 'jhon123456789.com@gmail.com',AuthorizePhone: '1',AuthorizeEmail: '1',status: '1'},
    {Id: '2',ID_Type_Document: '1',Name_Type_Document: 'CC',NIT: '0987654321',NameBusiness: 'buenas 2',FirstName: 'Yesenia',MiddleName: 'Alejandra',FirstLastName: 'Casallas',SecondLastName: 'Sarmiento',Email: 'Yesenia.casallas@gmail.com',AuthorizePhone: '1',AuthorizeEmail: '1',status: '0'}
  ];
  //accion = 'Agregar';
  formNIT: FormGroup;
  formUser: FormGroup;
  id: number | undefined;
  public subcriptionRequest: Subscription = new Subscription;
  //IDNIT: any[] = [];

  constructor(private Formbuild: FormBuilder, private toastr: ToastrService,private Request: RequestService) {

    this.formNIT = this.Formbuild.group({NIT: ['', [Validators.required, Validators.maxLength(10), Validators.minLength(8)]]})
    this.formUser = this.Formbuild.group({
      Id: ['',[Validators.required, Validators.maxLength(10), Validators.minLength(8)]],
      Name_Type_Document: ['',[Validators.required, Validators.maxLength(4), Validators.minLength(2)]],
      NumberDocument: ['',[Validators.required, Validators.maxLength(10), Validators.minLength(6)]],
      NameBusiness: ['',[Validators.required, Validators.maxLength(50), Validators.minLength(8)]],
      FirstName: ['',[Validators.required, Validators.maxLength(19), Validators.minLength(3)]],
      MiddleName: ['',[Validators.required, Validators.maxLength(19), Validators.minLength(3)]],
      FirstLastName: ['',[Validators.required, Validators.maxLength(19), Validators.minLength(3)]],
      SecondLastName: ['',[Validators.required, Validators.maxLength(19), Validators.minLength(3)]],
      Email: ['',[Validators.required, Validators.maxLength(100), Validators.minLength(10), Validators.email]],
      AuthorizePhone: ['',[Validators.required]],
      AuthorizeEmail: ['',[Validators.required]],
      Status: ['1']
    })
  
  }

  ngOnInit(): void {
    this.ReadAllPersonalDataByNIT();
  }

  ReadIDNIT(){
    let IDNIT = new Array();
    IDNIT.push( this.formNIT.get('NIT')?.value);

    if (this.formNIT.get('NIT')?.value ===  900674335) {
      let StatusNA = 'El numero de NIT se encuentra inactivo en el sistema';
      this.modalvalid(StatusNA)

    } else {
      
    
    if (this.subcriptionRequest) { this.subcriptionRequest.unsubscribe(); }

    this.subcriptionRequest = this.Request.getPersonalDataByNIT(IDNIT[0]).subscribe((data:any[]) => {
      this.toastr.success('Buscando NIT','Buscando...');
      const resultNIT = new Array();
      resultNIT.push(data);
        if (typeof resultNIT === 'undefined') {
        let NA = 'El numero de NIT no se encuentra registrado en la Base de datos';
        this.modalvalid(NA);
        } else {
          if (resultNIT[0]["status"] === 0) {

            let StatusNA = 'El numero de NIT se encuentra inactivo en el sistema';
            this.modalvalid(StatusNA)

            this.toastr.error('El numero de NIT se encuentra inactivo en el sistema','Datos encontrados');
          } else {
            this.toastr.success('Nit encontrado','Buscando...');
            console.log(resultNIT);
            this.ListBusiness = new Array();
            this.ListBusiness.push(this.ListBusiness1)
            //console.log(this.ListBusiness[0])
          }
        } 
    }, error => {
      let StatusNA = 'Por favor llenar correctamente los campos, los campos como NIT y Numero de documento deben ser numericos para los demas deben ser texto y sin signos de puntución';
      this.modalvalid(StatusNA);
    })
  }
    this.formNIT.reset();
  }

  modalvalid(dt: string){

    document.getElementById('Modalvalidator')?.click(); 
    var idmodaltext = document.getElementById("modaltext");
    var elementohtml = document.createElement("p");
    elementohtml.textContent = dt
    idmodaltext?.appendChild(elementohtml);
  }



  ReadAllPersonalData() {
    this.Request.getPersonalData().subscribe(data => {
      console.log(data);
      //this.listTarjetas = data;
    }, error => {
      console.log(error);
    })
  }

  ReadAllPersonalDataByNIT() {
    this.Request.getPersonalDataByNIT(123456789).subscribe(data => {
      console.log(data);
      //this.listTarjetas = data;
    }, error => {
      console.log(error);
    })
  }

  createUSer(data: any){
    //console.log(data["value"]["Name_Type_Document"])
    var convertid = data["value"]["NumberDocument"];
    var a = parseInt(convertid)
    console.log("numero",a)
    
    const userdata: any = {
      Id: parseInt(data["value"]["Id"]),
      Name_Type_Document: data["value"]["Name_Type_Document"],
      NumberDocument: parseInt(data["value"]["NumberDocument"]),
      NameBusiness: data["value"]["NameBusiness"],
      FirstName: data["value"]["FirstName"],
      MiddleName: data["value"]["MiddleName"],
      FirstLastName: data["value"]["FirstLastName"],
      SecondLastName: data["value"]["SecondLastName"],
      Email: data["value"]["Email"],
      AuthorizePhone: 1,
      AuthorizeEmail: 1,
      Status: 1
    }

    console.log(userdata);
    if (this.subcriptionRequest) { this.subcriptionRequest.unsubscribe(); }

    this.subcriptionRequest = this.Request.getPersonalDataCreate(userdata).subscribe((data:any[]) => {
      this.toastr.success('Empresa creada con exito','Registro Exitoso'); 
    }, error => {
      console.log(error)
      let StatusNA = 'Error en el sistema por favor intentelo de nuevo';
      this.modalvalid(StatusNA);
    })
  }

DeleteBussines(id: number) {

  console.log("delete: ", id);
  this.ListBusiness[0].splice(id, 1);
  this.toastr.error('La empresa se ha eliminado con exito','Eliminados  ');
      
  //   this._tarjetaService.deleteTarjeta(id).subscribe(data => {
  //     this.toastr.error('La tarjeta fue eliminada con exito!','Tarjeta eliminada');
  //     this.obtenerTarjetas();
  //   }, error => {
  //     console.log(error);
  //   })

 }

EditBussines(bussines: any) {

  console.log(bussines);
  
}

}
