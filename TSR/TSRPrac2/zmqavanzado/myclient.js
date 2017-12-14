var zmq = require("zeromq");
var requester = zmq.socket('req');
var args = process.argv.slice(2);
var myBrokerURL = args[0] || 'tcp://localhost:8059';
var myID = args[1] || 'NONE';
var myMSG = args[2] || 'Hello';
if(myID != 'NONE') requester.identity = myID;
requester.connect(myBrokerURL);
console.log("Cliente %s conectado a %s",myID, myBrokerURL);
requester.on("message",function(msg){
    console.log('Client (%s) has received reply "%s"', myID, msg.toString()); 
    process.exit(0);
});
requester.send(myMSG);
console.log('Client (%s) has sent its message: "%s"', myID, myMSG); 