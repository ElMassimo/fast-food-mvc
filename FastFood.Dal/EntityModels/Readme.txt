Para poder correr la aplicación localmente es necesario crear dos bases de datos.
En FastFood.Dal/EntityModels se encuentran scripts para crear los esquemas y para cargar datos de prueba en dichas bases.
	
*FoodExpress: Se utiliza para almacenar la mayor parte de la información de la aplicación.
Instrucciones: 
	1) Crear la base de datos "FoodExpress".
	2) Correr el script "FastFoodEntities.edmx.sql" para crear el esquema.
	3) Correr el script "FoodExpressData.sql" para cargar datos de prueba.
	
*FoodExpress.admin: Se utiliza para guardar las cuentas de los administradores del sistema.
Instrucciones:
	1) Crear la base de datos "FoodExpress.admin".
	2) Correr el script "FoodExpressAdminSchema.sql" para crear el esquema (es el que crea por defecto ASP.NET para ApplicationData).
	3) Correr el script "FoodExpressAdminData.sql" para cargar cuentas de prueba.
	4) Queda habilitado el registro de administradores para que puedan probar de todas maneras si el paso 3 se ejecuta con errores.


Hay por defecto dos cuentas administrativas:
	User: pcgarcia@microsoft.com
	Password: password
	
	User: t-gakles@microsoft.com
	Password: password
	
Se accede al sitio administrativo bajo el path ~/Admin.

IMPORTANTE1: Si se hace deploy en el IIS, puede ser necesario ir al pool de aplicaciones donde corre la aplicación y dentro de Configuración avanzada->Identidad seleccionar LocalSystem.
IMPORTANTE2: Publicar con la configuración de solución "Local", que utiliza las connectionStrings locales y no las de Azure.