USE [master]
GO
/****** Object:  Database [SmartMed]    Script Date: 21/07/2022 21:02:38 ******/
CREATE DATABASE [SmartMed]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SmartMed', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SmartMed.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SmartMed_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SmartMed_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SmartMed] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SmartMed].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SmartMed] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SmartMed] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SmartMed] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SmartMed] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SmartMed] SET ARITHABORT OFF 
GO
ALTER DATABASE [SmartMed] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SmartMed] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SmartMed] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SmartMed] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SmartMed] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SmartMed] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SmartMed] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SmartMed] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SmartMed] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SmartMed] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SmartMed] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SmartMed] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SmartMed] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SmartMed] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SmartMed] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SmartMed] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SmartMed] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SmartMed] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SmartMed] SET  MULTI_USER 
GO
ALTER DATABASE [SmartMed] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SmartMed] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SmartMed] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SmartMed] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SmartMed] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SmartMed] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SmartMed] SET QUERY_STORE = OFF
GO
USE [SmartMed]
GO
/****** Object:  Table [dbo].[medications]    Script Date: 21/07/2022 21:02:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[medications](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NULL,
	[cantidade] [int] NOT NULL,
	[dataCreacion] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[medications] ADD  DEFAULT ((1)) FOR [cantidade]
GO
ALTER TABLE [dbo].[medications] ADD  DEFAULT (getdate()) FOR [dataCreacion]
GO
/****** Object:  StoredProcedure [dbo].[CreateMedication]    Script Date: 21/07/2022 21:02:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CreateMedication](
@nome varchar(50),
@cantidade int,
@dataCreacion datetime
)
as
begin
insert into medications(nome,cantidade ,dataCreacion)
values(@nome,@cantidade ,@dataCreacion)
SELECT SCOPE_IDENTITY() as ID
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteMedication]    Script Date: 21/07/2022 21:02:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteMedication](
@id int
)
as
begin
delete from medications where id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllMedications]    Script Date: 21/07/2022 21:02:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetAllMedications]
as
begin
select id,nome,cantidade ,dataCreacion from medications
end
GO
/****** Object:  StoredProcedure [dbo].[GetMedicationByID]    Script Date: 21/07/2022 21:02:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetMedicationByID](
@id int
)
as
begin
select id,nome,cantidade ,dataCreacion from medications where id = @id
end
GO
USE [master]
GO
ALTER DATABASE [SmartMed] SET  READ_WRITE 
GO
