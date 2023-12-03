const dgram = require('dgram');

const udpServer = dgram.createSocket('udp4');

const PORT = 3000; // Выберите порт по вашему усмотрению

udpServer.on('message', (msg, rinfo) => {
    const message = `ECHO: ${msg}`;
    udpServer.send(message, rinfo.port, rinfo.address, (err) => {
        if (err) {
            console.error(`Error sending response to ${rinfo.address}:${rinfo.port}: ${err.message}`);
        } else {
            console.log(`Response sent to ${rinfo.address}:${rinfo.port}: ${message}`);
        }
    });
});

udpServer.on('listening', () => {
    const address = udpServer.address();
    console.log(`UDP server listening on ${address.address}:${address.port}`);
});

udpServer.on('error', (err) => {
    console.error(`UDP server error: ${err.message}`);
});

udpServer.bind(PORT);