
// import PropTypes, {func} from "prop-types";
import {useEffect, useState} from "react";
import PropTypes from "prop-types";

function AddItemToShoppinglist({ isOpen, onClose }) {
    const [loading, setLoading] = useState(true); // Add loading state
    const [error, setError] = useState(null); // Add error state
    const [fooditems, setFooditems] = useState([{}]); // Add error state

    useEffect(() => {
        const fetchData = async () => {
            const token = localStorage.getItem('token');
            if (!token) {
                setError('No token found. Please log in.');
                setLoading(false); // Stop loading since no token
                return;
            }

            try {
                const response = await fetch('http://localhost:5155/Fooditem/User', {
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
            const res = await fetch('http://localhost:5155/ShoppingList/AddItem', {
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
            <div className="modal-content" onClick={e => e.stopPropagation()}>
                {fooditems.map((foodItem) => {
                    return (
                        <div className="arrayItems" key={foodItem.id}>
                            {foodItem.name} -
                            <button onClick={() => handleClickAddItem(foodItem.id)}>Add</button>
                        </div>
                    );
                })}
                <button onClick={onClose}>Close</button>
            </div>
        </div>
    );
};

AddItemToShoppinglist.propTypes = {
    isOpen: PropTypes.bool.isRequired,
    onClose: PropTypes.func.isRequired,
};
export default AddItemToShoppinglist;


