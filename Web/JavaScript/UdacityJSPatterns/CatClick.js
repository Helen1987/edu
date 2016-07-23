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
    adminMode: false,
    init: function() {
        data.selectedCat = data.catsArray[0];
        listView.init();
        catView.init();
        adminView.init();
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
    },
    updateCurrentCat: function(name, url, clicks) {
        data.selectedCat.header = name;
        data.selectedCat.url = url;
        data.selectedCat.count = clicks;
    },
    toogleAdminMode: function() {
        this.adminMode = !this.adminMode;
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
                    adminView.render();
                });
            };
        for (var i = 0; i < arrayOfCats.length; ++i) {
            var elem = document.createElement('li');
            elem.innerText = arrayOfCats[i].header;
            this.list.appendChild(elem);
            bindListToCat(elem, arrayOfCats[i]);
        }
    }
};

var catView = {
    init: function() {
        this.img = document.getElementById('currentimg');
        this.idSpan = document.getElementById('id');
        this.countSpan = document.getElementById('count');

        this.img.addEventListener('click', function() {
            octupus.increaseCount();
            catView.render();
            adminView.render();
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

var adminView = {
    init: function() {
        this.admin = document.getElementById("adminMode");
        this.adminArea = document.getElementById("admin-content");
        this.name = document.getElementById("admin-name");
        this.url = document.getElementById("admin-url");
        this.clicks = document.getElementById("admin-clicks");
        this.save = document.getElementById("save");
        this.cancel = document.getElementById("cancel");

        this.save.addEventListener('click', function() {
            octupus.updateCurrentCat(adminView.name.value, adminView.url.value, adminView.clicks.value);
            catView.render();
        });
        this.admin.addEventListener('click', function() {
            octupus.toogleAdminMode();
            adminView.render();
        });
        this.cancel.addEventListener('click', function() {
            octupus.toogleAdminMode();
            adminView.render();
        });

        this.render();
    },
    render: function() {
        if (octupus.adminMode) {
            var catInfo = octupus.getSelectedCat();
            this.name.value = catInfo.header;
            this.url.value = catInfo.url;
            this.clicks.value = catInfo.count;
            this.adminArea.style.display = "block";
        }
        else {
            this.adminArea.style.display = "none";
        }
    }
};

octupus.init();