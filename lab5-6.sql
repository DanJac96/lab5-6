create database Lab5_6;
go
USE [Lab5_6];
go

create table Carro(
idCarro int not null,
Marca Varchar(50) not null,
Modelo Varchar(50) not null,
Pais Varchar(50) not null,
Costo int not null
);
go
USE [Lab5_6];
GO

INSERT INTO [dbo].[Carro]
           ([idCarro]
		   ,[Marca]
           ,[Modelo]
           ,[Pais]
           ,[Costo])
     VALUES
           (1,
		   'Honda',
           'Civic',
           'Costa Rica',
           1700000);
GO

USE [Lab5_6];
GO

SELECT [idCarro]
      ,[Marca]
      ,[Modelo]
      ,[Pais]
      ,[Costo]
  FROM [dbo].[Carro]
GO