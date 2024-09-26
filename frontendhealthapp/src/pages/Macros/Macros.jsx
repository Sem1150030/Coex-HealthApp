import './Macros.css';
import DonutChart from '../../components/DonutChart.jsx';

export default function Macros() {

    function data() {
        return [
            { name: 'Protein', value: 20 },
            { name: 'Carbs', value: 40 },
            { name: 'Fat', value: 30 },
            { name: 'Other', value: 10 }
        ];
    }
    return (
   <div>
    <div class='container'>
    <h1 class='title'>Macros</h1>
    </div>
    <div class='container'>
        <div class='containerMacros'>
            <br/>
            <br/>
            <DonutChart data={data} width={400} height={400}/>

        </div>
    </div>
   </div>
    );
}