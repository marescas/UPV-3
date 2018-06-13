var zmq = require('zmq')
var aux = require("./auxfunctions1718.js");
var publisher = zmq.socket('pub')
var puerto = process.argv[2];
var nmensajes = process.argv[3];
var tipos = process.argv.splice(4);


publisher.bind('tcp://*:'+puerto, function(err) {
  if(err)
    console.log(err)
  else
    console.log("Listening on 8688...")
})

for (var i=1 ; i<nmensajes ; i++)
    setTimeout(function() {
        console.log('sent');
        for(var j = 0; j<tipos.length;j++)
        publisher.send([tipos[j]," Hello there!"+aux.randNumber(nmensajes)]);

    }, 1000 * i);

process.on('SIGINT', function() {
  publisher.close()
  console.log('\nClosed')
})
