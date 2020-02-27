install ocelot api gate way 
PM> Install-Package Ocelot -Version 14.0.9

ocelot.json
contains the configuration for each microservice
UpstreamHttpMethod : refine which method we will enable in the api

configure ocelot.json inside 
Program.cs >> CreateHostBuilder
Startup.cs >> ConfigureServices , Configure