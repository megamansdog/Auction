/** Address **/
CREATE TABLE [dbo].[address](
  [Id] [int] IDENTITY(1,1) NOT NULL,
  [userid] [int] NOT NULL,
  [street_number] [varchar](50) NOT NULL,
  [street_name] [varchar](50) NOT NULL,
  [city] [varchar](50) NOT NULL,
  [state] [varchar](50) NOT NULL,
  [zip] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED
(
  [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

/** Bids **/
CREATE TABLE [dbo].[bids](
  [Id] [int] IDENTITY(1,1) NOT NULL,
  [userid] [int] NOT NULL,
  [itemid] [int] NOT NULL,
  [bid_amount] [money] NOT NULL,
  [bid_time] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED
(
  [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [itemid_userid_unique_key] UNIQUE NONCLUSTERED
(
  [userid] ASC,
  [itemid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

/** Contact Info **/
CREATE TABLE [dbo].[contact_info](
  [Id] [int] IDENTITY(1,1) NOT NULL,
  [userid] [int] NOT NULL,
  [phone_number] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED
(
  [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

/** Credit_Card **/
CREATE TABLE [dbo].[credit_card](
  [Id] [int] IDENTITY(1,1) NOT NULL,
  [userid] [int] NOT NULL,
  [number] [varchar](50) NOT NULL,
  [expiration] [date] NOT NULL,
  [owner] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED
(
  [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

/** item_pictures **/
CREATE TABLE [dbo].[item_pictures](
  [Id] [int] IDENTITY(1,1) NOT NULL,
  [image_name] [nvarchar](50) NOT NULL,
  [image_data] [varbinary](max) NOT NULL,
  [itemid] [int] NOT NULL,
PRIMARY KEY CLUSTERED
(
  [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

USE [D:\REPOS\AUCTION\APP_DATA\DATABASE1.MDF]
GO

/** Items **/
CREATE TABLE [dbo].[items](
  [Id] [int] IDENTITY(1,1) NOT NULL,
  [userid] [int] NOT NULL,
  [name] [varchar](50) NOT NULL,
  [condition] [varchar](50) NOT NULL,
  [initial_price] [int] NOT NULL,
  [description] [text] NOT NULL,
  [quantity] [int] NOT NULL,
  [start_time] [datetime2](7) NOT NULL,
  [end_time] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED
(
  [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

/** users **/
CREATE TABLE [dbo].[users](
  [Id] [int] IDENTITY(1,1) NOT NULL,
  [username] [varchar](50) NOT NULL,
  [password] [varchar](50) NOT NULL,
  [email] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED
(
  [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [email_unique] UNIQUE NONCLUSTERED
(
  [email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [username_unique] UNIQUE NONCLUSTERED
(
  [username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
