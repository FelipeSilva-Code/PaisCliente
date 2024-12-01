public class ClienteEntity : DefaultEntity
{
    public string Nome { get; set; }
    public int FkPais { get; set; }
    public PaisEntity Pais {get; set;}
}
