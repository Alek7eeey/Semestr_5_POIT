const dgram = require('dgram');

const client = dgram.createSocket('udp4');

const SERVER_PORT = 3000; // Порт сервера, на котором запущен UDP-сервер

const message = 'Hello!';

client.send(message, SERVER_PORT, '127.0.0.1', (err) => {
    if (err) {
        console.error(`Error sending message to server: ${err.message}`);
    } else {
        console.log(`Message sent to server: ${message}`);
    }
});

client.on('message', (msg) => {
    console.log(`Received from server: ${msg}`);
    client.close();
});

client.on('error', (err) => {
    console.error(`UDP client error: ${err.message}`);
});
