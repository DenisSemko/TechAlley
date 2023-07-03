import React from 'react'
import Slider from '../../components/Slider/Slider'
import Newsletter from '../../components/Newsletter/Newsletter'
import AboutProduct from '../../components/AboutProduct/AboutProduct'
import PickOnProduct from '../../components/PickOnProduct/PickOnProduct'
import Reviews from '../../components/Reviews/Reviews'
import Footer from '../../components/Footer/Footer'

const Home = () => {
  return (
    <div className='home'>
      <Slider />
      <AboutProduct />
      <PickOnProduct />
      <Reviews />
      <Newsletter />
      <Footer />
    </div>
  )
}

export default Home