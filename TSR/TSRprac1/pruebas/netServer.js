// c.write("") --> manda el contenido por el socket.
// c.on("data")--> Se dispara cuando se recibe datos.
// c.on("end")--> se dispara cuando se recibe un paquete FIN por el socket.
var net = require('net');
var server = net.createServer(
  function(c){
    console.log("Servidor: Cliente conectado.");
    c.on('end',function(){
      console.log("Servidor: Cliente desconectado");
    });
    c.on('data',
    function(data) {
      c.write('Hola\r\n'+ data.toString());
      c.end();
    });
  }
);
server.listen(8002,function(){
  console.log("Servidor listot")
});
