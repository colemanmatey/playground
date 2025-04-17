// modules
import express from "express";
import routes from "./routes.js";


// configure application
const app = express();


// routes
app.use("/", routes);


export default app;