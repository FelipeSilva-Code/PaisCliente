import { Link, useNavigate } from "react-router";
import "../../css/Custom.css";
import ApiService from "../../services/apiService";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";

function AdicionarPais() {

    const [nome, setNome] = useState("");
    
    const navigate = useNavigate();

    const incluirPaisAsync = async () => {
        try{         
            if(!nome)
            {
                toast.error("O nome do país é obrigatório");
                return;
            }

            var request = {
                nome
            };

            await ApiService.adicionarPaisAsync(request);
            toast.success("País cadastrado com sucesso!");
            navigate("/paises");
        }catch(e){
            toast.error(e.response.data.erros[0].mensagem);
        }
    }
  
    return (
      <>
        <h3>Adicionar país</h3>

        <div className="mb-3">
            <label htmlFor="nome" className="form-label">Nome</label>
            <input value={nome} onChange={e => setNome(e.target.value)} type="text" className="form-control" id="nome" placeholder="Nome"/>
        </div>
        
        <div className="dv-btns-adicionar">
            <Link  className="btn btn-secondary" to="/paises" > Cancelar </Link> 
            <button onClick={() => incluirPaisAsync()} className="btn btn-primary" to="/" > Adicionar </button>  
        </div>
        
      </>
    );
  }
  
export default AdicionarPais;