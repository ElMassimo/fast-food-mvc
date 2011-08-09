USE [FoodExpress]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 08/09/2011 01:18:39 ******/
SET IDENTITY_INSERT [dbo].[Addresses] ON
INSERT [dbo].[Addresses] ([Id], [Street], [City], [State], [Country], [PostalCode], [Number], [ApartmentNumber], [DependentLocalityName]) VALUES (3, N'Gonzalo Ramírez', N'Montevideo', N'Montevideo', N'Uruguay', 11200, 504, NULL, N'Parque Rodo')
INSERT [dbo].[Addresses] ([Id], [Street], [City], [State], [Country], [PostalCode], [Number], [ApartmentNumber], [DependentLocalityName]) VALUES (4, N'Gonzalo Ramírez', N'Montevideo', N'Montevideo', N'Uruguay', 11200, 1120, NULL, N'Parque Rodo')
INSERT [dbo].[Addresses] ([Id], [Street], [City], [State], [Country], [PostalCode], [Number], [ApartmentNumber], [DependentLocalityName]) VALUES (5, N'Maggiolo', N'Montevideo', N'Montevideo', N'Uruguay', 11200, 520, N'104', N'Parque Rodo')
INSERT [dbo].[Addresses] ([Id], [Street], [City], [State], [Country], [PostalCode], [Number], [ApartmentNumber], [DependentLocalityName]) VALUES (6, N'Tacuarembó', N'Montevideo', N'Montevideo', N'Uruguay', 11200, 1388, N'17', N'Cordon')
INSERT [dbo].[Addresses] ([Id], [Street], [City], [State], [Country], [PostalCode], [Number], [ApartmentNumber], [DependentLocalityName]) VALUES (7, N'Luis de la Torre', N'Montevideo', N'Montevideo', N'Uruguay', 11200, 502, NULL, N'Punta Carretas')
SET IDENTITY_INSERT [dbo].[Addresses] OFF
/****** Object:  Table [dbo].[Clients]    Script Date: 08/09/2011 01:18:39 ******/
SET IDENTITY_INSERT [dbo].[Clients] ON
INSERT [dbo].[Clients] ([Id], [FirstName], [LastName], [Phone], [Email], [Password], [Address_Id]) VALUES (3, N'Máximo', N'Mussini', N'099479451', N'maximomussini@hotmail.com', N'1E1455DD65483274E9509E89523217DFBD242C6F', 5)
INSERT [dbo].[Clients] ([Id], [FirstName], [LastName], [Phone], [Email], [Password], [Address_Id]) VALUES (4, N'Máximo', N'Mussini', N'099479451', N'massimo1590@hotmail.com', N'1E1455DD65483274E9509E89523217DFBD242C6F', 6)
SET IDENTITY_INSERT [dbo].[Clients] OFF
/****** Object:  Table [dbo].[Restaurants]    Script Date: 08/09/2011 01:18:39 ******/
INSERT [dbo].[Restaurants] ([Name], [Description], [Address_Id]) VALUES (N'francis', N'Restaurant - Parrilla Gourmet', 7)
INSERT [dbo].[Restaurants] ([Name], [Description], [Address_Id]) VALUES (N'La Taberna del Diablo', N'Las mejores empanadas de Parque Rodó', 4)
INSERT [dbo].[Restaurants] ([Name], [Description], [Address_Id]) VALUES (N'Rodelú', N'Pizzería y parrillada', 3)
/****** Object:  Table [dbo].[DeliveryBoys]    Script Date: 08/09/2011 01:18:39 ******/
INSERT [dbo].[DeliveryBoys] ([FirstName], [LastName], [SuccesfulDeliveries], [Password], [Nick], [Restaurant_Name]) VALUES (N'Maximo', N'Mussini', 3, N'holanda', N'Massimo', N'Rodelú')
INSERT [dbo].[DeliveryBoys] ([FirstName], [LastName], [SuccesfulDeliveries], [Password], [Nick], [Restaurant_Name]) VALUES (N'Jeronimo', N'Mussini', 0, N'holanda', N'Jero', N'La Taberna del Diablo')
INSERT [dbo].[DeliveryBoys] ([FirstName], [LastName], [SuccesfulDeliveries], [Password], [Nick], [Restaurant_Name]) VALUES (N'Jim', N'Morrison', 0, N'holanda', N'Jimmy', N'francis')
INSERT [dbo].[DeliveryBoys] ([FirstName], [LastName], [SuccesfulDeliveries], [Password], [Nick], [Restaurant_Name]) VALUES (N'Victoria', N'Senattore', 0, N'holanda', N'Victoria', N'La Taberna del Diablo')
/****** Object:  Table [dbo].[Orders]    Script Date: 08/09/2011 01:18:39 ******/
SET IDENTITY_INSERT [dbo].[Orders] ON
INSERT [dbo].[Orders] ([Id], [Description], [DateOrdered], [DateDelivered], [Status], [Cost], [ClientId], [DeliveryBoy_Nick]) VALUES (2, N'3 empanadas libanesas', CAST(0x00009F38000269C2 AS DateTime), NULL, 1, CAST(123 AS Decimal(18, 0)), 4, N'Jero')
INSERT [dbo].[Orders] ([Id], [Description], [DateOrdered], [DateDelivered], [Status], [Cost], [ClientId], [DeliveryBoy_Nick]) VALUES (3, N'Pizza con muzzarella', CAST(0x00009F39016034D2 AS DateTime), NULL, 3, CAST(148 AS Decimal(18, 0)), 3, N'Massimo')
INSERT [dbo].[Orders] ([Id], [Description], [DateOrdered], [DateDelivered], [Status], [Cost], [ClientId], [DeliveryBoy_Nick]) VALUES (4, N'1 empanada de jamón y queso', CAST(0x00009F3A000FC461 AS DateTime), NULL, 1, CAST(38 AS Decimal(18, 0)), 3, N'Jero')
SET IDENTITY_INSERT [dbo].[Orders] OFF
