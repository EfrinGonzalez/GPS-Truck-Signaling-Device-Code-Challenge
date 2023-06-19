This document gives guidance over the from DFDS Interview code challenge v3. 
------------------
NOTES: 

The Data
The folder named data cointains dummy data that is not complete at all. It aims is only to have an object to work agains. 
This should be a call to an API, ideally. The coordinates themselves are also not representative of reality. 

The Utils
The folder containing code snippet utils are completely taken from the internet due to time frame to finish the task. 
Due to this factor, the calculations cannot be claimed to be accurated what so ever. All is an approximation. 

The code Structure
The code design is build with SOLID Principles in mind. In this way we can make a code that is resilient to growth and change. 
Dependency Injection is an important aspect through out the solution. Therefore, the Interfaces are segregated according to the 
needs and injected inside the services that need them. For this you can see the services folder to get an idea. 

The services
There are two services. The Reporting and the Truck Plan. This separation is done in order to have single concerned services. 

The models
Based on the problem description, the domain is build by using the classes inside the models folder. Enums are also provided in order 
to represent some types. In this application the types are not a determinant or a drive to use a factory to construct certain kind of objects. 
In any case, I leave there as part of the process. 

The Implementations
All the specific functionality is inside implementations. That were the business logic and its integrations should happen. 
For instance: 
a) The gathering of information should be an API call to a webservice over the internet, consisting of an integration aspect in the application. 
b) The reporting should happen agains a persistance mechanism, such as a Database. 

------------------

A graphic notion of the application

Nomenclature: 
GPS-TDS: GPS-Truck Signaling Device
TCS: Tracking Central System
TPS: Truck Plan Service (Our problem)



GPS-TDS --> TCS <-- TPS
Sending signals with coordinates --> TCS <-- Receiveing coordinates

In short, the truck sends coordinates to the central service. Our truck system takes from the central service. 

Author: 
Efrin González 