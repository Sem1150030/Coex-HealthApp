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
import PropTypes, {func} from "prop-types";
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

const LineChart = ({ filter, dataProp, todaysData }) => {

    function dataInsert(){
        if(filter === 'week'){
            console.log("week");
            return handleWeekFilter();
        }
        if(filter === 'month'){
            console.log("month");
            return [1000, 1200, 1500, 1700, 1400, 1800];
        }
        if(filter === 'year'){
            console.log("year");
            return [1000, 1200, 1500, 1700, 1400, 1800];
        }
    }


    function handleWeekFilter(){
        const weekNumber = getWeekNumber(new Date());
        const datesInTheWeek = getDateOfISOWeek(weekNumber, new Date().getFullYear())

        var dataList = []

        for(let i in datesInTheWeek){
            let checkNullValue = 0
            for (var j in dataProp){
                var currentData = dataProp[j]
                let datespliced = currentData.date.split("T")
                if (datesInTheWeek[i] === datespliced[0]){
                    dataList.push(currentData.weight)
                    checkNullValue++
                }
            }
            if (checkNullValue < 1){
                dataList.push()
            }
        }

        return dataList;
    }

    function getWeekNumber(date) {
        const currentDate = new Date(date);
        const dayOfWeek = currentDate.getUTCDay() || 7;
        currentDate.setUTCDate(currentDate.getUTCDate() + 4 - dayOfWeek);
        const yearStart = new Date(Date.UTC(currentDate.getUTCFullYear(), 0, 1));
        const weekNumber = Math.ceil((((currentDate - yearStart) / 86400000) + 1) / 7);
        return weekNumber;
    }

    function getDateOfISOWeek(week, year) {
        const simple = new Date(Date.UTC(year, 0, 1 + (week - 1) * 7));
        const dayOfWeek = simple.getUTCDay();
        const ISOWeekStart = simple;

        if (dayOfWeek <= 4) {
            ISOWeekStart.setUTCDate(simple.getUTCDate() - simple.getUTCDay() + 1); // Adjust to Monday (day 1)
        } else {
            ISOWeekStart.setUTCDate(simple.getUTCDate() + 8 - simple.getUTCDay()); // Adjust to Monday in next week
        }

        const days = [];
        for (let i = 0; i < 7; i++) {
            const currentDay = new Date(ISOWeekStart);
            currentDay.setUTCDate(ISOWeekStart.getUTCDate() + i);
            days.push(currentDay.toISOString().slice(0, 10)); // Format as YYYY-MM-DD
        }

        return days;
    }


// Example usage:
    const date = "2024-10-07";
    const weekNumber = getWeekNumber(date);
    console.log(`Week number: ${weekNumber}`);


    function handleLabels(){
        if(filter === 'week'){
            const weekNumber = getWeekNumber(new Date());
            return  getDateOfISOWeek(weekNumber, new Date().getFullYear())
        }
        if(filter === 'month'){
            console.log("month");
            return [1000, 1200, 1500, 1700, 1400, 1800];
        }
        if(filter === 'year'){
            console.log("year");
            return [1000, 1200, 1500, 1700, 1400, 1800];
        }
    }



    const data = {
        labels: handleLabels(),
        datasets: [
            {
                label: 'Weight (kg)',
                data: dataInsert(),
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
                text: 'Weight Tracker',
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
        <>

            <h2>Weight Tracker</h2>
            <br />
            <div className="chart-container-line">
                <Line data={data} options={options}/>
            </div>
        </>

    );
};

LineChart.propTypes = {
    filter: PropTypes.array.isRequired,
    dataProp: PropTypes.any.isRequired,
};

export default LineChart;
