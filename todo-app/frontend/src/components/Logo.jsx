import logo from "../assets/react.svg";

function Logo() {
    return (
        <div className='d-flex'>
            <img src={ logo } alt="logo" />
            <h1 className="display-6">ToDo</h1>
        </div>
    )
}

export default Logo