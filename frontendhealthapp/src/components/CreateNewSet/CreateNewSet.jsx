import PropTypes from "prop-types";
import CreateNewFoodItem from "../CreateNewFoodItem/CreateNewFoodItem.jsx";
import {useEffect, useState} from "react";
import './CreateNewSet.css'
import weightIcon from '../../../src/assets/icons8-weightlifting-100.png'
import foodicon from "../../assets/icons8-food-and-drink-96.png";
import {baseUrl} from "../../config.js";

function CreateNewSet({isOpenCreate, OnCloseCreate, exceriseId}){

    const [formData, setFormData] = useState({
        reps: '',
        weight: '',
    });

    useEffect(() => {

        if (isOpenCreate) {
            document.body.classList.add('no-scroll'); // Hide scrollbar when modal is open
        } else {
            document.body.classList.remove('no-scroll'); // Restore scrollbar when modal is closed
        }

        // Cleanup on component unmount or when modal closes
        return () => {
            document.body.classList.remove('no-scroll');
        };
    }, [isOpenCreate]);

    if(isOpenCreate === false){
        return null;
    }

    function handleChange (e) {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value
        });
    };

    async function handleSubmit (e) {
        e.preventDefault();
        console.log(formData);
        console.log(exceriseId)


        var requestData = {
            reps: parseInt(formData.reps) ,
            weight: parseInt(formData.weight),
            exerciseId: exceriseId
        }
        console.log(requestData)
        if (formData.reps < 0 || formData.weight < 0){
            return alert('weight or reps  cannot be negative')
        }

        if (formData.reps > 9999 || formData.weight > 9999){
            return alert('weight or reps cannot be above 9999')
        }

        const jwtToken = localStorage.getItem('token')

        try {

            const res = await fetch( baseUrl + '/Workout/addset',
                {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${jwtToken}`  // Add JWT token in the Authorization header
                    },
                    body: JSON.stringify(requestData)  // Convert data to JSON
                });



            let result = await res.json();

            console.log(result)
            alert('Set Add')
            window.location.reload();
        } catch (error) {
            console.error('Error:', error);  // Handle error here
            alert('Error: ' + error)
        }

    };

    return (
        <div className="modal-overlay" onClick={OnCloseCreate}>
            <div className="modal-content-set" onClick={(e) => e.stopPropagation()}>
                <h2>Create New Set</h2>
                <br/>
                <hr/>
                <br/>


                <form>
                    <div className='IconContainer'>
                        <img src={weightIcon} alt="weightIcon" height={100} width={100}/>
                    </div>
                    <div>

                        <input className='CreateInputSet'
                               type="number"
                               name="reps"
                               placeholder="Amount of Reps"
                               value={formData.reps}
                               onChange={handleChange}
                               required

                        />
                    </div>
                    <div>

                        <input className='CreateInputSet'
                               type="number"
                               name="weight"
                               placeholder="Weight (Kilo)"
                               value={formData.weight}
                               onChange={handleChange}
                               required
                        />
                    </div>

                </form>
                <button type="submit" className='AddSetButton' onClick={handleSubmit}>Add Set</button>

                <button onClick={OnCloseCreate} className="close-button">Close</button>
            </div>
        </div>
    )

}

CreateNewFoodItem.propTypes = {
    isOpenCreate: PropTypes.bool.isRequired,
    OnCloseCreate: PropTypes.func.isRequired,
};

export default CreateNewSet;