import {useEffect, useState} from "react";
import PropTypes from "prop-types";
import './CreateNewFoodItem.css'
import backarrow from '../../../src/assets/icons8-arrow-back-50.png';
import foodicon from '../../../src/assets/icons8-food-and-drink-96.png';



function CreateNewFoodItem({isOpenCreate, OnCloseCreate}){


    const [formData, setFormData] = useState({
        name: '',
        measurement: '',
        kcalAmount: '',
        proteinAmount: '',
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

    async function handleSubmit (e)  {
        e.preventDefault();
        console.log(formData);
        if(formData.name === '' || formData.measurement === '' || formData.kcalAmount === '' || formData.proteinAmount === ''){
            return alert('Please fill in all fields')
        }

        if(formData.kcalAmount < 0 || formData.proteinAmount < 0){
            return alert('Kcal and Protein Amount cannot be negative')
        }

        if (formData.kcalAmount > 9999 || formData.proteinAmount > 9999){
            return alert('Kcal and Protein Amount must be less than 9999')
        }
        const jwtToken = localStorage.getItem('token')

        try {
            // const res = await fetch('http://localhost:5155/FoodItem',
            const res = await fetch('http://192.168.178.129:8001/FoodItem',
                {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${jwtToken}`  // Add JWT token in the Authorization header
                },
                body: JSON.stringify(formData)  // Convert data to JSON
            });



            let result = await res.json();

            console.log(result)
            alert('Food Item Created')
            window.location.reload();
        } catch (error) {
            console.error('Error:', error);  // Handle error here
            alert('Error: ' + error)
        }

    };

    function handleChange (e) {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value
        });
    };

    return (
        <div className="modal-overlay-Create" onClick={OnCloseCreate}>
            <div>
                <div className="modal-content" onClick={e => e.stopPropagation()}>
                    <div className='detailsheader'>
                        <button className='closeButton' onClick={OnCloseCreate}><img src={backarrow} alt="backarrow"
                                                                                     width='30px'/></button>
                        <h1 className="detailheadertitle"> New Food Item</h1>


                    </div>
                    <br/>
                    <hr/>
                    <br/>
                    <div className='CreateInputContainer'>

                        <form className='CreateInputForm'>
                            <img className="foodicon" src={foodicon} alt="foodicon"/>

                            <input className='CreateInput'
                                   placeholder="Enter Name"
                                   type='text'
                                      name={'name'}
                                      value={formData.name}
                                   onChange={handleChange}
                                   required={true}
                                   maxLength={25}
                                   minLength={3}

                            ></input>

                            <input className='CreateInput'
                                   placeholder="Measurement: '1 cup, 200 grams'"
                                   type='text'
                                   name={'measurement'}
                                      value={formData.measurement}
                                    onChange={handleChange}
                                      required={true}
                                   maxLength={15}
                                   minLength={3}

                            ></input>


                            <input className='CreateInputNumber'
                                   placeholder="Kcal"
                                   type='number'
                                        name={'kcalAmount'}
                                      value={formData.kcalAmount}
                                   onChange={handleChange}
                                      required={true}
                                   maxLength={4} pattern="\d{1, 4}"
                                   minLength={1}


                            ></input>
                            <input className='CreateInputNumber'
                                   placeholder="Protein (gr)"
                                   type='number'
                                        name={'proteinAmount'}
                                        value={formData.proteinAmount}
                                   onChange={handleChange}
                                        required={true}
                                   maxLength={4} pattern="\d{1, 4}"
                                   minLength={1}


                            ></input>
                            <input className='CreateInputNumber' placeholder="Fat (gr)" type='number'></input>
                            <input className='CreateInputNumber' placeholder="Carbs (gr)" type='number'></input>

                            <button onClick={handleSubmit} className='Add'>Create</button>
                        </form>
                    </div>

                </div>
            </div>
        </div>

    );


}

CreateNewFoodItem.propTypes = {
    isOpenCreate: PropTypes.bool.isRequired,
    OnCloseCreate: PropTypes.func.isRequired,
};

export default CreateNewFoodItem;