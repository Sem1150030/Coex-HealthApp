import PropTypes from "prop-types";
import {useEffect, useState} from "react";
import './AddExcercise.css'
import weightIcon from '../../../src/assets/icons8-rowing-machine-100.png'
import {baseUrl} from "../../config.js";

function AddWorkout({isOpenAddExcercise, OnCloseAddExcercise, workoutId}){

    const [formData, setFormData] = useState({
        name: '',

    });

    useEffect(() => {

        if (isOpenAddExcercise) {
            document.body.classList.add('no-scroll'); // Hide scrollbar when modal is open
        } else {
            document.body.classList.remove('no-scroll'); // Restore scrollbar when modal is closed
        }

        // Cleanup on component unmount or when modal closes
        return () => {
            document.body.classList.remove('no-scroll');
        };
    }, [isOpenAddExcercise]);
    console.log(isOpenAddExcercise)

    if(isOpenAddExcercise === false){
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



        var requestData = {
            name: formData.name,
            workoutId: workoutId
        }

        if(formData.name > 30){
            console.log(name.length)
            return alert('Name must be less than 30 characters')
        }
        if(formData.name < 3){
            console.log(name.length)
            return alert('Name must be more than 3 characters')

        }

        const jwtToken = localStorage.getItem('token')

        try {

            const res = await fetch( baseUrl + '/Workout/addexercise',
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
            alert('Exercise Added')
            window.location.reload();
        } catch (error) {
            console.error('Error:', error);  // Handle error here
            alert('Error: ' + error)
        }

    };

    return (
        <div className="modal-overlay" onClick={OnCloseAddExcercise}>
            <div className="modal-content-set" onClick={(e) => e.stopPropagation()}>
                <h2>Create New Exercise</h2>
                <br/>
                <hr/>
                <br/>


                <form>
                    <div className='IconContainer'>
                        <img src={weightIcon} alt="weightIcon" height={100} width={100}/>
                    </div>
                    <br/>
                    <div>

                        <input className='CreateInputSet'
                               type="text"
                               name="name"
                               placeholder="Exercise name"
                               value={formData.name}
                               onChange={handleChange}
                               required

                        />
                    </div>


                </form>
                <button type="submit" className='AddSetButton' onClick={handleSubmit}>Create</button>

                <button onClick={OnCloseAddExcercise} className="close-button">Close</button>
            </div>
        </div>
    )

}

AddWorkout.propTypes = {
    isOpenAddExcercise: PropTypes.bool.isRequired,
    OnCloseAddExcercise: PropTypes.func.isRequired,
};

export default AddWorkout;