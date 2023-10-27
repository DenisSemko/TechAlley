import React, {useState} from 'react'
import "./PickOnProduct.scss"
import useFetch from "../../hooks/useFetch.js";
import KeyboardArrowRightIcon from '@mui/icons-material/KeyboardArrowRight';
import KeyboardArrowLeftIcon from '@mui/icons-material/KeyboardArrowLeft';

const PickOnProduct = () => {

  const imageData = [
    "https://media.ldlc.com/r1600/ld/products/00/05/80/97/LD0005809736_1.jpg",
    "https://sony.scene7.com/is/image/sonyglobalsolutions/wh-ch720_Primary_image?$S7Product$&fmt=png-alpha",
    "https://www.beatsbydre.com/content/dam/beats/web/product/headphones/solo3-wireless/plp/plp-solo3-black.jpg.large.2x.jpg"
];

  const { data, isLoading, error } = useFetch({
    method: 'GET',
    url: '/Catalog',
    headers: {
      accept: '*/*'
    }
  });

  const filteredData = data.slice(0, 3);

  const [currentProduct, setCurrentProduct] = useState(0);

  const prevProduct = () => {
    setCurrentProduct((prev) => (prev === 0 ? filteredData.length - 1 : prev - 1));
  };

  const nextProduct = () => {
    setCurrentProduct((prev) => (prev + 1) % filteredData.length);
  };

  return (
    <div className='pick-product-container'>
        <div className='pick-product-content'>
          <h2 className="pick-product-content-title">Find your headphones</h2>
          <p className="pick-product-content-text">
            With its Active Noise Cancelling technology, experience an immersive sound <br />
              that provides you the freedom to create.
          </p>
        </div>
            { isLoading ? (
              <p>Loading...</p>
            ) : 
            <div>
              {
                error && (
                  <div>
                      <p>{error.message}</p>
                  </div>
              )}
              <div className='pick-product-slider'> 
                {
                  filteredData && filteredData.length > 0 ? (
                    <>
                      <div className='pick-product'>
                        <img src={imageData[currentProduct]} alt=""></img>
                        <p className='pick-product-name'>{filteredData[currentProduct].catalogBrand} {filteredData[currentProduct].name}</p>
                        <p className='pick-product-description'>{filteredData[currentProduct].description}</p>
                        <div className="pick-product-cart">
                          <p className="price">{filteredData[currentProduct].price} $</p>
                          <button className="add-to-cart">Add to Cart</button>
                      </div>
                      </div>
                      <div className="slider-buttons">
                        <div className="slider-button">
                          <button onClick={prevProduct} disabled={currentProduct === 0}>
                              <KeyboardArrowLeftIcon />
                          </button>
                        </div>
                        <div className="slider-button">
                          <button onClick={nextProduct} disabled={currentProduct === filteredData.length - 1}>
                            <KeyboardArrowRightIcon />
                          </button>
                        </div>
                      </div><br></br>
                    </>
                    ) : (
                      <p>No products are available.</p>
                  )}
            </div>
        </div>
          }
    </div>
  )}

export default PickOnProduct