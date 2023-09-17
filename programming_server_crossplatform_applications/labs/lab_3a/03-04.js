var http = require("http");
var url = require("url");
var fs = require("fs");

function factorial(num, callback) {
    process.nextTick(function() {
        if (num < 0) {
            callback(new Error("Факториал не определен для отрицательных чисел"));
            return;
        }

        let result = 1;

        function calculate(i) {
            if (i > num) {
                callback(null, result);
                return;
            }

            result *= i;
            process.nextTick(calculate.bind(null, i + 1));
        }

        calculate(2);
    });
}


http.createServer(function (req, res){

    if(req.url === "/" && req.method === "GET"){

        fs.stat("03-02_2.html",(err,stats)=>{
            if(err)
            {
                res.writeHead(500, { "Content-Type": "text/plain" });
                res.end("Server Error");
            }
            else
            {
                res.writeHead(200, { "Content-Type": "text/html" });
                let result = fs.readFileSync("03-02_2.html");
                res.end(result);
            }
        })
    }
    else if(req.url.startsWith("/fact") && req.method === "GET"){
        var queryData = url.parse(req.url, true).query;
        var k = parseInt(queryData.k);

        if (isNaN(k)) {
            res.writeHead(400, { "Content-Type": "text/plain" });
            res.end("Invalid parameter");
        } else {
            factorial(k, function(err, result) {
                if (err) {
                    res.writeHead(500, { "Content-Type": "text/plain" });
                    res.end("Server Error");
                    return;
                }

                var fact = parseInt(result);

                var responseJson = JSON.stringify({ k: k, fact: fact });

                res.writeHead(200, { "Content-Type": "application/json" });
                res.end(responseJson);
            });
        }
    }
    else {
        res.writeHead(404, { "Content-Type": "text/plain" });
        res.end("Page not found");
    }
}).listen(5000);

console.log('Server running at http://localhost:5000/fact');