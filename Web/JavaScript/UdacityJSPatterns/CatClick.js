var catsArray = [ { header: "cat 1", url: "https://c7.staticflickr.com/2/1211/625023078_62f07501a7_z.jpg", count: -1 },
    { header: "cat 2", url: "https://c8.staticflickr.com/3/2100/2285849591_28a55d7401_z.jpg", count: 0 },
    { header: "caaaatttt", url: "https://c1.staticflickr.com/9/8501/8300920648_d4a21bba59_z.jpg", count: 0 },
    { header: "sad cat", url: "https://c1.staticflickr.com/3/2072/2052922192_50dbc9d6a0.jpg", count: 0 },
    { header: "red cat", url: "https://c3.staticflickr.com/9/8620/16261024242_094f30b87e.jpg", count: 0 }
    ];

var img = document.getElementById('currentimg'),
    idSpan = document.getElementById('id'),
    countSpan = document.getElementById('count');

var setCurrentCat = function(catInfo) {
    img.src = catInfo.url;
    idSpan.innerText = catInfo.header;
    countSpan.innerText = ++catInfo.count;
};

for (var i = 0; i < catsArray.length; ++i) {
    var elem = document.createElement('li');
    elem.innerText = catsArray[i].header;
    document.getElementById('catlist').appendChild(elem);

    elem.addEventListener('click', (function(currentCat) {
        return  function() {
            setCurrentCat(currentCat);
        };
    })(catsArray[i]), false);
}

setCurrentCat(catsArray[0]);