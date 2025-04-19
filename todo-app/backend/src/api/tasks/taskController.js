/**
 * Task Controller
**/

// modules
import db from "../../core/db.js";
import taskService from "./taskService.js";

// Create new task
const createTask = async(req, res) => {
    const result = await db(client => taskService.addNewTask(client, req.body));
    res.status(201).send(result);
}

// Fetch all tasks
const getAllTasks = async (req, res) => {
    const result = await db(taskService.fetchAllTasks);
    res.status(200).send(result)
}

// Fetch task by ID
const getTaskByID = async(req, res) => {
    const result = await db(client => taskService.fetchSpecificTask(client, req.params.id))
    res.status(200).send(result);
}

// Update specific task fields
const updateTask = async(req, res) => {
    const result = await db(client => taskService.modifySpecificTaskFields(client, req.body))
    res.status(200).send(result);
}

// Update all task details
const replaceTask = async(req, res) => {
    const result = await db(client => taskService.modifyAllTaskFields(client, req.body))
    res.status(200).send(result);
}

// Delete task by ID
const deleteTaskByID = async(req, res) => {
    const result = await db(client => taskService.removeTask(client, req.params.id));
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
