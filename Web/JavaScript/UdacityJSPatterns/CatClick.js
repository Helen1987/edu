var data = {
    catsArray: [ { header: "cat 1", url: "https://c7.staticflickr.com/2/1211/625023078_62f07501a7_z.jpg", count: 0 },
        { header: "cat 2", url: "https://c8.staticflickr.com/3/2100/2285849591_28a55d7401_z.jpg", count: 0 },
        { header: "caaaatttt", url: "https://c1.staticflickr.com/9/8501/8300920648_d4a21bba59_z.jpg", count: 0 },
        { header: "sad cat", url: "https://c1.staticflickr.com/3/2072/2052922192_50dbc9d6a0.jpg", count: 0 },
        { header: "red cat", url: "https://c3.staticflickr.com/9/8620/16261024242_094f30b87e.jpg", count: 0 }
    ],
    selectedCat: null
};

var octupus = {
    init: function() {
        data.selectedCat = data.catsArray[0];
        listView.init();
        catView.init();
    },
    getCatsArray: function() {
        return data.catsArray;
    },
    getSelectedCat: function(){
        return data.selectedCat;
    },
    updateSelectedCat: function(cat) {
        data.selectedCat = cat;
    },
    increaseCount: function () {
        data.selectedCat.count++;
    }
};

var listView = {
    init: function(arrayOfCats) {
        this.list = document.getElementById('catlist');

        this.render();
    },
    render: function() {
        this.list.innerHTML = '';

        var arrayOfCats = octupus.getCatsArray();
        var bindListToCat = function(elem, cat) {
                elem.addEventListener('click', function() {
                    octupus.updateSelectedCat(cat);
                    catView.render();
                });
            };
        for (var i = 0; i < arrayOfCats.length; ++i) {
            var elem = document.createElement('li');
            elem.innerText = arrayOfCats[i].header;
            this.list.appendChild(elem);
            bindListToCat(elem, arrayOfCats[i]);
        }
    },

};

var catView = {
    init: function() {
        this.img = document.getElementById('currentimg');
        this.idSpan = document.getElementById('id');
        this.countSpan = document.getElementById('count');

        this.img.addEventListener('click', function() {
            octupus.increaseCount();
            catView.render();
        });
        this.render();
    },
    render: function() {
        var catInfo = octupus.getSelectedCat();
        this.img.src = catInfo.url;
        this.idSpan.innerText = catInfo.header;
        this.countSpan.innerText = catInfo.count;
    }
};

octupus.init();