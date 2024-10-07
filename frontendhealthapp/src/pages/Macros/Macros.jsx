import './Macros.css';
import DonutChart from '../../components/Charts/DonutChart.jsx';
import { useEffect, useState } from "react";
import MacroDashboardData from "../../components/MacroDashboardData.jsx";
import ShoppingList from "../../components/ShoppingList.jsx";

export default function Macros() {
    const [data, setData] = useState(null);
    const [loading, setLoading] = useState(true); // Add loading state
    const [error, setError] = useState(null); // Add error state
    const [shoppingListFoodItems, setShoppingListFoodItems] = useState([{}]);



    useEffect(() => {
        const fetchData = async () => {
            const token = localStorage.getItem('token');
            if (!token) {
                setError('No token found. Please log in.');
                setLoading(false); // Stop loading since no token
                return;
            }

            try {
                // const response = await fetch('http://localhost:5155/ShoppingList/User',
                const response = await fetch('http://192.168.178.129:8001/ShoppingList/User',{
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
                setShoppingListFoodItems(result.shoppingListFoodItems);
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
                <h1 className='title'>Macros</h1>
            </div>
            <div className='container'>
                <div className='containerMacros'>
                    <br/><br/>
                    <DonutChart dataProp={data} width={400} height={400}/>
                    <MacroDashboardData data={data} />

                </div>
            </div>
            <div className='container'>
                <div className='containerShoppinglistMacros'>
                    <br/><br/>

                    <ShoppingList data={shoppingListFoodItems}/>
                </div>
            </div>

        </div>
    );
}
