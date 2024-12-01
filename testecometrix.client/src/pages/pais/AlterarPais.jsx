import { Link, useLocation, useNavigate } from "react-router";
import "../../css/Custom.css";
import ApiService from "../../services/apiService";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";

function AlterarPais() {

    const location = useLocation();
    const navigate = useNavigate();

    const [id] = useState(location.state?.pais?.id);
    const [nome, setNome] = useState(location.state?.pais?.nome);

    useEffect(() => {
        if(!location.state?.pais?.id)
        {
            toast.error("País não informado");
            navigate("/paises");
        }
    }, []);

    const alterarPaisAsync = async () => {
        try{
            
            if(!nome)
            {
                toast.error("O nome do país é obrigatório");
                return;
            }

            var request = {
                id,
                nome
            };

            await ApiService.alterarPaisAsync(request);
            toast.success("País alterado com sucesso!");
            navigate("/paises");
        }catch(e){
            toast.error(e.response.data.erros[0].mensagem);
        }
    }
  
    return (
      <>
        <h3>Alterar país</h3>

        <div className="mb-3">
            <label htmlFor="id" className="form-label">Código</label>
            <input value={id} readOnly={true} type="text" className="form-control" id="id"/>
        </div>

        <div className="mb-3">
            <label htmlFor="nome" className="form-label">Nome</label>
            <input value={nome} onChange={e => setNome(e.target.value)} type="text" className="form-control" id="nome" placeholder="Nome"/>
        </div>
        
        <div className="dv-btns-adicionar">
            <Link  className="btn btn-secondary" to="/paises" > Cancelar </Link> 
            <button onClick={() => alterarPaisAsync()} className="btn btn-primary" to="/" > Alterar </button>  
        </div>
        
      </>
    );
  }
  
export default AlterarPais;