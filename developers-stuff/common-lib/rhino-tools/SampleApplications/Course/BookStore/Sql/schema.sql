SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](255) NOT NULL,
	[Lastname] [nvarchar](255) NOT NULL,
	[Username] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [trigger_for_user]
   ON  [dbo].[Users]
   AFTER insert
AS 
BEGIN
	SET NOCOUNT ON;
	insert into tmp values('a')

END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tmp]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tmp](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[t] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Books]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Books](
	[ISBN] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_BookCatalog] PRIMARY KEY CLUSTERED 
(
	[ISBN] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CheckOuts]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CheckOuts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NOT NULL,
	[bookCopyId] [int] NOT NULL,
	[checkedOutAt] [datetime] NOT NULL,
	[dueDate] [datetime] NOT NULL,
	[returnDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[CheckOuts]') AND name = N'IX_CheckOuts')
CREATE NONCLUSTERED INDEX [IX_CheckOuts] ON [dbo].[CheckOuts] 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BookCopy]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BookCopy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ISBN] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BookInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[BookInsert] 
	@isbn nvarchar(50),
	@name nvarchar(255)
AS
	SET NOCOUNT ON 
	
	INSERT INTO Books(ISBN, Name) VALUES(@isbn, @name)
	INSERT INTO BookCopy (ISBN) VALUES(@isbn)
	
	RETURN
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BookGetAllCheckedOutByUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE procedure [dbo].[BookGetAllCheckedOutByUser] 
	@userId int
as

select Books.ISBN, Books.Name 
from Books 
	inner join BookCopy on Books.ISBN = BookCopy.ISBN
	inner join CheckOuts on CheckOuts.BookCopyId = BookCopy.Id
WHERE CheckOuts.UserId = @userid and CheckOuts.returnDate is null
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BookFindAvailableCopy]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[BookFindAvailableCopy] 
	@isbn nvarchar(255)
AS

SELECT TOP 1 Id, ISBN FROM BookCopy 
WHERE BookCopy.ISBN = @isbn 
	AND BookCopy.Id not in (SELECT BookCopyId FROM CheckOuts
	WHERE CheckOuts.BookCopyId = BookCopy.Id and ReturnDate is null)' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BooksGetLateReturns]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[BooksGetLateReturns] 
AS 
SELECT 
	Users.Id, 
	Users.FirstName, 
	Users.LastName, 
	Users.Username,
	Books.Name,
	Books.ISBN,
	CheckedOutAt,
	DueDate
FROM CheckOuts 
	inner join Users on UserId = Users.Id
	inner join BookCopy on BookCopyId = BookCopy.Id
	inner join Books on BookCopy.ISBN = Books.ISBN
WHERE ReturnDate IS NULL and DueDate < getdate()' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UserInsert] 
    @username nvarchar(255),
	@firstname nvarchar(255),
	@lastname nvarchar(255)
AS
    SET NOCOUNT ON 

    INSERT INTO Users(Username, Firstname, lastname) VALUES(@username, @firstname, @lastname)

	select SCOPE_IDENTITY()

    RETURN' 
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__CheckOuts__bookC__1DE57479]') AND parent_object_id = OBJECT_ID(N'[dbo].[CheckOuts]'))
ALTER TABLE [dbo].[CheckOuts]  WITH CHECK ADD FOREIGN KEY([bookCopyId])
REFERENCES [dbo].[BookCopy] ([Id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__CheckOuts__userI__1CF15040]') AND parent_object_id = OBJECT_ID(N'[dbo].[CheckOuts]'))
ALTER TABLE [dbo].[CheckOuts]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([Id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Books_BookCatalog]') AND parent_object_id = OBJECT_ID(N'[dbo].[BookCopy]'))
ALTER TABLE [dbo].[BookCopy]  WITH CHECK ADD  CONSTRAINT [FK_Books_BookCatalog] FOREIGN KEY([ISBN])
REFERENCES [dbo].[Books] ([ISBN])
