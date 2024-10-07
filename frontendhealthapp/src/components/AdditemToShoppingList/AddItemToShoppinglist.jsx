
// import PropTypes, {func} from "prop-types";
import {useEffect, useState} from "react";
import PropTypes from "prop-types";
import './AddItemToShoppinglist.css'
import CreateNewFoodItem from "../CreateNewFoodItem/CreateNewFoodItem.jsx";

function AddItemToShoppinglist({ isOpen, onClose }) {
    const [loading, setLoading] = useState(true); // Add loading state
    const [error, setError] = useState(null); // Add error state
    const [fooditems, setFooditems] = useState([{}]); // Add error state
    const [isCreateFoodItemOpen, SetisCreateFoodItemOpen] = useState(false);

    function handleClickCreateItem(){
        SetisCreateFoodItemOpen(true);
    }

    function closeCreateItem(){
        SetisCreateFoodItemOpen(false);
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
                // const response = await fetch('http://localhost:5155/Fooditem/User',
                const response = await fetch('http://192.168.178.129:8001/Fooditem/User',


                    {
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
                setFooditems(result);
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

    useEffect(() => {
        if (isOpen) {
            document.body.classList.add('no-scroll'); // Hide scrollbar when modal is open
        } else {
            document.body.classList.remove('no-scroll'); // Restore scrollbar when modal is closed
        }

        // Cleanup on component unmount or when modal closes
        return () => {
            document.body.classList.remove('no-scroll');
        };

    }, [isOpen]);



    if (!isOpen) return null;

    if (loading) {
        return <div className='loading'>Loading...</div>;
    }

    if (error) {
        return <div className='error'>{error}</div>; // Show error message if any
    }

    async function handleClickAddItem(foodItemId) {

        const postData = {
            foodItemId: foodItemId
        };
        const jwtToken = localStorage.getItem('token')

        try {
            // const res = await fetch('http://localhost:5155/ShoppingList/AddItem',
            const res = await fetch('http://192.168.178.129:8001/ShoppingList/AddItem',
                {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${jwtToken}`  // Add JWT token in the Authorization header
                },
                body: JSON.stringify(postData)  // Convert data to JSON
            });

            const result = await res.json();
            console.log(result)
        } catch (error) {
            console.error('Error:', error);  // Handle error here
        }
        finally {
            window.location.reload();
        }
    };


    return (
        <div className="modal-overlay" onClick={onClose}>
            <div>
                <div className="modal-content" onClick={e => e.stopPropagation()}>
                    <div className='detailsheader'>
                        <h1 className="detailheadertitle">Add item</h1>
                        <button className='closeButton' onClick={onClose}>X</button>
                    </div>
                    <br/>
                    <hr/>
                    <br/>
                    <div className="table-container">
                        <table>
                            <thead>
                            <tr >
                                <th>&nbsp;Name</th>
                                <th>Measurement</th>
                                <th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Add</th>
                            </tr>
                            </thead>
                            <tbody>
                            {fooditems.map((foodItem) => (
                                <tr onClick={() => (console.log('helloworld'))} className="addItem" key={foodItem.id}>

                                    <td>&nbsp;{foodItem.name}</td>
                                    <td>&nbsp;{foodItem.measurement}</td>

                                    <td>

                                        <button className='Add' onClick={() => handleClickAddItem(foodItem.id)}>Add
                                        </button>
                                    </td>
                                </tr>
                            ))}
                            </tbody>
                        </table>
                    </div>
                    <button className="Add" onClick={handleClickCreateItem}>New Food Item</button>
                </div>
            </div>

            <CreateNewFoodItem isOpenCreate={isCreateFoodItemOpen} OnCloseCreate={closeCreateItem} />
        </div>
    );
};

AddItemToShoppinglist.propTypes = {
    isOpen: PropTypes.bool.isRequired,
    onClose: PropTypes.func.isRequired,
};
export default AddItemToShoppinglist;


