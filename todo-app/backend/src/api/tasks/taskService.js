/**
 * Task Service 
**/
import { ObjectId } from "mongodb";


// fetch all tasks
const fetchAllTasks = async (client) => {
    const documents = await client.db("todo").collection("tasks")
    return documents.find().toArray();
}

// fetch a specific task
const fetchSpecificTask = async (client, id) => {
    const documents = await client.db("todo").collection("tasks")
    return documents.findOne({ _id: new ObjectId(id)});
}

// create a new task
const addNewTask = async (client, task) => {
    return await client.db("todo").collection("tasks").insertOne(task);
}

// modify specific task fields
const modifySpecificTaskFields = async (client, data) => {
    // prepare filter
    const { _id, ...rest } = data.filter;
    const filter = _id ? { _id: new ObjectId(_id), ...rest } : { ...rest}
    
    // prepare update
    const update = {
        $set: data.update
    }
    return await client.db("todo").collection("tasks").updateOne(filter, update);
}

// modify all task fields
const modifyAllTaskFields = async (client, data) => {
    const {_id, ...rest} = data.filter;
    const filter = _id ? { _id: new ObjectId(_id), ...rest } : { ...rest }
    
    return await client.db("todo").collection("tasks").replaceOne(filter, data.update);
}

// delete task
const removeTask = async (client, id) => {
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

// exports
export default {
    fetchAllTasks,
    fetchSpecificTask,
    addNewTask,
    modifySpecificTaskFields,
    modifyAllTaskFields,
    removeTask
}