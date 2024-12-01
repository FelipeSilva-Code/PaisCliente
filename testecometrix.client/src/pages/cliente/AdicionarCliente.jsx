import { Link, useNavigate } from "react-router";
import "../../css/Custom.css";
import ApiService from "../../services/apiService";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";

function AdicionarCliente() {

    const [nome, setNome] = useState("");
    const [paises, setPaises] = useState([]);
    const [idPais, setIdPais] = useState(0);
    
    const navigate = useNavigate();

    const incluirClienteAsync = async () => {
        try{         
            if(!nome)
            {
                toast.error("O nome do cliente é obrigatório");
                return;
            }

            if (!idPais)
            {
                toast.error("O país é obrigatório");
                return;
            }

            var request = {
                nome,
                "fkPais": idPais
            };

            await ApiService.adicionarClienteAsync(request);
            toast.success("Cliente cadastrado com sucesso!");
            navigate("/clientes");
        }catch(e){
            toast.error(e.response.data.erros[0].mensagem);
        }
    }

    const loadPaises = async() => {
        var paises = await ApiService.getPaisesAsync("");
        setPaises(paises);
    };

    useEffect(() => {
        loadPaises();
    }, []);

    useEffect(() => {
        if (paises.length > 0) {
            setIdPais(paises[0].id); //Para garantir que o select ja comece com o value do primeiro país (assim não depende do onChange do usuário)
        }
    }, [paises]);

  
    return (
      <>
        <h3>Adicionar cliente</h3>

        <div className="mb-3">
            <label htmlFor="nome" className="form-label">Nome</label>
            <input value={nome} onChange={e => setNome(e.target.value)} type="text" className="form-control" id="nome" placeholder="Nome"/>
        </div>

        <div className="mb-3">
            <label htmlFor="pais" className="form-label">País</label>
            <select value={idPais} onChange={e => setIdPais(e.target.value)} className="form-control" id="pais">
                    {paises.map((pais) => (
                        <option key={pais.id} value={pais.id}> {pais.nome} </option>
                ))}
            </select>
        </div>
        
        <div className="dv-btns-adicionar">
            <Link  className="btn btn-secondary" to="/clientes" > Cancelar </Link> 
            <button onClick={() => incluirClienteAsync()} className="btn btn-primary" to="/" > Adicionar </button>  
        </div>
        
      </>
    );
  }
  
export default AdicionarCliente;