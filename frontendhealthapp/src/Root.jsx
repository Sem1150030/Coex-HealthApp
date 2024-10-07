import Navigationbar from "./components/navbar/Navigationbar.jsx";
import {Outlet, useLoaderData, useSubmit} from "react-router-dom";
import {useEffect} from "react";
import {getTokenDuration} from "./util/auth.js";

function RootLayout(){
    const token = useLoaderData();
    const submit = useSubmit()

    useEffect(() => {
    if (!token){
        return ;
    }

    if (token === 'EXPIRED'){
        submit(null, {action: '/Logout', method: 'POST'})
        return ;
    }

    const tokenDuration = getTokenDuration();
    console.log('Token Duration:', tokenDuration);

    setTimeout(() => {
        submit(null, {action: 'Logout', method: 'POST'})
    },tokenDuration)
    }, [token,  submit])

    return (
        <>
            <Navigationbar />
            <Outlet />
        </>
    );
}
export default RootLayout;