import { Link } from 'react-router-dom';
import './Workout.css';
import {useEffect, useState} from "react";
import {baseUrl} from "../../config.js";


export default function Workout() {

    const [data, setData] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [workoutData, setWorkoutData] = useState([{}]);

    useEffect(() => {
        const fetchData = async () => {
            const token = localStorage.getItem('token');
            if (!token) {
                setError('No token found. Please log in.');
                setLoading(false); // Stop loading since no token
                return;
            }

            try {
                const response = await fetch( baseUrl + '/Workout/user',{
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
                setWorkoutData(result.setWorkoutData);
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
        return <div className='loading'>Loading...</div>;
    }

    if (error) {
        return <div className='error'>{error}</div>;
    }



    return (
        <div>
            <div className='container'>
                <h1 className='title'>Workout</h1>
            </div>
            <div className="Workoutcont">
                {data.map((workout, index) => (
                    <div key={index} className="workoutItemCont">
                        <div className='workoutItem'>
                            <div className='excerciseCont'>

                            <h2>{workout.name}</h2>
                            <hr className='lineblack'></hr>
                            {workout.exercises.slice(0, 5).map((excercise, index) => (
                                <div key={index} className='excerciseItem'>
                                    <ul className='excercise'>
                                        <li>{excercise.name}</li>
                                    </ul>

                                </div>


                            ))}
                            </div>
                            <div className="buttondetailscont">
                                <button className='buttondetails'>Details</button>
                            </div>

                        </div>
                    </div>

                ))}

            </div>


        </div>
    );
}