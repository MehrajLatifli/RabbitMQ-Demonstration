Multiple startup projects:

CartToCartService.API
NotificationService
UserService.API
WalletService.Console

<p>================================================================</p>
<p>================================================================</p>

docker run -d --hostname my-rabbit --name some-rabbit -e RABBITMQ_DEFAULT_USER=sa -e RABBITMQ_DEFAULT_PASS=admin1234 -p 5672:5672 -p 15672:15672 rabbitmq:3-management

PS: Not supported in my project.

<p>==== OR ====</p>

docker run -d --hostname my-rabbit --name some-rabbit -p 5672:5672 -p 15672:15672 rabbitmq:3.8-management

login: guest

PS: Supported in my project.

<p>================================================================</p>
<p>================================================================</p>

rabbitmq terminal: 

rabbitmq-plugins list

<p>================================================================</p>
<p>================================================================</p>

rabbitmq terminal: 

rabbitmq-plugins enable  rabbitmq_management 
rabbitmq-plugins enable rabbitmq_mqtt 
rabbitmq-plugins enable rabbitmq_federation_management 
rabbitmq-plugins enable rabbitmq_stomp 
rabbitmq-plugins enable rabbitmq_amqp1_0 
rabbitmq-plugins enable rabbitmq_auth_backend_cache 
rabbitmq-plugins enable rabbitmq_auth_backend_http     

rabbitmq-plugins enable  rabbitmq_auth_backend_ldap 
rabbitmq-plugins enable rabbitmq_auth_backend_oauth2 
rabbitmq-plugins enable rabbitmq_auth_mechanism_ssl 
rabbitmq-plugins enable rabbitmq_consistent_hash_exchange 
rabbitmq-plugins enable rabbitmq_jms_topic_exchange 

rabbitmq-plugins enable  rabbitmq_peer_discovery_aws 
rabbitmq-plugins enable rabbitmq_peer_discovery_common 
rabbitmq-plugins enable rabbitmq_peer_discovery_consul 
rabbitmq-plugins enable rabbitmq_peer_discovery_etcd 
rabbitmq-plugins enable rabbitmq_peer_discovery_k8s

rabbitmq-plugins enable  rabbitmq_random_exchange 
rabbitmq-plugins enable rabbitmq_recent_history_exchange 
rabbitmq-plugins enable rabbitmq_sharding 
rabbitmq-plugins enable rabbitmq_shovel 
rabbitmq-plugins enable rabbitmq_shovel_management 
rabbitmq-plugins enable rabbitmq_top rabbitmq_tracing

rabbitmq-plugins enable  rabbitmq_trust_store 
rabbitmq-plugins enable rabbitmq_web_mqtt 
rabbitmq-plugins enable rabbitmq_web_mqtt_examples 
rabbitmq-plugins enable rabbitmq_web_stomp 
rabbitmq-plugins enable rabbitmq_web_stomp_examples 
rabbitmq-plugins enable rabbitmq_event_exchange

<p>================================================================</p>
<p>================================================================</p>

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=admin1234@" `-p 1430:1433 --name sql2 --hostname sql2` -d ` mcr.microsoft.com/mssql/server:2022-latest

sql server: localhost,1430

PS: Supported in my project.

<p>================================================================</p>
<p>================================================================</p>

connection string: 

Data Source=localhost,1430;Initial Catalog=RabbitMQ_Db;User ID=sa;Password=admin1234@;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;

Services: SQL Server Browser -> Start (Running)

PS: Supported in my project.

<p>================================================================</p>
<p>================================================================</p>

