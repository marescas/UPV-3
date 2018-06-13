var net = require('net');
var servers = {};
var LOCAL_IP = '127.0.0.1';
var PORT_CONTROLADOR = 8000;
servers[8001]={Port: 80, IP: '158.42.184.5'};
servers[8002]={Port: 80, IP: '158.42.4.23'};
servers[8003]={Port: 80, IP: '89.238.68.168'};
servers[8004]={Port: 8080, IP: '158.42.179.56'};
servers[8005]={Port: 80, IP: '147.156.222.65'};
for( i = 8001; i<=8005;i++){
  server = net.createServer(conectar(i)).listen(parseInt(i),LOCAL_IP);

}
var controlador = net.createServer(function(SocketControlador){
  SocketControlador.on('data',function(msg){
    var contrMSG = JSON.parse(msg);
    servers[contrMSG.inPort].IP = contrMSG.remote['ip'];
    servers[contrMSG.inPort].Port = contrMSG.remote['port'];
  });
}).listen(PORT_CONTROLADOR,LOCAL_IP);
function conectar(i){
  return function(socketCliente){

      var SocketServidor =new net.Socket();

      SocketServidor.connect(parseInt(servers[i].Port),servers[i].IP,function(){

        socketCliente.on('data',function(msg){
          SocketServidor.write(msg);
        });
        SocketServidor.on('data',function(msg){
          socketCliente.write(msg);
        });
      });

}
}
