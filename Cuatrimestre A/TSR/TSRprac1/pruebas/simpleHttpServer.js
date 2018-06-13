var http = require('http');
function dd(i){
  return (i<10?"0":"")+i //muestra las fechas en formato DD es decir [01..09] [10..31 o 60]
}
var server = http.createServer(
  function(req, res){
    res.writeHead(200,{'Content-Type':'text/html'});
    res.end('Hola mundo.')
    var dia = new Date();
    console.log("Conectado a las "+dia.getHours()+
    ":"+dd(dia.getMinutes()) +":"+
    dd(dia.getSeconds())); //cada vez que se conecta un cliente devuelve hola mundo y escribe por consola la hora de conexión.
}).listen(8000); //el servidor escucha en el puerto 8000
