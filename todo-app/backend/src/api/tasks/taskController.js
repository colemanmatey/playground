/**
 * Task Controller
**/

// modules
import db from "../../core/db.js";
import taskService from "./taskService.js";

// Create new task
const createTask = async (req, res) => {
    try {
        const result = await db(client => taskService.create(client, req.body));
        res.status(201).send(result);
    } catch (err) {
        console.error("An error occurred:", err.message || err);
        res.status(500).send({ error: "Internal Server Error" });
    }
}

// Fetch all tasks //
const getAllTasks = async (req, res) => {
    try {
        const result = await db(client => taskService.getAll(client))
        res.status(200).send(result)
    } catch (err) {
        console.error("An error occurred:", err.message || err);
        res.status(500).send({ error: "Internal Server Error" });
    }
}

// Fetch task by ID
const getTaskByID = async (req, res) => {
    try {
        const result = await db(client => tS.fetchSpecificTask(client, req.params.id))
        res.status(200).send(result);
    } catch (err) {
        console.error("An error occurred:", err.message || err);
        res.status(500).send({ error: "Internal Server Error" });
    }
}

// Update specific task fields
const updateTask = async(req, res) => {
    const result = await db(client => taskService.updateFields(client, req.body))
    res.status(200).send(result);
}

// Update all task details
const replaceTask = async(req, res) => {
    const result = await db(client => taskService.updateRecord(client, req.body))
    res.status(200).send(result);
}

// Delete task by ID
const deleteTaskByID = async(req, res) => {
    const result = await db(client => taskService.removeByID(client, req.params.id));
    res.status(200).json(result);
}

// exports
export default {
    createTask,
    getAllTasks,
    getTaskByID,
    updateTask,
    replaceTask,
    deleteTaskByID
}
