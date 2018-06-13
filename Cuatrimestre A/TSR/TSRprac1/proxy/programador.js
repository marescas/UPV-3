var net =require('net');
var msg = JSON.stringify(
  {'remote_ip':process.argv[4],'remote_port':process.argv[5]}
);
var progSocket = net.connect({port: process.argv[2], address: process.argv[3]},
  function(){
    progSocket.write(msg);
    progSocket.end();
  });
