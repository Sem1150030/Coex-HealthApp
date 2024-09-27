import { Doughnut } from 'react-chartjs-2';
import { Chart, ArcElement, Tooltip, Legend } from 'chart.js';
import PropTypes from "prop-types";


// Register the necessary chart.js components
Chart.register(ArcElement, Tooltip, Legend);

const DonutChart = () => {
    // Define the chart data
    const kcalConsumed = 2000;
    const kcalGoal = 2500;
    const kcalLeft = kcalGoal - kcalConsumed;

    const data = {
        labels: ['Kcal Consumed', 'Kcal left'],
        datasets: [
            {
                label: 'Kcals',
                data: [kcalConsumed, kcalLeft ],
                backgroundColor: [
                    'rgb(66, 99, 227)',
                    'rgba(54, 162, 235, 0.6)',

                ],
                borderColor: [
                    'rgb(66, 99, 227)',
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

DonutChart.propTypes = {
    kcalConsumed: PropTypes.number.isRequired, // Expect kcalConsumed to be a number and required
    kcalGoal: PropTypes.number.isRequired, // Expect kcalGoal to be a number and required
};
DonutChart.defaultProps = {
    kcalConsumed: 0, // Default value if not provided
    kcalGoal: 0, // Default value if not provided
};


export default DonutChart;
