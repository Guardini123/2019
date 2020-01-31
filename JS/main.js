function makeCounter() {
	var currentCount = 0;
	return function(){
		return ++currentCount;
	}
}
var counter = makeCounter();

var $button = document.querySelector('button');

$button.addEventListener('click', onClick);

function onClick(){
	this
		.querySelector('.count').textContent = counter();
}


var xhr = new XMLHttpRequest();

xhr.open('GET', 'https://api.openweathermap.org/data/2.5/weather?lat=61.77&lon=34.36&units=metric&APPID=ea454caf8ade66f2c9fb26c28b2ea95a', true);

xhr.send();

xhr.onload = function () {
	console.log(
		JSON.parse(xhr.response)
		);
};

