/**
 * Shared Services
**/

// modules
import { ObjectId } from "mongodb";

// CRUD Service
export class CRUDService {

    constructor(database, collection) {
        this.database = database;
        this.collection = collection;
    }

    async create(client, task) {
        try {
            return await client
            .db(this.database)
            .collection(this.collection)
            .insertOne(task)
        } catch (err) {
            console.log("Error retrieving data", err);
        }
    }

    async getAll(client) {
        try {
            return await client
            .db(this.database)
            .collection(this.collection)
            .find()
            .toArray();     

        } catch (err) {
            console.log("Error retrieving data:", err);
        }
    }

    async getByID(client, id) {
        try {
            return await client
            .db(this.database)
            .collection(this.collection)
            .findOne({ _id: new ObjectId(id)});
        } catch (err) {
            console.log("Error retrieving data", err);
        }
    }

    async updateFields(client, data) {
        try {
            // prepare filter
            const { _id, ...rest } = data.filter;
            const filter = _id ? { _id: new ObjectId(_id), ...rest } : { ...rest}
            
            // prepare update
            const update = {
                $set: data.update
            }
            return await client.db("todo").collection("tasks").updateOne(filter, update);
        } catch (err) {
            console.log("Error retrieving data", err);
        }
    }

    async updateRecord(client, data) {
        try {
            const {_id, ...rest} = data.filter;
            const filter = _id ? { _id: new ObjectId(_id), ...rest } : { ...rest }
            
            return await client.db("todo").collection("tasks").replaceOne(filter, data.update);
        } catch (err) {
            console.log("Error retrieving data", err);
        }
    }

    async removeByID(client, id) {
        try {
            const result = await client.db("todo").collection("tasks").deleteOne({ _id: new ObjectId(id) })
    
            if (result.deletedCount === 0) {
                return { message: `Task with ID: ${id} not found` };
            }  
    
            return { message: `Task with ID: ${id} has been deleted successfully` };
        } catch (error) {
            return { message: `An error occurred: ${error.message}` };
        }
    }
}
