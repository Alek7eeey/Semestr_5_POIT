// 06-03.js
const { send } = require('./m06_KAD/m06_KAD_local');
const http = require('http');
const fs = require('fs');

http.createServer(function (req, res){

    if(req.url==="/" && req.method==="GET")
    {
        fs.readFile("06-02.html", function (err, data) {
            if (err) {
                res.writeHead(500, { "Content-Type": "text/plain" });
                res.end("Server Error");
            } else {
                res.writeHead(200, { "Content-Type": "text/html" });
                res.end(data);
            }
        })
    }

    if(req.url==="/send" && req.method==='POST')
    {
        let body = '';
        req.on('data', chunk => {
            body += chunk.toString();
        });

        req.on('end', async () => {
            const data = JSON.parse(body);
            const messageToSend = data.message;
            const email = data.mail;

            const senderEmail = 'TaskWave@outlook.com';
            const password = '********';
            const recipientEmail = email;
            const message = messageToSend;
            const result = send(senderEmail, password, message, recipientEmail);
            console.log('Результат отправки:', result);

            res.writeHead(200, { "Content-Type": "application/json" });
            res.end(JSON.stringify(result));
        });
    }

}).listen(5000);

console.log('http://localhost:5000');


