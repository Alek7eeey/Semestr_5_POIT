const http = require('http');
const query = require('querystring');

let params =  query.stringify({x:3, y:4});
let path = `/ex2?${params}`;

let options =
    {
        host: 'localhost',
        path: path,
        port: 3000,
        method: 'GET'
    };

const req = http.request(options, (res)=>{

    console.log('params', params);
    console.log('path', path);
    console.log(`Статус ответа: ${res.statusCode}`);
    console.log(`Сообщение к статусу ответа: ${res.statusMessage}`);

    let data = '';
    res.on('data', (chunk)=>{
        console.log('http.request: data:body = ', data += chunk.toString());
    });

    res.on('end', ()=>{
        console.log('http.request: end: body =', data);
    });
});

req.on('error', (e) => {
    console.error(`Ошибка при отправке запроса: ${e.message}`);
});

req.end();

//our server
const server = http.createServer((req, res) => {
    if (req.url.startsWith('/ex2') && req.method === 'GET') {
        const params = req.url.split('?')[1];
        const parsedParams = query.parse(params);
        res.writeHead(200, { 'Content-Type': 'text/plain' });
        res.end(`Пример ответа сервера. Параметры: ${JSON.stringify(parsedParams)}`);
    } else {
        res.writeHead(404, { 'Content-Type': 'text/plain' });
        res.end('Страница не найдена');
    }
}).listen(3000);

console.log(`Сервер запущен по адресу http://localhost:3000`);