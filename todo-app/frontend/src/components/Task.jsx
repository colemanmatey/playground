import { API_URL } from "../shared/config";
import Button from "./Button"

function Task({task, index, onDelete}) {

    const edit = (task) => {

    }

    const remove = async (task) => {
        try {
            const response = await fetch(`${API_URL}/api/tasks/${task._id}`, {
                method: "DELETE",
            });
        
            if (!response.ok) {
                throw new Error(`Error: ${response.status}`);
            }
        
            const data = await response.json();
            onDelete();

            console.log('Task deleted:', data);
        } catch (error) {
            console.error('Delete failed:', error);
        }
        
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
                <Button name="Edit" clickHandler={() => edit(task) }  style="m-1 btn btn-warning" />
                <Button name="Delete" clickHandler={() => remove(task) } style="m-1 btn btn-danger" />
            </div>
        </div>
    )                                                                                                                                                 
}

export default Task