// newworker_v server in NodeJS,  implicit verbose activation mode
//  - v stands for verbose mode
// classID must be provided as a parameter
// CMD node myworker $BROKER_URL $CLASSID $LOGGER_URL

var zmq = require('zmq')
, requester = zmq.socket('req')
, util = require('util');

var nMsgs=10;
var args = process.argv.slice(2);
var loggerURL = args.pop();
var log       = zmq.socket('push');
var diag;
var classID = args.pop();  // rest of argument processing will follow

var backendURL = args[0] || 'tcp://localhost:8060';
var myID = args[1] || 'NONE';
var connText = args[2] || 'id';
var replyText = args[3] || 'World';

if (myID != 'NONE')
  requester.identity = myID;
requester.connect(backendURL);
log.connect(loggerURL);
diag = util.format('Worker (%s) with class "%s" connected to %s', myID, classID, backendURL);
log.send(diag);

requester.on('message', function(client, delimiter, msg) {
  diag = util.format('Worker (%s) has received request "%s" from client "%s"', myID, msg.toString(), client);
  log.send(diag);
  setTimeout(function() {
    diag = util.format('Worker (%s) sending "%s" back to broker for client "%s"', myID, replyText, client);
      log.send(diag);
      requester.send([client,'',replyText, classID]);
  }, 1000);
});
diag = util.format('Worker (%s) communicating availability for class "%s"', myID, classID);
log.send(diag);

requester.send([connText,classID]);
