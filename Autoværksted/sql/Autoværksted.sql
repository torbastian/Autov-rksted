use master
go

Create database AutoVaerksted
go

use AutoVaerksted
go

create table Kunder (
id int identity(1,1) Primary key,
fornavn nvarchar(50) not null,
efternavn nvarchar(50) not null,
adresse nvarchar(50) not null,
tlf nvarchar(12),
oprettelsesdato date not null
)
go

create table Biler (
reg_nr nvarchar(8) primary key,
kunde_id int foreign key references Kunder(id),
maerke nvarchar(50) not null,
model nvarchar(50) not null,
aargang int not null check(aargang > 1900),
km int check(km >= 0),
braendstof nvarchar(30) not null,
km_l float not null,
oprettelsesdato date not null
)
go

create table Vaerkstedsophold (
id int identity(1,1) Primary key,
oprettelsesdato date not null,
aflevering_dato date,
hentning_dato date,
kunde_id int foreign key references Kunder(id),
fk_reg_nr nvarchar(8) foreign key references Biler(reg_nr),
kunde_kommentar nvarchar(500),
diagnose nvarchar(500),
skade nvarchar(500)
)
go


insert into Kunder (oprettelsesdato, fornavn, efternavn, adresse, tlf) Values 
(GETDATE(), 'Børge', 'Bensen', 'Bovej 22', '27212233'),
(GETDATE(), 'Claus', 'Petersen', 'Stevej 110', '33446771')
go

Insert into Biler (oprettelsesdato, kunde_id, reg_nr, maerke, model, km, km_l, braendstof, aargang) values
(GETDATE(), 1, 'XXXABC', 'Tesla', 'S', 15000, 33.2, 'El', 2015),
(GETDATE(), 2, 'ABCDEF', 'Ford', 'Mustang', 200, 7.5, 'Diesel', 2014),
(GETDATE(), 2, 'FEDCBA', 'Ford', 'Fiesta', 200000, 16.4, 'Benzin', 2010)
go

insert into Vaerkstedsophold (oprettelsesdato, aflevering_dato, hentning_dato, kunde_id, fk_reg_nr, kunde_kommentar, diagnose, skade) values
(GETDATE(), null, null, 2, 'ABCDEF', 'Ryger', 'Skadet motor', 'Ny Motor')
go