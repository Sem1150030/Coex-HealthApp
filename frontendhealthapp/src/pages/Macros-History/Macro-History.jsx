import './Macro-History.css'
import {useEffect, useState} from "react";
import {baseUrl} from "../../config.js";

import {useNavigate} from "react-router-dom";

export default function MacroHistory() {

    const [macros, setMacros] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const navigate = useNavigate()

    // const borderColor = goalsMet === 4 ? 'darkgreen' : goalsMet === 3 ? 'green' : goalsMet === 2 ? 'orange' :  'red';

    useEffect(() => {
        const fetchData = async () => {
            const token = localStorage.getItem('token');
            if (!token) {
                setError('No token found. Please log in.');
                setLoading(false);
                return;
            }

            try {
                const responseMacros = await fetch(baseUrl + '/ShoppingList', {
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

                const sortedResult = result.sort((a, b) => new Date(b.createdOn) - new Date(a.createdOn));

                setMacros(sortedResult);
                // console.log("data: ", JSON.stringify(result, null, 2));
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

    function CheckGoalsMet(data){
        let quantity = 0;
        if (data.kcalGoal > data.kcalCurrent && data.kcalMax === true){
            quantity++;
        }
        if (data.proteinGoal < data.proteinCurrent){
            quantity++;
        }
        if (data.carbGoal > data.carbCurrent){
            quantity++;
        }
        if (data.fatGoal > data.fatCurrent){
            quantity++;
        }
        // setGoalsMet(quantity)
        return quantity;
    }

    return (
        <>
            <div className='container'>
                <h1 className='title'>Macro history</h1>
            </div>

            <div className='container'>
                <div className='containerSettings'>
                    <br/>
                    <h2>History</h2>
                    <br/><hr/><br/><br/>

                    {macros.map((macros) => {
                        const goalsMetCount = CheckGoalsMet(macros);
                        return (
                            <div  key={macros.id} className="shoppingListItemContainerH" >

                                <div className="arrayItemsH" >

                                    <div className="foodNameContainer">
                                        <p className="foodName"> {macros.createdOn.split("T")[0]} </p>
                                        <p className="foodMeasurement">{macros.kcalGoal}/{macros.kcalCurrent} Kcal</p>
                                    </div>

                                    <p className="kcalAmount button-like"
                                       role="button"
                                       tabIndex={0}
                                       onClick={() => navigate(`/macros/history/details?SLId=${macros.id}`)}
                                    >{goalsMetCount}/4 Goals
                                    </p>


                                </div>
                            </div>

                        );
                    })}
                </div>
            </div>
        </>
    );

}