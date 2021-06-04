use pruebas;

create table cancha(
idCancha int identity(1,1) not null primary key, 
nombreCancha varchar(100), 
capacidad varchar(100), 
estatus varchar(100));

create table cliente(
idCliente int identity(1,1) not null primary key, 
nombre varchar(100));

create table arbitro(
idArbitro int identity(1,1) not null primary key, 
nombre varchar(100));

create table reservas(
idReserva int identity(1,1) not null primary key, 
idCliente int not null, 
idCancha int not null, 
idArbitro int,
Fecha date, 
horaInicio time, 
horaFin time
);

alter table reservas add constraint FK_ReservaCliente foreign key(idCliente) references cliente (idCliente);
alter table reservas add constraint FK_ReservaCancha foreign key(idCancha) references cancha (idCancha);
alter table reservas add constraint FK_ReservaArbitro foreign key(idArbitro) references arbitro (idArbitro);

insert into cancha values('cancha1', '12', 'disponible');
insert into cancha values('cancha2', '12', 'disponible');
insert into cancha values('cancha3', '12', 'disponible');
insert into cancha values('cancha4', '12', 'disponible');

insert into cliente values('juan');
insert into cliente values('josé');
insert into cliente values('rodrigo');
insert into cliente values('carlos');

insert into arbitro values('sam');
insert into arbitro values('oscar');
insert into arbitro values('daniel');
insert into arbitro values('marcelo');

insert into reservas values(1,2,1,'2021-12-05', '14:50', '18:00');
insert into reservas values(1,2,1,'2021-12-05', '19:50', '21:00');
insert into reservas values(1,2,1,'2021-05-12', '14:50', '18:00');
insert into reservas values(1,2,1,'2021-05-14', '14:50', '18:00');
insert into reservas values(1,2,1,'2021-05-14', '09:00', '11:00');

select * from reservas

