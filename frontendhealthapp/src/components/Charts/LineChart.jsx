// LineChart.js
import React from 'react';
import { Line } from 'react-chartjs-2';
import {
    Chart as ChartJS,
    CategoryScale,
    LinearScale,
    PointElement,
    LineElement,
    Title,
    Tooltip,
    Legend,
} from 'chart.js';
import PropTypes from "prop-types";
import ShoppingList from "../ShoppingList.jsx";

// Register Chart.js components
ChartJS.register(
    CategoryScale,
    LinearScale,
    PointElement,
    LineElement,
    Title,
    Tooltip,
    Legend
);

const LineChart = ({ filter, dataProp }) => {
    const data = {
        labels: [],
        datasets: [
            {
                label: 'Sales 2023 (in USD)',
                data: [1000, 1200, 1500, 1700, 1400, 1800],
                borderColor: 'rgba(75, 192, 192, 1)',
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                tension: 0.3,
            },
        ],
    };

    const options = {
        responsive: true,  // Make chart responsive
        maintainAspectRatio: false,  // Disable aspect ratio to allow height change
        plugins: {
            legend: {
                position: 'top',
            },
            title: {
                display: true,
                text: 'Monthly Sales Data for 2023',
            },
        },
        scales: {
            x: {
                title: {
                    display: true,
                    text: 'Month',
                },
            },
            y: {
                title: {
                    display: true,
                    text: 'Sales (USD)',
                },

            },
        },
    };

    return (
        <div className="linechartContainer">
            <h2>Weight Tracker</h2>
            <br />
            <div className="chart-container-line">
                <Line data={data} options={options}/>
            </div>
        </div>
    );
};

LineChart.propTypes = {
    filter: PropTypes.array.isRequired,
    dataProp: PropTypes.any.isRequired,
};

export default LineChart;
