USE [master]
GO
/****** Object:  Database [Academia]    Script Date: 8/11/2024 11:40:19 ******/
CREATE DATABASE [Academia]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Academia', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Academia.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Academia_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Academia_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Academia] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Academia].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Academia] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Academia] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Academia] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Academia] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Academia] SET ARITHABORT OFF 
GO
ALTER DATABASE [Academia] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Academia] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Academia] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Academia] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Academia] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Academia] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Academia] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Academia] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Academia] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Academia] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Academia] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Academia] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Academia] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Academia] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Academia] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Academia] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Academia] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Academia] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Academia] SET  MULTI_USER 
GO
ALTER DATABASE [Academia] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Academia] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Academia] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Academia] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Academia] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Academia] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Academia] SET QUERY_STORE = ON
GO
ALTER DATABASE [Academia] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Academia]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/11/2024 11:40:19 ******/
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
/****** Object:  Table [dbo].[AlumnoInscripciones]    Script Date: 8/11/2024 11:40:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlumnoInscripciones](
	[IdAlumnoInscripcion] [int] IDENTITY(1,1) NOT NULL,
	[IdPersona] [int] NOT NULL,
	[IdCurso] [int] NOT NULL,
	[Nota] [int] NOT NULL,
	[Condicion] [nvarchar](max) NOT NULL,
	[UsuarioIdUsuario] [int] NULL,
 CONSTRAINT [PK_AlumnoInscripciones] PRIMARY KEY CLUSTERED 
(
	[IdAlumnoInscripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comisiones]    Script Date: 8/11/2024 11:40:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comisiones](
	[IdComision] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Comision] [nvarchar](max) NOT NULL,
	[IdPlan] [int] NOT NULL,
	[Anio_Especialidad] [int] NOT NULL,
 CONSTRAINT [PK_Comisiones] PRIMARY KEY CLUSTERED 
(
	[IdComision] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cursos]    Script Date: 8/11/2024 11:40:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cursos](
	[IdCurso] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[IdComision] [int] NOT NULL,
	[IdMateria] [int] NOT NULL,
	[Cupo] [int] NOT NULL,
	[Anio_Calendario] [int] NOT NULL,
 CONSTRAINT [PK_Cursos] PRIMARY KEY CLUSTERED 
(
	[IdCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocenteCursos]    Script Date: 8/11/2024 11:40:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocenteCursos](
	[IdDocenteCurso] [int] IDENTITY(1,1) NOT NULL,
	[IdPersona] [int] NOT NULL,
	[IdCurso] [int] NOT NULL,
	[Cargo] [int] NOT NULL,
	[UsuarioIdUsuario] [int] NULL,
 CONSTRAINT [PK_DocenteCursos] PRIMARY KEY CLUSTERED 
(
	[IdDocenteCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Especialidades]    Script Date: 8/11/2024 11:40:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especialidades](
	[IdEspecialidad] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Especialidad] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Especialidades] PRIMARY KEY CLUSTERED 
(
	[IdEspecialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materias]    Script Date: 8/11/2024 11:40:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materias](
	[IdMateria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Materia] [nvarchar](max) NOT NULL,
	[IdPlan] [int] NOT NULL,
	[Hs_Semanales] [int] NOT NULL,
	[Hs_Totales] [int] NOT NULL,
 CONSTRAINT [PK_Materias] PRIMARY KEY CLUSTERED 
(
	[IdMateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 8/11/2024 11:40:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[IdPersona] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Apellido] [nvarchar](max) NOT NULL,
	[Mail] [nvarchar](max) NOT NULL,
	[Direccion] [nvarchar](max) NOT NULL,
	[FechaNacimiento] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Planes]    Script Date: 8/11/2024 11:40:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Planes](
	[IdPlan] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Plan] [nvarchar](max) NOT NULL,
	[IdEspecialidad] [int] NOT NULL,
 CONSTRAINT [PK_Planes] PRIMARY KEY CLUSTERED 
(
	[IdPlan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 8/11/2024 11:40:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[IdPersona] [int] NOT NULL,
	[Rol] [nvarchar](max) NOT NULL,
	[Nombre_Usuario] [nvarchar](max) NOT NULL,
	[Clave] [nvarchar](max) NOT NULL,
	[Habilitado] [int] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_AlumnoInscripciones_IdCurso]    Script Date: 8/11/2024 11:40:19 ******/
