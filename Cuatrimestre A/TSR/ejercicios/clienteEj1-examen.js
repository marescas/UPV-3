var net =  require('net');
var func = process.argv[2];
var n = process.argv[3];
var client = net.connect({port:9005},function(){
  if(process.argv.length <4){
    console.log("Error el orden indicado es node programa funcion numero");
    client.end();
  }else{
    var msg = JSON.stringify({
      'func': func,
      'numb': parseInt(n)
    });
    client.write(msg);
    client.on('data', function(msg){
      console.log(msg.toString());
      client.end();
    })
  }
});
