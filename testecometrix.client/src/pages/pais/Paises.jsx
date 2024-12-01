import { Link } from "react-router";
import "../../css/Custom.css";
import ApiService from "../../services/apiService";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import Swal from 'sweetalert2'

function Paises() {

    const [paises, setPaises] = useState([]);
    const [nomePais, setNomePais] = useState("");
    
    const loadPaisesAsync = async() => {
        var paises = await ApiService.getPaisesAsync(nomePais);
        setPaises(paises);
    };

    useEffect(() => {
        loadPaisesAsync();
    }, []);

    const excluirPaisAsync = async (id) => { 
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
                    await ApiService.excluirPaisAsync(id);  
                    await loadPaisesAsync(); 
                    Swal.fire({ title: "Deletado!", text: "O país foi deletado.", icon: "success" }); } 
                catch (e) { 
                    Swal.fire({ title: "Erro!", text: e.response.data.erros[0].mensagem, icon: "error" });   
                } 
            } 
        }); 
    };
  
    return (
      <>
        <h3>Países</h3>

        <div className="dv-linha1">
            <div>
                <Link className="btn btn-primary" to="/adicionarPais" > + Adicionar </Link>
            </div>
            
            <div className="dv-buscar">
                <input onChange={e => setNomePais(e.target.value)} placeholder="País" className="form-control"/>
                <button onClick={() => loadPaisesAsync()} className="btn btn-primary">Buscar</button>
            </div>
            
        </div>

        {paises.map((pais) => (
            <div key={pais.id} className="card-itens">
                <div className="dv-itens01">
                    <p className="text-code">Código: {pais.id} </p>
                    <h5>{pais.nome}</h5>
                </div>

                <div className="dv-itens02">
                    <Link 
                        to="/alterarPais" state={{pais}}  
                        className="btn btn-warning"> Alterar </Link>

                    <button onClick={() => excluirPaisAsync(pais.id)} className="btn btn-danger "> Excluir </button>
                </div>
            </div>
        ))}
        
      </>
    );
  }
  
export default Paises;