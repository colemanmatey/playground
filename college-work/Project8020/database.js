// modules
const mongoose = require('mongoose');


const connectDB = function (){
    mongoose.connect(process.env.DATABASE_URL);
    
    const db = mongoose.connection;
    
    db.on('connected', () => {
        console.log(`Connected to MongoDB at ${db.host}:${db.port}/${db.name}`);
    });
    
    db.on('error', (error) => {
        console.log(`Database error\n${error}`);
    });
    
    db.on('disconnected', () => {
        console.log('Disconnected from MongoDB');
    }); 
}

module.exports = connectDB;
