USE [master]
GO
/****** Object:  Database [NKS]    Script Date: 06.06.2023 4:29:59 ******/
CREATE DATABASE [NKS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NKS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\NKS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NKS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\NKS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [NKS] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NKS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NKS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NKS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NKS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NKS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NKS] SET ARITHABORT OFF 
GO
ALTER DATABASE [NKS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NKS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NKS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NKS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NKS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NKS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NKS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NKS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NKS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NKS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NKS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NKS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NKS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NKS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NKS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NKS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NKS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NKS] SET RECOVERY FULL 
GO
ALTER DATABASE [NKS] SET  MULTI_USER 
GO
ALTER DATABASE [NKS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NKS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NKS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NKS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NKS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NKS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'NKS', N'ON'
GO
ALTER DATABASE [NKS] SET QUERY_STORE = ON
GO
ALTER DATABASE [NKS] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [NKS]
GO
/****** Object:  Table [dbo].[Executor]    Script Date: 06.06.2023 4:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Executor](
	[ExecutorID] [int] IDENTITY(1,1) NOT NULL,
	[NExecutor] [varchar](max) NULL,
 CONSTRAINT [PK_Executor] PRIMARY KEY CLUSTERED 
(
	[ExecutorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operator]    Script Date: 06.06.2023 4:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operator](
	[OperatorID] [int] IDENTITY(1,1) NOT NULL,
	[NOperator] [varchar](max) NULL,
 CONSTRAINT [PK_Operator] PRIMARY KEY CLUSTERED 
(
	[OperatorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Plan]    Script Date: 06.06.2023 4:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plan](
	[PlanID] [int] IDENTITY(1,1) NOT NULL,
	[TimeNeed] [datetime] NULL,
	[ContentN] [varchar](max) NULL,
	[TypeID] [int] NULL,
	[ExecutorID] [int] NULL,
	[Adress] [varchar](max) NULL,
	[StatusID] [int] NULL,
 CONSTRAINT [PK_Plan] PRIMARY KEY CLUSTERED 
(
	[PlanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 06.06.2023 4:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[RequestID] [int] IDENTITY(1,1) NOT NULL,
	[DateStart] [datetime] NULL,
	[ContentN] [varchar](max) NULL,
	[TypeID] [int] NULL,
	[SourceID] [int] NULL,
	[Applicant] [varchar](max) NULL,
	[ExecutorID] [int] NULL,
	[Adress] [varchar](max) NULL,
	[СonvenientTime] [varchar](max) NULL,
	[StatusID] [int] NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[RequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shutdown]    Script Date: 06.06.2023 4:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shutdown](
	[ShutdownID] [int] IDENTITY(1,1) NOT NULL,
	[TimeCreate] [datetime] NULL,
	[TypeID] [int] NULL,
	[TypeShutdown] [varchar](max) NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[Homes] [varchar](max) NULL,
	[OperatorID] [int] NULL,
	[StatusID] [int] NULL,
 CONSTRAINT [PK_Shutdown] PRIMARY KEY CLUSTERED 
(
	[ShutdownID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Source]    Script Date: 06.06.2023 4:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Source](
	[SourceID] [int] IDENTITY(1,1) NOT NULL,
	[NSource] [varchar](max) NULL,
 CONSTRAINT [PK_Source] PRIMARY KEY CLUSTERED 
(
	[SourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 06.06.2023 4:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[NStatus] [varchar](max) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type]    Script Date: 06.06.2023 4:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[NType] [varchar](max) NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Executor] ON 

INSERT [dbo].[Executor] ([ExecutorID], [NExecutor]) VALUES (1, N'Проминтех  ЕДС')
INSERT [dbo].[Executor] ([ExecutorID], [NExecutor]) VALUES (2, N'Партнёр инженерка (Сотрудник)')
INSERT [dbo].[Executor] ([ExecutorID], [NExecutor]) VALUES (3, N'ООО Водград')
INSERT [dbo].[Executor] ([ExecutorID], [NExecutor]) VALUES (4, N'ЭлектроТЕХ')
SET IDENTITY_INSERT [dbo].[Executor] OFF
GO
SET IDENTITY_INSERT [dbo].[Operator] ON 

INSERT [dbo].[Operator] ([OperatorID], [NOperator]) VALUES (1, N'ЕДС Стажёр')
INSERT [dbo].[Operator] ([OperatorID], [NOperator]) VALUES (2, N'Горшков Орест Рубенович')
INSERT [dbo].[Operator] ([OperatorID], [NOperator]) VALUES (3, N'Чернов Игнатий Владимирович')
INSERT [dbo].[Operator] ([OperatorID], [NOperator]) VALUES (4, N'Давыдов Герасим Георгьевич')
INSERT [dbo].[Operator] ([OperatorID], [NOperator]) VALUES (5, N'Тимофеев Андрей Тарасович')
INSERT [dbo].[Operator] ([OperatorID], [NOperator]) VALUES (6, N'Щукин Павел Юрьевич')
INSERT [dbo].[Operator] ([OperatorID], [NOperator]) VALUES (7, N'Никифоров Осип Алексеевич')
INSERT [dbo].[Operator] ([OperatorID], [NOperator]) VALUES (8, N'Алексеев Харитон Фролович')
SET IDENTITY_INSERT [dbo].[Operator] OFF
GO
SET IDENTITY_INSERT [dbo].[Plan] ON 

INSERT [dbo].[Plan] ([PlanID], [TimeNeed], [ContentN], [TypeID], [ExecutorID], [Adress], [StatusID]) VALUES (1, CAST(N'2023-05-01T09:40:00.000' AS DateTime), N'Проверка труб', 4, 3, N'17 Сентября ул., д. 17', 1)
INSERT [dbo].[Plan] ([PlanID], [TimeNeed], [ContentN], [TypeID], [ExecutorID], [Adress], [StatusID]) VALUES (2, CAST(N'2023-05-31T09:35:00.000' AS DateTime), N'Проверка вентиляции', 1, 2, N'Новая ул., д. 21', 1)
INSERT [dbo].[Plan] ([PlanID], [TimeNeed], [ContentN], [TypeID], [ExecutorID], [Adress], [StatusID]) VALUES (3, CAST(N'2023-05-31T10:30:00.000' AS DateTime), N'Проверить домофоны на работоспособность', 1, 1, N'Тихая ул., д. 15', 1)
INSERT [dbo].[Plan] ([PlanID], [TimeNeed], [ContentN], [TypeID], [ExecutorID], [Adress], [StatusID]) VALUES (4, CAST(N'2023-10-06T10:00:00.000' AS DateTime), N'Проверка проводки', 3, 4, N'Молодежная ул., д. 16,17,18,19', 2)
INSERT [dbo].[Plan] ([PlanID], [TimeNeed], [ContentN], [TypeID], [ExecutorID], [Adress], [StatusID]) VALUES (5, CAST(N'2023-11-06T05:00:00.000' AS DateTime), N'Проверить отключено ли отопленние', 4, 2, N'Садовая ул., д. 14', 2)
INSERT [dbo].[Plan] ([PlanID], [TimeNeed], [ContentN], [TypeID], [ExecutorID], [Adress], [StatusID]) VALUES (7, CAST(N'2023-05-16T10:35:00.000' AS DateTime), N'Проверка краски в подъездах', 1, 2, N'Центральный пер., д. 15', 2)
INSERT [dbo].[Plan] ([PlanID], [TimeNeed], [ContentN], [TypeID], [ExecutorID], [Adress], [StatusID]) VALUES (8, CAST(N'2023-05-15T08:00:00.000' AS DateTime), N'Проверка работоспособности лифта', 1, 1, N'Полесская ул., д. 11', 2)
SET IDENTITY_INSERT [dbo].[Plan] OFF
GO
SET IDENTITY_INSERT [dbo].[Request] ON 

INSERT [dbo].[Request] ([RequestID], [DateStart], [ContentN], [TypeID], [SourceID], [Applicant], [ExecutorID], [Adress], [СonvenientTime], [StatusID]) VALUES (1, CAST(N'2023-05-25T09:11:00.000' AS DateTime), N'Холодный п/с
', 4, 1, N'Носков Абрам Игоревич
', 2, N'17 Сентября ул., д. 17 кв.75
', N'8:30
', 1)
INSERT [dbo].[Request] ([RequestID], [DateStart], [ContentN], [TypeID], [SourceID], [Applicant], [ExecutorID], [Adress], [СonvenientTime], [StatusID]) VALUES (2, CAST(N'2023-05-25T09:37:00.000' AS DateTime), N'Поменять кран перекрытия
', 4, 2, N'Жуков Геннадий Кириллович
', 3, N'Новая ул., д. 21 кв.195
', NULL, 1)
INSERT [dbo].[Request] ([RequestID], [DateStart], [ContentN], [TypeID], [SourceID], [Applicant], [ExecutorID], [Adress], [СonvenientTime], [StatusID]) VALUES (3, CAST(N'2023-01-06T13:00:00.000' AS DateTime), N'Горячий п/c', 4, 1, N'Третьяков Прохор Мэлсович', 3, N'Новоселов ул., д. 14 кв.115', N'10:30', 1)
INSERT [dbo].[Request] ([RequestID], [DateStart], [ContentN], [TypeID], [SourceID], [Applicant], [ExecutorID], [Adress], [СonvenientTime], [StatusID]) VALUES (4, CAST(N'2023-12-05T08:45:00.000' AS DateTime), N'Засор в туалете', 2, 3, N'Фёдоров Валентин Владленович', 2, N'Школьная ул., д. 25 кв.101', N'12:32', 1)
INSERT [dbo].[Request] ([RequestID], [DateStart], [ContentN], [TypeID], [SourceID], [Applicant], [ExecutorID], [Adress], [СonvenientTime], [StatusID]) VALUES (5, NULL, N'Устранить засор', 4, 2, N'Давыдов Ян Сергеевич', 3, N'Новоселов ул., д. 4 кв.89', N'19:00', 1)
SET IDENTITY_INSERT [dbo].[Request] OFF
GO
SET IDENTITY_INSERT [dbo].[Shutdown] ON 

INSERT [dbo].[Shutdown] ([ShutdownID], [TimeCreate], [TypeID], [TypeShutdown], [StartTime], [EndTime], [Homes], [OperatorID], [StatusID]) VALUES (1, CAST(N'2023-02-06T12:45:00.000' AS DateTime), 3, N'Авария внутриломовых сетей', CAST(N'2023-02-06T11:45:00.000' AS DateTime), CAST(N'2023-02-06T16:45:00.000' AS DateTime), N'17 Сентября ул., д. 18, д. 19', 1, 1)
INSERT [dbo].[Shutdown] ([ShutdownID], [TimeCreate], [TypeID], [TypeShutdown], [StartTime], [EndTime], [Homes], [OperatorID], [StatusID]) VALUES (2, CAST(N'2023-02-08T08:11:00.000' AS DateTime), 4, N'Протечка трубы', CAST(N'2023-02-08T03:11:00.000' AS DateTime), CAST(N'2023-02-08T12:30:00.000' AS DateTime), N'Новая ул., д. 21, 22', 1, 1)
INSERT [dbo].[Shutdown] ([ShutdownID], [TimeCreate], [TypeID], [TypeShutdown], [StartTime], [EndTime], [Homes], [OperatorID], [StatusID]) VALUES (3, CAST(N'2023-02-15T09:32:00.000' AS DateTime), 4, N'Внешний фактор', CAST(N'2023-02-15T07:25:00.000' AS DateTime), CAST(N'2023-02-15T13:45:00.000' AS DateTime), N'Тихая ул., д. 15, 16', 1, 1)
INSERT [dbo].[Shutdown] ([ShutdownID], [TimeCreate], [TypeID], [TypeShutdown], [StartTime], [EndTime], [Homes], [OperatorID], [StatusID]) VALUES (4, CAST(N'2023-01-06T08:00:00.000' AS DateTime), 3, N'Замыкание электрической цепи', CAST(N'2023-01-06T06:00:00.000' AS DateTime), CAST(N'2023-01-06T10:30:00.000' AS DateTime), N'Спортивная ул., д. 13', 8, 1)
INSERT [dbo].[Shutdown] ([ShutdownID], [TimeCreate], [TypeID], [TypeShutdown], [StartTime], [EndTime], [Homes], [OperatorID], [StatusID]) VALUES (5, CAST(N'2023-03-06T00:00:00.000' AS DateTime), 3, N'Внешний фактор', CAST(N'2023-03-06T11:00:00.000' AS DateTime), CAST(N'2023-03-06T18:00:00.000' AS DateTime), N'ЯнкиКупалы ул., д. 6,7,8', 7, 1)
INSERT [dbo].[Shutdown] ([ShutdownID], [TimeCreate], [TypeID], [TypeShutdown], [StartTime], [EndTime], [Homes], [OperatorID], [StatusID]) VALUES (6, CAST(N'2023-04-06T12:00:00.000' AS DateTime), 2, N'Внешний фактор', CAST(N'2023-04-06T11:31:00.000' AS DateTime), CAST(N'2023-04-06T16:48:00.000' AS DateTime), N'Песчаная ул., д. 18', 6, 1)
SET IDENTITY_INSERT [dbo].[Shutdown] OFF
GO
SET IDENTITY_INSERT [dbo].[Source] ON 

INSERT [dbo].[Source] ([SourceID], [NSource]) VALUES (1, N'Телефон')
INSERT [dbo].[Source] ([SourceID], [NSource]) VALUES (2, N'АСУ')
INSERT [dbo].[Source] ([SourceID], [NSource]) VALUES (3, N'Email')
SET IDENTITY_INSERT [dbo].[Source] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([StatusID], [NStatus]) VALUES (1, N'Готово')
INSERT [dbo].[Status] ([StatusID], [NStatus]) VALUES (2, N'В работе')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Type] ON 

INSERT [dbo].[Type] ([TypeID], [NType]) VALUES (1, N'Иное')
INSERT [dbo].[Type] ([TypeID], [NType]) VALUES (2, N'Канализация')
INSERT [dbo].[Type] ([TypeID], [NType]) VALUES (3, N'Электроэнергия')
INSERT [dbo].[Type] ([TypeID], [NType]) VALUES (4, N'Водоснабжение')
SET IDENTITY_INSERT [dbo].[Type] OFF
GO
ALTER TABLE [dbo].[Plan]  WITH CHECK ADD  CONSTRAINT [FK_Plan_Executor] FOREIGN KEY([ExecutorID])
REFERENCES [dbo].[Executor] ([ExecutorID])
GO
ALTER TABLE [dbo].[Plan] CHECK CONSTRAINT [FK_Plan_Executor]
GO
ALTER TABLE [dbo].[Plan]  WITH CHECK ADD  CONSTRAINT [FK_Plan_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([StatusID])
GO
ALTER TABLE [dbo].[Plan] CHECK CONSTRAINT [FK_Plan_Status]
GO
ALTER TABLE [dbo].[Plan]  WITH CHECK ADD  CONSTRAINT [FK_Plan_Type] FOREIGN KEY([TypeID])
REFERENCES [dbo].[Type] ([TypeID])
GO
ALTER TABLE [dbo].[Plan] CHECK CONSTRAINT [FK_Plan_Type]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Executor] FOREIGN KEY([ExecutorID])
REFERENCES [dbo].[Executor] ([ExecutorID])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Executor]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Source] FOREIGN KEY([SourceID])
REFERENCES [dbo].[Source] ([SourceID])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Source]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([StatusID])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Status]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Type] FOREIGN KEY([TypeID])
REFERENCES [dbo].[Type] ([TypeID])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Type]
GO
ALTER TABLE [dbo].[Shutdown]  WITH CHECK ADD  CONSTRAINT [FK_Shutdown_Operator] FOREIGN KEY([OperatorID])
REFERENCES [dbo].[Operator] ([OperatorID])
GO
ALTER TABLE [dbo].[Shutdown] CHECK CONSTRAINT [FK_Shutdown_Operator]
GO
ALTER TABLE [dbo].[Shutdown]  WITH CHECK ADD  CONSTRAINT [FK_Shutdown_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([StatusID])
GO
ALTER TABLE [dbo].[Shutdown] CHECK CONSTRAINT [FK_Shutdown_Status]
GO
ALTER TABLE [dbo].[Shutdown]  WITH CHECK ADD  CONSTRAINT [FK_Shutdown_Type] FOREIGN KEY([TypeID])
REFERENCES [dbo].[Type] ([TypeID])
GO
ALTER TABLE [dbo].[Shutdown] CHECK CONSTRAINT [FK_Shutdown_Type]
GO
USE [master]
GO
ALTER DATABASE [NKS] SET  READ_WRITE 
GO
