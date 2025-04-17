// modules
import { MongoClient } from "mongodb";

// 
async function db(task) {
    // database credentials
    const username = process.env.DB_USER
    const password = encodeURIComponent(process.env.DB_PASSWORD);

    const uri = `mongodb+srv://${username}:${password}@babysteps.xbrc2ub.mongodb.net/?retryWrites=true&w=majority&appName=BabySteps`;
    const client = new MongoClient(uri);

    try{
        // connect to db
        await client.connect();
        console.log("Connected to MongoDB");

        // execute database operation
        return await task(client);
    } catch (err) {
        console.error("An error occurred:", error);
    } finally {
        await client.close();
    }
}

export default db;