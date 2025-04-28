import { API_URL } from "../shared/config";
import Button from "./Button"

function Task({task, index}) {

    const onEdit = (task) => {

    }

    const onDelete = (task) => {
        fetch(`${API_URL}/api/tasks/${task._id}`, {
            method: "DELETE",
        })
        .then(response => {
            if (!response.ok) {
                throw new Error(`Error: ${response.status}`);
            }
            return response.json();
        })
        .then(data => console.log('Task deleted:', data))
        .catch(error => console.error('Delete failed:', error));
        
    }

    return (
        <div className="row">
            <div className="col-lg-6 col-md-6">
                <input type="checkbox" name="status" id={index} />
                <p className="d-inline mx-1">{ task.title }</p>
            </div>
            <div className="col lg-4 col-md 4">
                <p>{ task.priority}</p>
            </div>
            <div className="col lg-2 col-md 2">
                <Button name="Edit" clickHandler={() => onEdit(task) }  style="m-1 btn btn-warning" />
                <Button name="Delete" clickHandler={() => onDelete(task) } style="m-1 btn btn-danger" />
            </div>
        </div>
    )                                                                                                                                                 
}

export default Task