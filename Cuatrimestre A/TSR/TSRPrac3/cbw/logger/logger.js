// logger in NodeJS
// First argument is port number for incoming messages
// Second argument is file path for appending log entries

var fs = require('fs');
var zmq = require('zmq')
,   log = zmq.socket('pull')
,   args = process.argv.slice(2);

var loggerPort = args[0] || '8066';
var filename = args[1] || "/tmp/cbwlog.txt";

log.bindSync('tcp://*:'+loggerPort);

log.on('message', function(text) {
  fs.appendFileSync(filename, text+'\n');
})
