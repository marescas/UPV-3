function a3(x) {
  return function(y) {
    return x*y;
  };
}
function add(v) {
  var sum=0;
  for (var i=0; i<v.length; i++)
  sum += v[i];
  return sum;
}
function iterate(num, f, vec) {
  var amount = num;
  var result = 0;
  if (vec.length<amount)
  amount=vec.length;
  for (var i=0; i<amount; i++)
  result += f(vec[i]);
return result;
}
var myArray = [3, 5, 7, 11];
console.log(iterate(2, a3, myArray)); // return a string
// 0function (y) {
//     return x*y;
//   }function (y) {
//     return x*y;
//   }
console.log(iterate(2, a3(2), myArray)); //return 16, 2*3+2+5
console.log(iterate(2, add, myArray)); //return 0 because !0<undefined
console.log(add(myArray)); // sum all the elements of the array. Same reduce(a+b)
console.log(iterate(5, a3(3), myArray)); //sum(3*elem(i))
console.log(iterate(5, a3(1), myArray)); //(sum(elem(i)))
