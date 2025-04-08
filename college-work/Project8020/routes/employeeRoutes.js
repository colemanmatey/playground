// modules
const express = require("express");
const multer = require("multer");
const Employee = require("../models/employee");
const upload = multer({ dest: "uploads/" });

// router
const router = express.Router();

// routes
router.get("/", (req, res) => {
  // display list of employees
  Employee.find({})
    .then((results) => {
      res.render("list", { title: "Employees", employees: results });
    })
    .catch((err) => {
      console.error(err);
      res.status(500).send("Error retrieving employees");
    });
});

router.get("/:id/detail", (req, res) => {
  // view details of a single employee
  const id = req.params.id;

  Employee.findById(id)
    .then((result) => {
      res.render("detail", { title: result.name, employee: result });
    })
    .catch((err) => {
      console.error(err);
      res.status(404).send("Employee not found");
    });
});

router.get("/:id/edit", (req, res) => {
  // edit a single employee
  const id = req.params.id;
  Employee.findById(id)
    .then((result) => {
      res.render("edit", { title: "Employee " + id, employee: result });
    })
    .catch((err) => {
      console.error(err);
      res.status(404).send("Employee not found");
    });
});

router.post("/:id/edit", upload.single("image"), (req, res) => {
  // update employee details
  const id = req.params.id;

  const data = {
    name: req.body.name,
    role: req.body.role,
    department: req.body.department,
    email: req.body.email,
    phone: req.body.phone,
    address: req.body.address,
    notes: req.body.notes,
  };

  if (req.file) {
    data.image = req.file.filename;
  }

  Employee.findByIdAndUpdate(id, data, { new: true })
    .then((result) => {
      res.redirect("/employees");
    })
    .catch((err) => {
      console.error(err);
      res.status(404).send("Error updating employee");
    });
});

router.get("/add", (req, res) => {
  // add new employee form
  res.render("add", { title: "New Employee", employee: {} });
});

router.post("/add/new", upload.single("image"), (req, res) => {
  // add new employee
  const { name, role, department, email, phone, address, notes } = req.body;

  const employee = new Employee({
    name,
    role,
    department,
    email,
    phone,
    address,
    image: req.file.filename,
    notes,
  });

  employee
    .save()
    .then((result) => {
      res.redirect("/employees");
    })
    .catch((err) => {
      console.error(err);
      res.status(500).send("Error adding employee");
    });
});

module.exports = router;
