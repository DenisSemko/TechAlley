import React, {useState, useEffect} from 'react'
import "./Navbar.scss"
import { Link } from 'react-router-dom';
import PersonOutlineOutlinedIcon from "@mui/icons-material/PersonOutlineOutlined";
import FavoriteBorderOutlinedIcon from "@mui/icons-material/FavoriteBorderOutlined";
import ShoppingCartOutlinedIcon from "@mui/icons-material/ShoppingCartOutlined";

const Navbar = () => {

  const [isSticky, setIsSticky] = useState(false);
  const [isReached, setReached] = useState(false);

  useEffect(() => {
    const handleScroll = () => {
      const scrollTop = window.pageYOffset;

      if (scrollTop > 0 && !isSticky) {
        setIsSticky(true);
      } else if (scrollTop === 0 && isSticky) {
        setIsSticky(false);
      }
      if (scrollTop > 1200) {
        setReached(true);
      } else {
        setReached(false);
      }
    };

    window.addEventListener('scroll', handleScroll);

    return () => {
      window.removeEventListener('scroll', handleScroll);
    };
  }, [isSticky, isReached]);

  return (
    <div className={`navbar-container ${isSticky ? 'navbar-sticky' : ''}`}>
      <div className={`navbar ${isReached ? 'navbar-black' : ''}`}>
          <div className="wrapper">
              <div className="left">
                  <div className="logo">
                      <img src="/img/logo.png" alt=""></img>
                  </div>
                  <div className='page'>
                    <Link className='link' to="/">HOME</Link>
                  </div>
                  <div className='page'>
                    <Link className='link' to="/">ABOUT</Link>
                  </div>
                  <div className='page'>
                    <Link className='link' to="/">STORES</Link>
                  </div>
              </div>
              <div className="right">
                <div className="icons">
                  <PersonOutlineOutlinedIcon />
                  <div className="wish-list-icon">
                    <FavoriteBorderOutlinedIcon />
                    <span>0</span>
                  </div>
                  <div className="cart-icon">
                    <ShoppingCartOutlinedIcon />
                    <span>0</span>
                  </div>
                </div>
              </div>
          </div>
      </div>
    </div>
  )
}

export default Navbar