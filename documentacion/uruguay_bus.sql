USE [uruguay_bus]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 7/12/2020 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[id] [int] NOT NULL,
 CONSTRAINT [PK_admin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[conductor]    Script Date: 7/12/2020 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[conductor](
	[id] [int] NOT NULL,
	[vencimiento_libreta] [date] NOT NULL,
 CONSTRAINT [PK_conductor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[horario]    Script Date: 7/12/2020 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[horario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hora] [time](7) NOT NULL,
	[conductor_id] [int] NOT NULL,
	[vehiculo_id] [int] NOT NULL,
	[linea_id] [int] NOT NULL,
 CONSTRAINT [PK_horario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[linea]    Script Date: 7/12/2020 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[linea](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_linea] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[parada]    Script Date: 7/12/2020 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[parada](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[latitud] [decimal](8, 6) NOT NULL,
	[longitud] [decimal](9, 6) NOT NULL,
 CONSTRAINT [PK_parada] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[parametro]    Script Date: 7/12/2020 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[parametro](
	[nombre] [varchar](50) NOT NULL,
	[valor] [numeric](6, 2) NOT NULL,
 CONSTRAINT [PK_parametro] PRIMARY KEY CLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pasaje]    Script Date: 7/12/2020 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pasaje](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[asiento] [int] NULL,
	[usado] [bit] NOT NULL,
	[tipo_documento] [int] NULL,
	[documento] [varchar](50) NULL,
	[usuario_id] [int] NULL,
	[viaje_id] [int] NOT NULL,
	[parada_id_origen] [int] NOT NULL,
	[parada_id_destino] [int] NOT NULL,
 CONSTRAINT [PK_pasaje] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[paso_por_parada]    Script Date: 7/12/2020 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[paso_por_parada](
	[viaje_id] [int] NOT NULL,
	[parada_id] [int] NOT NULL,
	[fecha_hora] [datetime] NOT NULL,
 CONSTRAINT [PK_paso_por_parada] PRIMARY KEY CLUSTERED 
(
	[viaje_id] ASC,
	[parada_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[persona]    Script Date: 7/12/2020 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[persona](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[correo] [varchar](50) NOT NULL,
	[contrasenia] [text] NOT NULL,
	[tipo_documento] [int] NOT NULL,
	[documento] [varchar](50) NOT NULL,
 CONSTRAINT [PK_persona] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_persona_correo] UNIQUE NONCLUSTERED 
(
	[correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[precio]    Script Date: 7/12/2020 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[precio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[valor] [decimal](6, 2) NOT NULL,
	[fecha_validez] [date] NOT NULL,
	[parada_id] [int] NOT NULL,
	[linea_id] [int] NOT NULL,
 CONSTRAINT [PK_precio] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[superadmin]    Script Date: 7/12/2020 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[superadmin](
	[id] [int] NOT NULL,
 CONSTRAINT [PK_superadmin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tramo]    Script Date: 7/12/2020 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tramo](
	[parada_id] [int] NOT NULL,
	[linea_id] [int] NOT NULL,
	[numero] [int] NOT NULL,
	[tiempo] [time](7) NOT NULL,
 CONSTRAINT [PK_tramo] PRIMARY KEY CLUSTERED 
(
	[parada_id] ASC,
	[linea_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 7/12/2020 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[id] [int] NOT NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vehiculo]    Script Date: 7/12/2020 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vehiculo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[matricula] [varchar](50) NOT NULL,
	[marca] [varchar](50) NOT NULL,
	[modelo] [varchar](50) NOT NULL,
	[cant_asientos] [int] NOT NULL,
	[latitud] [decimal](8, 6) NULL,
	[longitud] [decimal](9, 6) NULL,
 CONSTRAINT [PK_vehiculo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_vehiculo_matricula] UNIQUE NONCLUSTERED 
(
	[matricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[viaje]    Script Date: 7/12/2020 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[viaje](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NOT NULL,
	[finalizado] [bit] NULL,
	[horario_id] [int] NOT NULL,
 CONSTRAINT [PK_viaje] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[pasaje] ADD  CONSTRAINT [DF_pasaje_asiento]  DEFAULT (NULL) FOR [asiento]
GO
ALTER TABLE [dbo].[pasaje] ADD  CONSTRAINT [DF_pasaje_usado]  DEFAULT ((0)) FOR [usado]
GO
ALTER TABLE [dbo].[pasaje] ADD  CONSTRAINT [DF_pasaje_tipo_documento]  DEFAULT (NULL) FOR [tipo_documento]
GO
ALTER TABLE [dbo].[pasaje] ADD  CONSTRAINT [DF_pasaje_documento]  DEFAULT (NULL) FOR [documento]
GO
ALTER TABLE [dbo].[pasaje] ADD  CONSTRAINT [DF_pasaje_usuario_id]  DEFAULT (NULL) FOR [usuario_id]
GO
ALTER TABLE [dbo].[tramo] ADD  CONSTRAINT [DF_tramo_tiempo]  DEFAULT ('00:00:00') FOR [tiempo]
GO
ALTER TABLE [dbo].[vehiculo] ADD  CONSTRAINT [DF_vehiculo_latitud]  DEFAULT (NULL) FOR [latitud]
GO
ALTER TABLE [dbo].[vehiculo] ADD  CONSTRAINT [DF_vehiculo_longitud]  DEFAULT (NULL) FOR [longitud]
GO
ALTER TABLE [dbo].[viaje] ADD  CONSTRAINT [DF_viaje_finalizado]  DEFAULT (NULL) FOR [finalizado]
GO
ALTER TABLE [dbo].[admin]  WITH CHECK ADD  CONSTRAINT [FK_admin_persona] FOREIGN KEY([id])
REFERENCES [dbo].[persona] ([id])
GO
ALTER TABLE [dbo].[admin] CHECK CONSTRAINT [FK_admin_persona]
GO
ALTER TABLE [dbo].[conductor]  WITH CHECK ADD  CONSTRAINT [FK_conductor_persona] FOREIGN KEY([id])
REFERENCES [dbo].[persona] ([id])
GO
ALTER TABLE [dbo].[conductor] CHECK CONSTRAINT [FK_conductor_persona]
GO
ALTER TABLE [dbo].[horario]  WITH CHECK ADD  CONSTRAINT [FK_horario_conductor] FOREIGN KEY([conductor_id])
REFERENCES [dbo].[conductor] ([id])
GO
ALTER TABLE [dbo].[horario] CHECK CONSTRAINT [FK_horario_conductor]
GO
ALTER TABLE [dbo].[horario]  WITH CHECK ADD  CONSTRAINT [FK_horario_linea] FOREIGN KEY([linea_id])
REFERENCES [dbo].[linea] ([id])
GO
ALTER TABLE [dbo].[horario] CHECK CONSTRAINT [FK_horario_linea]
GO
ALTER TABLE [dbo].[horario]  WITH CHECK ADD  CONSTRAINT [FK_horario_vehiculo] FOREIGN KEY([vehiculo_id])
REFERENCES [dbo].[vehiculo] ([id])
GO
ALTER TABLE [dbo].[horario] CHECK CONSTRAINT [FK_horario_vehiculo]
GO
ALTER TABLE [dbo].[pasaje]  WITH CHECK ADD  CONSTRAINT [FK_pasaje_parada_destino] FOREIGN KEY([parada_id_destino])
REFERENCES [dbo].[parada] ([id])
GO
ALTER TABLE [dbo].[pasaje] CHECK CONSTRAINT [FK_pasaje_parada_destino]
GO
ALTER TABLE [dbo].[pasaje]  WITH CHECK ADD  CONSTRAINT [FK_pasaje_parada_origen] FOREIGN KEY([parada_id_origen])
REFERENCES [dbo].[parada] ([id])
GO
ALTER TABLE [dbo].[pasaje] CHECK CONSTRAINT [FK_pasaje_parada_origen]
GO
ALTER TABLE [dbo].[pasaje]  WITH CHECK ADD  CONSTRAINT [FK_pasaje_usuario] FOREIGN KEY([usuario_id])
REFERENCES [dbo].[usuario] ([id])
GO
ALTER TABLE [dbo].[pasaje] CHECK CONSTRAINT [FK_pasaje_usuario]
GO
ALTER TABLE [dbo].[pasaje]  WITH CHECK ADD  CONSTRAINT [FK_pasaje_viaje] FOREIGN KEY([viaje_id])
REFERENCES [dbo].[viaje] ([id])
GO
ALTER TABLE [dbo].[pasaje] CHECK CONSTRAINT [FK_pasaje_viaje]
GO
ALTER TABLE [dbo].[paso_por_parada]  WITH CHECK ADD  CONSTRAINT [FK_paso_por_parada_parada] FOREIGN KEY([parada_id])
REFERENCES [dbo].[parada] ([id])
GO
ALTER TABLE [dbo].[paso_por_parada] CHECK CONSTRAINT [FK_paso_por_parada_parada]
GO
ALTER TABLE [dbo].[paso_por_parada]  WITH CHECK ADD  CONSTRAINT [FK_paso_por_parada_viaje] FOREIGN KEY([viaje_id])
REFERENCES [dbo].[viaje] ([id])
GO
ALTER TABLE [dbo].[paso_por_parada] CHECK CONSTRAINT [FK_paso_por_parada_viaje]
GO
ALTER TABLE [dbo].[precio]  WITH CHECK ADD  CONSTRAINT [FK_precio_tramo] FOREIGN KEY([parada_id], [linea_id])
REFERENCES [dbo].[tramo] ([parada_id], [linea_id])
GO
ALTER TABLE [dbo].[precio] CHECK CONSTRAINT [FK_precio_tramo]
GO
ALTER TABLE [dbo].[superadmin]  WITH CHECK ADD  CONSTRAINT [FK_superadmin_persona] FOREIGN KEY([id])
REFERENCES [dbo].[persona] ([id])
GO
ALTER TABLE [dbo].[superadmin] CHECK CONSTRAINT [FK_superadmin_persona]
GO
ALTER TABLE [dbo].[tramo]  WITH CHECK ADD  CONSTRAINT [FK_tramo_linea] FOREIGN KEY([linea_id])
REFERENCES [dbo].[linea] ([id])
GO
ALTER TABLE [dbo].[tramo] CHECK CONSTRAINT [FK_tramo_linea]
GO
ALTER TABLE [dbo].[tramo]  WITH CHECK ADD  CONSTRAINT [FK_tramo_parada] FOREIGN KEY([parada_id])
REFERENCES [dbo].[parada] ([id])
GO
ALTER TABLE [dbo].[tramo] CHECK CONSTRAINT [FK_tramo_parada]
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [FK_usuario_persona] FOREIGN KEY([id])
REFERENCES [dbo].[persona] ([id])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [FK_usuario_persona]
GO
ALTER TABLE [dbo].[viaje]  WITH CHECK ADD  CONSTRAINT [FK_viaje_horario] FOREIGN KEY([horario_id])
REFERENCES [dbo].[horario] ([id])
GO
ALTER TABLE [dbo].[viaje] CHECK CONSTRAINT [FK_viaje_horario]
GO
