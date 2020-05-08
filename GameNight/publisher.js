#!/usr/bin/env node

const accountSid = '<<AccountSIDgoeshere>>';
const authToken = '<<YourAuthTokenGoeshere>>';
const fromNumber = "whatsapp:<<PhoneNumberGoeshere>>"
var amqp = require('amqplib/callback_api');
var twilio = require('twilio')(accountSid, authToken);

amqp.connect('amqp://localhost', function(error0, connection) {
    if (error0) {
        throw error0;
    }
    connection.createChannel(function(error1, channel) {
        if (error1) {
            throw error1;
        }

        var queue = 'werewolfqueue';

        channel.assertQueue(queue, {
            durable: true
        });

        console.log(" [*] Waiting for messages in %s. To exit press CTRL+C", queue);

        channel.consume(queue, function(msg) {
            //console.log(" [x] Received %s", msg.content.toString());
            var msgDTO = JSON.parse(msg.content.toString());
            if(msgDTO.Contact != null)
            {
                var playerContact = "whatsapp:+"+ msgDTO.Contact;
                console.log("Sending message to "+ playerContact);

                twilio.messages.create({
                    from: fromNumber,
                    body: msgDTO.Message,
                    to: playerContact
                }).then(message => console.log(message.sid));
            }

        }, {
            noAck: true
        });
    });
});