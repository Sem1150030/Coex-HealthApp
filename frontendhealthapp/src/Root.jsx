import Navigationbar from "./components/navbar/Navigationbar.jsx";
import {Outlet} from "react-router-dom";

function RootLayout(){
    return (
        <>
            <Navigationbar />
            <Outlet />
        </>
    );
}
export default RootLayout;