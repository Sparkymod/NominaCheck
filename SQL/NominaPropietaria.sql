USE [NominaPropietaria]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/25/2022 3:27:41 PM ******/
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
/****** Object:  Table [dbo].[cargos]    Script Date: 3/25/2022 3:27:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cargos](
	[cod_cargo] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[cod_departamento] [int] NOT NULL,
 CONSTRAINT [PK_cargos] PRIMARY KEY CLUSTERED 
(
	[cod_cargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[departamentos]    Script Date: 3/25/2022 3:27:41 PM ******/
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
/****** Object:  Table [dbo].[empleados]    Script Date: 3/25/2022 3:27:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empleados](
	[cod_empleados] [int] NOT NULL,
	[nombre] [char](30) NOT NULL,
	[apellido] [char](30) NOT NULL,
	[telefono] [int] NOT NULL,
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
/****** Object:  Table [dbo].[factura_proveedores]    Script Date: 3/25/2022 3:27:41 PM ******/
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
/****** Object:  Table [dbo].[ingresos_otrosconceptos]    Script Date: 3/25/2022 3:27:41 PM ******/
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
/****** Object:  Table [dbo].[ingresos_servicios]    Script Date: 3/25/2022 3:27:41 PM ******/
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
/****** Object:  Table [dbo].[nomina]    Script Date: 3/25/2022 3:27:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nomina](
	[cod_nomina] [int] NOT NULL,
	[monto] [money] NOT NULL,
	[fecha_pago] [date] NOT NULL,
	[cod_empleado] [int] NOT NULL,
 CONSTRAINT [PK_nomina] PRIMARY KEY CLUSTERED 
(
	[cod_nomina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[otros_conceptos]    Script Date: 3/25/2022 3:27:41 PM ******/
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
/****** Object:  Table [dbo].[pago_empleados]    Script Date: 3/25/2022 3:27:41 PM ******/
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
/****** Object:  Table [dbo].[proveedores]    Script Date: 3/25/2022 3:27:41 PM ******/
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
/****** Object:  Table [dbo].[servicios]    Script Date: 3/25/2022 3:27:41 PM ******/
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
/****** Object:  Table [dbo].[tipos_empleado]    Script Date: 3/25/2022 3:27:41 PM ******/
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
ALTER TABLE [dbo].[empleados]  WITH CHECK ADD  CONSTRAINT [FK_nomina] FOREIGN KEY([cod_nomina])
REFERENCES [dbo].[nomina] ([cod_nomina])
GO
ALTER TABLE [dbo].[empleados] CHECK CONSTRAINT [FK_nomina]
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
ALTER TABLE [dbo].[nomina]  WITH CHECK ADD  CONSTRAINT [FK_empleado] FOREIGN KEY([cod_empleado])
REFERENCES [dbo].[empleados] ([cod_empleados])
GO
ALTER TABLE [dbo].[nomina] CHECK CONSTRAINT [FK_empleado]
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
