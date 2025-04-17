// modules
import express from "express";

// router
const router = express.Router();

// routes
router.get("/", async (req, res) => {
    res.send("To-Do Application");

})


export default router;