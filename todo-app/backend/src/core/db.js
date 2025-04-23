// modules
import { MongoClient } from "mongodb";

// 
async function db(task) {
    // database credentials
    const password = encodeURIComponent(process.env.DB_PASSWORD);
    const uri = `mongodb+srv://${process.env.DB_USER}:${password}@babysteps.xbrc2ub.mongodb.net/?retryWrites=true&w=majority&appName=BabySteps`;
    
    const options = {
        ssl: true,
        sslValidate: true,
        tlsAllowInvalidCertificates: false,
      };
      

    // create a mongoclient
    const client = new MongoClient(uri, options);

    try{
        // connect to db
        await client.connect();
        console.log("Connected to MongoDB");

        // execute database operation
        console.log("Running operation on database");
        return await task(client);
    } catch (err) {
        console.error(err);
    } finally {
        await client.close();
        console.log("MongoDB connection closed.");
    }
}

export default db;
