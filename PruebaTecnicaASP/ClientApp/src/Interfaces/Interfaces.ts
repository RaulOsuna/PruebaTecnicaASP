export interface TiendaInterfaz {
  Direccion: string;
  Sucursal: string;
  Estatus: boolean;
}
export interface TiendaInterfazDB {
  Id: number;
  Direccion: string;
  Sucursal: string;
  Estatus: boolean;
}
export interface ArticuloInterfaz {
  Id?: number;
  Codigo: string;
  Descripcion: string;
  Precio: number;
  Stock: number;
  Estatus: boolean;
  Image?: Uint8Array[],
  TiendaId:number
}
export interface ArticuloEditInterfaz {
  Id: Number
  Codigo: string;
  Descripcion: string;
  Precio: number;
  Stock: number;
  Estatus?: boolean;
  TiendaId?: number;
}
export interface CarritoComprasInterfaz {
  IdArticulo: number;
  Cantidad: number;
  Precio: number;
  Descripcion: string;
}

export interface CarritoComprasDataInterfaz {
  ArticuloId: number;
  UserId: String;
  Cantidad: number;
  Precio: number;
  
}

export interface ContabilidadSimple {
  UserId: string;
  Total: number;

}

export interface FileInterfaz {
  Base64: string;
  Extension: string;
  Codigo: string;

}





