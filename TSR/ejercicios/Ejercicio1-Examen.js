var net = require('net');
var fun = require('./myfunctions');
var end_listener = function() {console.log('server disconnected');}
var error_listener = function() {console.log('some connection error');}
var bound_listener = function() {console.log('server bound');}
var server = net.createServer(
  function(cliente){
    cliente.on('end', end_listener);
    cliente.on('error', error_listener);
    cliente.on('data', function(msg){
      var obj = JSON.parse(msg);
      var tipo = obj.func;
      var numb =obj.numb;
      console.log(typeof(numb));
      if(tipo == 'fact'){
        if (typeof(n)=='Number') {
          cliente.write('fact('+numb+')='+ fun.fact(numb));
        }else{
          cliente.write('fact('+numb+')=NAN holi');
        }
      }else if(tipo == 'fibo'){
        if (typeof(n)=='Number') {
          cliente.write('fibo('+numb+')=' + fun.fibo(numb));
        }else{
          cliente.write('fibo('+numb+')=NAN');
        }
      }else{
        cliente.write(tipo+'('+numb+')=NAN' );
      }
    });


});
server.listen(9005, bound_listener);
function comprobar(n){
  if(typeof(n)=='number')return true;
  return false;
}
