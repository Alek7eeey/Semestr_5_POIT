const net = require('net');

const ports = [40000, 50000];

const servers = ports.map(port => {
    const server = net.createServer();
    let sum = 0;

    server.on('connection', (sock) => {
        console.log(`Server connected: ${sock.remoteAddress}:${sock.remotePort} on port ${port}`);

        sock.on('data', (data) => {
            const number = data.readInt32LE();
            sum += number;
            console.log(`Received number ${number}. Current sum: ${sum}`);
        });

        setInterval(() => {
            const buf = Buffer.alloc(4);
            buf.writeInt32LE(sum, 0);
            sock.write(buf);
        }, 5000);

        sock.on('close', () => {
            console.log(`Server closed: ${sock.remoteAddress} ${sock.remotePort} on port ${port}`);
        });

        sock.on('error', (e) => {
            console.log(`Server error: ${sock.remoteAddress} ${sock.remotePort} on port ${port}: ${e.message}`);
        });
    });

    server.on('listening', () => {
        console.log(`TCP-server listening on port ${port}`);
    });

    server.on('error', (e) => {
        console.log(`TCP-server error on port ${port}: ${e.message}`);
    });

    server.listen(port, '127.0.0.1');
    return server;
});

