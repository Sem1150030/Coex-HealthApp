// LineChart.js
import React from 'react';
import { baseUrl } from "../../config.js";

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
            return handleMonthFilter();
        }
        if(filter === 'year'){
            console.log("year");
            return [1000, 1200, 1500, 1700, 1400, 1800];
        }
    }

    function handleMonthFilter(){
        const monthNumber = new Date().getMonth() + 1;
        let dates = getAllDatesInMonth(new Date().getFullYear(), monthNumber)
        console.log(dates)
    }

    function getAllDatesInMonth(year, month) {
        // JavaScript months are 0-indexed, so we subtract 1 from the month number
        let firstDate = new Date(year, month - 1, 1);
        let dates = [];

        // Get the last day of the month by going to the next month and subtracting a day
        let lastDate = new Date(year, month, 0); // 0 gets the last day of the previous month

        // Loop through each day of the month
        for (let day = firstDate.getDate(); day <= lastDate.getDate(); day++) {
            let currentDate = new Date(year, month - 1, day);
            let formattedDate = currentDate.toLocaleDateString('en-GB'); // Formats to 'dd-mm-yyyy'
            dates.push(formattedDate);
        }

        return dates;
    }

// Example usage
    let datesInOctober = getAllDatesInMonth(2024, 10);
    console.log(datesInOctober);



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
            const monthNumber = new Date().getMonth() + 1;
            return getAllDatesInMonth(new Date().getFullYear(), monthNumber)
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
                spanGaps: true // Connect lines through null values

            },
        ],
    };

    function getMonthName(monthNumber) {
        const monthNames = [
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        ];

        // Since monthNumber is usually 1-based (1 = January, 12 = December), we subtract 1
        return monthNames[monthNumber];
    }


    function displayX(){
        if(filter === 'week'){
            const weekNumber = getWeekNumber(new Date());
            return "Week: " + weekNumber
        }
        if(filter === 'month'){
            const monthNumber = new Date().getMonth() ;
            return getMonthName(monthNumber)
        }
        if(filter === 'year'){
            console.log("year");
            return [1000, 1200, 1500, 1700, 1400, 1800];
        }
    }


    function handleMaxTicks(){
        if(filter === 'week'){
            return 7
        }
        if(filter === 'month'){
            return 7
        }
        if(filter === 'year'){
            return 12
        }

    }


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
                    text: displayX(),
                },
                ticks: {
                    maxTicksLimit: handleMaxTicks(), // Show fewer ticks (e.g., 7 ticks)
                },
            },
            y: {
                title: {
                    display: true,
                    text: 'Weight (kg)',
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
