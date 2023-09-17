var http = require("http");
var fs = require("fs");
var readline = require("readline");

const arrStates = ["norm", "stop", "test", "idle"];
class State{
    constructor(st){
        this.state = st;
    }

    getElement(st){
        if(arrStates.includes(st))
        {
            return this.state;
        }
        else {
            return null;
        }
    }
}

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

var actualState = new State("norm");

http.createServer(function (req, res){
    fs.readFile("03-01.html", function (err, data){
        if(err)
        {
            res.writeHead(500, { "Content-Type": "text/plain" });
            res.end("Server Error");
        }
        else
        {
            res.writeHead(200, { "Content-Type": "text/html" });
            res.end("State: " + actualState.state);
        }
    })
}).listen(5000);

console.log('Server running at http://localhost:5000');
console.log('State: ' + actualState.state);

rl.on('line', function(newState) {

    if(newState === "end"){
        process.exit(0);
    }

    if(actualState.getElement(newState) !== null)
    {
        actualState.state = newState;
        console.log('State: ' + actualState.state);
    }
    else {
        console.log("Incorrect state: " + newState);
    }
});