CREATE NONCLUSTERED INDEX [IX_AlumnoInscripciones_IdCurso] ON [dbo].[AlumnoInscripciones]
(
	[IdCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AlumnoInscripciones_IdPersona]    Script Date: 8/11/2024 11:40:19 ******/
CREATE NONCLUSTERED INDEX [IX_AlumnoInscripciones_IdPersona] ON [dbo].[AlumnoInscripciones]
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AlumnoInscripciones_UsuarioIdUsuario]    Script Date: 8/11/2024 11:40:19 ******/
CREATE NONCLUSTERED INDEX [IX_AlumnoInscripciones_UsuarioIdUsuario] ON [dbo].[AlumnoInscripciones]
(
	[UsuarioIdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comisiones_IdPlan]    Script Date: 8/11/2024 11:40:19 ******/
CREATE NONCLUSTERED INDEX [IX_Comisiones_IdPlan] ON [dbo].[Comisiones]
(
	[IdPlan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Cursos_IdComision]    Script Date: 8/11/2024 11:40:19 ******/
CREATE NONCLUSTERED INDEX [IX_Cursos_IdComision] ON [dbo].[Cursos]
(
	[IdComision] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Cursos_IdMateria]    Script Date: 8/11/2024 11:40:19 ******/
CREATE NONCLUSTERED INDEX [IX_Cursos_IdMateria] ON [dbo].[Cursos]
(
	[IdMateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DocenteCursos_IdCurso]    Script Date: 8/11/2024 11:40:19 ******/
CREATE NONCLUSTERED INDEX [IX_DocenteCursos_IdCurso] ON [dbo].[DocenteCursos]
(
	[IdCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DocenteCursos_IdPersona]    Script Date: 8/11/2024 11:40:19 ******/
CREATE NONCLUSTERED INDEX [IX_DocenteCursos_IdPersona] ON [dbo].[DocenteCursos]
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DocenteCursos_UsuarioIdUsuario]    Script Date: 8/11/2024 11:40:19 ******/
CREATE NONCLUSTERED INDEX [IX_DocenteCursos_UsuarioIdUsuario] ON [dbo].[DocenteCursos]
(
	[UsuarioIdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Materias_IdPlan]    Script Date: 8/11/2024 11:40:19 ******/
CREATE NONCLUSTERED INDEX [IX_Materias_IdPlan] ON [dbo].[Materias]
(
	[IdPlan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Planes_IdEspecialidad]    Script Date: 8/11/2024 11:40:19 ******/
CREATE NONCLUSTERED INDEX [IX_Planes_IdEspecialidad] ON [dbo].[Planes]
(
	[IdEspecialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuarios_IdPersona]    Script Date: 8/11/2024 11:40:19 ******/
CREATE NONCLUSTERED INDEX [IX_Usuarios_IdPersona] ON [dbo].[Usuarios]
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AlumnoInscripciones]  WITH CHECK ADD  CONSTRAINT [FK_AlumnoInscripciones_Cursos_IdCurso] FOREIGN KEY([IdCurso])
REFERENCES [dbo].[Cursos] ([IdCurso])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AlumnoInscripciones] CHECK CONSTRAINT [FK_AlumnoInscripciones_Cursos_IdCurso]
GO
ALTER TABLE [dbo].[AlumnoInscripciones]  WITH CHECK ADD  CONSTRAINT [FK_AlumnoInscripciones_Personas_IdPersona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Personas] ([IdPersona])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AlumnoInscripciones] CHECK CONSTRAINT [FK_AlumnoInscripciones_Personas_IdPersona]
GO
ALTER TABLE [dbo].[AlumnoInscripciones]  WITH CHECK ADD  CONSTRAINT [FK_AlumnoInscripciones_Usuarios_UsuarioIdUsuario] FOREIGN KEY([UsuarioIdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[AlumnoInscripciones] CHECK CONSTRAINT [FK_AlumnoInscripciones_Usuarios_UsuarioIdUsuario]
GO
ALTER TABLE [dbo].[Comisiones]  WITH CHECK ADD  CONSTRAINT [FK_Comisiones_Planes_IdPlan] FOREIGN KEY([IdPlan])
REFERENCES [dbo].[Planes] ([IdPlan])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comisiones] CHECK CONSTRAINT [FK_Comisiones_Planes_IdPlan]
GO
ALTER TABLE [dbo].[Cursos]  WITH CHECK ADD  CONSTRAINT [FK_Cursos_Comisiones_IdComision] FOREIGN KEY([IdComision])
REFERENCES [dbo].[Comisiones] ([IdComision])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cursos] CHECK CONSTRAINT [FK_Cursos_Comisiones_IdComision]
GO
ALTER TABLE [dbo].[Cursos]  WITH CHECK ADD  CONSTRAINT [FK_Cursos_Materias_IdMateria] FOREIGN KEY([IdMateria])
REFERENCES [dbo].[Materias] ([IdMateria])
GO
ALTER TABLE [dbo].[Cursos] CHECK CONSTRAINT [FK_Cursos_Materias_IdMateria]
GO
ALTER TABLE [dbo].[DocenteCursos]  WITH CHECK ADD  CONSTRAINT [FK_DocenteCursos_Cursos_IdCurso] FOREIGN KEY([IdCurso])
REFERENCES [dbo].[Cursos] ([IdCurso])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DocenteCursos] CHECK CONSTRAINT [FK_DocenteCursos_Cursos_IdCurso]
GO
ALTER TABLE [dbo].[DocenteCursos]  WITH CHECK ADD  CONSTRAINT [FK_DocenteCursos_Personas_IdPersona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Personas] ([IdPersona])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DocenteCursos] CHECK CONSTRAINT [FK_DocenteCursos_Personas_IdPersona]
GO
ALTER TABLE [dbo].[DocenteCursos]  WITH CHECK ADD  CONSTRAINT [FK_DocenteCursos_Usuarios_UsuarioIdUsuario] FOREIGN KEY([UsuarioIdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[DocenteCursos] CHECK CONSTRAINT [FK_DocenteCursos_Usuarios_UsuarioIdUsuario]
GO
ALTER TABLE [dbo].[Materias]  WITH CHECK ADD  CONSTRAINT [FK_Materias_Planes_IdPlan] FOREIGN KEY([IdPlan])
REFERENCES [dbo].[Planes] ([IdPlan])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Materias] CHECK CONSTRAINT [FK_Materias_Planes_IdPlan]
GO
ALTER TABLE [dbo].[Planes]  WITH CHECK ADD  CONSTRAINT [FK_Planes_Especialidades_IdEspecialidad] FOREIGN KEY([IdEspecialidad])
REFERENCES [dbo].[Especialidades] ([IdEspecialidad])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Planes] CHECK CONSTRAINT [FK_Planes_Especialidades_IdEspecialidad]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Personas_IdPersona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Personas] ([IdPersona])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Personas_IdPersona]
GO
USE [master]
GO
ALTER DATABASE [Academia] SET  READ_WRITE 
GO

