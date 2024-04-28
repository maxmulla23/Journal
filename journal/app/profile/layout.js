import NavBar from "../components/forms/navbar"

export default function Layout({ children }) {
    return(
        <div className="relative h-screen overflow-hidden bg-white dark:bg--100">
            <NavBar />

            <div className="container">
                {children}
            </div>
        </div>
    )
}