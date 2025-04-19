/**
 * User router
**/

// modules
import express from "express";
import userController from "./userController.js";

const router = express.Router();

// routes
router.get("/", userController.getAllUsers);

router.route("/:id")
.get(userController.getUserByID)
.put(userController.updateUser)
.patch(userController.modifyUserFields)
.delete(userController.deleteUserByID);

// exports
export default router;
