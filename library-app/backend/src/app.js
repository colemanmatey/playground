/**
 * App
**/

import express from "express";

const app = express();

app.get("/", (req, res) => {
    res.json({"message": "Welcome to the Library Application API"});
});


export default app;