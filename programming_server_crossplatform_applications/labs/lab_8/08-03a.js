const WebSocket = require('ws');

const ws = new WebSocket('ws://localhost:4000');

let parm = process.argv[2];
let prfx = typeof parm == 'undefined'?'A':parm;

ws.on('open', () => {
    console.log('Connected to WebSocket server');

    // Пример отправки сообщения от клиента
    ws.send('Hello, WebSocket server from '+prfx+'!');
});

ws.on('message', (message) => {
    console.log(`Received from server: ${message}`);
});

ws.on('close', () => {
    console.log('Disconnected from WebSocket server');
});
