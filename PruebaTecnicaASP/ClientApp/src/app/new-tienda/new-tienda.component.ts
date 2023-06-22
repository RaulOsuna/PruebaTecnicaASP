import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';
import { TiendaInterfaz } from '../../Interfaces/Interfaces';
import { MiModalComponent } from '../mi-modal/mi-modal.component';

@Component({
  selector: 'app-new-tienda',
  templateUrl: './new-tienda.component.html',
  styleUrls: ['./new-tienda.component.css']
})
export class NewTiendaComponent {
  baseApiURL: string = environment.baseApiUrl;
  constructor(private http: HttpClient, public dialog: MatDialog, private router: Router) {

  }

  Guardar(Sucursal: string, Direccion: string) {


    let tienda: TiendaInterfaz = {
      Sucursal: Sucursal,
      Direccion: Direccion,
      Estatus:true
    };

    this.http.post<any>(this.baseApiURL + "api/CRUDTienda", tienda).subscribe(data => {
      this.openDialog();
    });

    



  }
  openDialog(): void {
    const dialogRef = this.dialog.open(MiModalComponent, {
      width: '250px',
      data: {}
    });
    dialogRef.afterClosed().subscribe(res  => {
      this.router.navigateByUrl('/articulos');
    });
  }
}
