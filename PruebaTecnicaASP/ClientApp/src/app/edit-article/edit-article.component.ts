import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router, ActivatedRoute, Params, Route } from '@angular/router';
import { environment } from '../../environments/environment';
import { ArticuloEditInterfaz, TiendaInterfaz, TiendaInterfazDB } from '../../Interfaces/Interfaces';
import { MiModalComponent } from '../mi-modal/mi-modal.component';

@Component({
  selector: 'app-edit-article',
  templateUrl: './edit-article.component.html',
  styleUrls: ['./edit-article.component.css']
})
export class EditArticleComponent {
  id: number=0;
  articuloEditar: any;
  tiendaEditar:any;
  baseApiURL: string = environment.baseApiUrl;
  constructor(private router: Router, private route: ActivatedRoute, private http: HttpClient, public dialog: MatDialog) {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.ObtenerArticuloPorId();

    
  }

  ObtenerTiendaPorId() {
    var self = this;
    var tienda: TiendaInterfazDB = {
      Id: this.articuloEditar.tiendaId,
      Sucursal: "",
      Direccion: "",
      Estatus:false
    };
    this.http.post<any>(this.baseApiURL + "api/CRUDTienda/Id", tienda).subscribe(x => {
      self.tiendaEditar = x;
      console.log(x);
    });
  }
  ObtenerArticuloPorId() {
    var self = this;
    var Articulo: ArticuloEditInterfaz = {
      Id: this.id,
      Codigo: "",
      Descripcion: "",
      Stock: 0,
      Precio: 0,
      TiendaId:0
    };
    
    this.http.post<any>(this.baseApiURL + "api/CRUDArticulo/Id", Articulo).subscribe(x => {
      self.articuloEditar = x;
      this.ObtenerTiendaPorId();
    });
  }
  Editar (code: string, Descripcion: string, Precio: string, stock: string) {
    let articulo: ArticuloEditInterfaz = {
      Id: this.id,
      Codigo: code,
      Descripcion: Descripcion,
      Precio: Number(Precio),
      Stock:Number(stock)
    };
    this.http.put<any>(this.baseApiURL + "api/CRUDArticulo", articulo).subscribe(data => {
      this.openDialog();
    });
  }
  openDialog(): void {
    const dialogRef = this.dialog.open(MiModalComponent, {
      width: '250px',
      data: {}
    });
    dialogRef.afterClosed().subscribe(res => {
      this.router.navigateByUrl("articulos");
    });
  }
  ngOnInit() {
    
  }
}
