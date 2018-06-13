var net = require('net');
var client = net.connect({port:8002},
function(){
console.log('Cliente conectado');
client.write("Mundo \r\n");

});

client.on('data',
function(data){
  console.log(data.toString());
  client.end();
});
client.on('end',
function(){
  console.log("Cliente desconectado");
});
