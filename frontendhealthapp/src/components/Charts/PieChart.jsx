import React from 'react';
import { Pie } from 'react-chartjs-2';
import { Chart as ChartJS, ArcElement, Tooltip, Legend } from 'chart.js';
import '../FoodItemDetails/FoodItemDetails.css';
import PropTypes from "prop-types";

// Register the components required by Chart.js
ChartJS.register(ArcElement, Tooltip, Legend);

const PieChart = ({protein, carbs, fat}) => {
    const data = {
        labels: ['Protein', 'Carbs', 'Fat'],
        datasets: [
            {
                label: 'grams',
                data: [protein, carbs, fat],
                backgroundColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                ],
                borderWidth: 1,
            },
        ],
    };

    const options = {
        plugins: {
            legend: {
                display: true,
                position: 'bottom',
                labels: {
                    usePointStyle: true, // Makes the legend markers round
                },
            },
        },
        responsive: true,
        maintainAspectRatio: false,
    };

    return (
        <div className="chart-container">
            <h2 className="Nutritional">Nutritional value</h2>
            <div className="chart-wrapper">
                <Pie data={data} options={options} />
            </div>
        </div>
    );
};

PieChart.prototype = {
    protein: PropTypes.number.isRequired,
    carbs: PropTypes.number.isRequired,
    fat: PropTypes.number.isRequired,
};

export default PieChart;
