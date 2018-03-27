CREATE TABLE Evento (
  Id int NOT NULL AUTO_INCREMENT,
  Descripcion varchar(500) NOT NULL,
  SubCategoriaId int null,
  Fecha datetime not null,
  PRIMARY KEY (Id),
  FOREIGN KEY (SubCategoriaId) REFERENCES SubCategoria(Id)
) 