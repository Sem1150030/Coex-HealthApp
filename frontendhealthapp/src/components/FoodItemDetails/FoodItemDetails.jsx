import './FoodItemDetails.css'
import PropTypes from "prop-types";
import {useEffect} from "react";
import PieChart from "../Charts/PieChart.jsx";

 function FoodItemDetails({ isOpen, onClose, foodItem }) {
     useEffect(() => {
     }, [foodItem]);

     if (!isOpen) return null; // Do not render anything if the modal is not open

     async function handleClickDeleteItem(foodItemId, foodId) {


         const jwtToken = localStorage.getItem('token')

         try {
             // const res = await fetch('http://localhost:5155/ShoppingList/DeleteItem/' + foodItemId + "/" + foodId,
             const res = await fetch('http://192.168.178.129:8001/ShoppingList/DeleteItem/' + foodItemId + "/" + foodId,
                 {
                 method: 'DELETE',
                 headers: {
                     'Content-Type': 'application/json',
                     'Authorization': `Bearer ${jwtToken}`  // Add JWT token in the Authorization header
                 },
                  // Convert data to JSON
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
                <div className='detailsheader'>
                    <h1 className="detailheadertitle">{foodItem.foodItem.name}</h1>
                    <button className='closeButton' onClick={onClose}>X</button>

                </div>
                <br/>
                <hr/>
                <br/>
                <div className="dataDetails">
                    <div className='Piechart'>
                        <PieChart/>
                    </div>
                    <br/>
                    <hr/>
                    <br/>

                    <div className='nutrition'>
                        <table style={{borderCollapse: 'collapse', width: '100%'}}>
                            <tbody className='nutrtiontb'>
                                <tr>
                                    <td className='id' style={{border: '1px solid black', padding: '8px'}}>Kcal:</td>
                                    <td style={{
                                        border: '1px solid black',
                                        padding: '8px'
                                    }}>{foodItem.foodItem.kcalAmount}</td>
                                </tr>
                                <tr>
                                    <td className='id' style={{border: '1px solid black', padding: '8px'}}>Protein:</td>
                                    <td style={{
                                        border: '1px solid black',
                                        padding: '8px'
                                    }}>{foodItem.foodItem.proteinAmount}gr
                                    </td>
                                </tr>
                                <tr>
                                    <td className='id' style={{border: '1px solid black', padding: '8px'}}>Carbs:</td>
                                    <td style={{border: '1px solid black', padding: '8px'}}>30gr</td>
                                </tr>
                                <tr>
                                    <td className='id' style={{border: '1px solid black', padding: '8px'}}>Fat:</td>
                                    <td style={{border: '1px solid black', padding: '8px'}}>24gr</td>
                                </tr>
                                <tr>
                                    <td className='id' style={{border: '1px solid black', padding: '8px'}}>Measurement:</td>
                                    <td style={{
                                        border: '1px solid black',
                                        padding: '8px'
                                    }}>{foodItem.foodItem.measurement}</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    {/*<br/>*/}
                    {/*<br/>*/}

                    <div className='block'>
                        <button className='removeitem'
                                onClick={() => handleClickDeleteItem(foodItem.id, foodItem.foodItem.id)}>Remove
                        </button>
                        <br/>
                    </div>
                </div>
            </div>
        </div>
    );
 };

FoodItemDetails.propTypes = {
    isOpen: PropTypes.bool.isRequired,
    onClose: PropTypes.func.isRequired,
    foodItem: PropTypes.object,
};
export default FoodItemDetails;


