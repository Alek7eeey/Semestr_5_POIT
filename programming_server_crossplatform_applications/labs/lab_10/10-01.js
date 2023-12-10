const net= require('net');

let host='127.0.0.1';
let port= 4000;

net.createServer((sock)=>{
    console.log('client connected: ' + sock.remoteAddress+': ' + sock.remotePort);
    sock.on('data',(data)=>{
        console.log('client data: ', sock.remoteAddress+': ' + data.toString());
        sock.write('echo: ' + data);
    });
    sock.on('close',()=>{
        console.log('client exit: ', sock.remoteAddress + '' + sock.remotePort);
    });

}).listen(port,host);

console.log('TCP-server ' + host + ': ' + port);