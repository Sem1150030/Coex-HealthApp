import './App.css';
import Macros from "./pages/macros/Macros.jsx"
import Weight from "./pages/Weight/Weight.jsx"

import { createBrowserRouter, RouterProvider} from 'react-router-dom';
import RootLayout from "./Root.jsx";
import Workout from "./pages/Workout/Workout.jsx";

const router = createBrowserRouter([
    {
        path: '/',
        element: <RootLayout />,
        children: [
            { path: '/', element: <Macros /> },
            { path: '/weight', element: <Weight />},
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
