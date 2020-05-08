# Werewolf Online

This repo helps with playing the Werewolf game with players playing the game remotely. 
The program automatically assigns different players with a role in the game and notifies the players through a Whatsapp message. 

## Requirements
.NetCore
Rabbitmq
- Create a queue named werewolfqueue. (Optional) Rabbitmq management extension
Nodejs  
 - Repo does not contain a package.json. The node script requires the RabbitMq and Twilio node package. Run the following commands
 ``` js
 npm install amqplib
 npm install twilio
```
Twilio Account
- Notification is done using the Twilio whatsapp feature. Update publisher.js script with Twilio credentials. 

## Usage

Update the .\Config\prod-config.json with the Player name and contact number 

Run the GameNight.exe . 

Use the following commands

```
shuffle # Shuffles the roles assigned to players

display # Lists the roles assigned to each players

notify # Notifies the player about the role
```


## Questions 

Q . What was the game set up like ? 
A : All the participants joined a Zoom meeting. The moderator would run the program.
    A day lasted 5 minutes, after which the moderator would post a poll. Player with the most votes is eliminated. If there is a tie, Repoll.
    A night lasted 2 minute, the moderator manually assigns the players to breakout rooms . Each player is placed in individual breakout rooms, if there are multiple werewolfs place them together in the same room.
    The player chosen to be eliminated is brought to the werewolf room . Moderator goes to the seer room and other roles if required. Night ends when the breakout room closes. 

Q: How to add/remove roles ? 
A: Make changes to the RoleFactory.cs file and rebuild the project. 

Q: Why Rabbitmq and Nodejs ? 
A : Pet project. 
    
