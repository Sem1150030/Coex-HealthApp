
import {Form, Link, useSearchParams, useActionData, useNavigation} from 'react-router-dom';
import './Login.css'; // Correctly importing CSS

export default function Login() {
    const navigation= useNavigation();
    const [searchParams] = useSearchParams();
    const isLogin = searchParams.get('mode') === 'login';
    const data = useActionData();
    const isSubmitting = navigation.state === 'submitting';

    return (
        <>
            <Form method="post" className="form">
                <h1>{isLogin ? 'Log in' : 'Create a new user'}</h1>
                {data && data.errors && (
                    <ul>
                        {Object.values(data.errors).map((error) => (
                            <li key={error}>{error}</li>
                        ))}
                    </ul>
                )}
                {data && data.message && <p>{data.message}</p>}
                <p>
                    <label htmlFor="email">Email</label>
                    <input id="email" type="email" name="email" required />
                </p>
                <p>
                    <label htmlFor="password">Password</label>
                    <input id="password" type="password" name="password" required />
                </p>
                <div className="actions">
                    <Link to={`?mode=${isLogin ? 'signup' : 'login'}`}>
                        {isLogin ? 'Create new user' : 'Login'}
                    </Link>
                    <button disabled={isSubmitting}>{isSubmitting ? 'submitting ...': 'save'}</button>
                </div>
            </Form>
        </>
    );
}
