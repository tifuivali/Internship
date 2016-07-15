

//Exercise 1

var hotel = {
    id: 1,
    name: "Maestro",
    description: "abcd",
    city: "Cluj Napoca",
    rooms_count: 40,
    stars_count: 4

};


console.log("Id:" + hotel.id);
console.log("desc: " + hotel.description);
console.log("city " + hotel.city);
console.log("rooms: " + hotel.rooms_count);
console.log("stars: " + hotel.stars_count);



//Exercise 2


var reservation = {
    id: 1,
    first_name: "Popescu",
    last_name: "Ionut",
    city: "Bucuresti",
    check_in: new Date("7/15/2016"),
    check_out: new Date("8/15/2016")
};

console.log("Reservation:");
console.log("id: " + reservation.id);
console.log("fisrt name: " + reservation.first_name);
console.log("last name: " + reservation.last_name);
console.log("city: " + reservation.city);
console.log("check-in date: " + reservation.check_in);
console.log("check-out date: " + reservation.check_out);


function Hotel(id, name, description, city, rooms_count, stars_count) {
    this.id = id;
    this.name = name;
    this.description = description;
    this.city = city;
    this.rooms_count = rooms_count;
    this.stars_count = stars_count;
    this.display=function() {
        console.log(name + "," + city + "," + stars_count+" stele");
    };

};

var hotel1 = new Hotel(1, "Hotel1", "aaa", "Iasi", 30, 4);
var hotel2 = new Hotel(2, "Hotel2", "bbbb", "Cluj Napoca", 100, 5);


console.log("Hotels created: ");

hotel1.display();
hotel2.display();



//Exercise 4

var array = [];
array[0] = hotel1;
array[1] = hotel2;
array[3] = new Hotel(3, "Hotel3", "ccc", "Vaslui", 200, 5);
array[4] = new Hotel(4, "Hotel4", "dddd", "Bucuresti", 40, 3);

console.log("Array content:");

for (var item in array)
{
    console.log(array[item]);
}


console.log("Array length:" + array.length);

array.push(new Hotel(5, "Hotel5", "fff", "Timisoara", 20, 2));

console.log("Array length:" + array.length);
console.log("Array content after push:");

for (var item in array) {
    console.log(array[item]);
}

array.pop();

console.log("Array length after pop:" + array.length);

array.unshift(2);

console.log("Array length unshift:" + array.length);

array.shift(3);

console.log("Array length shift:" + array.length);



//Exercise 5


function Hotels()
{
    this.list = [];

}

Hotels.prototype.add = function (hotel) {
    var exists = false;
    for (var item in this.list)
    {
        if(this.list[item].id===hotel.id)
        {
            exists = true;
        }
    }
    if (exists)
    {
        throw {
            message:"Hotels with the same id:"+hotel.id+ " already exists!"
        }
    }
   
    this.list.push(hotel);
};

Hotels.prototype.update = function (hotel) {
    var exists = false;
    for (var item in this.list) {
        if (this.list[item].id === hotel.id) {
            exists = true;
            this.list[item]=hotel;
        }
    }
    if (!exists)
    {
        throw {
            message: "Hotel doesn't exists!"
        }
    }
};

Hotels.prototype.delete = function (id) {
    var exists = false;
    for (var item in this.list) {
        if (this.list[item].id === id) {
            exists = true;
            this.list.splice(item, 1);
        }
    }
    if (!exists) {
        throw {
            message: "Hotel doesn't exists!"
        }
    }
};


Hotels.prototype.getInfo = function (id) {
    for (var item in this.list) {
        if (this.list[item].id ===id) {
            return this.list[item].name + "-" + this.list[item].city + "-" + this.list[item].stars_count + " stele";
        }
    }
}


Hotels.prototype.getAllInfo = function () {
    var infos = [];
    for (var item in this.list) {
        infos.push(this.getInfo(this.list[item].id));
    }
    return infos;
}




var listHotels = new Hotels();

listHotels.add(hotel1);
listHotels.add(hotel2);
console.log(listHotels.getAllInfo());
console.log("hotel: " + listHotels.getInfo(hotel1.id));

listHotels.delete(1);

console.log(listHotels.list.length);

console.log(listHotels.getAllInfo());



//Exercise 6

function writeSpaces() {
    console.log();
    console.log();
    console.log();
}

console.log("Exercise 6");
console.log("Hotels container :"+document.getElementById("hotelsContainer"));
console.log("third span "+document.querySelectorAll("#third span"));
console.log("right " + document.getElementsByClassName("right"));

var headers = document.getElementsByTagName("h1");

for (var i = 0; i < headers.length;i++)
{
    //if (headers[item].style)
    headers[i].style.color = "red";
}

var spans = document.getElementsByTagName("span");

for (var i = 0; i < spans.length;i++)
{
    spans[i].style.color = "blue";
}
