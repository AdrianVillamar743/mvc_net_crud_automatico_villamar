create database Bibliotecas;

use Bibliotecas;

create table biblioteca (
id_biblioteca int primary key identity (1,1),
nombre varchar (255),
direccion varchar (255)
)



create table bibliotecaria (
id_bibliotecaria int primary key identity (1,1),
nombre varchar (255),
apellido varchar (255),
id_biblioteca int,
CONSTRAINT fk_bibliotecaria_biblioteca FOREIGN KEY (id_biblioteca) REFERENCES biblioteca (id_biblioteca)
        ON DELETE CASCADE
        ON UPDATE CASCADE
)


create table libro (
id int primary key identity (1,1),
nombre varchar (255),
descripcion varchar (255),
id_bibliotecaria int,
CONSTRAINT fk_libro_bibliotecaria FOREIGN KEY (id_bibliotecaria) REFERENCES bibliotecaria (id_bibliotecaria)
        ON DELETE CASCADE
        ON UPDATE CASCADE
)




insert into biblioteca (nombre, direccion ) values ('Monroe', 'La Libertad');
insert into biblioteca (nombre, direccion ) values ('Marilyn', 'Salinas');
insert into biblioteca (nombre, direccion ) values ('Manson', 'Santa Elena');

select *from biblioteca


insert into bibliotecaria (nombre,apellido,id_biblioteca) values ('Alejandra','Malave', 1);
insert into bibliotecaria (nombre,apellido,id_biblioteca) values ('Carla','Rosales',2);
insert into bibliotecaria (nombre,apellido,id_biblioteca) values ('Maria','Sanchez',3)
insert into bibliotecaria (nombre,apellido,id_biblioteca) values ('Alma','Rada',2)


select persona.nombre as NOMBRE, persona.apellido as APELLIDO, lugar.nombre as BIBLIOTECA, lugar.direccion as DIRECCION from bibliotecaria persona, biblioteca lugar where persona.id_biblioteca=lugar.id_biblioteca




insert into libro (nombre,descripcion,id_bibliotecaria) values ('Dracula','Es de un vampiro', 1);
insert into libro (nombre,descripcion,id_bibliotecaria) values ('Frankestein','Es de un monstruo',2);
insert into libro (nombre, descripcion,id_bibliotecaria)values ('Ciudad Zombie','Es de ponies',3);
insert into libro (nombre,descripcion,id_bibliotecaria) values ('Mi lucha','Es de Lenin Moreno',1)


select documento.nombre as NOMBRE, documento.descripcion as DESCRIPCION, persona.nombre as NOMBRE_DUEÑA, persona.apellido as APELLIDO_DUEÑA from libro documento, bibliotecaria persona where documento.id_bibliotecaria=persona.id_bibliotecaria