CREATE TABLE SubCategoria (
  Id int NOT NULL AUTO_INCREMENT,
  Descripcion varchar(500) NOT NULL,
  CategoriaId int,  
  PRIMARY KEY (Id),
  FOREIGN KEY (CategoriaId) REFERENCES Categoria(Id)
  )