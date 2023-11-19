const httserver = require('http')
    .createServer((req, res)=>{
   if(req.method === 'GET' && req.url === '/start')
   {
       res.writeHead(200, {'Content-Type':'text/html; charset=utf-8'});
       res.end(require('fs').readFileSync('./08-01.html'));
   }
});

httserver.listen(3000);
console.log('ws server: 3000');

let k = 0;
let mes = '';
const WebSocket = require('ws');
const wsserver = new WebSocket.Server({port: 4000, host:'localhost', path:'/wsserver'});

wsserver.on('connection', (ws)=>{
    ws.on('message', message => {
        console.log(`Received message => ${message}`);
        mes = message;
    });
    setInterval(()=>{ws.send('08-01-server:' + mes + '->' + ++k)}, 3000);
});

wsserver.on('error', (e)=>{console.log('ws server error', e)});
console.log(`ws server: host: ${wsserver.options.host}, port:${wsserver.options.port}, path:${wsserver.options.path}`);