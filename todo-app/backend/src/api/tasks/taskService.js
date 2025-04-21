/**
 * Task service 
**/

// modules
import { CRUDService } from "../../shared/services.js";

class TaskService extends CRUDService {
    constructor(database, collection) {
        super(database, collection);
    }
}

// export
export default new TaskService("todo", "tasks");
