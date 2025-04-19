/**
 * Task router
**/

// modules
import express from "express";
import taskController from "./taskController.js";

const router = express.Router();

// routes
router.route("/")
.get(taskController.getAllTasks)
.post(taskController.createTask);

router.route("/:id")
.get(taskController.getTaskByID)
.patch(taskController.updateTask)
.put(taskController.replaceTask)
.delete(taskController.deleteTaskByID);

// exports
export default router;
