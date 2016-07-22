var catsArray = [ { header: "cat 1", url: "https://c7.staticflickr.com/2/1211/625023078_62f07501a7_z.jpg" },
    { header: "cat 2", url: "https://c8.staticflickr.com/3/2100/2285849591_28a55d7401_z.jpg"}],
clicksCount = 0;

for (var i = 0; i < catsArray.length; ++i) {
    var elem = document.createElement('img');
    elem.src = catsArray[i].url;
    var conDiv = document.createElement('div');
    conDiv.innerText = catsArray[i].header;
    conDiv.appendChild(elem);
    document.getElementById('cats').appendChild(conDiv);

    elem.addEventListener('click', function() {
        alert('you clicked ' + ++clicksCount + ' times');
    }, false);
}