import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common'

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { ArticlesComponent } from './articles/articles.component';
import { NewarticleComponent } from './newarticle/newarticle.component';
import { CarritoComprasComponent} from './carrito-compras/carrito-compras.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MiModalComponent } from './mi-modal/mi-modal.component';
import { EditArticleComponent } from './edit-article/edit-article.component';
import { NewTiendaComponent } from './new-tienda/new-tienda.component';
//ANGULAR MATERIAL
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSortModule } from '@angular/material/sort';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatDialogModule } from '@angular/material/dialog';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ArticlesComponent,
    NewarticleComponent,
    CarritoComprasComponent,
    MiModalComponent,
    EditArticleComponent,
    NewTiendaComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      { path: 'articulos', component: ArticlesComponent},
      { path: 'articulos/nuevoArticulo', component: NewarticleComponent, canActivate: [AuthorizeGuard] },
      { path: 'nuevaTienda', component: NewTiendaComponent, canActivate: [AuthorizeGuard] },
      { path: 'articulos/edit/:id', component: EditArticleComponent, canActivate: [AuthorizeGuard] },
      { path: 'carrito', component: CarritoComprasComponent, canActivate: [AuthorizeGuard] },
      
    ]),
    //ANGULAR MATERIAL
    MatTableModule,
    MatPaginatorModule,
    MatInputModule,
    MatProgressSpinnerModule,
    MatSortModule,
    MatCardModule,
    MatButtonModule,
    MatSelectModule,
    MatDialogModule,
    BrowserAnimationsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
