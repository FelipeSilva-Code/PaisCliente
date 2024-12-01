import { Link } from "react-router";
import "../../css/Custom.css";
import ApiService from "../../services/apiService";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import Swal from 'sweetalert2'

function clientes() {

    const [clientes, setClientes] = useState([]);
    const [nomeCliente, setNomeCliente] = useState("");

    const loadClientesAsync = async() => {
        var clientes = await ApiService.getClientesAsync(nomeCliente);
        setClientes(clientes);
    };

    useEffect(() => {
        loadClientesAsync();
    }, []);

    const excluirClienteAsync = async (id) => { 
        Swal.fire({ 
            title: "Você tem certeza?", 
            text: "Você não poderá reverter isso!", 
            icon: "warning", 
            showCancelButton: true, 
            confirmButtonColor: "#3085d6", 
            cancelButtonColor: "#d33", 
            confirmButtonText: "Confirmar",
            cancelButtonText: "Cancelar" 
        }).then(async (result) => { 
            if (result.isConfirmed) { 
                try { 
                    await ApiService.excluirClienteAsync(id);
                    await loadClientesAsync();
                    Swal.fire({ title: "Deletado!", text: "O cliente foi deletado.", icon: "success" }); } 
                catch (e) { 
                    Swal.fire({ title: "Erro!", text: e.response.data.erros[0].mensagem, icon: "error" });   
                } 
            } 
        }); 
    };
  
    return (
      <div className="dv-clientes">
        <h3>Clientes</h3>

        <div className="dv-linha1">
          <div>
            <Link className="btn btn-primary" to="/adicionarCliente" > + Adicionar </Link>
          </div>
              
          <div className="dv-buscar">
              <input onChange={e => setNomeCliente(e.target.value)} placeholder="Cliente" className="form-control"/>
              <button onClick={() => loadClientesAsync()} className="btn btn-primary">Buscar</button>
          </div>
        </div>

        {clientes.map((cliente) => (
            <div key={cliente.id} className="card-itens">
                <div className="dv-itens01">
                    <p className="text-code">País: {cliente.pais.nome} </p>
                    <h5>{cliente.nome}</h5>
                </div>

                <div className="dv-itens02">
                    <Link 
                        to="/alterarCliente" state={{cliente}}  
                        className="btn btn-warning"> Alterar </Link>

                    <button onClick={() => excluirClienteAsync(cliente.id)} className="btn btn-danger "> Excluir </button>
                </div>
            </div>
        ))}
        
      </div>
    );
  }
  
export default clientes;