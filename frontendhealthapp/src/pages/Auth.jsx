import Login from "./Login/Login.jsx";
import {json, redirect} from "react-router-dom";

function AuthPage(){
    return  <Login />

}
export default AuthPage;

export async function action({request}) {

    const searchParams = new URL(request.url).searchParams;
    const mode = searchParams.get('mode') || 'login'

    if (mode !== 'login' && mode !== 'signup' ) {
        return {
            status: 400,
            body: 'Invalid mode'
        }
    }

    const data = await request.formData();
    const authData = {
        username: data.get('email'),
        password: data.get('password')
    };

    const  response = await fetch('http://localhost:5155/api/Auth/' + mode, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(authData)
    });



    if(response.status === 422 || response.status === 401){
        return response;
    }

    if (mode === 'signup' && response.status === 400) {
        console.log("User already exists")
        return json({message: 'User already exists'}, {status: 500});
    }

    if (mode === 'login' && response.status === 400) {
        console.log("username and password combination is wrong")
        return json({message: 'username and password combination is wrong'}, {status: 500});
    }

    if(!response.ok){
        throw json({message: 'Failed to authenticate'}, {status: 500});
    }

    const resData = await response.json()
    console.log('Response Data:', JSON.stringify(resData, null, 2)); // Pretty prints with 2-space indentation
    const token = resData.jwtToken;

    localStorage.setItem('token', token);

    return redirect('/');

}
