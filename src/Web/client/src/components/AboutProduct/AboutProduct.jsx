import React from 'react'
import "./AboutProduct.scss"
import LocalShippingIcon from '@mui/icons-material/LocalShipping';
import SettingsBackupRestoreIcon from '@mui/icons-material/SettingsBackupRestore';
import HandymanIcon from '@mui/icons-material/Handyman';
import EmailIcon from '@mui/icons-material/Email';
import NotificationsOffIcon from '@mui/icons-material/NotificationsOff';
import BluetoothIcon from '@mui/icons-material/Bluetooth';
import BatteryFullIcon from '@mui/icons-material/BatteryFull';

const AboutProduct = () => {
  return (
    <div className="about-product">
        <img src="/img/aboutProduct-bg.png" alt="" />
        <div className='customer-benefits'>
            <div className="icon-box">
                <span className="icon-box-icon">
                    <LocalShippingIcon />
                </span>
                <div className="icon-box-content">
                    <h3 className="icon-box-title">Payment &amp; Delivery</h3>
                    <p>Choose shipping method you prefer</p>
                </div>
            </div>
            <div className="icon-box">
                <span className="icon-box-icon">
                    <SettingsBackupRestoreIcon />
                </span>
                <div className="icon-box-content">
                    <h3 className="icon-box-title">Return &amp; Refund</h3>
                    <p>Free 100% money back guarantee</p>
                </div>
            </div>
            <div className="icon-box">
                <span className="icon-box-icon">
                    <HandymanIcon />
                </span>
                <div className="icon-box-content">
                    <h3 className="icon-box-title">Quality Support</h3>
                    <p>Online support 24/7</p>
                </div>
            </div>
            <div className="icon-box">
                <span className="icon-box-icon">
                    <EmailIcon />
                </span>
                <div className="icon-box-content">
                    <h3 className="icon-box-title">Join Our Newsletter</h3>
                    <p>You will receive the latest updates</p>
                </div>
            </div>
        </div>
        <div className='headphones-container'>
            <div className='headphones-wrapper'>
                <img src="/img/headphones.png" alt="" />
            </div>
            <div className="heaphones-content">
                <h3 className="headphones-content-subtitle">Hear nothing, but music</h3>
                <h2 className="headphones-content-title">Natural Sound</h2>
                <p className="headphones-content-text">
                    With a blend of vintage aesthetics, durable construction, and powerful sound quality, headphones offer a premium listening experience for music enthusiasts.
                </p>
            </div>
            <div className="headphones-info">
                <div className="icon-box">
                    <span className="icon-box-icon">
                        <NotificationsOffIcon />
                    </span>
                    <p>Noise Cancelling</p>
                </div>
                <div className="icon-box">
                    <span className="icon-box-icon">
                        <BluetoothIcon />
                    </span>
                    <p>Wireless</p>
                </div>
                <div className="icon-box">
                    <span className="icon-box-icon">
                        <BatteryFullIcon />
                    </span>
                    <p>80+ hours</p>
                </div>
            </div>
        </div>
        <div className="charging-details">
            <div className='charging-wrapper'>
                <img src="https://t3.ftcdn.net/jpg/02/65/57/54/360_F_265575417_kbv0RvOy9T0DnRt0SgwmjN8BltVuAaSl.jpg"></img>
            </div>
            <div className="charging-content">
                <h3 className="charging-content-subtitle">Listen all day</h3>
                <p className="charging-content-text">
                    These headphones provide an incredible listening experience, <br />
                    allowing you to enjoy up to 80 hours of uninterrupted music, <br /> podcasts, or audiobooks on the go.
                </p>
                <div className="charging-content-boxes">
                    <div className="info-box">
                        <p>Charge</p>
                        <strong>2</strong>
                        <p>hours</p>
                    </div>
                    <div className="info-box">
                        <p>Playtime</p>
                        <strong>80+</strong>
                        <p>hours</p>
                    </div>
                </div>
            </div>

        </div>
    </div>
  )
}

export default AboutProduct