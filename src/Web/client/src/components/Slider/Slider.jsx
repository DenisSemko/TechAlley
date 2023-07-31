import React, { useState } from 'react'
import ArrowCircleLeftIcon from '@mui/icons-material/ArrowCircleLeft';
import "./Slider.scss"

const Slider = () => {

    const [currentSlide, setCurrentSlide] = useState(0);
    const [isClicked, setIsClicked] = useState(false);

    const data = [
        "/img/first_slide.jpeg",
        "/img/slider2.jpg"
    ];

    const prevSlide = () => {
        setCurrentSlide(currentSlide === 0 ? 1 : (prev) => prev - 1);
        setIsClicked(!isClicked);
    };

    const nextSlide = () => {
        setCurrentSlide(currentSlide === 1 ? 0 : (prev) => prev + 1);
        setIsClicked(!isClicked);
    };

    return (
        <div className='slider'>
            <div className="container" style={{transform:`translateX(-${currentSlide * 100}vw)`}}>
                {data.map((slide, index) => (
                    <img key={index} src={slide} alt="" />
                ))}
            </div>
            <div className={`left-arrow ${isClicked ? 'circle' : 'rounded-rectangle'}`} onClick={prevSlide}>
            </div>
            <div className={`right-arrow ${isClicked ? 'rounded-rectangle' : 'circle'}`} onClick={nextSlide}>
            </div>
        </div>
    )
}

export default Slider