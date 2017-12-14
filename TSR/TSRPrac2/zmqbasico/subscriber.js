var zmq = require('zmq')

var subscriber = zmq.socket('sub');
endpoint = process.argv[2];
descriptor = process.argv[3];

subscriber.on("message", function(reply) {
  console.log('Received message: ', reply.toString());
})

subscriber.connect(endpoint);
subscriber.subscribe(descriptor);

process.on('SIGINT', function() {
  subscriber.close()
  console.log('\nClosed')
})
