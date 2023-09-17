var http = require("http");
var url = require("url");

function factorial(num) {
    if (num === 0) {
        return 1;
    }
    return num * factorial(num - 1);
}

http.createServer(function (req, res){
    if(req.url.startsWith("/fact") && req.method === "GET"){
        var queryData = url.parse(req.url, true).query;
        var k = parseInt(queryData.k);

        if (isNaN(k)) {
            res.writeHead(400, { "Content-Type": "text/plain" });
            res.end("Invalid parameter");
        } else {
            var fact = factorial(k);
            var responseJson = JSON.stringify({ k: k, fact: fact });

            res.writeHead(200, { "Content-Type": "application/json" });
            res.end(responseJson);
        }
    }
    else {
        res.writeHead(404, { "Content-Type": "text/plain" });
        res.end("Page not found");
    }
}).listen(5000);

console.log('Server running at http://localhost:5000');