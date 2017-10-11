var net = require('net');
var fs = require('fs');
const os = require('os');
var server = net.createServer(
  function(c){
      console.log("Servidor: Cliente conectado.");

      c.on('end',function(){
        console.log("Servidor: Cliente desconectado");
        process.exit(); //finalizo la conexió
      });
      c.on('data',
      function(data) {
        c.write(getLoad().toString()+"\n"+os.networkInterfaces()['eth0'][0].address);
        c.end();
      });
  }
);
server.listen(8001,function(){
  console.log("Servidor listo")
});
// getLoad calcula la carga actual del Servidor
// Suma una centesima para evitar confusion entre 0 y un error
// devuelve la media ponderada dandole mayor peso al ultimo minuto.
function getLoad(){
 data=fs.readFileSync("/proc/loadavg"); //requiere fs
 var tokens = data.toString().split(' '); //devuelve una lista con los elementos separados por espacios
 var min1 = parseFloat(tokens[0])+0.01;
 var min5 = parseFloat(tokens[1])+0.01;
 var min15 = parseFloat(tokens[2])+0.01;
 return min1*10+min5*2+min15;
 };
