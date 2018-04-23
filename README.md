# miniVueling.Redis
Pequeño proyecto de uso de Redis en Visual (conexión con RedisDocker)

Instal·lem package
	StackExchange.Redis
	StackExchange.Redis.LegacacyConfiguration
		                 .Core        (automàtic)
		                 .StrongName  (automàtic)
	StackExchange.Redis.Newtonsoft

Utilitzem :

        NewtonsoftSerializer serializer = new NewtonsoftSerializer();
        RedisCachingSectionHandler redisConfiguration = RedisCachingSectionHandler.GetConfig();
	StackExchangeRedisCacheClient cacheClient = new StackExchangeRedisCacheClient(serializer, redisConfiguration);

per declarar
el serialitzador de json per poder guardar objectes en format json,
la configuració del redis (RedisCachingSectionHandler.GetConfig) per la qual necessitem afegir la configuració a l'app.config (després ho veiem),
el clientCache del redis (amb el serialitzador i la configuració).

i després utilitzem 

cacheClient.Set<T>(nom_db, T value) o 
cacheClient.Get<T>(nom_db(= key)) 

per guardar o llegir de la db per defecte db_01. Notem que podem utilitzar GetAsync o SetAsync per a guardar i llegir de forma asincrona.


Important, cal afegir a l'app.config 

```
  <configSections>
    <section name="redisCacheClient" type="StackExchange.Redis.Extensions.LegacyConfiguration.RedisCachingSectionHandler, StackExchange.Redis.Extensions.LegacyConfiguration" />
  </configSections>
  
  <redisCacheClient allowAdmin="true" ssl="false" connectTimeout="5000" database="0">
    <hosts>
      <add host="192.168.99.100" cachePort="6379"/>
    </hosts>
  </redisCacheClient>
```
El configSections sempre com a primer bloc dins de la configuració.
Cambiem el host i el port (i més) tal i com els necessitèssim.
