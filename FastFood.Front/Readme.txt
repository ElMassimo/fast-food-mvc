El sitio se divide en dos, una área administrativa y otra para clientes.

Hay por defecto dos cuentas administrativas:
	User: pcgarcia@microsoft.com
	Password: password
	
	User: t-gakles@microsoft.com
	Password: password
	
Se accede al sitio administrativo bajo el path ~/Admin.

Para poder superar el problema de la sesión en Windows Azure, se utiliza el servicio de Cache de la AppFabric para guardar la sesión.


IMPORTANTE1: Si se hace deploy en el IIS, puede ser necesario ir al pool de aplicaciones donde corre la aplicación y dentro de Configuración avanzada->Identidad seleccionar LocalSystem.
IMPORTANTE2: Publicar con la configuración de solución "Local", que utiliza las connectionStrings locales y no las de Azure.

