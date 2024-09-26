import { Doughnut } from 'react-chartjs-2';
import { Chart, ArcElement, Tooltip, Legend } from 'chart.js';

// Register the necessary chart.js components
Chart.register(ArcElement, Tooltip, Legend);

const DonutChart = () => {
    // Define the chart data
    const data = {
        labels: ['Kcal Consumed', 'Kcal left'],
        datasets: [
            {
                label: 'Votes',
                data: [1700, 800],
                backgroundColor: [
                    'rgba(255, 99, 132, 0.6)',
                    'rgba(54, 162, 235, 0.6)',

                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)',

                ],
                borderWidth: 1,
            },
        ],
    };

    // Define optional chart configuration
    const options = {
        responsive: true,
        plugins: {
            legend: {
                position: 'top',
            },
            tooltip: {
                enabled: true,
            },
        },
        cutout: '70%', // Makes it a donut chart (instead of a pie chart)
    };

    return (
        <div style={{ width: '50%', margin: '0 auto' }}>
            <h2>Dashboard</h2>
            <br />
            {/* Render the Doughnut chart with the data and options */}
            <Doughnut data={data} options={options} />
        </div>
    );
};

export default DonutChart;
