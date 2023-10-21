const http = require('http');

let params = JSON.stringify({_comment: 'Lab_7', x:1, y:2, s:"message", m: ["a", "b", "c"], o: {surname: "Kravchenko", name: "Aleksey"}});

let options = {
    host: 'localhost',
    path: '/ex4',
    port: 3000,
    method: 'POST',
    headers: {
        'Content-Type': 'application/json', 'accept': 'application/json'
    }
};

const req = http.request(options, (res) => {
    console.log(`Статус ответа: ${res.statusCode}`);
    console.log(`Сообщение к статусу ответа: ${res.statusMessage}`);

    let data = '';
    res.on('data', (chunk) => {
        data += chunk.toString();
    });

    res.on('end', () => {
        console.log('http.response: end: body = ', data);
        console.log('http.response: end: parse(body) = ', JSON.parse(data));
    });
});

req.on('error', (e) => {
    console.log('http.request: error:', e.message);
});

req.write(params);
req.end();

//our server
const server = http.createServer((req, res) => {
    if (req.url.startsWith('/ex4') && req.method === 'POST') {

        let body = '';
        req.on('data', chunk => {
            body += chunk;
        });

        req.on('end', () => {
            const requestData = JSON.parse(body);
            const comment = requestData._comment;
            const x = Number.parseInt(requestData.x);
            const y = Number.parseInt(requestData.y);
            const s = requestData.s;
            const o = requestData.o;
            const m = requestData.m;

            res.writeHead(200, { 'Content-Type': 'text/plain' });
            const response = {
                "__comment": "Ответ: " + comment,
                "x:" : x,
                "y:" : y,
                "x_plus_y": x + y,
                "Concatination_s_o": s +": "+ o.name,
                "Length_m": m.length
            };

            res.end(JSON.stringify(response));
        });
    } else {
        res.writeHead(404, { 'Content-Type': 'text/plain' });
        res.end('Страница не найдена');
    }
}).listen(3000);

console.log('Сервер запущен по адресу http://localhost:3000');