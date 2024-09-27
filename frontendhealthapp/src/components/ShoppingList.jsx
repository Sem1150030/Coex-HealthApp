import PropTypes from "prop-types";
import {useEffect} from "react";



function ShoppingList({ data }) {
    function li() {
        return console.log(data)
    }

    useEffect(() => {
        console.log(data); // Will log only when data changes
    }, [data]);
    return (
        <div>
            <h2 className="titleShoppinglist">Shopping List</h2>

            <div>
                {data.map((foodItem) => {

                    return <div key={foodItem.id}>{foodItem.foodItem.name} - {foodItem.foodItem.kcalAmount}</div>;
                })}

            </div>
        </div>
    );
}

ShoppingList.propTypes = {
    data: PropTypes.array.isRequired,  // Added isRequired to enforce prop type validation
};

export default ShoppingList;
