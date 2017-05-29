/* 
site.js 
*/
/* 
use strict tell to the compiler use strict rules when parsing this js file. 
e.g.: Do not allow undefined variables such as: result = 10; -> should be: var result = 10;
*/
"use strict"; 

var helloWorldMsg = "Hello Javascript";
console.log(helloWorldMsg);

var resultsDiv = document.getElementById("results");
resultsDiv.innerHTML = "<p>This is from JavaScript</p>";

var result = {
	name: "jQuery",
	language: "JavaScript",
	score: 4.5,
	showLog: function() {},
	owner: {
		login: "kevy",
		id: 1234
	}
};

result.phoneNumber = "3697-8234";
console.log(result.phoneNumber);

var results = [{
		name: "jQuery",
		language: "JavaScript",
		score: 4.5,
		showLog: function() {},
		owner: {
			login: "kevy",
			id: 1234
		}
	},
	{
		name: "jQuery UI",
		language: "JavaScript",
		score: 3.5,
		showLog: function() {},
		owner: {
			login: "marcia",
			id: 23
		}
	}];

results.push(result);

console.log(results.length);
console.log(results[0].name);

for(var i = 0; i < results.length; i++){
	var item = results[i];
	console.log(item);
}

// console.log("helloWorldMsg is " + typeof(helloWorldMsg));
// console.log("resultsDiv is " + typeof(resultsDiv));

// var none;
// console.log("none is " + typeof(none));

// var aNumber = 0;
// console.log("aNumber is " + typeof(aNumber));

// var trueFalse = true;
// console.log("trueFalse is " + typeof(trueFalse));

// var aFloatNumber = 5.0;
// console.log("aFloatNumber is " + typeof(aFloatNumber));

// //result = 10;

// if (!none) {
// 	console.log("none is undefined");
// }

// if (aNumber == "10") {
// 	console.log("10 is 10");
// }

// // function showMsg (msg) {
// // 	console.log("showMsg: " + msg);
// // }

// function showMsg (msg, more) {
// 	if (more) {
// 		console.log("showMsg: " + msg + more);
// 	}
// 	else {
// 		console.log("showMsg: " + msg);
// 	}
// }

// showMsg("message this!!!");
// showMsg("message this!!!", " even more");

// var showIt = function(msg) {
// 	console.log(msg);
// };

// showIt("call showIt");

// function showItThen (msg, callback) {
// 	showIt(msg);
// 	callback();
// }

// showItThen("showItThen called", function(){
// 	console.log("callback called");
// });

// var vGlobal = true;

// function testMe () {
// 	console.log("testMe() :" + vGlobal);

// 	var someMessage = "some message";
// 	console.log("testMe(): " + someMessage);

// 	showItThen("withClosure", function() {
// 		showIt("testMeWithClosure() " + someMessage);
// 	});
// }

// testMe();