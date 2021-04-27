const cities = require('./cities');
const {places, descriptors} = require('./seedHelpers');
const mongoose = require('mongoose');
const Campground = require('../models/campground');

//conenct to mongodb "yelp-camp" & error handling
mongoose.connect('mongodb://localhost:27017/yelp-camp', {
    useNewUrlParser: true,
    useCreateIndex: true,
    useUnifiedTopology: true
}) 

const db = mongoose.connection;
db.on("error", console.error.bind(console,"cennection error:"));
db.once("open", () => {
    console.log("Database connected");
});

//for title 從array選element是用array.length
const sample = array => array[Math.floor(Math.random() * array.length)]

//a func to create datas fast
const seedDB = async() => {
    await Campground.deleteMany({});
    for(let i=0; i<300; i++){
        //for location 因為從nested array，所以是cities[0].city這樣選取
        const random1000 = Math.floor(Math.random() * 1000);
        const price = Math.floor(Math.random() * 20)+ 10;
        const camp = new Campground({
            //My user id
            author: '607cf4e63ddd79430be36c2f',
            location:`${cities[random1000].city}, ${cities[random1000].state}`,
            title: `${sample(descriptors)} ${sample(places)}`,
            description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Eaque facilis id rerum, maxime dignissimos provident cupiditate nostrum similique nemo ipsa, impedit minus, laborum distinctio eius ipsum ex minima. Consequatur, deserunt!',
            price,
            geometry: { 
                type: 'Point', 
                coordinates: [
                    cities[random1000].longitude,
                    cities[random1000].latitude,
                ]
            },
            images: [
                {
                  url: 'https://res.cloudinary.com/dswbqujyc/image/upload/v1619153666/YelpCamp/peoyqdv1yoqtbdqxoxhj.jpg',
                  filename: 'YelpCamp/peoyqdv1yoqtbdqxoxhj'
                },
                {
                  url: 'https://res.cloudinary.com/dswbqujyc/image/upload/v1619153666/YelpCamp/fzi2qiwmrtutbzg5i5yo.jpg',
                  filename: 'YelpCamp/fzi2qiwmrtutbzg5i5yo'
                }
              ]
        })
        await camp.save();
    }
}

//output & close database
seedDB().then(() => {
    mongoose.connection.close()
})

// seedDB();