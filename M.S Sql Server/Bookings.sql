USE [Bookings]
GO
ALTER TABLE [dbo].[Rooms] DROP CONSTRAINT [CK_Rooms_NumbetOfBeds]
GO
ALTER TABLE [dbo].[Rooms] DROP CONSTRAINT [CK_Rooms_Id]
GO
ALTER TABLE [dbo].[RoomFacilities] DROP CONSTRAINT [CK_RoomFacilities_Id]
GO
ALTER TABLE [dbo].[Persons] DROP CONSTRAINT [CK_Persons_Id]
GO
ALTER TABLE [dbo].[Locations] DROP CONSTRAINT [CK_Locations_Id]
GO
ALTER TABLE [dbo].[Hotels] DROP CONSTRAINT [CK_Id_Hotels]
GO
ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [TestID]
GO
ALTER TABLE [dbo].[RoomsFacilities-Rooms] DROP CONSTRAINT [FK_RoomsFacilities-Rooms_Faciliti]
GO
ALTER TABLE [dbo].[RoomsFacilities-Rooms] DROP CONSTRAINT [FK_RoomsFacilities_Room]
GO
ALTER TABLE [dbo].[Rooms] DROP CONSTRAINT [FK_Rooms_Hotels]
GO
ALTER TABLE [dbo].[Locations] DROP CONSTRAINT [FK_Locations_Hotel]
GO
ALTER TABLE [dbo].[Hotels] DROP CONSTRAINT [FK_Hotels_Location]
GO
ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_Bookings_Rooms]
GO
ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_Bookings_Persons]
GO
ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_Bookings_Hotels]
GO
/****** Object:  Table [dbo].[RoomsFacilities-Rooms]    Script Date: 8/2/2016 11:59:30 AM ******/
DROP TABLE [dbo].[RoomsFacilities-Rooms]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 8/2/2016 11:59:30 AM ******/
DROP TABLE [dbo].[Rooms]
GO
/****** Object:  Table [dbo].[RoomFacilities]    Script Date: 8/2/2016 11:59:30 AM ******/
DROP TABLE [dbo].[RoomFacilities]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 8/2/2016 11:59:30 AM ******/
DROP TABLE [dbo].[Persons]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 8/2/2016 11:59:30 AM ******/
DROP TABLE [dbo].[Locations]
GO
/****** Object:  Table [dbo].[Hotels]    Script Date: 8/2/2016 11:59:30 AM ******/
DROP TABLE [dbo].[Hotels]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 8/2/2016 11:59:30 AM ******/
DROP TABLE [dbo].[Bookings]
GO
USE [master]
GO
/****** Object:  Database [Bookings]    Script Date: 8/2/2016 11:59:30 AM ******/
DROP DATABASE [Bookings]
GO
/****** Object:  Database [Bookings]    Script Date: 8/2/2016 11:59:30 AM ******/
CREATE DATABASE [Bookings]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Bookings', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Bookings.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Bookings_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Bookings_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Bookings] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bookings].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Bookings] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bookings] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bookings] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bookings] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bookings] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bookings] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Bookings] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Bookings] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bookings] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bookings] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Bookings] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bookings] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bookings] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bookings] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bookings] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Bookings] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Bookings] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Bookings] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Bookings] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Bookings] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Bookings] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Bookings] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Bookings] SET RECOVERY FULL 
GO
ALTER DATABASE [Bookings] SET  MULTI_USER 
GO
ALTER DATABASE [Bookings] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Bookings] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Bookings] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Bookings] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Bookings] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Bookings', N'ON'
GO
USE [Bookings]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 8/2/2016 11:59:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[Id] [int] NOT NULL,
	[BookingDate] [date] NOT NULL,
	[HotelId] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hotels]    Script Date: 8/2/2016 11:59:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotels](
	[Id] [int] NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[LocationId] [int] NOT NULL,
 CONSTRAINT [PK_Hotels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Locations]    Script Date: 8/2/2016 11:59:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[Id] [int] NOT NULL,
	[City] [nchar](20) NOT NULL,
	[Country] [nchar](20) NOT NULL,
	[Street] [nchar](20) NOT NULL,
	[StreetNumber] [int] NOT NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 8/2/2016 11:59:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[Id] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nchar](50) NOT NULL,
	[RegisterDate] [date] NOT NULL,
	[HasMoneyToSpend] [int] NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoomFacilities]    Script Date: 8/2/2016 11:59:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomFacilities](
	[Id] [int] NOT NULL,
	[Name] [nchar](30) NOT NULL,
	[HasTv] [int] NOT NULL,
	[HasAirConditioning] [int] NOT NULL,
 CONSTRAINT [PK_RoomFacilities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [Unique_RoomFacilities_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 8/2/2016 11:59:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [int] NOT NULL,
	[FloorNumber] [int] NOT NULL,
	[NumberOfBeds] [int] NOT NULL,
	[HotelId] [int] NULL,
	[Type] [nchar](20) NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoomsFacilities-Rooms]    Script Date: 8/2/2016 11:59:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomsFacilities-Rooms](
	[Id] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
	[RoomFacilitiesId] [int] NOT NULL,
 CONSTRAINT [PK_RoomsFacilities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Hotels] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotels] ([Id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Hotels]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Persons] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Persons] ([Id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Persons]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Rooms] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Rooms] ([Id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Rooms]
GO
ALTER TABLE [dbo].[Hotels]  WITH CHECK ADD  CONSTRAINT [FK_Hotels_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([Id])
GO
ALTER TABLE [dbo].[Hotels] CHECK CONSTRAINT [FK_Hotels_Location]
GO
ALTER TABLE [dbo].[Locations]  WITH CHECK ADD  CONSTRAINT [FK_Locations_Hotel] FOREIGN KEY([Id])
REFERENCES [dbo].[Locations] ([Id])
GO
ALTER TABLE [dbo].[Locations] CHECK CONSTRAINT [FK_Locations_Hotel]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_Hotels] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotels] ([Id])
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Rooms_Hotels]
GO
ALTER TABLE [dbo].[RoomsFacilities-Rooms]  WITH CHECK ADD  CONSTRAINT [FK_RoomsFacilities_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Rooms] ([Id])
GO
ALTER TABLE [dbo].[RoomsFacilities-Rooms] CHECK CONSTRAINT [FK_RoomsFacilities_Room]
GO
ALTER TABLE [dbo].[RoomsFacilities-Rooms]  WITH CHECK ADD  CONSTRAINT [FK_RoomsFacilities-Rooms_Faciliti] FOREIGN KEY([RoomFacilitiesId])
REFERENCES [dbo].[RoomFacilities] ([Id])
GO
ALTER TABLE [dbo].[RoomsFacilities-Rooms] CHECK CONSTRAINT [FK_RoomsFacilities-Rooms_Faciliti]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [TestID] CHECK  (([Id]>(0)))
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [TestID]
GO
ALTER TABLE [dbo].[Hotels]  WITH CHECK ADD  CONSTRAINT [CK_Id_Hotels] CHECK  (([Id]>(0)))
GO
ALTER TABLE [dbo].[Hotels] CHECK CONSTRAINT [CK_Id_Hotels]
GO
ALTER TABLE [dbo].[Locations]  WITH CHECK ADD  CONSTRAINT [CK_Locations_Id] CHECK  (([Id]>(0)))
GO
ALTER TABLE [dbo].[Locations] CHECK CONSTRAINT [CK_Locations_Id]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [CK_Persons_Id] CHECK  (([Id]>(0)))
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [CK_Persons_Id]
GO
ALTER TABLE [dbo].[RoomFacilities]  WITH CHECK ADD  CONSTRAINT [CK_RoomFacilities_Id] CHECK  (([Id]>(0)))
GO
ALTER TABLE [dbo].[RoomFacilities] CHECK CONSTRAINT [CK_RoomFacilities_Id]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [CK_Rooms_Id] CHECK  (([Id]>(0)))
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [CK_Rooms_Id]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [CK_Rooms_NumbetOfBeds] CHECK  (([NumberOfBeds]>(0)))
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [CK_Rooms_NumbetOfBeds]
GO
USE [master]
GO
ALTER DATABASE [Bookings] SET  READ_WRITE 
GO
