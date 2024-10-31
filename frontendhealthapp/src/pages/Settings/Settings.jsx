import './Settings.css';
import { baseUrl } from "../../config.js";
import { useEffect, useState } from "react";
import {useNavigate, useNavigation} from "react-router-dom";

function Settings() {

    const [macros, setMacros] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    // States to store input values
    const [kcalGoal, setKcalGoal] = useState('');
    const [proteinGoal, setProteinGoal] = useState('');
    const [carbLimit, setCarbLimit] = useState('');
    const [fatLimit, setFatLimit] = useState('');
    const [kcalMacro, setKcalMacro] = useState('');
    const navigate = useNavigate();

    useEffect(() => {
        const fetchData = async () => {
            const token = localStorage.getItem('token');
            if (!token) {
                setError('No token found. Please log in.');
                setLoading(false);
                return;
            }

            try {
                const responseMacros = await fetch(baseUrl + '/ShoppingList/User/', {
                    method: 'GET',
                    headers: {
                        'Authorization': `Bearer ${token}`,
                        'Content-Type': 'application/json'
                    }
                });

                if (!responseMacros.ok) {
                    throw new Error('Network response was not ok');
                }

                const result = await responseMacros.json();
                setMacros(result);

                // Set initial values for the input fields
                setKcalGoal(result.kcalGoal || 0);
                setProteinGoal(result.proteinGoal || 0);
                setCarbLimit(result.carbGoal || 0);
                setFatLimit(result.fatGoal || 0);
                setKcalMacro(result.kcalMax || true);

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

    // Handle save button click
    async function handleSave(){
        const updatedMacros = {
            kcalGoal: kcalGoal,
            proteinGoal: proteinGoal,
            carbGoal: carbLimit,
            fatGoal: fatLimit,
            kcalMax: kcalMacro
        };

        const jwtToken = localStorage.getItem('token')

        try {

            const res = await fetch( baseUrl + '/ShoppingList/UpdateItem/Goals',
                {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${jwtToken}`  // Add JWT token in the Authorization header
                    },
                    body: JSON.stringify(updatedMacros)  // Convert data to JSON
                });



            let result = await res.json();

            console.log(result)
            alert('Set Updated')
            window.location.reload();
        } catch (error) {
            console.error('Error:', error);  // Handle error here
            alert('Error: ' + error)
        }




    };



    return (
        <>
            <div className='container'>
                <h1 className='title'>Profile</h1>
            </div>

            <div className='container'>
                <div className='containerSettings'>
                    <br/>
                    <h2>Macros</h2>

                    <br/>
                    <hr/>
                    <br/>
                    <p>Change your Goals</p>
                    <br/>
                    <form>
                        <div>
                            <p className='information'>Kcal Goal</p>
                            <input
                                className='CreateInputSet'
                                type="number"
                                placeholder="Kcal Goal"
                                value={kcalGoal}
                                onChange={(e) => setKcalGoal(e.target.value)}
                                required
                            />

                            <p className='information'>Protein Goal</p>
                            <input
                                className='CreateInputSet'
                                type="number"
                                placeholder="Protein Goal"
                                value={proteinGoal}
                                onChange={(e) => setProteinGoal(e.target.value)}
                                required
                            />

                            <p className='information'>Carb Limit</p>
                            <input
                                className='CreateInputSet'
                                type="number"
                                placeholder="Carb Limit"
                                value={carbLimit}
                                onChange={(e) => setCarbLimit(e.target.value)}
                                required
                            />

                            <p className='information'>Fat Limit</p>
                            <input
                                className='CreateInputSet'
                                type="number"
                                placeholder="Fat Limit"
                                value={fatLimit}
                                onChange={(e) => setFatLimit(e.target.value)}
                                required
                            />
                        </div>

                        <button type="button" onClick={handleSave} className='AddSetButton'>
                            Save
                        </button>
                    </form>
                    <br/>
                    <hr/>
                    <br/>
                    <p>View your macro history</p>
                    <br/>
                    <button onClick={() => navigate('../macros/history')} type="button" className='Add'>
                        View History</button>
                </div>
            </div>
        </>
    );
}

export default Settings;
