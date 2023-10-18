const http = require('http');
const fs = require('fs');
const controller = require('./controller')

http.createServer(function (req, res)
{
    if(req.method==="GET")
    {
        controller.getReq(req, res);
    }

    if(req.method === 'POST')
    {
        controller.postReq(req, res);
    }
}).listen(5000);

console.log('Server running at http://localhost:5000/upload');