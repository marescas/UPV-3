function fib(n){
  return (n<2)? 1:fib(n-1)+fib(n-2); //operador ternario igual que java.
}
console.log("Iniciando...");
setTimeout(function(){
  console.log("Esperaré 10 u.t antes de escribir este mensaje.");
},10);
var j = fib(40);
function otroMSG(m,u) {
  console.log(m+": El resultado es  "+u);
}
otroMSG("M2",j);
setTimeout(function(){
  otroMSG("M3",j);
},1);
