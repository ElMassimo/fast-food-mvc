Para poder correr la aplicación localmente es necesario crear dos bases de datos.
En FastFood.Dal/EntityModels se encuentran scripts para crear los esquemas y para cargar datos de prueba en dichas bases.
	
*FoodExpress: Se utiliza para almacenar la mayor parte de la información de la aplicación.
Instrucciones: 
	-Crear la base de datos "FoodExpress".
	-Correr el script "FastFoodEntities.edmx.sql" para crear el esquema.
	-Correr el script "FoodExpressData.sql" para cargar datos de prueba.
	
*FoodExpress.admin: Se utiliza para guardar las cuentas de los administradores del sistema.
Instrucciones:
	-Crear la base de datos "FoodExpress.admin".
	-Correr el script "InstallCommon.sql".
	-Correr el script "InstallMembership.sql".
	-Correr el script "InstallRoles.sql".
	-Correr el script "FoodExpressAdminData.sql" para cargar cuentas de prueba.

Hay por defecto dos cuentas administrativas:
	User: pcgarcia@microsoft.com
	Password: password
	
	User: t-gakles@microsoft.com
	Password: password
	
Se accede al sitio administrativo bajo el path ~/Admin.
