/**
 * Server
**/

import app from "./app.js"

// Start server
app.listen(8000, () => {
    console.log("Server running on port", 8000);
});
