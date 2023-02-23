Multiple startup projects:

CartToCartService.API
NotificationService
UserService.API
WalletService.Console

=======================================================================================================
=======================================================================================================

docker run -d --hostname my-rabbit --name some-rabbit -e RABBITMQ_DEFAULT_USER=sa -e RABBITMQ_DEFAULT_PASS=admin1234 -p 5672:5672 -p 15672:15672 rabbitmq:3-management

==== OR ====


docker run -d --hostname my-rabbit --name some-rabbit -p 5672:5672 -p 15672:15672 rabbitmq:3.8-management

login: guest

=======================================================================================================
=======================================================================================================

rabbitmq terminal: 

rabbitmq-plugins list

=======================================================================================================
=======================================================================================================

rabbitmq terminal: 

rabbitmq-plugins enable --offline 
rabbitmq_management
rabbitmq_mqtt 
rabbitmq_federation_management 
rabbitmq_stomp
rabbitmq_amqp1_0 
rabbitmq_auth_backend_cache       
rabbitmq_auth_backend_http        
rabbitmq_auth_backend_ldap        
rabbitmq_auth_backend_oauth2      
rabbitmq_auth_mechanism_ssl  
rabbitmq_consistent_hash_exchange
rabbitmq_jms_topic_exchange 
rabbitmq_peer_discovery_aws
rabbitmq_peer_discovery_common
rabbitmq_peer_discovery_consul
rabbitmq_peer_discovery_etcd
rabbitmq_peer_discovery_k8s
rabbitmq_random_exchange
rabbitmq_recent_history_exchange
rabbitmq_sharding
rabbitmq_shovel
rabbitmq_shovel_management
rabbitmq_top
rabbitmq_tracing
rabbitmq_trust_store
rabbitmq_web_mqtt
rabbitmq_web_mqtt_examples
rabbitmq_web_stomp
rabbitmq_web_stomp_examples

=======================================================================================================
=======================================================================================================

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=admin1234@" `-p 1430:1433 --name sql2 --hostname sql2` -d ` mcr.microsoft.com/mssql/server:2022-latest

sql server: localhost,1430

=======================================================================================================
=======================================================================================================

connection string: 

Data Source=localhost,1433;Initial Catalog=RabbitMQ_Db;User ID=sa;Password=admin1234@; Integrated Security=True; ApplicationIntent=ReadWrite; MultipleActiveResultSets = True; Trusted_Connection=True;Trusted_Connection=True; TrustServerCertificate=True;

=======================================================================================================
=======================================================================================================

