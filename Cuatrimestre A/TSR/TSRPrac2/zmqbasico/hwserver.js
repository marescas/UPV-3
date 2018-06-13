 // Hello World server
// Binds REP socket to tcp://*:5555
// Expects "Hello" from client, replies with "world"



// Cuando se ha enviado un mensaje a través de un socket req,
// otro envío posterior por ese socket será encolado localmente
// Hasta que el mensaje de respuesta sea recibido

var zmq = require('zmq');

// socket to talk to clients
var responder = zmq.socket('rep');
var port = process.argv[2];
var seg = process.argv[3];
var msg = process.argv[4];
if(process.argv.length != 5){
  console.log("Error el uso correcto es node hwserver port segundos msg");
    process.exit();
}
responder.on('message', function(request) {
  console.log("Received request: [", request.toString(), "]");

  // do some 'work'
  setTimeout(function() {

    // send reply back to client.
    responder.send(request +" "+msg);
  }, seg*1000);
});

responder.bind('tcp://*:'+port, function(err) {
  if (err) {
    console.log(err);
  } else {
    console.log("Listening on 5555...");
  }
});

process.on('SIGINT', function() {
  responder.close();
});
