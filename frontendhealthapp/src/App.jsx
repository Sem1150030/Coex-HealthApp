import './App.css';
import Macros from "./pages/macros/Macros.jsx"
import Weight from "./pages/Weight/Weight.jsx"
import { createBrowserRouter, RouterProvider} from 'react-router-dom';
import RootLayout from "./Root.jsx";
import Workout from "./pages/Workout/Workout.jsx";
import AuthPage, {action as authAction} from "./pages/Auth.jsx";
import ErrorPage from "./pages/Error.jsx";
import {action as logoutAction} from "./pages/Logout.js";
import {checkAuthLoader, tokenLoader} from './util/auth.js';
import WorkoutDetails from "./pages/WorkoutDetails/WorkoutDetails.jsx";
import Settings from "./pages/Settings/Settings.jsx";
import MacroHistory from "./pages/Macros-History/Macro-History.jsx";
import MacroHistoryDetails from "./pages/MacroHistoryDetails/MacroHistoryDetails.jsx";

const router = createBrowserRouter([
    {
        path: '/',
        element: <RootLayout />,
        errorElement: <ErrorPage />,
        id: 'root',
        loader: tokenLoader,
        children: [
            { path: '/macros',
                element: <Macros />,
                loader: checkAuthLoader},

            { path: '/weight',
                element: <Weight />,
                loader: checkAuthLoader },

            { path: '/auth', element: <AuthPage />, action: authAction},
            { path: '/workout', element: <Workout />, loader: checkAuthLoader},
            { path: '/Logout', action: logoutAction},
            { path: '/workoutDetails', element: <WorkoutDetails />, loader: checkAuthLoader }, // <-- Add this line
            { path: '/Profile', element: <Settings />, loader: checkAuthLoader},
            { path: '/macros/history', element: <MacroHistory />, loader: checkAuthLoader},
            { path: '/macros/history/details', element: <MacroHistoryDetails />, loader: checkAuthLoader},





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


