import React, { useEffect, useState } from "react";
import LineChart from "../../components/Charts/LineChart.jsx";
import { baseUrl } from "../../config.js";
import './Weight.css';

export default function Weight() {

    const [data, setData] = useState(null);
    const [dataToday, setDataToday] = useState({});
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [filter, setFilter] = useState('week');
    const [currentWeight, setCurrentWeight] = useState('');
    const [goalWeight, setGoalWeight] = useState('');

    function handleFilterChange(event) {
        setFilter(event.target.value);
    }

    function handleCurrentWeightChange(e) {
        setCurrentWeight(e.target.value);
    }

    function handleGoalWeightChange(e) {
        setGoalWeight(e.target.value);
    }

    async function handleGoalWeightSubmit(e) {
        e.preventDefault();
        const token = localStorage.getItem('token');
        let formData = {
            "weight": currentWeight,
            "weightGoal": goalWeight
        };
        try {
            const res = await fetch(baseUrl + '/UpdateWeightData', {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`
                },
                body: JSON.stringify(formData)
            });

            let result = await res.json();
            alert('Weight Data Updated');
            window.location.reload();
        } catch (error) {
            console.error('Error:', error);
            alert('Error: ' + error);
        }
    }

    // Fetching overall weight data
    useEffect(() => {
        const fetchData = async () => {
            const token = localStorage.getItem('token');
            if (!token) {
                return;
            }

            try {
                const response = await fetch(baseUrl + '/Weight', {
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
            } catch (error) {
                console.error("Fetch error: ", error);
                setError(error.message);
            } finally {
                setLoading(false);
            }
        };

        fetchData();
    }, []);

    // Fetching today's weight data
    useEffect(() => {
        const fetchDataToday = async () => {
            const token = localStorage.getItem('token');
            if (!token) {
                return;
            }

            try {
                const response = await fetch(baseUrl + '/WeightToday', {
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
                setDataToday(result);

                // Once dataToday is fetched, set the weight and weight goal
                if (result.weight) setCurrentWeight(result.weight);
                if (result.weightGoal) setGoalWeight(result.weightGoal);

            } catch (error) {
                console.error("Fetch error: ", error);
                setError(error.message);
            } finally {
                setLoading(false);
            }
        };

        fetchDataToday();
    }, []);  // Fetch only on component mount

    if (loading) {
        return <div className='loading'>Loading...</div>;
    }

    if (error) {
        return <div className='error'>{error}</div>;
    }

    return (
        <div>
            <div className='container'>
                <h1 className='title'>Weight</h1>
            </div>

            <div className="linechartContainer">
                <div className='linechartContainer'>
                    <h2>Weight Tracker</h2>
                    <br />
                    <select className="select" value={filter} onChange={handleFilterChange}>
                        <option value="week">Week</option>
                        <option value="month">Month</option>
                        <option value="year">Year</option>
                    </select>

                    <LineChart filter={filter} dataProp={data} todaysData={{ "date": "2024-10-07T00:00:00" }} />


                <div className="WeightFormContainer">
                    <form className="WeightForm">
                        <br/>
                        <div >
                            <label className='information'>Current weight</label> <br/>

                            <input
                                className="WeightInput"
                                placeholder="Current weight"
                                type="number"
                                value={currentWeight || ''}  // Set default value
                                onChange={handleCurrentWeightChange}
                            />

                            <button className="Add" type="submit" onClick={handleGoalWeightSubmit}>
                                Set
                            </button>
                        </div>
                        <br/>

                        <br/><label className='information'>Weight goal</label> <br/>
                        <input
                            className="WeightInput"
                            placeholder="Weight goal"
                            type="number"
                            value={goalWeight || ''}  // Set default value
                            onChange={handleGoalWeightChange}
                        />

                        <button className="Add" type="submit" onClick={handleGoalWeightSubmit}>
                            Set
                        </button>
                    </form>
                </div>
                </div>
            </div>
        </div>
    );
}
