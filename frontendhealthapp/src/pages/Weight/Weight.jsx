import LineChart from "../../components/Charts/LineChart.jsx";
import './Weight.css';
import {useEffect, useState} from "react";
import {func} from "prop-types";
import {baseUrl}  from "../../config.js";

export default function Weight() {

    const [data, setData] = useState(null);
    const [loading, setLoading] = useState(true); // Add loading state
    const [error, setError] = useState(null); // Add error state
    const [filter, setFilter] = useState('week');

    function handleFilterChange(event) {
        setFilter(event.target.value);
    }

    useEffect(() => {
        const fetchData = async () => {
            const token = localStorage.getItem('token');
            if (!token) {
                return;
            }

            try {
                // const response = await fetch('http://localhost:5155/ShoppingList/User',
                const response = await fetch(  baseUrl + '/Weight',{
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
                setLoading(false);

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


                <h1 className='title'>Weight</h1>
            </div>

            <div className="linechartContainer">
                <div className="linechartContainer">
                    <select value={filter} onChange={handleFilterChange}>
                        <option value="week">Week</option>
                        <option value="month">Month</option>
                        <option value="year">Year</option>
                    </select>

                    <LineChart filter={filter} dataProp={data} todaysData={{"date": "2024-10-07T00:00:00"}}/>
                </div>
            </div>
        </div>
    );
}