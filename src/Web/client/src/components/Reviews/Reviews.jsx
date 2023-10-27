import React from 'react'
import "./Reviews.scss"

const Reviews = () => {
  return (
    <div className='reviews-container'>
        <div className='reviews-content'>
            <h2 className="reviews-content-title">Customer Reviews</h2>
        </div>
        <div className='reviews'>
            <div className="review">
                <blockquote className="review-block">
                    <div className="avatar"> 
                        <img src="/img/avatar-1.jpg" alt=""></img>
                    </div>
                    <div className="ratings-container">
                        <div className="ratings">
                            <div className="ratings-val"></div>
                        </div>
                        <h4 className="review-title">I didn't expect such powerful headphones.</h4>
                        <p>
                            I recently purchased the headphones and I am blown away by their sound quality.
                        </p>
                    </div>
                </blockquote>
            </div>
            <div className="review">
                <blockquote className="review-block">
                    <div className="avatar"> 
                        <img src="https://i.guim.co.uk/img/media/37fae91abf78e15044877072484d9fe60824f6b4/0_1092_5504_3302/master/5504.jpg?width=1200&height=1200&quality=85&auto=format&fit=crop&s=c4dc6a95fc4c0dd3f4e9b895e9b25e78" alt="" />
                    </div>
                    <div className="ratings-container">
                        <div className="ratings">
                            <div className="ratings-val"></div>
                        </div>
                        <h4 className="review-title">It's a very good product.</h4>
                        <p>
                            These headphones have exceeded my expectations.
                        </p>
                    </div>
                </blockquote>
            </div>
            <div className="review">
                <blockquote className="review-block">
                    <div className="avatar"> 
                        <img src="https://static2.gensler.com/uploads/image/80417/people-travis-albrecht-02-GRIDBLOCK_508x508_1674843350.jpg" alt=""></img>
                    </div>
                    <div className="ratings-container">
                        <div className="ratings">
                            <div className="ratings-val"></div>
                        </div>
                        <h4 className="review-title">Wow, I'm deeply shocked!</h4>
                        <p>
                            Those headphones are the best I've ever used. They have transformed my listening experience.
                        </p>
                    </div>
                </blockquote>
            </div>
        </div>
    </div>
  )
}

export default Reviews