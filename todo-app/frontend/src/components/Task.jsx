
function Task({task}) {

    return (
        <div className="row">
            <div className="col-lg-4 col-md-4">
                <p>{ task.title }</p>
            </div>
            <div className="col lg-2 col-md 2">
                <p>{ task.priority.to}</p>
            </div>
            <div className="col-lg-2 col-md-2">
                
            </div>
            <div className="col-lg-4 col-md-4"></div>
        </div>
    )
}

export default Task