USE [master]
GO
/****** Object:  Database [LinguoCardsDevelop]    Script Date: 05.12.2017 22:21:12 ******/
CREATE DATABASE [LinguoCardsDevelop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LinguoCardsDevelop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\LinguoCardsDevelop.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LinguoCardsDevelop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\LinguoCardsDevelop_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LinguoCardsDevelop] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LinguoCardsDevelop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LinguoCardsDevelop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LinguoCardsDevelop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LinguoCardsDevelop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LinguoCardsDevelop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LinguoCardsDevelop] SET ARITHABORT OFF 
GO
ALTER DATABASE [LinguoCardsDevelop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LinguoCardsDevelop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LinguoCardsDevelop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LinguoCardsDevelop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LinguoCardsDevelop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LinguoCardsDevelop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LinguoCardsDevelop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LinguoCardsDevelop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LinguoCardsDevelop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LinguoCardsDevelop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LinguoCardsDevelop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LinguoCardsDevelop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LinguoCardsDevelop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LinguoCardsDevelop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LinguoCardsDevelop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LinguoCardsDevelop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LinguoCardsDevelop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LinguoCardsDevelop] SET RECOVERY FULL 
GO
ALTER DATABASE [LinguoCardsDevelop] SET  MULTI_USER 
GO
ALTER DATABASE [LinguoCardsDevelop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LinguoCardsDevelop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LinguoCardsDevelop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LinguoCardsDevelop] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [LinguoCardsDevelop] SET DELAYED_DURABILITY = DISABLED 
GO
USE [LinguoCardsDevelop]
GO
/****** Object:  Table [dbo].[CardGroups]    Script Date: 05.12.2017 22:21:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardGroups](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Main_Card] [int] NOT NULL,
	[Additional_Card] [int] NOT NULL,
 CONSTRAINT [PK_CardGroups] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dictionary]    Script Date: 05.12.2017 22:21:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dictionary](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[english_id] [int] NOT NULL,
	[russian_id] [int] NOT NULL,
 CONSTRAINT [PK_Dictionary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words]    Script Date: 05.12.2017 22:21:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[value] [nvarchar](50) NOT NULL,
	[language] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CardGroups]  WITH CHECK ADD  CONSTRAINT [FK_CardGroups_Dictionary] FOREIGN KEY([Main_Card])
REFERENCES [dbo].[Dictionary] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CardGroups] CHECK CONSTRAINT [FK_CardGroups_Dictionary]
GO
ALTER TABLE [dbo].[CardGroups]  WITH CHECK ADD  CONSTRAINT [FK_CardGroups_Dictionary1] FOREIGN KEY([Additional_Card])
REFERENCES [dbo].[Dictionary] ([id])
GO
ALTER TABLE [dbo].[CardGroups] CHECK CONSTRAINT [FK_CardGroups_Dictionary1]
GO
ALTER TABLE [dbo].[Dictionary]  WITH CHECK ADD  CONSTRAINT [FK_Dictionary_Words_W_to_R] FOREIGN KEY([russian_id])
REFERENCES [dbo].[Words] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Dictionary] CHECK CONSTRAINT [FK_Dictionary_Words_W_to_R]
GO
USE [master]
GO
ALTER DATABASE [LinguoCardsDevelop] SET  READ_WRITE 
GO
