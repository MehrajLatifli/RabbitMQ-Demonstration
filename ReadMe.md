Multiple startup projects:

CartToCartService.API
NotificationService
UserService.API
WalletService.Console

=======================================================================================================
=======================================================================================================

docker run -d --hostname my-rabbit --name some-rabbit -e RABBITMQ_DEFAULT_USER=sa -e RABBITMQ_DEFAULT_PASS=admin1234 -p 5672:5672 -p 15672:15672 rabbitmq:3-management

PS: Not supported in my project.

==== OR ====

docker run -d --hostname my-rabbit --name some-rabbit -p 5672:5672 -p 15672:15672 rabbitmq:3.8-management

login: guest

PS: Supported in my project.

=======================================================================================================
=======================================================================================================

rabbitmq terminal: 

rabbitmq-plugins list

=======================================================================================================
=======================================================================================================

rabbitmq terminal: 

rabbitmq-plugins enable --offline rabbitmq_management rabbitmq_mqtt rabbitmq_federation_management rabbitmq_stomp rabbitmq_amqp1_0 rabbitmq_auth_backend_cache rabbitmq_auth_backend_http     

rabbitmq-plugins enable --offline rabbitmq_auth_backend_ldap rabbitmq_auth_backend_oauth2 rabbitmq_auth_mechanism_ssl rabbitmq_consistent_hash_exchange rabbitmq_jms_topic_exchange 

rabbitmq-plugins enable --offline rabbitmq_peer_discovery_aws rabbitmq_peer_discovery_common rabbitmq_peer_discovery_consul rabbitmq_peer_discovery_etcd rabbitmq_peer_discovery_k8s

rabbitmq-plugins enable --offline rabbitmq_random_exchange rabbitmq_recent_history_exchange rabbitmq_sharding rabbitmq_shovel rabbitmq_shovel_management rabbitmq_top rabbitmq_tracing

rabbitmq-plugins enable --offline rabbitmq_trust_store rabbitmq_web_mqtt rabbitmq_web_mqtt_examples rabbitmq_web_stomp rabbitmq_web_stomp_examples rabbitmq_event_exchange

=======================================================================================================
=======================================================================================================

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=admin1234@" `-p 1430:1433 --name sql2 --hostname sql2` -d ` mcr.microsoft.com/mssql/server:2022-latest

sql server: localhost,1430

PS: Supported in my project.

=======================================================================================================
=======================================================================================================

connection string: 

Data Source=localhost,1430;Initial Catalog=RabbitMQ_Db;User ID=sa;Password=admin1234@;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;

Services: SQL Server Browser -> Start (Running)

PS: Supported in my project.

=======================================================================================================
=======================================================================================================

