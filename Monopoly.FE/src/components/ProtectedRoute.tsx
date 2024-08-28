import { Outlet, Navigate } from "react-router-dom"
export const ProtectedRoutes = () => {
    const auth = localStorage.getItem("token")
    return(
        // auth !== null ? <Outlet />:<Navigate to={`/login`} />
        true ? <Outlet />:<Navigate to={`/login`} />
    )
}