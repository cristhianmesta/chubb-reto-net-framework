CREATE DATABASE CHUBB_RETO;
GO

USE CHUBB_RETO;

CREATE TABLE Authors(
	AuthorId int identity(1,1) not null,
	FullName nvarchar(250) not null,
	BirthDate date not null,
	CityOfOrigin nvarchar(100) null,
	Email nvarchar(100) not null,
	CONSTRAINT PK_Authors PRIMARY KEY (AuthorId),
	CONSTRAINT UQ_AuthorsName UNIQUE (FullName),
)

CREATE TABLE Genres(
	GenreId int identity(1,1) not null,
	Name nvarchar(250) not null,
	CONSTRAINT PK_Genre PRIMARY KEY (GenreId),
)

CREATE TABLE Books(
	BookId int identity(1,1) not null,
	Title nvarchar(250) not null,
	Year int not null,
	GenreId int null,
	NumberOfPages int null,
	AuthorId int not null,
	CONSTRAINT PK_Book_ PRIMARY KEY (BookId),
	CONSTRAINT FK_Book_Genre FOREIGN KEY (GenreId) REFERENCES Genres(GenreId),
	CONSTRAINT FK_Book_Author FOREIGN KEY (AuthorId) REFERENCES Authors(AuthorId)
)

INSERT INTO Authors VALUES ('Mario Vargas Llosa', '1936-03-28', 'Arequipa', 'contacto@mvll.com');
INSERT INTO Authors VALUES ('Robert C. Martín', '1952-12-05', null, 'unclebob@cleancoder.com');
INSERT INTO Authors VALUES ('Carlos Ruiz Zafón', '1964-09-25', 'Barcelona', 'yo@carlosruizzafon.com');
INSERT INTO Authors VALUES ('Gabriel García Márquez', '1927-03-06', null , 'contacto@gabrielgarciamarquez.com');

SELECT * FROM Authors

INSERT INTO Genres VALUES ('Novela');
INSERT INTO Genres VALUES ('Poesia');
INSERT INTO Genres VALUES ('Autoayuda');
INSERT INTO Genres VALUES ('Ciencias Sociales');
INSERT INTO Genres VALUES ('Informática');
INSERT INTO Genres VALUES ('Ingeniería');
INSERT INTO Genres VALUES ('Politica');
INSERT INTO Genres VALUES ('Historia');
INSERT INTO Genres VALUES ('Otros');

SELECT * FROM Genres


INSERT INTO Books VALUES ('Conversación en la Catedral', 1969, 1, 680, 1);
INSERT INTO Books VALUES ('La ciudad y los perros', 1963, 1, 420, 1);
INSERT INTO Books VALUES ('Travesuras de la niña mala', 2006, 1, 400, 1);
INSERT INTO Books VALUES ('La fiesta del Chivo', 2000, 1, 510, 1);
INSERT INTO Books VALUES ('Clean Code', 2008, 5, 644, 2);
INSERT INTO Books VALUES ('La sombra del viento', 2001, null, 576, 3);

SELECT * FROM Books