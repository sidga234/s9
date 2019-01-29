USE [master]
GO
/****** Object:  Database [Library]    Script Date: 12/31/2018 18:50:54 ******/
CREATE DATABASE [Library] ON  PRIMARY 
( NAME = N'library', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\library.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'library_log', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\library_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Library] SET COMPATIBILITY_LEVEL = 90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Library].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Library] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Library] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Library] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Library] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Library] SET ARITHABORT OFF
GO
ALTER DATABASE [Library] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Library] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Library] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Library] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Library] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Library] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Library] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Library] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Library] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Library] SET  DISABLE_BROKER
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Library] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Library] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Library] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Library] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Library] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Library] SET  READ_WRITE
GO
ALTER DATABASE [Library] SET RECOVERY SIMPLE
GO
ALTER DATABASE [Library] SET  MULTI_USER
GO
ALTER DATABASE [Library] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Library] SET DB_CHAINING OFF
GO
USE [Library]
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 12/31/2018 18:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[LanguageId] [int] IDENTITY(1,1) NOT NULL,
	[Language] [nvarchar](50) NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[LanguageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Types]    Script Date: 12/31/2018 18:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Types](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](500) NULL,
 CONSTRAINT [PK_Types] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classs]    Script Date: 12/31/2018 18:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classs](
	[Classid] [int] IDENTITY(1,1) NOT NULL,
	[Class] [nvarchar](50) NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[Classid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 12/31/2018 18:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [nvarchar](max) NULL,
	[AuthorName] [nvarchar](max) NULL,
	[Class] [int] NULL,
	[Price] [numeric](18, 2) NULL,
	[Publisher] [nvarchar](max) NULL,
	[DateOfPurchase] [datetime] NULL,
	[Language] [int] NULL,
	[Type] [int] NULL,
 CONSTRAINT [PK_Book_Details] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetALLLanguage]    Script Date: 12/31/2018 18:51:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetALLLanguage]
as

SET NOCOUNT ON  
SET QUOTED_IDENTIFIER OFF  
Begin
Select * from Languages
END
GO
/****** Object:  StoredProcedure [dbo].[spGetBookRecord]    Script Date: 12/31/2018 18:51:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[spGetBookRecord]

@ID int

as

SET NOCOUNT ON  
SET QUOTED_IDENTIFIER OFF  

Begin
Select B.ID,B.BookName,B.AuthorName,B.Price,B.Publisher,B.DateOfPurchase,
CL.Class,L.Language,T.Type
 from 
  Books B  
 Inner Join  Classs cl on cl.Classid=B.Class
 Inner Join Languages L on L.LanguageID=B.Language
 Inner Join Types T on T.TypeID=B.Type
Where B.ID=@id
end
GO
/****** Object:  StoredProcedure [dbo].[spGetALLBookRecords]    Script Date: 12/31/2018 18:51:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[spGetALLBookRecords]
as

SET NOCOUNT ON  
SET QUOTED_IDENTIFIER OFF  

Begin
Select B.ID,B.BookName,B.AuthorName,B.Price,B.Publisher,B.DateOfPurchase,
CL.Class,L.[Language],T.[Type]
 from 
  Books B  
 Inner Join  Classs cl on cl.Classid=B.Class
 Inner Join Languages L on L.LanguageID=B.[Language]
 Inner Join [Types] T on T.TypeID=B.[Type]

end
GO
/****** Object:  StoredProcedure [dbo].[spGetALLBookRecordsByBookName]    Script Date: 12/31/2018 18:51:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[spGetALLBookRecordsByBookName]
@_BookName nvarchar(max) 

as
SET NOCOUNT ON  
SET QUOTED_IDENTIFIER OFF  

Begin
Select B.ID,B.BookName,B.AuthorName,B.Price,B.Publisher,B.DateOfPurchase,
CL.Class,L.[Language],T.[Type]
 from 
  Books B  
 Inner Join  Classs cl on cl.Classid=B.Class
 Inner Join Languages L on L.LanguageID=B.[Language]
 Inner Join [Types] T on T.TypeID=B.[Type]
 
 Where B.BookName like '%'+ @_BookName +'%'
 

end
GO
/****** Object:  StoredProcedure [dbo].[GetAllType]    Script Date: 12/31/2018 18:51:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetAllType]
as

SET NOCOUNT ON  
SET QUOTED_IDENTIFIER OFF  
Begin
Select TypeId,Type from Types

END
GO
/****** Object:  StoredProcedure [dbo].[GetALLClasss]    Script Date: 12/31/2018 18:51:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetALLClasss]
as

SET NOCOUNT ON  
SET QUOTED_IDENTIFIER OFF  
Begin
Select * from Classs
END
GO
/****** Object:  StoredProcedure [dbo].[spAddBooks]    Script Date: 12/31/2018 18:51:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[spAddBooks]


@BookName nvarchar(max) ,
@AuthorName nvarchar(max)= null,
@Class int,
@Price numeric(18,2)=null,
@publisher nvarchar(max) =null,
@DateOfPurchase datetime =null,
@language int,
@Type int
as
SET NOCOUNT ON  
SET QUOTED_IDENTIFIER OFF  

Begin
Insert into Books (BookName,AuthorName,Class,Price,publisher,DateOfPurchase,[language],[Type])
values (@BookName,@AuthorName,@Class,@Price,@publisher,@DateOfPurchase,@language,@Type)

end
GO
/****** Object:  StoredProcedure [dbo].[spUpdateBooks]    Script Date: 12/31/2018 18:51:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[spUpdateBooks]

@ID int,
@BookName nvarchar(max) ,
@AuthorName nvarchar(max)= null,
@Class int,
@Price numeric(18,2)=null,
@publisher nvarchar(max) =null,
@DateOfPurchase datetime =null,
@language int,
@Type int
as
SET NOCOUNT ON  
SET QUOTED_IDENTIFIER OFF  

Begin
Update Books
set BookName =@BookName,
AuthorName =@AuthorName,
Class =@Class,
Price=@Price
,publisher=@publisher
,DateOfPurchase=@DateOfPurchase
,[language]=@language
,[Type]=@Type

Where ID=@id
end
GO
/****** Object:  StoredProcedure [dbo].[spDeleteBooks]    Script Date: 12/31/2018 18:51:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[spDeleteBooks]

@ID int

as

SET NOCOUNT ON  
SET QUOTED_IDENTIFIER OFF  

Begin
Delete from  Books

Where ID=@id
end
GO
/****** Object:  ForeignKey [FK_Book_Details_Class]    Script Date: 12/31/2018 18:50:55 ******/
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Book_Details_Class] FOREIGN KEY([Class])
REFERENCES [dbo].[Classs] ([Classid])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Book_Details_Class]
GO
/****** Object:  ForeignKey [FK_Book_Details_Language]    Script Date: 12/31/2018 18:50:55 ******/
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Book_Details_Language] FOREIGN KEY([Language])
REFERENCES [dbo].[Languages] ([LanguageId])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Book_Details_Language]
GO
/****** Object:  ForeignKey [FK_Book_Details_Types]    Script Date: 12/31/2018 18:50:55 ******/
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Book_Details_Types] FOREIGN KEY([Type])
REFERENCES [dbo].[Types] ([TypeID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Book_Details_Types]
GO
