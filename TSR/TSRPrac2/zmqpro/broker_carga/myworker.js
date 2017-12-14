var zmq  = require("zmq");
var aux = require("./auxfunctions1718.js");
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
    var load = aux.getLoad();
    responder.send([client,"",repyText,load]);
},1000)

});
var load = aux.getLoad();
responder.send([connText,load]); //cuando el borker se conecta envia un mensaje para notificar que se ha conectado