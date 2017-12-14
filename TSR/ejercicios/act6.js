var fs = require("fs");
var max = 0;
var nomF = "";
var args = process.argv.slice(2);
for(var i =0; i<args.length;i++){
comprobar(i);
}
function comprobar(i){
  fs.readFile(args[i],'utf8',function(err, data){
    if(!err && data.length>max){
      max =data.length;
      nomF = args[i];
    }
  });

}
process.on('exit',function(){
  console.log("el fichero es "+ nomF+ " con tamaño "+max);
});
