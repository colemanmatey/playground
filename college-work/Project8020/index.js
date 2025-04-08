// modules
const express = require("express");
const path = require("path");
const morgan = require("morgan");
const connectDB = require("./database");
const employeeRoutes = require("./routes/employeeRoutes");

// environment variables
require("dotenv").config();
const PORT = process.env.PORT || 3000;

// database connect
connectDB();

// application
const app = express();
app.set("view engine", "ejs");
app.set("views", path.join(__dirname, "views"));

// middleware
app.use(express.static(path.join(__dirname, "public")));
app.use(express.urlencoded({ extended: true }));
app.use(morgan("dev"));
app.use("/uploads", express.static(path.join(__dirname, "uploads")));
app.use('/tinymce', express.static(path.join(__dirname, 'node_modules', 'tinymce')));


// routes
app.get("/", (req, res) => {
  // homepage
  res.render("index", { title: "Homepage" });
});

app.use("/employees", employeeRoutes);

// 404
app.use((req, res) => {
  res.status(404).send("Page not found");
});

// listen
app.listen(PORT, () => {
  console.log(`Server running on port ${PORT}`);
});
