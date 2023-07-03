import React from 'react'
import "./Newsletter.scss"
import { SocialIcon } from 'react-social-icons';

const Newsletter = () => {
  return (
    <>
      <h2 className="newsletter-title">Join Us! </h2>
      <div className='newsletter-container'>
        <div className="border-box">
          <h3 className="border-box-title">Social Media</h3>
          <p className='border-box-subtitle'>Stay updated on the latest breakthroughs!</p>
          <div className="social-icons">
              <SocialIcon url="https://linkedin.com/" className='icon' target="_blank" />
              <SocialIcon url="https://facebook.com/" className='icon' target="_blank" />
              <SocialIcon url="https://instagram.com/" className='icon' target="_blank" />
              <SocialIcon url="https://twitter.com/" className='icon' target="_blank" />
              <SocialIcon url="https://youtube.com/" className='icon' target="_blank" />
          </div>
        </div>
        <div className='border-box'>
          <h3 className="border-box-title">Find out More</h3>
          <p className='border-box-subtitle'>Subscribe to the latest news!</p>
          <form>
            <input type="email" placeholder="Your email address" required />
            <button type="submit">Subscribe</button>
          </form>
        </div>
      </div><br />
    </>
  )
}

export default Newsletter