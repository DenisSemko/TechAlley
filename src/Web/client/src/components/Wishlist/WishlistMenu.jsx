import React from 'react'
import "./Wishlist.scss"
import FavoriteBorderOutlinedIcon from "@mui/icons-material/FavoriteBorderOutlined";
import useFetch from "../../hooks/useFetch.js";

const WishlistMenu = () => {

    const { data, isLoading, error } = useFetch({
        method: 'GET',
        url: '/Wishlist',
        headers: {
            accept: '*/*'
        }
    });

    return (
    <div className='wishlist-menu'>

    </div>
    )
}

export default WishlistMenu