// modules
import authRoutes from "./auth/authRoutes.js";
import userRoutes from "./users/userRoutes.js";
import taskRoutes from "./tasks/taskRoutes.js";

// exports
export default {
    auth: authRoutes,
    users: userRoutes,
    tasks: taskRoutes
}
