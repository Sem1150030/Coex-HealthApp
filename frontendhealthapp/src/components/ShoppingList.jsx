import PropTypes from "prop-types";
import {useEffect, useState} from "react";
import FoodItemDetails from "./FoodItemDetails/FoodItemDetails.jsx";
// import lightningImg from "../assets/icons8-lightning-48.png"
import addicon from "../assets/icons8-add-50.png"
import AddItemToShoppinglist from "./AdditemToShoppingList/AddItemToShoppinglist.jsx";



function ShoppingList({ data  }) {
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [selectedFoodItem, setSelectedFoodItem] = useState(null);
    const [isAddItemOpen, setisAddItemOpen] = useState(false);


    useEffect(() => {
        console.log(data); // Will log only when data changes
    }, [data]);

    function handleClick(foodItem) {
        setSelectedFoodItem(foodItem);
        setIsModalOpen(true);
    }

    function handleClickAddItem() {
        setisAddItemOpen(true);
    }



    function closeAddItem(){
        setisAddItemOpen(false);
    }



    function closeModal() {
        setIsModalOpen(false);
        setSelectedFoodItem(null);
    }

    return (
        <div>
            <div className='titlecontainer'>
                <h2 className="titleShoppinglist">Shopping List</h2>
                <div className="imageAdd">
                    <img src={addicon} alt="add icon" className="addicon" height={40} width={40}
                         role="button"
                         tabIndex={0}
                         onClick={() => handleClickAddItem() }/>
                </div>
            </div>
            <br/>
            <hr/>
            <br/>
            <div className="shoppingListItemContainer">
                {data.map((foodItem) => {
                    return (
                        <div className="arrayItems" key={foodItem.id}>
                            <div className="foodNameContainer">
                                <p className="foodName"> {foodItem.foodItem.name} </p>
                                <p className="foodMeasurement">{foodItem.foodItem.measurement}</p>
                            </div>

                            <p className="kcalAmount button-like"
                               role="button"
                               tabIndex={0}
                               onClick={() => handleClick(foodItem)}>{foodItem.foodItem.kcalAmount} kcal
                            </p>
                        </div>
                    );
                })}
            </div>
            <FoodItemDetails
                isOpen={isModalOpen}
                onClose={closeModal}
                foodItem={selectedFoodItem}
            />

            <AddItemToShoppinglist onClose={closeAddItem} isOpen={isAddItemOpen} />
        </div>
    );
}

ShoppingList.propTypes = {
    data: PropTypes.array.isRequired,  // Added isRequired to enforce prop type validation
};

export default ShoppingList;
