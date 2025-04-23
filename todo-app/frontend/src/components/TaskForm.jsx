function TaskForm() {

    const submit = async (formData) => {
        const title = formData.get("title");
        const priority = formData.get("priority");
        const data = { title, priority }

        try {
            const response = await fetch(`${import.meta.env.VITE_API_URL}/api/tasks`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(data)
            });

            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            console.log(await response.json());
        } catch (error) {
            console.error("An error occurred", error);
        }  
    }

    return (
        <form action={ submit } className="my-5 py-3">
            <div className="row">
                <div className="col-lg-7 col-md-7">
                    <input type="text" className="form-control" name="title" placeholder="Enter a task here" />
                </div>
                <div className="col-lg-2 col-md-2">
                    <div className="form-floating">
                        <select className="form-select" id="floatingSelect" name="priority" aria-label="Floating label select example">
                            <option value="low">Low</option>
                            <option value="medium">Medium</option>
                            <option value="high">High</option>
                        </select>
                        <label htmlFor="floatingSelect">Priority</label>
                    </div>
                </div>
                <div className="col-lg-2 col-md-2">
                    <button className="btn btn-primary" type="submit">Add</button>
                </div>
            </div>
        </form>
    )
}

export default TaskForm
