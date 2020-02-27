version : '3.5'

networks :
  localdev :
      name : localhost
      
      
services :
    // this is a custom name of the service that it can use as next 
    ocelot :        
	   //image is the name of image created when you run > docker build --tag abanoub-labeeb/ocelotmicroservice-ocelot 
	   //name of the image that the docker will make build on 
       //if you did not build an image before , docker will create one with the name  bmwsurveymvc6andcore_ocelot [name of current base folder which contains docker-compose.yml then name of the service ]	   
	   image: docker.elastic.co/apm/apm-server:6.2.4
	   //this is the directory of service web api which contains the docker file that it will use to build 
	   build      : OcelotApiGateway/   
	   restart    : always
       ports      :  
	        //like a custom unique address you give it to the image , 83 custom unique port you give it to the image in that address
            //it must match one of the Specified ports in the Dockerfile for this web api   
	        //docker run -p 8085:80 abanoub-labeeb/ocelotmicroservice-ocelot
            - "44441:83"       			
       depends_on :
            - api-forcast   // if it starts after other services
            - api-predict
       networks :
            - localdev      

    api-forcast :
       build      : MicroServiceWebApi/
       restart    : always
       ports      :  
            - "44442:81"       
       networks :
            - localdev      
           
    api-predict :
       build      : MicroServiceWebApiV2/
       ports      :  
            - "44443:82"       
       networks :
            - localdev                