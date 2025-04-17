// modules
import express from "express";


// configure application
const app = express();


// routes
app.get("/", (req, res) => {
    res.send("To-Do Application");
})


export default app;