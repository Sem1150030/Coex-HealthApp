import './WorkoutDetails.css';
import { useEffect, useState } from "react";
import { baseUrl } from "../../config.js";
import {useLocation, useNavigate} from 'react-router-dom';
import CreateNewFoodItem from "../../components/CreateNewFoodItem/CreateNewFoodItem.jsx";
import CreateNewSet from "../../components/CreateNewSet/CreateNewSet.jsx";
import SetDetails from "../../components/SetDetails/SetDetails.jsx";
import AddWorkout from "../../components/AddWorkout/AddWorkout.jsx";
import AddExcercise from "../../components/AddExcercise/AddExcercise.jsx";
import trashIcon from '../../../src/assets/icons8-delete-48.png'


export default function WorkoutDetails() {

    const [data, setData] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [excerciseId, setExcerciseId] = useState(null);
    const location = useLocation();
    const queryParams = new URLSearchParams(location.search);
    const workoutId = queryParams.get('workoutId'); // Retrieve the workoutId
    const [isCreateFoodItemOpen, SetisCreateFoodItemOpen] = useState(false);
    const [isUpdateSetOpen, SetisUpdateSetOpen] = useState(false);
    const [isCreateExcerciseOpen, SetCreateExcerciseOpen] = useState(false);
    const [setInfo, setSetInfo] = useState(null);
    const navigate = useNavigate();


    function handleClickCreateExcercis() {
        SetCreateExcerciseOpen(true);

    }

    function closeCreateExcercis() {
        SetCreateExcerciseOpen(false);
    }

    function handleClickCreateItem(excId) {
        setExcerciseId(excId);
        SetisCreateFoodItemOpen(true);

    }

    function closeCreateItem() {
        SetisCreateFoodItemOpen(false);
    }

    function handleClickUpdateItem(set) {
        setSetInfo(set);
        SetisUpdateSetOpen(true);

    }
    function closeUpdateItem() {
        SetisUpdateSetOpen(false);
    }

    async function handleDelete(setId){
        const jwtToken = localStorage.getItem('token')
        console.log(setId)
        try {
            const res = await fetch( baseUrl + '/Workout/DeleteSet/' + setId,
                {
                    method: 'DELETE',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${jwtToken}`  // Add JWT token in the Authorization header
                    },
                });
            let result = await res.json();

            console.log(result)
            alert('Set deleted')
            window.location.reload();
        } catch (error) {
            console.error('Error:', error);  // Handle error here
            alert('Error: ' + error)
        }
    }

    useEffect(() => {
        const fetchData = async () => {
            const token = localStorage.getItem('token');
            if (!token) {
                setError('No token found. Please log in.');
                setLoading(false); // Stop loading since no token
                return;
            }

            try {
                const response = await fetch(baseUrl + '/Workout/user/' + workoutId, {
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

    async function handleExcerciseDelete(excerciseId){
        const jwtToken = localStorage.getItem('token')
        console.log(excerciseId)
        try {
            const res = await fetch( baseUrl + '/Workout/DeleteExcercise/' + excerciseId,
                {
                    method: 'DELETE',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${jwtToken}`  // Add JWT token in the Authorization header
                    },
                });
            let result = await res.json();

            console.log(result)
            alert('Excercise deleted')
            window.location.reload();
        } catch (error) {
            console.error('Error:', error);  // Handle error here
            alert('Error: ' + error)
        }
    }

    async function handleDeleteWorkout(){
        const jwtToken = localStorage.getItem('token')
        console.log(workoutId)
        try {
            const res = await fetch( baseUrl + '/Workout/DeleteWorkout/' + workoutId,
                {
                    method: 'DELETE',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${jwtToken}`  // Add JWT token in the Authorization header
                    },
                });
            let result = await res.json();

            console.log(result)
            alert('Workout deleted')
            navigate('/workout')
        } catch (error) {
            console.error('Error:', error);  // Handle error here
            alert('Error: ' + error)
        }
    }

    if (loading) {
        return <div className='loading'>Loading...</div>;
    }

    if (error) {
        return <div className='error'>{error}</div>;
    }

    return (
        <div>
            <div className='detailcontainer'>
                <div className="containerWorkoutName">
                    <h1>{data.name}</h1>
                </div>
                <br/><br/>

                <button onClick={() => handleClickCreateExcercis()} className='Add'>Add Excercise</button>

                {data.exercises.map((exc, index) => (
                    <div key={index} className="exercisesContainer">
                        <div className='exerciseBox'>
                            <h2>{exc.name}</h2>

                            <button className="plusButton" onClick={() => handleClickCreateItem(exc.id)}>+</button>
                            <img onClick={() => handleExcerciseDelete(exc.id)} src={trashIcon} alt='trashcan'
                                 className="deleteExcercise" height={25} width={25}></img>
                        </div>

                        {exc.sets.map((set, index) => (
                            <div key={index} onClick={() => handleClickUpdateItem(set)} className="SetContainer">
                                <div className="setBox">
                                    <h3>Set {index + 1}</h3>
                                    <p>Reps: {set.reps}</p>
                                    <p>Weight: {set.weight}</p>
                                </div>

                                <button
                                    className="deleteButton"
                                    onClick={(e) => {
                                        e.stopPropagation();  // Prevents event from bubbling up
                                        handleDelete(set.id);  // Executes delete function
                                    }}
                                >
                                    Delete
                                </button>

                            </div>
                        ))}


                    </div>
                ))}
                <button onClick={handleDeleteWorkout} className='workoutDelete'> Delete Workout</button>
            </div>
            <CreateNewSet isOpenCreate={isCreateFoodItemOpen} OnCloseCreate={closeCreateItem} exceriseId={excerciseId} />
            <SetDetails isOpenUpdate={isUpdateSetOpen} OnCloseUpdate={closeUpdateItem} data={setInfo} />
            <AddExcercise isOpenAddExcercise={isCreateExcerciseOpen} OnCloseAddExcercise={closeCreateExcercis} workoutId={workoutId} />
        </div>
    );
}
