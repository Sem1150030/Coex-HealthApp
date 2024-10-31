import PropTypes from "prop-types";
import CreateNewFoodItem from "../CreateNewFoodItem/CreateNewFoodItem.jsx";
import {useEffect, useState} from "react";
import './SetDetails.css'
import weightIcon from '../../../src/assets/icons8-weightlifting-100.png'

import {baseUrl} from "../../config.js";

function SetDetails({isOpenUpdate, OnCloseUpdate, data}){

    const [formData, setFormData] = useState({
        reps: {setReps},
        weight: {setWeight}
    });



    useEffect(() => {

        if (isOpenUpdate) {
            document.body.classList.add('no-scroll'); // Hide scrollbar when modal is open
        } else {
            document.body.classList.remove('no-scroll'); // Restore scrollbar when modal is closed
        }

        // Cleanup on component unmount or when modal closes
        return () => {
            document.body.classList.remove('no-scroll');
        };
    }, [isOpenUpdate]);

    if(isOpenUpdate === false){
        return null;
    }

    function setWeight(){
        let weight = data.weight
        if (weight === 0){
            return weight = ''
        }
        return weight
    }


    function setReps(){
        let reps = data.reps
        if (reps === 0){
            return reps = ''
        }
        return reps
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



        var requestData = {
            id: data.id,
            reps: parseInt(formData.reps) ,
            weight: parseInt(formData.weight),
            exerciseId: data.exerciseId
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

            const res = await fetch( baseUrl + '/Workout/UpdateSet',
                {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${jwtToken}`  // Add JWT token in the Authorization header
                    },
                    body: JSON.stringify(requestData)  // Convert data to JSON
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
        <div className="modal-overlay" onClick={OnCloseUpdate}>
            <div className="modal-content-set" onClick={(e) => e.stopPropagation()}>
                <h2>Update Set</h2>
                <br/>
                <hr/>
                <br/>

                <form>
                    <div className='IconContainer'>
                        <img src={weightIcon} alt="weightIcon" height={100} width={100}/>
                    </div>
                    <div>
                        <p className='information'>Reps</p>
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
                        <p className='information'>Weight</p>
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
                <button type="submit" className='AddSetButton' onClick={handleSubmit}>Update</button>

                <button onClick={OnCloseUpdate} className="close-button">Cancel</button>
            </div>
        </div>
    )

}

CreateNewFoodItem.propTypes = {
    isOpenUpdate: PropTypes.bool.isRequired,
    OnCloseUpdate: PropTypes.func.isRequired,
    data: PropTypes.any.isRequired
};

export default SetDetails;