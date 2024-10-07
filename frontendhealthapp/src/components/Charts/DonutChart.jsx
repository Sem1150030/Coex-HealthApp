import { Doughnut } from 'react-chartjs-2';
import { Chart, ArcElement, Tooltip, Legend } from 'chart.js';
import PropTypes from "prop-types";



// Register the necessary chart.js components
Chart.register(ArcElement, Tooltip, Legend);

const DonutChart = ({dataProp}) => {
    // Define the chart data
    const kcalConsumed = dataProp.kcalCurrent;
    const kcalGoal = dataProp.kcalGoal;
    let kcalLeft = kcalGoal - kcalConsumed;
    if (kcalLeft < 0) {
        kcalLeft = 0;
    }

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
        <div style={{width: '50%', margin: '0 auto'}}>
            <h2>Dashboard</h2>
            <br/>
            {/* Render the Doughnut chart with the data and options */}
            <Doughnut data={data} options={options}/>
            <br/> <br/> <br/>
        </div>
    );
};



DonutChart.propTypes = {
    dataProp: PropTypes.any // or the specific type of `data` (e.g., string, object, array, etc.)
};
export default DonutChart;
