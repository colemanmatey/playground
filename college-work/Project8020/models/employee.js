// modules
const mongoose = require('mongoose');

const employeeSchema = new mongoose.Schema({
    name: {
        type: String,
        required: true
    },
    role: {
        type: String,
        required: true
    },
    department: {
        type: String,
        required: true
    },
    email: {
        type: String,
        required: true
    },
    phone: {
        type: String,
        required: true
    },
    address: {
        type: String,
        required: true
    },
    image: {
        type: String,
        required: false
    },
    notes: {
        type: String,
        required: false
    }
});


const Employee = mongoose.model('Employee', employeeSchema);


module.exports = Employee;
