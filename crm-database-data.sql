USE [InDrivoHRM]
GO
SET QUOTED_IDENTIFIER ON
GO
DELETE FROM [dbo].[Tasks]
DELETE FROM [dbo].[TaskStatuses]
DELETE FROM [dbo].[TaskTypes]
DELETE FROM [dbo].[Opportunities]
DELETE FROM [dbo].[OpportunityStatuses]
DELETE FROM [dbo].[Contacts]
DELETE FROM [dbo].[AspNetUsers]
DELETE FROM [dbo].[AspNetUserRoles]
DELETE FROM [dbo].[AspNetRoles]
GO

INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'7ed881d3-5fcd-45d1-97f7-a9f1cfc43529', N'c5662bf0-9a40-4c0f-a005-00f549d85117', N'Sales Representative', N'SALES REPRESENTATIVE')

INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'af4a12b8-bd98-42d9-8539-139bb63a461f', N'0dd1cdd6-51c7-40be-805d-6eed33a4dd61', N'Sales Manager', N'SALES MANAGER')

SET IDENTITY_INSERT [dbo].[OpportunityStatuses] ON
INSERT [dbo].[OpportunityStatuses] ([Id], [Name]) VALUES (1, N'Inactive')
INSERT [dbo].[OpportunityStatuses] ([Id], [Name]) VALUES (2, N'Won')
INSERT [dbo].[OpportunityStatuses] ([Id], [Name]) VALUES (3, N'Lost')
INSERT [dbo].[OpportunityStatuses] ([Id], [Name]) VALUES (4, N'Active')
SET IDENTITY_INSERT [dbo].[OpportunityStatuses] OFF

SET IDENTITY_INSERT [dbo].[TaskStatuses] ON
INSERT [dbo].[TaskStatuses] ([Id], [Name]) VALUES (1, N'Not Started')
INSERT [dbo].[TaskStatuses] ([Id], [Name]) VALUES (2, N'In Progress')
INSERT [dbo].[TaskStatuses] ([Id], [Name]) VALUES (3, N'Complete')
SET IDENTITY_INSERT [dbo].[TaskStatuses] OFF

SET IDENTITY_INSERT [dbo].[TaskTypes] ON
INSERT [dbo].[TaskTypes] ([Id], [Name]) VALUES (1, N'Online Meeting')
INSERT [dbo].[TaskTypes] ([Id], [Name]) VALUES (2, N'Email')
INSERT [dbo].[TaskTypes] ([Id], [Name]) VALUES (3, N'Call')
SET IDENTITY_INSERT [dbo].[TaskTypes] OFF
