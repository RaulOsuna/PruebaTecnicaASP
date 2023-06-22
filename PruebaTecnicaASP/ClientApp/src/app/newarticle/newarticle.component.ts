import { HttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { Component, EventEmitter } from '@angular/core';
import { FormControl } from '@angular/forms';
import { environment } from '../../environments/environment';
import { ArticuloInterfaz, FileInterfaz } from '../../Interfaces/Interfaces';
import { MatDialog, MatDialogRef, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MiModalComponent } from '../mi-modal/mi-modal.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-newarticle',
  templateUrl: './newarticle.component.html',
  styleUrls: ['./newarticle.component.css']
})

export class NewarticleComponent {
  formulario = new FormControl('');
  baseApiURL: string = environment.baseApiUrl;
  TiendasDisponibles: any;
  imagen: any;
  ImagenExtension:any;
  base64: string = "";
  ddSucursal: any;
  constructor(private http: HttpClient, public dialog: MatDialog, private router: Router) {
    
    this.TiendasDisponibles = this.ObtenerTiendas();
    console.log(this.imagen);
  }
  

  FileCambio(event: Event) {
    const target = event.target as HTMLInputElement;
    const files = target.files as FileList;
    var reader = new FileReader();
    var ImagenExtension = files[0].type.split("image/");
    this.ImagenExtension = "."+ImagenExtension[1].toString();
    reader.readAsDataURL(files[0]);
    var self = this;
    reader.onload = function () {
      
      self.imagen = reader.result;
      console.log(self.imagen);
    };
    reader.onerror = function (error) {
      console.log('Error: ', error);
    };

  }

  Guardar(code: string, Descripcion: string, Precio: string, stock: string) {
    
    
    let articulo: ArticuloInterfaz = {
      Codigo: code,
      Descripcion: Descripcion,
      Precio: Number(Precio),
      Stock: Number(stock),
      Image: this.imagen,
      Estatus: true,
      TiendaId: this.ddSucursal
    };

    this.http.post<any>(this.baseApiURL + "api/CRUDArticulo", articulo).subscribe(data => {
      if (this.imagen!=undefined) {
        var Imagen: FileInterfaz = {
          Base64: this.imagen.split(',')[1],
          Codigo: String(data),
          Extension: this.ImagenExtension
        };
        this.http.post<any>(this.baseApiURL + "api/FileUpload", Imagen).subscribe(data => {
          this.openDialog();
        });
      } else {
        this.openDialog();
      }
      
    });
    
    
    
    

  }
  changeClient(event: any) {
    this.ddSucursal = event;
  }
  openDialog(): void {
    const dialogRef = this.dialog.open(MiModalComponent, {
      width: '250px',
      data: { }
    });
    dialogRef.afterClosed().subscribe(res => {
      this.router.navigateByUrl('/articulos');
    });
  }
  ObtenerTiendas() {
    var self = this;
    this.http.get(this.baseApiURL + "api/CRUDTienda").subscribe(x => {
      self.TiendasDisponibles = x;
    });
  }

}

