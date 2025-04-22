import 'bootstrap/dist/css/bootstrap.min.css'
import logo from './assets/react.svg'
import './App.css'

function App() {
  return (
    <div className='container'>
      <div className='d-flex'>
        <img src={ logo } alt="logo" />
        <h1>ToDo</h1>
      </div>
    </div>
  )
}

export default App
