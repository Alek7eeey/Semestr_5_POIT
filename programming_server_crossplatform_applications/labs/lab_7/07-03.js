const http = require('http');
const query = require('querystring');

let params = query.stringify({x: 3, y: 4, s: 'xxx'});
console.log('params', params);

let options = {
    host: 'localhost',
    path: '/ex3',
    port: 3000,
    method: 'POST',
    headers: {
        'Content-Type': 'application/x-www-form-urlencoded',
        'Content-Length': Buffer.byteLength(params)
    }
};

const req = http.request(options, (res) => {
    console.log(`Статус ответа: ${res.statusCode}`);
    console.log(`Сообщение к статусу ответа: ${res.statusMessage}`);

    let data = '';
    res.on('data', (chunk) => {
        console.log('http.request: data: body = ', data += chunk.toString());
    });

    res.on('end', () => {
        console.log('http.request: end: body = ', data);
    });
});

req.on('error', (e) => {
    console.log('http.request: error:', e.message);
});

req.write(params);
req.end();

//our server
const server = http.createServer((req, res) => {
    if (req.url.startsWith('/ex3') && req.method === 'POST') {

        let body = '';
        req.on('data', chunk => {
            body += chunk.toString();
        });

        req.on('end', () => {
            const requestData = query.parse(body);
            res.writeHead(200, { 'Content-Type': 'text/plain' });
            res.end(`Пример ответа сервера. Параметры: ${requestData.x}, ${requestData.y}, ${requestData.s}`);
        });
    } else {
        res.writeHead(404, { 'Content-Type': 'text/plain' });
        res.end('Страница не найдена');
    }
}).listen(3000);

console.log('Сервер запущен по адресу http://localhost:3000');