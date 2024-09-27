import PropTypes from "prop-types";

function MacroDashboardData({data}) {
    return (
        <div className="Dashboarddatacontainer">
            <div className='textcon'>
                <p className='dashboard'>{data.kcalGoal - data.kcalCurrent}</p>
                <p className='information'>Kcal Left</p>

            </div>
            <div className='textcon'>
                <h2 className='dashboard'>{data.kcalCurrent}</h2>
                <p className='information'>Kcal Consumed</p>
            </div>
            <div className='textcon'>
                <p className='dashboard'>{data.kcalGoal}</p>
                <p className='information'>Kcal Goal</p>

            </div>
        </div>

    );

}

 MacroDashboardData.propTypes = {
     data: PropTypes.any // or the specific type of `data` (e.g., string, object, array, etc.)
 };

 export default MacroDashboardData;