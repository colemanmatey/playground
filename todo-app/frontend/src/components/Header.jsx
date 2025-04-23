import Logo from "../components/Logo"
import Navbar from '../components/Navbar'

function Header() {

    return (
        <header className="header d-flex justify-content-between align-items-center">
            <Logo />
            <Navbar />
        </header>
    )
}

export default Header