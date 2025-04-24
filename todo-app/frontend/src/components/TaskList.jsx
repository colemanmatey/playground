import { useState, useEffect } from "react";
import { API_URL } from "../shared/config.js";
import Task from "./Task.jsx";

function TaskList() {

    const [tasks, setTasks] = useState([]);

    const fetchData = async() => {
        fetch(`${API_URL}/api/tasks`)
        .then(response => {
            if (response.ok) {
                return response.json(); // Parse the JSON if the response is successful
            } else {
                throw new Error(`Error: ${response.status} - ${response.statusText}`);
            }
        })
        .then(data => {
            setTasks(data);
        })
        .catch(error => {
            console.error('Fetch error:', error); // Handle any errors that occurred
        });
    }

    useEffect(() => {
        fetchData();   
    }, [tasks]);

    return (
        <div className="row">
            <h3 className="text-center">Task List</h3>
            <div className="row">
                <div className="col-lg-4 col-md-4">
                    <h5>Title</h5>
                </div>
                <div className="col lg-2 col-md 2">
                    <h5>Priority</h5>
                </div>
                <div className="col-lg-2 col-md-2">
                    <h5>Actions</h5>
                </div>
                <div className="col-lg-4 col-md-4"></div>
            </div>
            { tasks.map((task, index) => (
                // <p key={index}>{ task.title } - { task.priority }</p>
                <Task key={index} task={task} />
            ))}
        </div>
    )
}

export default TaskList