import { Link } from "react-router";
import "../../css/Custom.css";
import React from "react";

function Header() {
  
    return (
        <div className="header"> 
            <Link to="/paises" className="link-header"> Paises </Link>
            <Link to="/clientes" className="link-header"> Clientes </Link>
        </div>
    );
}
  
export default Header;