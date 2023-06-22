import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthorizeService } from '../../api-authorization/authorize.service';
import { environment } from '../../environments/environment';
import { CarritoComprasDataInterfaz, CarritoComprasInterfaz, ContabilidadSimple } from '../../Interfaces/Interfaces';

@Component({
  selector: 'app-carrito-compras',
  templateUrl: './carrito-compras.component.html',
  styleUrls: ['./carrito-compras.component.css']
})
export class CarritoComprasComponent {
  public displayedColumns = ['IdArticulo', 'Descripcion', 'Cantidad', 'Precio','Total','Accion'];
  userIdSesion = "";
  carritoArticulos: CarritoComprasInterfaz[] = [];
  totalCarrito = 0;
  baseApiURL: string = environment.baseApiUrl;
  constructor(private http:HttpClient, private router:Router) {
    this.ObtenerArticulosLS();
    this.ObtenerIdUsuarioActual();
  }
   ObtenerIdUsuarioActual() {
     var service: AuthorizeService = new AuthorizeService();
     
     var user = service.getUser().subscribe(x => {
       var dataParse = JSON.stringify(x);
       var data = JSON.parse(dataParse);
       this.userIdSesion = data.sub;
     });

     
   }

  ObtenerArticulosLS() {
    if ('carritoCompras' in localStorage) {
      var localstorageCarrito: CarritoComprasInterfaz[] = JSON.parse(localStorage.getItem('carritoCompras') || '{}');
      localstorageCarrito.forEach((LScarrito) => {
        this.carritoArticulos.push(LScarrito);
      });
      this.ActualizarMontoTotal();
    }
  }
  EliminarElemento(IdArticulo: number) {
    var carritoArticulosAUX: CarritoComprasInterfaz[] = [];
    if ('carritoCompras' in localStorage) {
      var localstorageCarrito: CarritoComprasInterfaz[] = JSON.parse(localStorage.getItem('carritoCompras') || '{}');
      localstorageCarrito.forEach((LScarrito) => {
        if (IdArticulo!=LScarrito.IdArticulo) {
          carritoArticulosAUX.push(LScarrito);
        }
      });
      localStorage.removeItem("carritoCompras");
      localStorage.setItem("carritoCompras", JSON.stringify(carritoArticulosAUX))
      this.carritoArticulos = JSON.parse(localStorage.getItem('carritoCompras') || '{}');
      this.ActualizarMontoTotal();
    }

    
  }
  ActualizarMontoTotal() {
    if ('carritoCompras' in localStorage) {
      this.totalCarrito = 0; 
      var localstorageCarrito: CarritoComprasInterfaz[] = JSON.parse(localStorage.getItem('carritoCompras') || '{}');
      localstorageCarrito.forEach((LScarrito) => {
        this.totalCarrito += LScarrito.Cantidad * LScarrito.Precio;
      });

    }
  }
  SimularCompra(UserId: string) {
    
    if ('carritoCompras' in localStorage) {
      var cestaLista: CarritoComprasDataInterfaz[]=[];
      var localstorageCarrito: CarritoComprasInterfaz[] = JSON.parse(localStorage.getItem('carritoCompras') || '{}');
      localstorageCarrito.forEach((LScarrito) => {
        var cesta: CarritoComprasDataInterfaz = {
          ArticuloId: LScarrito.IdArticulo,
          UserId:UserId,
          Cantidad: LScarrito.Cantidad,
          Precio: LScarrito.Precio,

        };
        cestaLista.push(cesta);
      });
      
      this.http.post<any>(this.baseApiURL + "api/CRUDCarritoCompra", cestaLista).subscribe(data => {
        var contab: ContabilidadSimple = {
          Total: this.totalCarrito,
          UserId:UserId
        };
        this.http.post<any>(this.baseApiURL + "api/CRUDCarritoCompra/contabilidad", contab).subscribe(data => {
          this.http.put<any>(this.baseApiURL + "api/CRUDInventario", cestaLista).subscribe(data => {
            localStorage.removeItem("carritoCompras");
            this.router.navigateByUrl("/articulos");
          });
        });
      });

    }
    
    
  }
}
