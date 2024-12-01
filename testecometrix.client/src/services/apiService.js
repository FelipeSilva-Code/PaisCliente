import axios from "axios";

const api = axios.create({
    baseURL: "https://localhost:7081"
})

export default class ApiService {
    
    static async getPaisesAsync(nome) 
    {
        var apiResponse = await api.get(`/pais?nome=${nome}`);
        return apiResponse.data;
    };

    static async adicionarPaisAsync(request) 
    {
        var apiResponse = await api.post("/pais", request);
        return apiResponse.data;
    };

    static async alterarPaisAsync(request) 
    {
        var apiResponse = await api.put("/pais", request);
        return apiResponse.data;
    };

    static async excluirPaisAsync(id) 
    {
        var apiResponse = await api.delete(`/pais/${id}`);
        return apiResponse.data;
    };

    static async getClientesAsync(nome)
    {
        var apiResponse = await api.get(`/cliente?nome=${nome}`);
        return apiResponse.data;
    }

    static async adicionarClienteAsync(request)
    {
        var apiResponse = await api.post("/cliente", request);
        return apiResponse.data;
    }

    static async alterarClienteAsync(request)
    {
        var apiResponse = await api.put("/cliente", request);
        return apiResponse.data;
    }

    static async excluirClienteAsync(id)
    {
        var apiResponse = await api.delete(`/cliente/${id}`);
        return apiResponse.data;
    }
}