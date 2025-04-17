// modules
import app from "./app.js";
import "dotenv/config";

// server configuration
const host = process.env.HOST || 'localhost'
const port = process.env.PORT || 3000

// listen for requests
app.listen(port, () => {
    console.log(`Server running on http://${host}:${port}`)
})
