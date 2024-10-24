import './Navigationbar.css';
import {Form, NavLink, useRouteLoaderData} from 'react-router-dom';

export default function Navigationbar() {
    const token = useRouteLoaderData('root');
    return (
        <div className='navbar'>
            <ul className='nav'>
                {/* Left section: Settings */}
                <li className='settingsButton'>
                    <NavLink
                        to='/Workout'
                        className={({isActive}) => (isActive ? 'active' : '')}
                    >
                        Settings
                    </NavLink>
                </li>

                {/* Center section */}
                <div className='centerItems'>
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
                            to='/macros'
                            className={({isActive}) => (isActive ? 'active' : '')}
                        >
                            Macros
                        </NavLink>
                    </li>
                    <li>
                        <NavLink
                            to='/weight'
                            className={({isActive}) => (isActive ? 'active' : '')}>
                            Weight
                        </NavLink>
                    </li>
                </div>

                {/* Right section: Login/Logout */}
                <li className='logoutButton'>
                    {!token && (
                        <NavLink
                            to='/auth?mode=login'
                            className={({isActive}) => (isActive ? 'active' : '')}
                        >
                            Login
                        </NavLink>
                    )}
                    {token && (
                        <Form action="/Logout" method="POST">
                            <button
                                className={({isActive}) => (isActive ? 'active' : '')}
                            >
                                Logout
                            </button>
                        </Form>
                    )}
                </li>
            </ul>
            <br/>
            <br/>
        </div>
    );
}
