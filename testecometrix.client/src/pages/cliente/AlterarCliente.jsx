import { Link, useLocation, useNavigate } from "react-router";
import "../../css/Custom.css";
import ApiService from "../../services/apiService";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";

function AlterarCliente() {
    const location = useLocation();
    const navigate = useNavigate();

    const [id] = useState(location.state?.cliente?.id);
    const [nome, setNome] = useState(location.state?.cliente?.nome);
    const [paises, setPaises] = useState([]);
    const [idPais, setIdPais] = useState(location.state?.cliente?.pais?.id || 0);

    const loadPaises = async () => {
        const paises = await ApiService.getPaisesAsync("");
        setPaises(paises);
    };

    useEffect(() => {
        loadPaises();
    }, []);

    useEffect(() => {
        if (!location.state?.cliente?.id) {
            toast.error("Cliente não informado");
            navigate("/clientes");
        }
    }, []);

    const alterarClienteAsync = async () => {
        try {
            if (!nome) {
                toast.error("O nome do cliente é obrigatório");
                return;
            }

            const request = {
                id,
                nome,
                "fkPais": idPais, 
            };

            await ApiService.alterarClienteAsync(request);
            toast.success("Cliente alterado com sucesso!");
            navigate("/clientes");
        } catch (e) {
            toast.error(e.response.data.erros[0].mensagem);
        }
    };

    return (
        <>
            <h3>Alterar cliente</h3>

            <div className="mb-3">
                <label htmlFor="id" className="form-label">Código</label>
                <input value={id} readOnly={true} type="text" className="form-control" id="id" />
            </div>

            <div className="mb-3">
                <label htmlFor="nome" className="form-label">Nome</label>
                <input value={nome} onChange={(e) => setNome(e.target.value)} type="text" className="form-control" id="nome" placeholder="Nome" />
            </div>

            <div className="mb-3">
                <label htmlFor="cliente" className="form-label">País</label>
                <select
                    value={idPais}
                    onChange={(e) => setIdPais(e.target.value)}
                    className="form-control"
                    id="cliente"
                >
                    {paises.map((pais) => (
                        <option key={pais.id} value={pais.id}>
                            {pais.nome}
                        </option>
                    ))}
                </select>
            </div>

            <div className="dv-btns-adicionar">
                <Link className="btn btn-secondary" to="/clientes">
                    Cancelar
                </Link>
                <button onClick={() => alterarClienteAsync()} className="btn btn-primary">
                    Alterar
                </button>
            </div>
        </>
    );
}

export default AlterarCliente;
