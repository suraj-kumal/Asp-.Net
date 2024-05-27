import React from "react";
import myPhoto from "../assets/SurajKumal.jpeg";
import "./style.css";
const Home = () => {
  return (
    <div className="home">
      <div className="wrap">
        <h1>React App By Suraj</h1>
        <img src={myPhoto} alt="My Photo" width="500px" />
      </div>
    </div>
  );
};

export default Home;
