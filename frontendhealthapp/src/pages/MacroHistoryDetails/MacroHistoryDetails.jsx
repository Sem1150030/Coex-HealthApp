import DonutChart from '../../components/Charts/DonutChart.jsx';
import MacroDashboardData from "../../components/MacroDashboardData.jsx";
import ShoppingList from "../../components/ShoppingList.jsx";
import {useEffect, useState} from "react";
import {baseUrl} from "../../config.js";



function MacroHistoryDetails() {

    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [data, setData] = useState(null);
    const queryParams = new URLSearchParams(location.search);
    const workoutId = queryParams.get('SLId');


    useEffect(() => {
        const fetchData = async () => {
            const token = localStorage.getItem('token');
            if (!token) {
                setError('No token found. Please log in.');
                setLoading(false); // Stop loading since no token
                return;
            }

            try {
                const response = await fetch( baseUrl + '/ShoppingList/' + workoutId,{
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
        return <div className='loading'>Loading...</div>;
    }
    if (error) {
        return <div className='error'>{error}</div>;
    }


    return (
        <div>
            <div className='container'>
                <h1 className='title'>Macros</h1>

            </div>
            <div className='container'>
                <div className='containerMacros'>

                    <br/><br/>
                    <p>{data.createdOn.split("T")[0]}</p>
                    <DonutChart dataProp={data} width={400} height={400}/>
                    <MacroDashboardData data={data}/>

                </div>
            </div>
            <div className='container'>
                <div className='containerShoppinglistMacros'>
                    <br/><br/>

                    <ShoppingList data={data.shoppingListFoodItems} isHistory={true}/>
                </div>
            </div>

        </div>
    );
}



export default MacroHistoryDetails;
