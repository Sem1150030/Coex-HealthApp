import logo from './logo.svg';
import './App.css';
import navigation from './components/navbar/Navigationbar.jsx';
import Navigationbar from "./components/navbar/Navigationbar.jsx";
import Macros from "./components/Macros/Macros.jsx";

function App() {
  return (
    <div>
      <Navigationbar />
      <Macros />
    </div>
  );
}

export default App;
