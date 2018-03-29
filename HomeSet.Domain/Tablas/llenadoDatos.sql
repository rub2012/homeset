insert into Categoria (descripcion) values ('Moto');
insert into Categoria (descripcion) values ('Finanzas');
insert into Categoria (descripcion) values ('Electrónica');

insert into SubCategoria (descripcion,CategoriaId) values ('Lavado',1);
insert into SubCategoria (descripcion,CategoriaId) values ('Cambio Aceite',1);
insert into SubCategoria (descripcion,CategoriaId) values ('Cambio Filtro Aceite',1);

insert into SubCategoria (descripcion,CategoriaId) values ('Compra',2);
insert into SubCategoria (descripcion,CategoriaId) values ('Vacaciones',2);
insert into SubCategoria (descripcion,CategoriaId) values ('Venta',2);

insert into SubCategoria (descripcion,CategoriaId) values ('Hardware',3);
insert into SubCategoria (descripcion,CategoriaId) values ('Pic',3);
insert into SubCategoria (descripcion,CategoriaId) values ('Sonido',3);

insert into Evento (descripcion,SubCategoriaId,fecha) values ('Lavado sin jabon',1,'2018-02-11');
  insert into Evento (descripcion,SubCategoriaId,fecha) values ('Motul 2 L',2,'2018-04-14');
  insert into Evento (descripcion,SubCategoriaId,fecha) values ('Filtro original',3,'2018-01-22');
  insert into Evento (descripcion,SubCategoriaId,fecha) values ('Compra PS4',4,'2017-09-11');
  insert into Evento (descripcion,SubCategoriaId,fecha) values ('Necochea 2018',5,'2017-05-01');
  insert into Evento (descripcion,SubCategoriaId,fecha) values ('Cama vendida $1500',6,'2016-07-25');
  insert into Evento (descripcion,SubCategoriaId,fecha) values ('Motherboard server',7,'2016-04-03');
  insert into Evento (descripcion,SubCategoriaId,fecha) values ('Motor arduino',8,'2015-11-20');
  insert into Evento (descripcion,SubCategoriaId,fecha) values ('Parlantes Stereo',9,'2017-12-01');