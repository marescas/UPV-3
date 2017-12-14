var zmq = require('zmq');
var verbose = false
var aux = require('./auxfunctions1718')
var frontend = zmq.socket('router');
var backend = zmq.socket('router');
var args = process.argv.slice(2);
var fePortNbr = args[0] || 8059;
var bePortNbr = args[1] || 8060;
if(args[args.length-1]=="verbose"){
     args.pop()
     verbose = true;
     console.log("verbose activado");
}
//Workers disponibles
var workers = [] //devuelve una lista de workers {id,load}
//clientes pendientes
var clients = [];
var requestPerWorker = [];

console.log(fePortNbr +" " );
frontend.bindSync('tcp://*:'+fePortNbr);

backend.bindSync('tcp://*:'+bePortNbr);
frontend.on("message",function(){
    var args = Array.apply(null, arguments);
    if(verbose)aux.showMessage(args)
    if(workers.length > 0){ // si existen workers para poder trabajar
        if(verbose)aux.showMessage(workers)
        var myWorker = menosCarga(workers);  //escogemos el primer worker y lo eliminamos de la lista de workers 
        if(verbose)console.log("el worker que me va a atender es "+ myWorker);
        var m = [myWorker, ""].concat(args); 
        //construimos el mensaje con el identificador del worker  y un segmento vacio 
        // estructura del mensaje [idworker, "",idClient,"",mensaje]
        backend.send(m); //lo enviamos por el backend
    }else{//si no hay workers disponibles 
        clients.push({id:args[0],msg:args.slice(2)}); 
        //agregamos a la lista de clientes pendientes el identificador del cliente y mensaje
        //estructura  de args --- [id, "", msg]
    }
});

function processPendingClient(workerID){
    if(clients.length>0){ // si quedan clientes por procesar 
        var nextClient =clients.shift(); //eliminamos y escogemos el primer cliente
        var m = [workerID,'',nextClient.id,''].concat(nextClient.msg); 
        backend.send(m); //enviamos el mensaje por el socket
        return true;
    }else{
        return false;
    }
}
backend.on('message',function(){ //cuando llega un mensaje de un worker 
    var args = Array.apply(null, arguments); 
    //todos los mensajes de un worker llevarán como segmento final su carga.
    var carga = args.pop();
    if(verbose) console.log("id "+ args[0]+" carga "+carga);
    
    
    if(args.length == 3){ //si es un mensaje para anunciar que se ha conectado nuevo worker estructura [idWoker, "", mensajeAnuncio]
        requestPerWorker[args[0]]=0; //iniciamos el contador del worker a 0
        if(!processPendingClient(args[0])){ // si no hay clientes por procesar
            workers.push({id:args[0],load:carga}); //ESTO CAMBIA, añadimos el identificador del worker y su carga asociada a la lista 
            if(verbose){
                for(i in workers.data){
                    console.log(workers[i].id)
                }
                
            }
        }
    }else{  //si es una contestación de un worker estructura [idWoker, "", idCliente, "", mensaje]
        var workerID = args[0];
        requestPerWorker[workerID]++; //incrementamos el contador del worker al llegar un mensaje
        args = args.slice(2);
        frontend.send(args); //enviamos por el frontend la respuesta al cliente
        if(!processPendingClient(workerID)){
            workers.push({id:args[0],load:carga});
        }

    }

});
function showStatistics() {
    var totalAmount = 0;
    console.log('Current amount of requests served by each worker:');
    for (var i in requestPerWorker) {
        console.log(' %s : %d requests', i, requestPerWorker[i]);
        totalAmount += requestPerWorker[i];

    }
    console.log('Requests already served (total): %d', totalAmount);

}
process.on('SIGINT',showStatistics);
function menosCarga(workers){
   var min = 1000;
    var idmin = -1;
    var imin = -1
for(i in workers){
    if(workers[i].load<min){
        min =  workers[i].load;
        idmin = workers[i].id;
        imin = i
    }
}
workers.splice(imin,1)
return idmin
}