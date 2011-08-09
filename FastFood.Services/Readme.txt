Se proveen dos grupos de servicios distintos, uno para la aplicación de Windows Phone 7, y otro para crear y consultar ordenes.

*DeliveryServices:
	-GetUndeliveredOrders: Devuelve las órdenes que tiene asignadas un repartidor.
	-GetOrderDetail: Obtiene el detalle de una orden.
	-DeliverOrder: Actualiza el estado de una orden.

*RestaurantServices:
	-MakeOrder: Crea una orden a nombre del cliente indicado, en el restaurant indicado.
	-GetFullOrderDetail: Obtiene el detalle completo de una orden.

IMPORTANTE1: Si se hace deploy en el IIS, puede ser necesario ir al pool de aplicaciones donde corre la aplicación y dentro de Configuración avanzada->Identidad seleccionar LocalSystem.
IMPORTANTE2: Publicar con la configuración de solución "Local", que utiliza las connectionStrings locales y no las de Azure.