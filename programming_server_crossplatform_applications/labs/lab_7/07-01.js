const http = require('http');

const options = {
    host: 'localhost',
    port: 3000,
    path: '/ex1',
    method: 'GET'
};

const req = http.request(options, (res) => {
    console.log(`Статус ответа: ${res.statusCode}`);
    console.log(`Сообщение к статусу ответа: ${res.statusMessage}`);
    console.log(`IP-адрес удаленного сервера: ${res.socket.remoteAddress}`);
    console.log(`Порт удаленного сервера: ${res.socket.remotePort}`);
});

req.on('error', (e) => {
    console.error(`Ошибка при отправке запроса: ${e.message}`);
});

req.end();

//our server
const server = http.createServer((req, res) => {
    if (req.url === '/ex1' && req.method === 'GET') {
        res.writeHead(200, { 'Content-Type': 'text/plain' });
        res.end('Пример ответа сервера');
    } else {
        res.writeHead(404, { 'Content-Type': 'text/plain' });
        res.end('Страница не найдена');
    }
}).listen(3000);





