import './App.css';
import Macros from "./pages/macros/Macros.jsx"
import Weight from "./pages/Weight/Weight.jsx"

import { createBrowserRouter, RouterProvider} from 'react-router-dom';
import RootLayout from "./Root.jsx";
import Workout from "./pages/Workout/Workout.jsx";
// import ErrorPage from "./pages/Error.jsx";

import Register from "./pages/Register/Register.jsx";
import AuthPage, {action as authAction} from "./pages/Auth.jsx";

const router = createBrowserRouter([
    {
        path: '/',
        element: <RootLayout />,
        // errorElement: <ErrorPage />,
        children: [
            { path: '/', element: <Macros /> },
            { path: '/weight', element: <Weight />},
            { path: '/auth', element: <AuthPage />, action: authAction},
            { path: '/register', element: <Register />},
            { path: '/workout', element: <Workout />}

        ]
    }

])

function App() {
    return (
        <>
            <RouterProvider router={router} />
        </>



    );
}

export default App;


