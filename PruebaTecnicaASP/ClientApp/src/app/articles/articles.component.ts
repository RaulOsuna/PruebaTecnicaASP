import { HttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';
import { CarritoComprasInterfaz } from '../../Interfaces/Interfaces';
@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css']
})
export class ArticlesComponent {
  baseApiURL: string = environment.baseApiUrl;
  articulosDisponibles: any;
  
  constructor(private router: Router, private http: HttpClient) {
    this.articulosDisponibles = this.ObtenerArticulos();
    
   
  }
  goToPage(page: string) {
    this.router.navigateByUrl('/'+page);
  }
  ObtenerArticulos() {
    var self = this;
    this.http.get(this.baseApiURL + "api/CRUDArticulo").subscribe(x => {
      self.articulosDisponibles = x;
      
    });
  }
  editarArticulo(IdArticulo:number) {
    this.router.navigateByUrl("articulos/edit/"+IdArticulo.toString());
  }
  agreagrAlCarrito(IdArticulo: number, Precio: number, Stock: number, Descripcion:string) {
    
    var Cantidad = Number((<HTMLInputElement>document.getElementById("Cantidad" + IdArticulo.toString())).value);
    var Carrito: CarritoComprasInterfaz[] = [
      { IdArticulo: IdArticulo, Cantidad: Number(Cantidad), Precio:Precio,Descripcion:Descripcion}
    ];
    if ('carritoCompras' in localStorage) {
      var localstorageCarrito: CarritoComprasInterfaz[] = JSON.parse(localStorage.getItem('carritoCompras') || '{}');
      var cantidadNueva = 0;
      var repetido:boolean=false
      localstorageCarrito.forEach((LScarrito) => {
        if (LScarrito.IdArticulo == Carrito[0].IdArticulo) {
          repetido = true;
          cantidadNueva = LScarrito.Cantidad + Cantidad;

          LScarrito.Cantidad = cantidadNueva;
          if (Stock >= cantidadNueva) {
            localStorage.removeItem("carritoCompras");
            localStorage.setItem("carritoCompras", JSON.stringify(localstorageCarrito));
          }
        }
      });
      if (!repetido) {
        localstorageCarrito.push(Carrito[0]);
        localStorage.removeItem("carritoCompras");
        localStorage.setItem("carritoCompras", JSON.stringify(localstorageCarrito));
      }
    } else {
      localStorage.setItem("carritoCompras", JSON.stringify(Carrito));
      
    }
    
  }
}
