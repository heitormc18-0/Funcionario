namespace apifuncio.Models;

public class Funcionario
{
    public int FuncionarioId {get;set;}
    public string? Nome {get;set;}
    public int SetorId {get;set;}
    public virtual Setor? Setor {get;set;} 
}
