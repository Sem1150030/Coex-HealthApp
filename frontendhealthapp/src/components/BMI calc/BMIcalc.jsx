import React, { useState } from "react";

function BMICalculator() {
    const [weight, setWeight] = useState("");
    const [height, setHeight] = useState("");
    const [gender, setGender] = useState("male");
    const [bmi, setBmi] = useState(null);
    const [status, setStatus] = useState("");

    const calculateBMI = () => {
        if (weight && height) {
            const heightInMeters = height / 100; // convert height to meters
            const calculatedBMI = (weight / (heightInMeters ** 2)).toFixed(2); // calculate BMI
            setBmi(calculatedBMI);
            setStatus(getStatus(calculatedBMI, gender));
        } else {
            alert("Please enter both weight and height");
        }
    };

    const getStatus = (bmi, gender) => {
        if (gender === "male") {
            if (bmi < 18.5) return "Underweight";
            if (bmi < 24.9) return "Normal weight";
            if (bmi < 29.9) return "Overweight";
            return "Obesity";
        } else {
            if (bmi < 18) return "Underweight";
            if (bmi < 24) return "Normal weight";
            if (bmi < 29) return "Overweight";
            return "Obesity";
        }
    };

    return (
        <div style={{ textAlign: "center", marginTop: "20px" }}>
            <h2>BMI Calculator</h2>
            <div style={{marginBottom: "10px"}}>
                <input
                    type="number"
                    className="WeightInput"

                    placeholder="Weight (kg)"
                    value={weight}
                    onChange={(e) => setWeight(e.target.value)}
                    style={{marginRight: "10px"}}
                />
                <input
                    type="number"
                    className="WeightInput"

                    placeholder="Height (cm)"
                    value={height}
                    onChange={(e) => setHeight(e.target.value)}
                    style={{marginRight: "10px"}}
                />
                <br/>
                <select value={gender} onChange={(e) => setGender(e.target.value)}>
                    <option value="male">Male</option>
                    <option value="female">Female</option>
                </select>
            </div>

            <button className="Add" onClick={calculateBMI} style={{ marginBottom: "10px" }}>
                Calculate BMI
            </button>
            {bmi && (
                <div>
                    <h3>Your BMI: {bmi}</h3>
                    <p>Status: {status}</p>
                </div>
            )}
        </div>
    );
}

export default BMICalculator;
