var net = require('net');
// 2 ADDRESS_PROXY 
// 3 PORT_PROXY
// 4 REMOTE_IP
// 5 REMOTE_PORT
var msg = JSON.stringify(
  {'op':"set",
   'inPort':process.argv[3],
   'remote':{'ip':String(process.argv[4]), 'port':process.argv[5]}}
);
var controladorSocket = net.connect({port:8000,address:process.argv[2]},
  function(){
    controladorSocket.write(msg);
    controladorSocket.end();
  })
