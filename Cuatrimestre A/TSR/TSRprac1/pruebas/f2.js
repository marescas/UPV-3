//Escribe o crea un fichero con el contenido especificado.
var fs = require('fs');
fs.writeFile('hola.txt','Hola mundo, este es el contenido del nuevo fichero.','utf8',
function(err,data){
  if (err) {
    return console.log(err);
  }
  console.log("Completado con exito.");
})
