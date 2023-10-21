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

//ex1
//console.log('Server running at http://localhost:5000/connection?set=4');
//ex2
//console.log('Server running at http://localhost:5000/headers');
//ex3
//console.log('Server running at http://localhost:5000/parameter?x=15&y=3');
//ex4
//console.log('Server running at http://localhost:5000/parameter/15/6');
//ex5
//console.log('Server running at http://localhost:5000/socket');
//ex6
//console.log('Server running at http://localhost:5000/resp-status?code=222&mess=dfgfdglf');
//ex7
//console.log('Server running at http://localhost:5000/formparameter');
//ex8
//console.log('Server running at http://localhost:5000/json');
//ex9
//console.log('Server running at http://localhost:5000/xml');
//ex10
//console.log('Server running at http://localhost:5000/files');
//ex11
//console.log('Server running at http://localhost:5000/files/file12.txt');
//ex12
//console.log('Server running at http://localhost:5000/upload');