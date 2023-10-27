import Navbar from "./components/Navbar/Navbar";
import Home from "./pages/Home/Home";
import { Route, BrowserRouter as Router, Routes } from "react-router-dom";
import './App.css';
import Wishlist from './components/Wishlist/Wishlist';

const Layout = () => {
  return (
    <div className="app">
      <Navbar />
      <Home />
      <Routes>
        <Route exact path="/" component={Home} />
        <Route exact path="/wishlist" component={Wishlist} />
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
