import './Navigationbar.css';
import { NavLink } from 'react-router-dom';

export default function Navigationbar() {

    return (
        <div className='navbar'>
            <ul>
                <li>
                    <NavLink
                        to='/Workout'
                        className={({isActive}) => (isActive ? 'active' : '')}
                    >
                        Workout
                    </NavLink>
                </li>
                <li>
                    <NavLink
                        to='/'
                        className={({isActive}) => (isActive ? 'active' : '')}
                    >
                        Macros
                    </NavLink>
                </li>
                <li>
                    <NavLink
                        to='/weight'
                        className={({isActive}) => (isActive ? 'active' : '')}
                    >
                        Weight
                    </NavLink>
                </li>
            </ul>
            <br/>
            <br/>
        </div>
    );
}
