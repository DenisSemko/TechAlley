<img src="https://github.com/DenisSemko/TechAlley/blob/main/src/Web/client/public/img/logo.png" alt="logo" title="logo" align="right" height="100" />

# TechAlley
> Innovative e-commerce project specializing in high-quality headphones! 

## Table of Contents
* [General Info](#general-information)
* [Technologies Used](#technologies-used)
* [Architecture](#architecture)
* [Features](#features)
* [Screenshots](#screenshots)
* [Setup](#setup)
* [Usage](#usage)
* [Project Status](#project-status)
* [Contact](#contact)
* [License](#license)

## General Information
Platform combines cutting-edge technologies and industry best practices to deliver an exceptional shopping experience to headphone enthusiasts around the world.

System provides a friendly UI along with REST API requests to work with the theme.

At the heart of the project lies a powerful stack comprising .NET, React, and Microservices Architecture. This robust foundation ensures that the platform is highly scalable, reliable, and provides seamless integration across various components. With a focus on Domain-Driven Design (DDD) principles, it was crafted an architecture that promotes modularization, flexibility, and maintainability.

## Technologies Used
- Web Application - React.js
- Back-end: .NET 6, C#
- Containerization: Docker
- Databases: MSSQL, MongoDb, PostgreSQL, Redis
- Microservices and Clean Architecture
- API Gateway - Ocelot API
- Identity - ASP.NET Identity, PostgreSQL database
- Microservices Communication - RabbitMQ via MassTransit
- Filese Hub - AWS S3 Bucket
- DDD principles, CQRS
- Unit Testing

## Architecture

<img width="1213" alt="Screenshot 2023-07-03 at 15 48 52" src="https://github.com/DenisSemko/TechAlley/assets/53062219/222f634a-4e2f-40e9-b6ff-c196b1756236">


## Features

## Screenshots

## Setup
Project is built locally and it uses SSL certificate to run the Web App securely.

Make sure you have installed and configured [docker](https://docs.docker.com/desktop/install/windows-install/) in your environment. After that, you need to run the below commands from the /src/ directory.

`docker-compose build`
`docker-compose up`

*Another Approach:*

You need to download this repository and run it using Visual Studio 2019 or newer version or any other IDE that is suitable for you.

You can run the Web application via installing all the dependencies with the command `npm install`.

After that, use the command `HTTPS=true SSL_CRT_FILE={CERT-PATH} SSL_KEY_FILE={KEY-PATH} npm start` for Linux/MacOS systems or `set HTTPS=true&&SSL_CRT_FILE={CERT-PATH}&&SSL_KEY_FILE={KEY-PATH}&&npm start` for Windows!


> You need to make sure you have installed MSSQL, MongoDb, PostgreSQL, Redis & RabbitMQ locally or via Docker.

## Usage

## Project Status
_v1.0 has not been finished yet_

## Contact
Created by [@dench327](https://www.linkedin.com/in/denis-semko-551b91191) - feel free to contact me!

© 2023

## License
> You can check out the full license [here](https://github.com/DenisSemko/TechAlley/blob/master/LICENSE).
This project is licensed under the terms of the MIT license.
