/**
 * Authentication router
**/

// modules
import express from "express";
import authController from "./authController.js";

const router = express.Router();

// routes
router.post("/register", authController.register);
router.post("/login", authController.login)
router.post("/logout", authController.logout)

// exports
export default router;
