var fs = require('fs');
function getFiles(dir,files_) {
  files_ = files_ || []; //files es una lista vacia o con n elementos.
  var files = fs.readdirSync(dir); //lee los ficheros del directorio.
  for (var variable in files) {
    var nombre = dir+'/'+files[variable];
    if (fs.statSync(nombre).isDirectory()) { //si es un directorio entra recursivamente.
        getFiles(nombre,files_);
    }else{
      files_.push(nombre); //agregamos nombre a la lista.
    }
  }
  return files_;
}
console.log(getFiles('..'));
