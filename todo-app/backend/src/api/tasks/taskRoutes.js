/**
 * Task router
**/

// modules
import express from "express";
import taskController from "./taskController.js";

const router = express.Router();

// routes
router.route("/")
.get(taskController.getAll)
.post(taskController.create);

router.route("/:id")
.get(taskController.getByID)
.patch(taskController.updateFields)
.put(taskController.updateRecord)
.delete(taskController.deleteByID);

// exports
export default router;
