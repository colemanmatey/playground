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


    if (tasks != []){
        return (
            <div className="row">
                <h3 className="text-center">Task List</h3>
               
                { tasks.map((task, index) => (
                    <Task key={index} index={index} task={task} />
                ))}
            </div>
        )
    } else {
        return (
            <p>No tasks available</p>
        )
    }

}

export default TaskList