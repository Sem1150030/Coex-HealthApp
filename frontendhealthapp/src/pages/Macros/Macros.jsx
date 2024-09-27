import './Macros.css';
import DonutChart from '../../components/DonutChart.jsx';
import { useEffect, useState } from "react";

export default function Macros() {
    const [data, setData] = useState(null);
    const [loading, setLoading] = useState(true); // Add loading state
    const [error, setError] = useState(null); // Add error state

    useEffect(() => {
        const fetchData = async () => {
            const token = localStorage.getItem('token');
            if (!token) {
                setError('No token found. Please log in.');
                setLoading(false); // Stop loading since no token
                return;
            }

            try {
                const response = await fetch('http://localhost:5155/ShoppingList/User', {
                    method: 'GET',
                    headers: {
                        'Authorization': `Bearer ${token}`,
                        'Content-Type': 'application/json'
                    }
                });

                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }

                const result = await response.json();
                setData(result);
                console.log("data: ", JSON.stringify(result, null, 2));
            } catch (error) {
                console.error("Fetch error: ", error);
                setError(error.message);
            } finally {
                setLoading(false); // Stop loading regardless of success or failure
            }
        };

        fetchData();
    }, []);

    if (loading) {
        return <div className='loading'>Loading...</div>; // Show loading state
    }

    if (error) {
        return <div className='error'>{error}</div>; // Show error message if any
    }

    return (
        <div>
            <div className='container'>
                <h1 className='title'>Macros</h1>
            </div>
            <div className='container'>
                <div className='containerMacros'>
                    <br/> <br/>
                    <div>
                        <DonutChart width={400} height={400}/>
                    </div>
                    <br/> <br/> <br/>
                    <div className="Dashboarddatacontainer">
                        <div className='textcon'>
                            <p className='dashboard'>{data.kcalGoal}</p>
                            <p className='information'>Kcal Left</p>

                        </div>
                        <div className='textcon'>
                            <h2 className='dashboard'>{data.kcalCurrent}</h2>
                            <p className='information'>Kcal Consumed</p>
                        </div>
                        <div className='textcon'>
                            <p className='dashboard'>{data.kcalGoal - data.kcalCurrent}</p>
                            <p className='information'>Kcal Goal</p>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}
