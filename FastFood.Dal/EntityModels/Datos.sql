USE [FoodExpress]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 08/01/2011 21:10:34 ******/
SET IDENTITY_INSERT [dbo].[Addresses] ON
INSERT [dbo].[Addresses] ([Id], [Street], [City], [State], [Country], [PostalCode], [Number], [ApartmentNumber], [DependentLocalityName]) VALUES (1, N'Maggiolo', N'Montevideo', N'Montevideo', N'Uruguay', 11200, 520, N'104', N'Parque Rodo')
INSERT [dbo].[Addresses] ([Id], [Street], [City], [State], [Country], [PostalCode], [Number], [ApartmentNumber], [DependentLocalityName]) VALUES (3, N'Gonzalo Ramírez', N'Montevideo', N'Montevideo', N'Uruguay', 11200, 504, NULL,  N'Parque Rodo')
INSERT [dbo].[Addresses] ([Id], [Street], [City], [State], [Country], [PostalCode], [Number], [ApartmentNumber], [DependentLocalityName]) VALUES (4, N'Gonzalo Ramírez', N'Montevideo', N'Montevideo', N'Uruguay', 11200, 1120, NULL, N'Parque Rodo')
SET IDENTITY_INSERT [dbo].[Addresses] OFF
/****** Object:  Table [dbo].[Clients]    Script Date: 08/01/2011 21:10:34 ******/
SET IDENTITY_INSERT [dbo].[Clients] ON
INSERT [dbo].[Clients] ([Id], [FirstName], [LastName], [Phone], [Email], [Password], [Address_Id]) VALUES (1, N'Maximo', N'Mussini', N'099479451', N'maximomussini@gmail.com', N'holanda', 1)
SET IDENTITY_INSERT [dbo].[Clients] OFF
/****** Object:  Table [dbo].[Restaurants]    Script Date: 08/01/2011 21:10:34 ******/
INSERT [dbo].[Restaurants] ([Name], [Description], [Address_Id]) VALUES (N'Rodelú', N'Pizzería y parrillada', 3)
INSERT [dbo].[Restaurants] ([Name], [Description], [Address_Id]) VALUES (N'La Taberna del Diablo', N'Las mejores empanadas de Parque Rodó', 4)
/****** Object:  Table [dbo].[DeliveryBoys]    Script Date: 08/01/2011 21:10:34 ******/
INSERT [dbo].[DeliveryBoys] ([FirstName], [LastName], [SuccesfulDeliveries], [Password], [Nick], [Restaurant_Name]) VALUES (N'Maximo', N'Mussini', 0, N'holanda', N'ElMassimo', N'Rodelú')
INSERT [dbo].[DeliveryBoys] ([FirstName], [LastName], [SuccesfulDeliveries], [Password], [Nick], [Restaurant_Name]) VALUES (N'Jeronimo', N'Mussini', 0, N'holanda', N'Jero', N'La Taberna del Diablo')
/****** Object:  Table [dbo].[Orders]    Script Date: 08/01/2011 21:10:34 ******/
SET IDENTITY_INSERT [dbo].[Orders] ON
INSERT [dbo].[Orders] ([Id], [Description], [DateOrdered], [DateDelivered], [Status], [Cost], [ClientId], [DeliveryBoy_Nick]) VALUES (1, N'Chivito con fritas', CAST(0x00009F32015CB856 AS DateTime), NULL, 0, CAST(9 AS Decimal(18, 0)), 1, N'Massimo')
SET IDENTITY_INSERT [dbo].[Orders] OFF
