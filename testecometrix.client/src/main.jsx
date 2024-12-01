import React from "react";
import ReactDOM from "react-dom/client";
import { BrowserRouter, Routes, Route, Navigate } from "react-router";
import Paises from "./pages/pais/Paises";
import Clientes from "./pages/cliente/Clientes";
import AdicionarCliente from "./pages/cliente/AdicionarCliente";
import AlterarCliente from "./pages/cliente/AlterarCliente";
import AdicionarPais from "./pages/pais/AdicionarPais";
import AlterarPais from "./pages/pais/AlterarPais";
import DefaultContainer from "./components/defaultContainer/DefaultContainer";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const root = document.getElementById("root");

ReactDOM.createRoot(root).render(
  <BrowserRouter>
    <ToastContainer/>
    <DefaultContainer>
      <Routes>
        <Route path="/" element={<Navigate to="paises" />} />
        <Route path="paises" element={<Paises />} />
        <Route path="adicionarPais" element={<AdicionarPais />} />
        <Route path="alterarPais" element={<AlterarPais />} />
        <Route path="clientes" element={<Clientes />} />       
        <Route path="adicionarCliente" element={<AdicionarCliente />} />       
        <Route path="alterarCliente" element={<AlterarCliente />} />       
      </Routes>
    </DefaultContainer>
  </BrowserRouter>
);
