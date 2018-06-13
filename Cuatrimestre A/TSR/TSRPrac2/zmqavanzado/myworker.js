var zmq  = require("zeromq");
var responder = zmq.socket('req');
var args = process.argv.slice(2);
var backendURL = args[0] || 'tcp://localhost:8060';
var myID = args[1] ||'NONE';
var connText = args[2] || 'id';
var repyText = args[3] || 'World';
if(myID != 'NONE') responder.identity = myID;
responder.connect(backendURL);
responder.on("message",function(client,delimite,msg){
setTimeout(function(){
    responder.send([client,"",repyText]);
},1000)

});
responder.send(connText);