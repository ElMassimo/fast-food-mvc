Se proveen dos grupos de servicios distintos, uno para la aplicaci�n de Windows Phone 7, y otro para crear y consultar ordenes.

*DeliveryServices:
	-GetUndeliveredOrders: Devuelve las �rdenes que tiene asignadas un repartidor.
	-GetOrderDetail: Obtiene el detalle de una orden.
	-DeliverOrder: Actualiza el estado de una orden.

*RestaurantServices:
	-MakeOrder: Crea una orden a nombre del cliente indicado, en el restaurant indicado.
	-GetFullOrderDetail: Obtiene el detalle completo de una orden.

IMPORTANTE1: Si se hace deploy en el IIS, puede ser necesario ir al pool de aplicaciones donde corre la aplicaci�n y dentro de Configuraci�n avanzada->Identidad seleccionar LocalSystem.
IMPORTANTE2: Publicar con la configuraci�n de soluci�n "Local", que utiliza las connectionStrings locales y no las de Azure.