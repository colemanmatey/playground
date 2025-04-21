/**
 * Task Controller
**/

// modules
import db from "../../core/db.js";
import service from "./taskService.js";
import { CRUDController } from "../../shared/controllers.js";


class TaskController extends CRUDController {
    constructor(service, db) {    
        super(service, db);
    }
}

export default new TaskController(service, db)
