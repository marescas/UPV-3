// ROUTER-ROUTER request-reply broker in NodeJS.
// Work classes. Logger variant
// Worker availability-aware variant.
//
// As code grows, complexity increases. This version returns to the
// original structure with auxiliar functions (sendToWorker & sendRequest)

var zmq      = require('zmq')
, frontend = zmq.socket('router')
, backend  = zmq.socket('router')
, util = require('util');

var args = process.argv.slice(2);
var loggerURL = args[args.length-1];
var log       = zmq.socket('push');
args.pop(); // rest of argument processing will follow
var diag;

var fePortNbr = args[0] || 8059;
var bePortNbr = args[1] || 8060;
var workers = [];
var clients = [];

const classIDs = ['A','B','C','D'] // Do we really need this limitation?
for (var i in classIDs) {
  workers[classIDs[i]]=[];
  clients[classIDs[i]]=[];
}

const answerInterval = 2000;
var busyWorkers = [];

function showMessage(t, action, contents) { // adapted from auxfunctions
 log.send(util.format('Broker (%s) %s this message:', t, action));
 var msg = Array.apply(null, contents);
  msg.forEach( (value,index) => {
     log.send(util.format('     Segment %d: %s', index, value));
  })
}
   
frontend.bindSync('tcp://*:'+fePortNbr);
backend.bindSync('tcp://*:'+bePortNbr);
log.connect(loggerURL);
diag = util.format('Broker listening on fePort %d and bePort %d', fePortNbr, bePortNbr);
log.send(diag);

// Send a message to a worker.
function sendToWorker(msg, classID) {
  var myWorker = msg[0];
diag = util.format('Broker passing client (%s) request to queued worker (%s) through backend.', msg[2], msg[0]);
log.send(diag);
showMessage('be', 'sending', msg);
  backend.send(msg);
  busyWorkers[myWorker] = {};
  busyWorkers[myWorker].classID = classID;
  busyWorkers[myWorker].msg = msg.slice(2);
  busyWorkers[myWorker].timeout =
    setTimeout(generateTimeoutHandler(myWorker),answerInterval);
}

// Function that sends a message to a worker, or
// holds the message if no worker is available now.
// Parameter 'args' is an array of message segments.
function sendRequest(args, classID) {
  if (workers[classID].length > 0) {
    var myWorker = workers[classID].shift();
    var m = [myWorker,''].concat(args);
    sendToWorker(m, classID);
  } else {
diag = util.format('Broker queueing client (%s) (cl%s queue length: %d).', args[0], classID, clients[classID].length+1);
log.send(diag);
    clients[classID].push( {id: args[0],msg: args.slice(2)});
  }
}

function generateTimeoutHandler(workerID) {
diag = util.format('Broker "installing" function for handling worker (%s) timeout.', workerID);
log.send(diag);
  return function() {
diag = util.format('Broker "running" function for worker (%s) timeout. busyWorkers.length=%d', workerID, busyWorkers.length);
log.send(diag);
    var msg = busyWorkers[workerID].msg;
    var classID = busyWorkers[workerID].classID;
  delete busyWorkers[workerID];
    sendRequest(msg, classID);
  }
}

frontend.on('message', function() {
  var args = Array.apply(null, arguments);
  var classID = args.pop();
showMessage('fe', 'receiving', arguments);
diag = util.format('Broker receiving frontend request: "%s" from client (%s) with class "%s".', args[2], args[0], classID);
log.send(diag);
  sendRequest(args, classID);
});

function processPendingClient(workerID, classID) {
  if (clients[classID].length>0) {
    var nextClient = clients[classID].shift();
    var msg = [workerID,'',nextClient.id,''].concat(nextClient.msg);
        sendToWorker(msg, classID);
    return true;
  } else
    return false;
}

backend.on('message', function() {
showMessage('be', 'receiving', arguments);
  var args = Array.apply(null, arguments);
  var classID = args.pop();
  if (args.length == 3) {
diag = util.format('Broker receiving backend request: "%s" from worker (%s) with class "%s".', args[2], args[0], classID);
log.send(diag);
    if (!processPendingClient(args[0],classID)) {      
diag = util.format('Broker queueing worker (%s) (wk%s queue length: %d).', args[0], classID, workers[classID].length+1);
log.send(diag);
         workers[classID].push(args[0]);
    }
  } else {
    var workerID = args[0];
diag = util.format('Broker receiving reply: "%s" from worker (%s)', args[4], workerID);
log.send(diag);
      clearTimeout(busyWorkers[workerID].timeout);
    args = args.slice(2);
diag = util.format('Broker passing worker (%s) reply to client (%s) through frontend.', workerID, args[0]);
log.send(diag);
showMessage('fe', 'sending', args);
    frontend.send(args);
    if (!processPendingClient(workerID,classID)) {
diag = util.format('Broker queueing worker (%s) (wk%s queue length: %d).', args[0], classID, workers[classID].length+1);
log.send(diag);
         workers[classID].push(workerID);
    }
  }
});
