import PropTypes from "prop-types";



function MacroDashboardData({data}) {
    let kcalLeft = data.kcalGoal - data.kcalCurrent;
    if (kcalLeft < 0) {
        kcalLeft = 0;
    }

    return (
        <div>
            <div className="Dashboarddatacontainer">
                <div className='textcon'>
                    <p className='dashboard'>{kcalLeft}</p>
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
            <br/><br/><br/>
            <div className="Dashboarddatacontainer">
                <div className='textcon'>
                    <p className='dashboard2'>{data.carbCurrent}/{data.carbGoal}</p>
                    <p className='information2'>Carbs</p>
                </div>

                <div className='textcon'>
                    <p className='dashboard2'>{data.proteinCurrent}/{data.proteinGoal}</p>
                    <p className='information2'>Protein</p>
                </div>

                <div className='textcon'>
                    <p className='dashboard2'>{data.fatCurrent}/{data.fatGoal}</p>
                    <p className='information2'>Fat</p>
                </div>
            </div>
        </div>


    );

}

MacroDashboardData.propTypes = {
    data: PropTypes.any // or the specific type of `data` (e.g., string, object, array, etc.)
};

export default MacroDashboardData;