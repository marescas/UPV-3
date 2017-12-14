// Hello World client
// Connects REQ socket to tcp://localhost:5555
// Sends "Hello" to server.

var zmq = require('zmq');
var endpoint = process.argv[2];
var npeticiones = process.argv[3];
var texto = process.argv[4];
// socket to talk to server
if(process.argv.length != 5){
  console.log("Error el uso correcto es node hwclient endpoint npeticiones msg");
  process.exit();
}
console.log("Connecting to hello world server...");
var requester = zmq.socket('req');

var x = 0;
requester.on("message", function(reply) {
  console.log("Received reply", x, ": [", reply.toString(), ']');
  x += 1;
  if (x === npeticiones) {
    requester.close();
    process.exit(0);
  }
});

requester.connect(endpoint);

for (var i = 0; i < npeticiones; i++) {
  console.log("Sending request", i, '...');
  requester.send(texto);
}

process.on('SIGINT', function() {
  //SIGINT --> CTRL+C en terminal
  requester.close();
});
