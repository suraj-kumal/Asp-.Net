import React from "react";
import "./style.css";
const Footer = () => {
  const currentYear = new Date().getFullYear();
  return (
    <div className="footer">
      <footer>
        <p>© Suraj Kumal, {currentYear}</p>
      </footer>
    </div>
  );
};

export default Footer;
