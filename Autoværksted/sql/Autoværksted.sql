create database AutoVaerksted
use AutoVaerksted

create table Kunder (
id int identity(1,1) Primary key,
fornavn nvarchar(50) not null,
efternavn nvarchar(50) not null,
adresse nvarchar(50) not null,
tlf nvarchar(12),
oprettelsesdato date not null
)

create table Biler (
reg_nr nvarchar(8) primary key,
kunde_id int foreign key references Kunder(id),
maerke nvarchar(50) not null,
model nvarchar(50) not null,
aargang date not null check(aargang > 1900),
km int check(km >= 0),
braendstof nvarchar(30) not null,
km_l float not null,
oprettelsesdato date not null
)

create table Vaerkstedsophold (
id int identity(1,1) Primary key,
dato date not null,
kunde_id int foreign key references Kunder(id),
fk_reg_nr nvarchar(8) foreign key references Biler(reg_nr)
)