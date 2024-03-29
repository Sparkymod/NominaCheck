USE [master]
GO
/****** Object:  Database [NominaPropietaria]    Script Date: 3/25/2022 11:08:16 PM ******/
CREATE DATABASE [NominaPropietaria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NominaPropietaria', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\NominaPropietaria.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NominaPropietaria_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\NominaPropietaria_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [NominaPropietaria] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NominaPropietaria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NominaPropietaria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NominaPropietaria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NominaPropietaria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NominaPropietaria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NominaPropietaria] SET ARITHABORT OFF 
GO
ALTER DATABASE [NominaPropietaria] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NominaPropietaria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NominaPropietaria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NominaPropietaria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NominaPropietaria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NominaPropietaria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NominaPropietaria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NominaPropietaria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NominaPropietaria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NominaPropietaria] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NominaPropietaria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NominaPropietaria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NominaPropietaria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NominaPropietaria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NominaPropietaria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NominaPropietaria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NominaPropietaria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NominaPropietaria] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NominaPropietaria] SET  MULTI_USER 
GO
ALTER DATABASE [NominaPropietaria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NominaPropietaria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NominaPropietaria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NominaPropietaria] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NominaPropietaria] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NominaPropietaria] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [NominaPropietaria] SET QUERY_STORE = OFF
GO
USE [NominaPropietaria]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/25/2022 11:08:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cargos]    Script Date: 3/25/2022 11:08:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cargos](
	[cod_cargo] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[monto] [money] NULL,
	[cod_departamento] [int] NOT NULL,
 CONSTRAINT [PK_cargos] PRIMARY KEY CLUSTERED 
(
	[cod_cargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[departamentos]    Script Date: 3/25/2022 11:08:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departamentos](
	[cod_departamento] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_departamentos] PRIMARY KEY CLUSTERED 
(
	[cod_departamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[empleados]    Script Date: 3/25/2022 11:08:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empleados](
	[cod_empleados] [int] NOT NULL,
	[nombre] [char](30) NOT NULL,
	[apellido] [char](30) NOT NULL,
	[telefono] [varchar](10) NOT NULL,
	[direccion] [varchar](25) NOT NULL,
	[email] [varchar](25) NOT NULL,
	[cod_nomina] [int] NOT NULL,
	[cod_cargo] [int] NOT NULL,
	[cod_tipo_empleado] [int] NOT NULL,
 CONSTRAINT [PK_empleados] PRIMARY KEY CLUSTERED 
(
	[cod_empleados] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[factura_proveedores]    Script Date: 3/25/2022 11:08:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[factura_proveedores](
	[cod_factura] [int] NOT NULL,
	[descrpcion] [char](40) NOT NULL,
	[valor_mensual] [money] NOT NULL,
	[cod_proveedor] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ingresos_otrosconceptos]    Script Date: 3/25/2022 11:08:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ingresos_otrosconceptos](
	[cod_otrosconceptos] [int] NOT NULL,
	[valor] [money] NOT NULL,
	[cod_concepto] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_otrosconceptos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ingresos_servicios]    Script Date: 3/25/2022 11:08:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ingresos_servicios](
	[cod_ingreso] [int] NOT NULL,
	[tipo_servicio] [char](25) NOT NULL,
	[valor] [money] NOT NULL,
	[cod_servicio] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_ingreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nomina]    Script Date: 3/25/2022 11:08:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nomina](
	[cod_nomina] [int] IDENTITY(1,1) NOT NULL,
	[fecha_pago] [date] NOT NULL,
 CONSTRAINT [PK_nomina] PRIMARY KEY CLUSTERED 
(
	[cod_nomina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[otros_conceptos]    Script Date: 3/25/2022 11:08:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[otros_conceptos](
	[cod_concepto] [int] NOT NULL,
	[descripcion] [char](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_concepto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pago_empleados]    Script Date: 3/25/2022 11:08:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pago_empleados](
	[cod_pago] [int] NOT NULL,
	[valor_mensual] [money] NOT NULL,
	[cod_empleados] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedores]    Script Date: 3/25/2022 11:08:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedores](
	[cod_proveedor] [int] NOT NULL,
	[nombre] [char](30) NOT NULL,
	[telefono] [int] NOT NULL,
	[direccion] [varchar](25) NOT NULL,
	[email] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[servicios]    Script Date: 3/25/2022 11:08:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[servicios](
	[cod_servicio] [int] NOT NULL,
	[descripcion] [char](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_servicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipos_empleado]    Script Date: 3/25/2022 11:08:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipos_empleado](
	[cod_tipo_empleado] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tipos_empleado] PRIMARY KEY CLUSTERED 
(
	[cod_tipo_empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[cargos]  WITH CHECK ADD  CONSTRAINT [FK_departamento] FOREIGN KEY([cod_departamento])
REFERENCES [dbo].[departamentos] ([cod_departamento])
GO
ALTER TABLE [dbo].[cargos] CHECK CONSTRAINT [FK_departamento]
GO
ALTER TABLE [dbo].[empleados]  WITH CHECK ADD  CONSTRAINT [FK_cargo] FOREIGN KEY([cod_cargo])
REFERENCES [dbo].[cargos] ([cod_cargo])
GO
ALTER TABLE [dbo].[empleados] CHECK CONSTRAINT [FK_cargo]
GO
ALTER TABLE [dbo].[empleados]  WITH CHECK ADD  CONSTRAINT [FK_tipo_empleado] FOREIGN KEY([cod_tipo_empleado])
REFERENCES [dbo].[tipos_empleado] ([cod_tipo_empleado])
GO
ALTER TABLE [dbo].[empleados] CHECK CONSTRAINT [FK_tipo_empleado]
GO
ALTER TABLE [dbo].[factura_proveedores]  WITH CHECK ADD FOREIGN KEY([cod_proveedor])
REFERENCES [dbo].[proveedores] ([cod_proveedor])
GO
ALTER TABLE [dbo].[factura_proveedores]  WITH CHECK ADD FOREIGN KEY([cod_proveedor])
REFERENCES [dbo].[proveedores] ([cod_proveedor])
GO
ALTER TABLE [dbo].[ingresos_otrosconceptos]  WITH CHECK ADD FOREIGN KEY([cod_concepto])
REFERENCES [dbo].[otros_conceptos] ([cod_concepto])
GO
ALTER TABLE [dbo].[ingresos_otrosconceptos]  WITH CHECK ADD FOREIGN KEY([cod_concepto])
REFERENCES [dbo].[otros_conceptos] ([cod_concepto])
GO
ALTER TABLE [dbo].[ingresos_servicios]  WITH CHECK ADD FOREIGN KEY([cod_servicio])
REFERENCES [dbo].[servicios] ([cod_servicio])
GO
ALTER TABLE [dbo].[ingresos_servicios]  WITH CHECK ADD FOREIGN KEY([cod_servicio])
REFERENCES [dbo].[servicios] ([cod_servicio])
GO
ALTER TABLE [dbo].[pago_empleados]  WITH CHECK ADD  CONSTRAINT [FK__pago_empl__cod_e__34C8D9D1] FOREIGN KEY([cod_empleados])
REFERENCES [dbo].[empleados] ([cod_empleados])
GO
ALTER TABLE [dbo].[pago_empleados] CHECK CONSTRAINT [FK__pago_empl__cod_e__34C8D9D1]
GO
ALTER TABLE [dbo].[pago_empleados]  WITH CHECK ADD  CONSTRAINT [FK__pago_empl__cod_e__403A8C7D] FOREIGN KEY([cod_empleados])
REFERENCES [dbo].[empleados] ([cod_empleados])
GO
ALTER TABLE [dbo].[pago_empleados] CHECK CONSTRAINT [FK__pago_empl__cod_e__403A8C7D]
GO
USE [master]
GO
ALTER DATABASE [NominaPropietaria] SET  READ_WRITE 
GO
