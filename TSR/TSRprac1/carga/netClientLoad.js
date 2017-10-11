var net = require('net');

var client = net.connect({port:8001, localAddress:process.argv[3] , host:process.argv[2]},
function(){
console.log('Cliente conectado');
client.write(process.argv[3]); //envia la ip local del cliente por el socket

});

client.on('data',
function(data){
  console.log("Cliente "+data.toString());
  client.end();
});
client.on('end',
function(){
  console.log("Cliente desconectado");
});
