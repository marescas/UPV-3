var net = require('net');
var LOCAL_PORT = 8002;
var LOCAL_IP = '127.0.0.1';
var REMOTE_PORT = 80;
var REMOTE_IP = '158.42.4.23'; //direccion de la upv
//Creamos el servidor Proxy,
//cuando un cliente se ponga en contacto con el proxy, este lanza el evento sCliente.on('data')
// Cuando el servidor responde se lanza el evento sServidor.on('data')
var server = net.createServer(function(socketCliente){
  var socketServidor =new net.Socket();
  socketServidor.connect(parseInt(REMOTE_PORT),REMOTE_IP,function(){
    //Cuando el socket Cliente recibe datos los encamina por el socket servidor
    socketCliente.on('data',function(msg){
      socketServidor.write(msg);
    });
    //cuando el socketServidor recibe datos los encamina hacia el socket cliente
  socketServidor.on('data',function(msg){
    socketCliente.write(msg);
  });

});

}).listen(LOCAL_PORT,LOCAL_IP);
console.log("Servidor TCP funcionando en el puerto"+ LOCAL_PORT);
