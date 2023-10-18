var http = require('http');
var fs = require('fs');

http.createServer(function (req, res) {
    fs.readFile('06-02.html', function (err, data) {
        if(err)
        {
            res.writeHead(500, { "Content-Type": "text/plain" });
            res.end("Server Error");
        }
        else
        {
            res.writeHead(200, { "Content-Type": "text/html" });
            res.end(data);
        }
    });

}).listen(5000);

console.log('Server running at http://localhost:5000/html');