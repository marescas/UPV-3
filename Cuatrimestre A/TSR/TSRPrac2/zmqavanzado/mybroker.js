var zmq = require('zeromq');
var frontend = zmq.socket('router');
var backend = zmq.socket('router');
var args = process.argv.slice(2);
var fePortNbr = args[0] || 8059;
var bePortNbr = args[1] || 8060;
//Workers disponibles
var workers = [];
//clientes pendientes
var clients = [];
var requestPerWorker = [];

console.log(fePortNbr +" " );
frontend.bindSync('tcp://*:'+fePortNbr);

backend.bindSync('tcp://*:'+bePortNbr);
frontend.on("message",function(){
    //QUE SIGNIFICA LA LINEA DE ABAJO
    var args = Array.apply(null, arguments);
    if(workers.length > 0){
        var myWorker = workers.shift(); 
        var m = [myWorker, ""].concat(args);
        backend.send(m);
    }else{
        clients.push({id:args[0],msg:args.slice(2)});
    }
});

function processPendingClient(workerID){
    if(clients.length>0){
        var nextClient =clients.shift();
        var m = [workerID,'',nextClient.id,''].concat(nextClient.msg);
        backend.send(m);
        return true;
    }else{
        return false;
    }
}
backend.on('message',function(){
    var args = Array.apply(null, arguments); 
    if(args.length == 3){
        requestPerWorker[args[0]]=0; //worker id 
        if(!processPendingClient(args[0])){
            workers.push(args[0]);
        }
    }else{
        var workerID = args[0];
        requestPerWorker[workerID]++;
        args = args.slice(2);
        frontend.send(args);
        if(!processPendingClient(workerID)){
            workers.push(workerID);
        }

    }

});
function showStatistics() {
    var totalAmount = 0;
    console.log('Current amount of requests served by each worker:');
    for (var i in requestsPerWorker) {
        console.log(' %s : %d requests', i, requestsPerWorker[i]);
        totalAmount += requestsPerWorker[i];

    }
    console.log('Requests already served (total): %d', totalAmount);

}
process.on('SIGINT',showStatistics);