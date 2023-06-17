import logo from './logo.svg';
import Navbar from "./components/Navbar/Navbar";
import Home from "./pages/Home/Home";
import { Route, BrowserRouter as Router, Routes } from "react-router-dom";
import './App.css';

const Layout = () => {
  return (
    <div className="app">
      <Navbar />
      <Home />
      <Routes>
        <Route exact path="/" component={Home} />
      </Routes>
    </div>
  );
};

function App() {
  return (
    <Router>
      <Layout />
    </Router>
  );
}

export default App;