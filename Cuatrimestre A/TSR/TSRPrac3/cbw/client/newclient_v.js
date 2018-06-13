// newclient_v in NodeJS, implicit verbose activation mode
//  - v stands for verbose mode
// classID must be provided as a parameter
// CMD node myclient $BROKER_URL $CLASSID $LOGGER_URL

var zmq = require('zmq')
, requester = zmq.socket('req')
, util = require('util');

var nMsgs=10;
var args = process.argv.slice(2);
var loggerURL = args.pop();
var log       = zmq.socket('push');
var diag;
var classID = args.pop();  // rest of argument processing will follow

var brokerURL = args[0] || 'tcp://localhost:8059';
var myID = args[1] || 'NONE';
var myMsg = args[2] || 'Hello';

if (myID != 'NONE')
  requester.identity = myID;
requester.connect(brokerURL);
log.connect(loggerURL);
diag = util.format('Client (%s) with class "%s" connected to %s', myID, classID, brokerURL);
log.send(diag);

requester.on('message', function(msg) {
  diag = util.format('Client (%s) has received reply "%s"', myID, msg.toString());
  log.send(diag);
  if (--nMsgs == 0)
    process.exit(0);
  else
    requester.send([myMsg,classID]);
});
diag = util.format('Client (%s) sending request "%s" of class "%s"', myID, myMsg, classID);
log.send(diag);

requester.send([myMsg,classID]);
