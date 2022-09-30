using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers;

[ApiController] // Avisa o C# que essa classe é uma API
[Route("[controller]")] // Pega o nome do controller e elimina a palavra "controller"
public class PersonController : ControllerBase
{
    [HttpGet]
    public Pessoa Get()
    {
        // Instanciando a classe pessoa
        Pessoa pessoa = new Pessoa("Carlos", 33, "369.738.278-02");
        Contrato novoContrato = new Contrato("abc123", 50.46);

        pessoa.contratos.Add(novoContrato);
        return pessoa;
    }
    [HttpPost]
    public Pessoa Post(Pessoa pessoa)
    {
        return pessoa;
    }
    
    // Recebe dados do navegador
    [HttpPut("{id}")]
    public string Update([FromRoute] int id, [FromBody] Pessoa pessoa)
    {
        Console.WriteLine(id);
        Console.WriteLine(pessoa);
        return "Dados do ID " + id + " atualizados";
    }
    
    [HttpDelete("{id}")]
    public string Delete([FromRoute] int id)
    {
        return "Deletado pessoa de ID " + id;
    }

}