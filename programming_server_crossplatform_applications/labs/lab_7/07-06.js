const fs = require('fs');
const http = require('http');

const fileStream = fs.createReadStream('MyFile.png');

const options = {
    hostname: 'localhost',
    port: 3000,
    path: '/upload',
    method: 'POST',
    headers: {
        'Content-Type': 'multipart/form-data',
    }
};

const req = http.request(options, (res) => {
    let data = '';

    res.on('data', (chunk) => {
        data += chunk;
    });

    res.on('end', () => {
        console.log(`Статус ответа: ${res.statusCode}`);
        console.log(`Ответ: ${data}`);
    });
});

req.on('error', (e) => {
    console.error(`Ошибка при отправке запроса: ${e.message}`);
});

fileStream.pipe(req);


const server = http.createServer((req, res) => {
    if (req.url === '/upload' && req.method === 'POST') {
        const fileStream = fs.createWriteStream('MyFile1.png');

        req.on('data', (chunk) => {
            fileStream.write(chunk);
        });

        req.on('end', () => {
            fileStream.end();
            res.writeHead(200, { 'Content-Type': 'text/plain' });
            res.end('All load!');
        });
    } else {
        res.writeHead(404, { 'Content-Type': 'text/plain' });
        res.end('Страница не найдена');
    }
});

server.listen(3000, () => {
    console.log('Сервер запущен по адресу http://localhost:3000');
});
