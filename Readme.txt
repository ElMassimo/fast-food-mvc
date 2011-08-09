Para poder correr la aplicaci�n localmente es necesario crear dos bases de datos.
En FastFood.Dal/EntityModels se encuentran scripts para crear los esquemas y para cargar datos de prueba en dichas bases.
	
*FoodExpress: Se utiliza para almacenar la mayor parte de la informaci�n de la aplicaci�n.
Instrucciones: 
	-Crear la base de datos "FoodExpress".
	-Correr el script "FastFoodEntities.edmx.sql" para crear el esquema.
	-Correr el script "FoodExpressData.sql" para cargar datos de prueba.
	
*FoodExpress.admin: Se utiliza para guardar las cuentas de los administradores del sistema.
Instrucciones:
	-Crear la base de datos "FoodExpress.admin".
	-Correr el script "FoodExpressAdminSchema.sql" para crear el esquema (es el que crea por defecto ASP.NET para ApplicationData).
	-Correr el script "FoodExpressAdminData.sql" para cargar cuentas de prueba.

Hay por defecto dos cuentas administrativas:
	User: pcgarcia@microsoft.com
	Password: password
	
	User: t-gakles@microsoft.com
	Password: password
	
Se accede al sitio administrativo bajo el path ~/Admin.

IMPORTANTE: Si se hace deploy en el IIS, puede ser necesario ir al pool de aplicaciones donde corre la aplicaci�n y dentro de Configuraci�n avanzada->Identidad seleccionar LocalSystem.