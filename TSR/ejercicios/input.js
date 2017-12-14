
// Needed for initiating the reads from stdin.
process.stdin.resume()
// Needed for reading strings instead of “Buffers”.
process.stdin.setEncoding("utf8")
// Endless loop. Every time we read a radius its circumference is printed and a new radius is
process.stdin.on("data", function(str) {
 // The string that has been read is “str”. Remove its trailing endline.
 var rd = str.slice(0,str.length-1)
 console.log("Circumference for radius " + rd );
 console.log(" ")
 console.log("Radius of the circle: ")
})
// The “end” event is generated when STDIN is closed. [Ctrl]+[D] in UNIX.
process.stdin.on("end", function() {console.log("Terminating...")})
