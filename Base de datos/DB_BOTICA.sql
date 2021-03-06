USE [DB_BOTICA]
GO
/****** Object:  ForeignKey [FK_Tb_Compra_Tb_Cliente]    Script Date: 04/29/2018 14:07:03 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tb_Compra_Tb_Cliente]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tb_Compra]'))
ALTER TABLE [dbo].[Tb_Compra] DROP CONSTRAINT [FK_Tb_Compra_Tb_Cliente]
GO
/****** Object:  ForeignKey [FK_Tb_MillajeSalud_Tb_Cliente]    Script Date: 04/29/2018 14:07:03 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tb_MillajeSalud_Tb_Cliente]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tb_MillajeSalud]'))
ALTER TABLE [dbo].[Tb_MillajeSalud] DROP CONSTRAINT [FK_Tb_MillajeSalud_Tb_Cliente]
GO
/****** Object:  StoredProcedure [dbo].[Usp_Botica_Tb_Compra_InsertUpdateDelete]    Script Date: 04/29/2018 14:07:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usp_Botica_Tb_Compra_InsertUpdateDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Usp_Botica_Tb_Compra_InsertUpdateDelete]
GO
/****** Object:  StoredProcedure [dbo].[Usp_Botica_Tb_Compra_Select]    Script Date: 04/29/2018 14:07:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usp_Botica_Tb_Compra_Select]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Usp_Botica_Tb_Compra_Select]
GO
/****** Object:  StoredProcedure [dbo].[Usp_Botica_Tb_MillajeSalud_InsertUpdate]    Script Date: 04/29/2018 14:07:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usp_Botica_Tb_MillajeSalud_InsertUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Usp_Botica_Tb_MillajeSalud_InsertUpdate]
GO
/****** Object:  StoredProcedure [dbo].[Usp_Botica_Tb_MillajeSalud_Select]    Script Date: 04/29/2018 14:07:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usp_Botica_Tb_MillajeSalud_Select]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Usp_Botica_Tb_MillajeSalud_Select]
GO
/****** Object:  Table [dbo].[Tb_Compra]    Script Date: 04/29/2018 14:07:03 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tb_Compra_Tb_Cliente]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tb_Compra]'))
ALTER TABLE [dbo].[Tb_Compra] DROP CONSTRAINT [FK_Tb_Compra_Tb_Cliente]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tb_Compra]') AND type in (N'U'))
DROP TABLE [dbo].[Tb_Compra]
GO
/****** Object:  Table [dbo].[Tb_MillajeSalud]    Script Date: 04/29/2018 14:07:03 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tb_MillajeSalud_Tb_Cliente]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tb_MillajeSalud]'))
ALTER TABLE [dbo].[Tb_MillajeSalud] DROP CONSTRAINT [FK_Tb_MillajeSalud_Tb_Cliente]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tb_MillajeSalud]') AND type in (N'U'))
DROP TABLE [dbo].[Tb_MillajeSalud]
GO
/****** Object:  Table [dbo].[Tb_Cliente]    Script Date: 04/29/2018 14:07:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tb_Cliente]') AND type in (N'U'))
DROP TABLE [dbo].[Tb_Cliente]
GO
/****** Object:  Table [dbo].[Tb_Cliente]    Script Date: 04/29/2018 14:07:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tb_Cliente]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tb_Cliente](
	[ClienteDNI] [varchar](20) NOT NULL,
	[Nombres] [varchar](50) NULL,
 CONSTRAINT [PK_Tb_Cliente] PRIMARY KEY CLUSTERED 
(
	[ClienteDNI] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Tb_Cliente] ([ClienteDNI], [Nombres]) VALUES (N'09999999', N'Juan')
INSERT [dbo].[Tb_Cliente] ([ClienteDNI], [Nombres]) VALUES (N'10000001', N'Luis')
/****** Object:  Table [dbo].[Tb_MillajeSalud]    Script Date: 04/29/2018 14:07:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tb_MillajeSalud]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tb_MillajeSalud](
	[ClienteDNI] [varchar](20) NOT NULL,
	[ImporteSolesAcumulados] [money] NULL,
 CONSTRAINT [PK_Tb_MillajeSalud] PRIMARY KEY CLUSTERED 
(
	[ClienteDNI] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tb_Compra]    Script Date: 04/29/2018 14:07:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tb_Compra]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tb_Compra](
	[IdCompra] [int] IDENTITY(1,1) NOT NULL,
	[ClienteDNI] [varchar](20) NULL,
	[ImporteCompra] [money] NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[Usp_Botica_Tb_MillajeSalud_Select]    Script Date: 04/29/2018 14:07:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usp_Botica_Tb_MillajeSalud_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N' 
CREATE PROC [dbo].[Usp_Botica_Tb_MillajeSalud_Select] 
@OpcionSql VARCHAR(2) = ''S'', 
@ClienteDNI VARCHAR(20) = '''' 
AS BEGIN 
	IF (@OpcionSql = ''S'') BEGIN 
		SELECT	ClienteDNI, ISNULL(ImporteSolesAcumulados, 0) AS ImporteSolesAcumulados 
		FROM         Tb_MillajeSalud 
		WHERE     (ClienteDNI = @ClienteDNI) 
	END 
END 
' 
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_Botica_Tb_MillajeSalud_InsertUpdate]    Script Date: 04/29/2018 14:07:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usp_Botica_Tb_MillajeSalud_InsertUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[Usp_Botica_Tb_MillajeSalud_InsertUpdate] 
@OpcionSql VARCHAR(2),
@ClienteDNI VARCHAR(20) = '''', 
@ImporteSolesAcumulados MONEY, 
@Resultado INT = 0 OUTPUT 
AS BEGIN TRANSACTION 
	SET NOCOUNT ON
	--
	IF @ClienteDNI = '''' BEGIN
		ROLLBACK TRANSACTION
		RETURN
	END
	--
	IF (@OpcionSql = ''IU'') BEGIN 
		IF EXISTS (SELECT 1 FROM Tb_MillajeSalud WHERE (ClienteDNI = @ClienteDNI)) BEGIN 
			UPDATE    Tb_MillajeSalud 
			SET ImporteSolesAcumulados += @ImporteSolesAcumulados 
			WHERE     (ClienteDNI = @ClienteDNI) 
			--
			IF @@ERROR <> 0 BEGIN
				ROLLBACK TRANSACTION
				RETURN
			END
			--
			SET @Resultado = 2
		END 
		ELSE BEGIN 
			INSERT INTO Tb_MillajeSalud
								  (ClienteDNI, ImporteSolesAcumulados)
			VALUES     (@ClienteDNI,@ImporteSolesAcumulados)
			--
			IF @@ERROR <> 0 BEGIN
				ROLLBACK TRANSACTION
				RETURN
			END
			--
			SET @Resultado = 1
		END 
	END 
COMMIT TRANSACTION
' 
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_Botica_Tb_Compra_Select]    Script Date: 04/29/2018 14:07:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usp_Botica_Tb_Compra_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[Usp_Botica_Tb_Compra_Select] 
@OpcionSql VARCHAR(2) = ''S'', 
@IdCompra INT = 0, 
@ClienteDNI VARCHAR(20) = ''''
AS BEGIN 
	IF (@OpcionSql = ''S'') BEGIN 
		SELECT     IdCompra, ClienteDNI, ISNULL(ImporteCompra, 0) AS ImporteCompra
		FROM         Tb_Compra
		WHERE     (IdCompra = @IdCompra)
	END 
	ELSE IF (@OpcionSql = ''L'') BEGIN 
		SELECT     IdCompra, ClienteDNI, ISNULL(ImporteCompra, 0) AS ImporteCompra
		FROM         Tb_Compra
		WHERE     (ClienteDNI = @ClienteDNI)
	END 
END 
' 
END
GO
/****** Object:  StoredProcedure [dbo].[Usp_Botica_Tb_Compra_InsertUpdateDelete]    Script Date: 04/29/2018 14:07:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usp_Botica_Tb_Compra_InsertUpdateDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[Usp_Botica_Tb_Compra_InsertUpdateDelete] 
@OpcionSql VARCHAR(2), 
@IdCompra INT, 
@ClienteDNI VARCHAR(20) = '''', 
@ImporteCompra MONEY, 
@Resultado INT = 0 OUTPUT 
AS BEGIN TRANSACTION 
	SET NOCOUNT ON
	--
	IF @ClienteDNI = '''' BEGIN
		ROLLBACK TRANSACTION
		RETURN
	END
	--
	IF (@OpcionSql = ''I'') BEGIN
		--
		INSERT INTO Tb_Compra
				 (ClienteDNI, ImporteCompra)
		VALUES   (@ClienteDNI,@ImporteCompra)
		--
		IF @@ERROR <> 0 BEGIN
			ROLLBACK TRANSACTION
			RETURN
		END
		--
		SET @Resultado = SCOPE_IDENTITY()
	END 
COMMIT TRANSACTION
' 
END
GO
/****** Object:  ForeignKey [FK_Tb_Compra_Tb_Cliente]    Script Date: 04/29/2018 14:07:03 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tb_Compra_Tb_Cliente]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tb_Compra]'))
ALTER TABLE [dbo].[Tb_Compra]  WITH CHECK ADD  CONSTRAINT [FK_Tb_Compra_Tb_Cliente] FOREIGN KEY([ClienteDNI])
REFERENCES [dbo].[Tb_Cliente] ([ClienteDNI])
ON UPDATE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tb_Compra_Tb_Cliente]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tb_Compra]'))
ALTER TABLE [dbo].[Tb_Compra] CHECK CONSTRAINT [FK_Tb_Compra_Tb_Cliente]
GO
/****** Object:  ForeignKey [FK_Tb_MillajeSalud_Tb_Cliente]    Script Date: 04/29/2018 14:07:03 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tb_MillajeSalud_Tb_Cliente]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tb_MillajeSalud]'))
ALTER TABLE [dbo].[Tb_MillajeSalud]  WITH CHECK ADD  CONSTRAINT [FK_Tb_MillajeSalud_Tb_Cliente] FOREIGN KEY([ClienteDNI])
REFERENCES [dbo].[Tb_Cliente] ([ClienteDNI])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tb_MillajeSalud_Tb_Cliente]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tb_MillajeSalud]'))
ALTER TABLE [dbo].[Tb_MillajeSalud] CHECK CONSTRAINT [FK_Tb_MillajeSalud_Tb_Cliente]
GO
