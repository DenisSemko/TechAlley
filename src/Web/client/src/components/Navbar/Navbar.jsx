import React from 'react'
import "./Navbar.scss"
import { Link } from 'react-router-dom';
import PersonOutlineOutlinedIcon from "@mui/icons-material/PersonOutlineOutlined";
import FavoriteBorderOutlinedIcon from "@mui/icons-material/FavoriteBorderOutlined";
import ShoppingCartOutlinedIcon from "@mui/icons-material/ShoppingCartOutlined";

const Navbar = () => {
  return (
    <div className='navbar'>
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
  )
}

export default Navbar