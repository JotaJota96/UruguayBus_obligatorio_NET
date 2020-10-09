USE [master]
GO
/****** Object:  Database [uruguay_bus]    Script Date: 8/10/2020 21:32:37 ******/
CREATE DATABASE [uruguay_bus]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'uruguay_bus', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\uruguay_bus.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'uruguay_bus_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\uruguay_bus_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [uruguay_bus] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [uruguay_bus].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [uruguay_bus] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [uruguay_bus] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [uruguay_bus] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [uruguay_bus] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [uruguay_bus] SET ARITHABORT OFF 
GO
ALTER DATABASE [uruguay_bus] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [uruguay_bus] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [uruguay_bus] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [uruguay_bus] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [uruguay_bus] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [uruguay_bus] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [uruguay_bus] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [uruguay_bus] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [uruguay_bus] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [uruguay_bus] SET  DISABLE_BROKER 
GO
ALTER DATABASE [uruguay_bus] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [uruguay_bus] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [uruguay_bus] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [uruguay_bus] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [uruguay_bus] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [uruguay_bus] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [uruguay_bus] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [uruguay_bus] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [uruguay_bus] SET  MULTI_USER 
GO
ALTER DATABASE [uruguay_bus] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [uruguay_bus] SET DB_CHAINING OFF 
GO
ALTER DATABASE [uruguay_bus] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [uruguay_bus] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [uruguay_bus] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [uruguay_bus] SET QUERY_STORE = OFF
GO
USE [uruguay_bus]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 8/10/2020 21:32:37 ******/
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
/****** Object:  Table [dbo].[conductor]    Script Date: 8/10/2020 21:32:37 ******/
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
/****** Object:  Table [dbo].[horario]    Script Date: 8/10/2020 21:32:37 ******/
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
/****** Object:  Table [dbo].[linea]    Script Date: 8/10/2020 21:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[linea](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_linea] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[parada]    Script Date: 8/10/2020 21:32:37 ******/
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
/****** Object:  Table [dbo].[parametro]    Script Date: 8/10/2020 21:32:37 ******/
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
/****** Object:  Table [dbo].[pasaje]    Script Date: 8/10/2020 21:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pasaje](
	[id] [int] NOT NULL,
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
/****** Object:  Table [dbo].[persona]    Script Date: 8/10/2020 21:32:37 ******/
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
/****** Object:  Table [dbo].[precio]    Script Date: 8/10/2020 21:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[precio](
	[id] [int] NOT NULL,
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
/****** Object:  Table [dbo].[superadmin]    Script Date: 8/10/2020 21:32:37 ******/
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
/****** Object:  Table [dbo].[tramo]    Script Date: 8/10/2020 21:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tramo](
	[parada_id] [int] NOT NULL,
	[linea_id] [int] NOT NULL,
	[numero] [int] NOT NULL,
	[tiempo] [time](7) NULL,
 CONSTRAINT [PK_tramo] PRIMARY KEY CLUSTERED 
(
	[parada_id] ASC,
	[linea_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 8/10/2020 21:32:37 ******/
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
/****** Object:  Table [dbo].[vehiculo]    Script Date: 8/10/2020 21:32:37 ******/
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
/****** Object:  Table [dbo].[viaje]    Script Date: 8/10/2020 21:32:37 ******/
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
USE [master]
GO
ALTER DATABASE [uruguay_bus] SET  READ_WRITE 
GO
