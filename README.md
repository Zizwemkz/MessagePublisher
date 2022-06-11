# MessagePublisher
The is a console app that publish message events from rabbitmq.


## The project

This project consists of one-project :
- **MessagePublisher**: a console project containing a class and logic to type our message and also classes with the rules for sending and publish the message.
- **MessagePublisher.Models**: 
        - **MessageEvent**: a class model that will be stored and send to rabbitMQ.
- **MessagePublisher.publisher**: 
        - **MessagePublisher**: This class service has a logic of configuring and sending the event sender to rabbitmq.