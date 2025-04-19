// modules
import express from "express";
import cors from "cors";
import "dotenv/config";

import api from "../api/index.js";

// environment variables
const host = process.env.HOST || 'localhost'
const port = process.env.PORT || 3000

// create application
const app = express();

// middleware
app.use(express.json());
app.use(cors());

// routes
app.get("/", (req, res) => {
    res.status(200).send({
        message: "Welcome to the To-Do Application API",
        endpoints: {
            users: "/api/users",
            tasks: "/api/tasks/",
            task: "/api/tasks/:id",
        }
    });
})

// api
app.use("/api/auth", api.auth)
app.use("/api/users", api.users);
app.use("/api/tasks", api.tasks);

// start the server
app.listen(port, () => {
    console.log(`Server running on http://${host}:${port}`)
})
