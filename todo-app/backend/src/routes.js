// modules
import express from "express";

// router
const router = express.Router();

// routes
router.get("/", (req, res) => {
    res.send("To-Do Application");
})


export default router;