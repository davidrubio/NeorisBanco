USE [NeorisDB]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 11/12/2023 8:51:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Secuencial] [int] IDENTITY(1,1) NOT NULL,
	[SecuencialPersona] [int] NOT NULL,
	[Clave] [varchar](10) NOT NULL,
	[EstaActivo] [bit] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Secuencial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuenta]    Script Date: 11/12/2023 8:51:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta](
	[Secuencial] [int] IDENTITY(1,1) NOT NULL,
	[SecuencialCliente] [int] NOT NULL,
	[NumeroCuenta] [varchar](20) NOT NULL,
	[SecuencialTipoCuenta] [int] NOT NULL,
	[SaldoCorte] [decimal](18, 0) NOT NULL,
	[SaldoActual] [decimal](18, 0) NOT NULL,
	[EstaActivo] [bit] NOT NULL,
 CONSTRAINT [PK_Cuenta] PRIMARY KEY CLUSTERED 
(
	[Secuencial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genero]    Script Date: 11/12/2023 8:51:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genero](
	[Secuencial] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[EstaActivo] [bit] NOT NULL,
 CONSTRAINT [PK_Genero] PRIMARY KEY CLUSTERED 
(
	[Secuencial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimiento]    Script Date: 11/12/2023 8:51:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimiento](
	[Secuencial] [int] IDENTITY(1,1) NOT NULL,
	[SecuencialCuenta] [int] NOT NULL,
	[SecuencialTipoMovimiento] [int] NOT NULL,
	[SecuencialTipoCanal] [int] NOT NULL,
	[FechaMovimiento] [datetime] NOT NULL,
	[Valor] [decimal](18, 0) NOT NULL,
	[Saldo] [decimal](18, 0) NOT NULL,
	[Detalle] [varchar](200) NULL,
	[EstaActivo] [bit] NOT NULL,
 CONSTRAINT [PK_Movimiento] PRIMARY KEY CLUSTERED 
(
	[Secuencial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 11/12/2023 8:51:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[Secuencial] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[SecuencialGenero] [int] NOT NULL,
	[Edad] [int] NOT NULL,
	[Identificacion] [varchar](10) NOT NULL,
	[Direccion] [varchar](200) NOT NULL,
	[Telefono] [varchar](13) NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[Secuencial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCanal]    Script Date: 11/12/2023 8:51:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCanal](
	[Secuencial] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[EstaActivo] [bit] NOT NULL,
 CONSTRAINT [PK_TipoCanal] PRIMARY KEY CLUSTERED 
(
	[Secuencial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCuenta]    Script Date: 11/12/2023 8:51:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCuenta](
	[Secuencial] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[EstaActivo] [bit] NOT NULL,
 CONSTRAINT [PK_TipoCuenta] PRIMARY KEY CLUSTERED 
(
	[Secuencial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoMovimiento]    Script Date: 11/12/2023 8:51:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoMovimiento](
	[Secuencial] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[EstaActivo] [bit] NOT NULL,
 CONSTRAINT [PK_TipoMovimiento] PRIMARY KEY CLUSTERED 
(
	[Secuencial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([Secuencial], [SecuencialPersona], [Clave], [EstaActivo]) VALUES (1, 1, N'123456789', 1)
INSERT [dbo].[Cliente] ([Secuencial], [SecuencialPersona], [Clave], [EstaActivo]) VALUES (2, 3, N'151515', 0)
INSERT [dbo].[Cliente] ([Secuencial], [SecuencialPersona], [Clave], [EstaActivo]) VALUES (6, 9, N'123456789', 0)
INSERT [dbo].[Cliente] ([Secuencial], [SecuencialPersona], [Clave], [EstaActivo]) VALUES (7, 11, N'123456789', 0)
INSERT [dbo].[Cliente] ([Secuencial], [SecuencialPersona], [Clave], [EstaActivo]) VALUES (8, 12, N'123456789', 1)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Cuenta] ON 

INSERT [dbo].[Cuenta] ([Secuencial], [SecuencialCliente], [NumeroCuenta], [SecuencialTipoCuenta], [SaldoCorte], [SaldoActual], [EstaActivo]) VALUES (1, 1, N'00202312101', 1, CAST(200 AS Decimal(18, 0)), CAST(200 AS Decimal(18, 0)), 0)
INSERT [dbo].[Cuenta] ([Secuencial], [SecuencialCliente], [NumeroCuenta], [SecuencialTipoCuenta], [SaldoCorte], [SaldoActual], [EstaActivo]) VALUES (4, 1, N'2023121111', 3, CAST(500 AS Decimal(18, 0)), CAST(1070 AS Decimal(18, 0)), 1)
INSERT [dbo].[Cuenta] ([Secuencial], [SecuencialCliente], [NumeroCuenta], [SecuencialTipoCuenta], [SaldoCorte], [SaldoActual], [EstaActivo]) VALUES (5, 1, N'2023121121', 3, CAST(100 AS Decimal(18, 0)), CAST(100 AS Decimal(18, 0)), 0)
SET IDENTITY_INSERT [dbo].[Cuenta] OFF
GO
SET IDENTITY_INSERT [dbo].[Genero] ON 

INSERT [dbo].[Genero] ([Secuencial], [Nombre], [EstaActivo]) VALUES (1, N'Masculino', 1)
INSERT [dbo].[Genero] ([Secuencial], [Nombre], [EstaActivo]) VALUES (2, N'Femenino', 1)
SET IDENTITY_INSERT [dbo].[Genero] OFF
GO
SET IDENTITY_INSERT [dbo].[Movimiento] ON 

INSERT [dbo].[Movimiento] ([Secuencial], [SecuencialCuenta], [SecuencialTipoMovimiento], [SecuencialTipoCanal], [FechaMovimiento], [Valor], [Saldo], [Detalle], [EstaActivo]) VALUES (1, 1, 3, 2, CAST(N'2023-12-10T00:00:00.000' AS DateTime), CAST(200 AS Decimal(18, 0)), CAST(200 AS Decimal(18, 0)), N'Apertura Cuenta Ahorros', 1)
INSERT [dbo].[Movimiento] ([Secuencial], [SecuencialCuenta], [SecuencialTipoMovimiento], [SecuencialTipoCanal], [FechaMovimiento], [Valor], [Saldo], [Detalle], [EstaActivo]) VALUES (2, 4, 3, 1, CAST(N'2023-12-11T01:49:47.453' AS DateTime), CAST(500 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), N'Apertura Cuenta', 1)
INSERT [dbo].[Movimiento] ([Secuencial], [SecuencialCuenta], [SecuencialTipoMovimiento], [SecuencialTipoCanal], [FechaMovimiento], [Valor], [Saldo], [Detalle], [EstaActivo]) VALUES (3, 4, 1, 1, CAST(N'2023-12-11T02:58:27.143' AS DateTime), CAST(20 AS Decimal(18, 0)), CAST(480 AS Decimal(18, 0)), N'Debito Canal digital', 1)
INSERT [dbo].[Movimiento] ([Secuencial], [SecuencialCuenta], [SecuencialTipoMovimiento], [SecuencialTipoCanal], [FechaMovimiento], [Valor], [Saldo], [Detalle], [EstaActivo]) VALUES (4, 4, 2, 1, CAST(N'2023-12-11T02:59:23.407' AS DateTime), CAST(600 AS Decimal(18, 0)), CAST(1080 AS Decimal(18, 0)), N'Deposito Ventanilla', 1)
INSERT [dbo].[Movimiento] ([Secuencial], [SecuencialCuenta], [SecuencialTipoMovimiento], [SecuencialTipoCanal], [FechaMovimiento], [Valor], [Saldo], [Detalle], [EstaActivo]) VALUES (5, 5, 3, 2, CAST(N'2023-12-11T08:17:27.317' AS DateTime), CAST(100 AS Decimal(18, 0)), CAST(100 AS Decimal(18, 0)), N'Apertura Cuenta', 1)
INSERT [dbo].[Movimiento] ([Secuencial], [SecuencialCuenta], [SecuencialTipoMovimiento], [SecuencialTipoCanal], [FechaMovimiento], [Valor], [Saldo], [Detalle], [EstaActivo]) VALUES (6, 4, 1, 1, CAST(N'2023-12-11T08:34:58.367' AS DateTime), CAST(10 AS Decimal(18, 0)), CAST(1070 AS Decimal(18, 0)), N'detalle prueba', 1)
SET IDENTITY_INSERT [dbo].[Movimiento] OFF
GO
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([Secuencial], [Nombres], [SecuencialGenero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (1, N'David Sebastian Rubio Carrera', 1, 31, N'1721600532', N'Av Gonzalez Suarez y Placido, Boreal C38', N'0987738051')
INSERT [dbo].[Persona] ([Secuencial], [Nombres], [SecuencialGenero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (2, N'Martin Rubio', 1, 2, N'1721600598', N'Conocoto', N'0987738051')
INSERT [dbo].[Persona] ([Secuencial], [Nombres], [SecuencialGenero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (3, N'Nicolas Rubio', 1, 1, N'1754855698', N'Av Gonzalez Suarez y Placido Caamaño, Conjunto Boreal C38', N'0987738051')
INSERT [dbo].[Persona] ([Secuencial], [Nombres], [SecuencialGenero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (9, N'Ivonne Hidalgo B.', 2, 30, N'1727275057', N'Conocoto y Gonzalez Suarez', N'0984417275')
INSERT [dbo].[Persona] ([Secuencial], [Nombres], [SecuencialGenero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (11, N'Ivonne Hidalgo B.', 2, 30, N'1727275057', N'Conocoto y Gonzalez Suarez', N'0984417275')
INSERT [dbo].[Persona] ([Secuencial], [Nombres], [SecuencialGenero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (12, N'Ivonne Hidalgo B.', 2, 30, N'1727275057', N'Conocoto y Gonzalez Suarez', N'0984417275')
SET IDENTITY_INSERT [dbo].[Persona] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoCanal] ON 

INSERT [dbo].[TipoCanal] ([Secuencial], [Nombre], [EstaActivo]) VALUES (1, N'Web', 1)
INSERT [dbo].[TipoCanal] ([Secuencial], [Nombre], [EstaActivo]) VALUES (2, N'Ventanilla', 1)
INSERT [dbo].[TipoCanal] ([Secuencial], [Nombre], [EstaActivo]) VALUES (3, N'Movil', 1)
SET IDENTITY_INSERT [dbo].[TipoCanal] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoCuenta] ON 

INSERT [dbo].[TipoCuenta] ([Secuencial], [Nombre], [EstaActivo]) VALUES (1, N'Ahorro', 1)
INSERT [dbo].[TipoCuenta] ([Secuencial], [Nombre], [EstaActivo]) VALUES (2, N'Corriente', 1)
INSERT [dbo].[TipoCuenta] ([Secuencial], [Nombre], [EstaActivo]) VALUES (3, N'Ahorro Flex', 1)
INSERT [dbo].[TipoCuenta] ([Secuencial], [Nombre], [EstaActivo]) VALUES (4, N'Ahorro Programado', 1)
SET IDENTITY_INSERT [dbo].[TipoCuenta] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoMovimiento] ON 

INSERT [dbo].[TipoMovimiento] ([Secuencial], [Nombre], [EstaActivo]) VALUES (1, N'Debito', 1)
INSERT [dbo].[TipoMovimiento] ([Secuencial], [Nombre], [EstaActivo]) VALUES (2, N'Credito', 1)
INSERT [dbo].[TipoMovimiento] ([Secuencial], [Nombre], [EstaActivo]) VALUES (3, N'Apertura', 1)
SET IDENTITY_INSERT [dbo].[TipoMovimiento] OFF
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Persona] FOREIGN KEY([SecuencialPersona])
REFERENCES [dbo].[Persona] ([Secuencial])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Persona]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Cliente] FOREIGN KEY([SecuencialCliente])
REFERENCES [dbo].[Cliente] ([Secuencial])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_Cliente]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_TipoCuenta] FOREIGN KEY([SecuencialTipoCuenta])
REFERENCES [dbo].[TipoCuenta] ([Secuencial])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_TipoCuenta]
GO
ALTER TABLE [dbo].[Movimiento]  WITH CHECK ADD  CONSTRAINT [FK_Movimiento_Cuenta] FOREIGN KEY([SecuencialCuenta])
REFERENCES [dbo].[Cuenta] ([Secuencial])
GO
ALTER TABLE [dbo].[Movimiento] CHECK CONSTRAINT [FK_Movimiento_Cuenta]
GO
ALTER TABLE [dbo].[Movimiento]  WITH CHECK ADD  CONSTRAINT [FK_Movimiento_TipoCanal] FOREIGN KEY([SecuencialTipoCanal])
REFERENCES [dbo].[TipoCanal] ([Secuencial])
GO
ALTER TABLE [dbo].[Movimiento] CHECK CONSTRAINT [FK_Movimiento_TipoCanal]
GO
ALTER TABLE [dbo].[Movimiento]  WITH CHECK ADD  CONSTRAINT [FK_Movimiento_TipoMovimiento] FOREIGN KEY([SecuencialTipoMovimiento])
REFERENCES [dbo].[TipoMovimiento] ([Secuencial])
GO
ALTER TABLE [dbo].[Movimiento] CHECK CONSTRAINT [FK_Movimiento_TipoMovimiento]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Genero] FOREIGN KEY([SecuencialGenero])
REFERENCES [dbo].[Genero] ([Secuencial])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_Genero]
GO
