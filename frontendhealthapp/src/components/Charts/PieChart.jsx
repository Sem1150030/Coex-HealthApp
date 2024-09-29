// PieChart.js
import React from 'react';
import { Pie } from 'react-chartjs-2';
import { Chart as ChartJS, ArcElement, Tooltip, Legend } from 'chart.js';

// Register the components required by Chart.js
ChartJS.register(ArcElement, Tooltip, Legend);

const PieChart = () => {
    // Data and configuration for the pie chart
    const data = {
        labels: ['Protein', 'Carbs', 'Fat'],
        datasets: [
            {
                label: 'grams',
                data: [30, 17, 23],
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

    return (
        <div style={{ width: '50%', margin: '0 auto' }}>
            <h2>Nutritional value</h2>
            <Pie data={data} />
        </div>
    );
};

export default PieChart;
