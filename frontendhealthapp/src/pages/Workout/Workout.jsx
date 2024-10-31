import { Link } from 'react-router-dom';
import './Workout.css';
import {useEffect, useState} from "react";
import {baseUrl} from "../../config.js";
import { useNavigate } from 'react-router-dom';
import CreateNewSet from "../../components/CreateNewSet/CreateNewSet.jsx";
import AddWorkout from "../../components/AddWorkout/AddWorkout.jsx";


export default function Workout() {

    const [data, setData] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [workoutData, setWorkoutData] = useState([{}]);
    const navigate = useNavigate();
    const [isCreateFoodItemOpen, SetisCreateFoodItemOpen] = useState(false);



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

    function handleClick(exc){
        navigate(`/workoutDetails?workoutId=${exc.id}`);
    }

    function handleClickCreateItem() {
        SetisCreateFoodItemOpen(true);

    }

    function closeCreateItem() {
        SetisCreateFoodItemOpen(false);
    }

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
            <div className='containerWB'>
                <button className='Add' onClick={handleClickCreateItem}>Add Workout</button>
            </div>
            <div className="Workoutcont">

                <br/>
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
                                <button   onClick={() => handleClick(workout)} className='buttondetails'>Details</button>
                            </div>

                        </div>
                    </div>

                ))}

            </div>
            <br/> <br/>

            <AddWorkout isOpenCreate={isCreateFoodItemOpen} OnCloseCreate={closeCreateItem} />

        </div>
    );
}