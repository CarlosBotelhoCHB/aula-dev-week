using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Persistence;
using Microsoft.EntityFrameworkCore;

namespace src.Controllers;

[ApiController] // Avisa o C# que essa classe é uma API
[Route("[controller]")] // Pega o nome do controller e elimina a palavra "controller"
public class PersonController : ControllerBase
{
    // Criando um construtor para solicitar a instancia DataBaseContext
    public PersonController(DataBaseContext context)
    {
        this._context = context;
    }
    // Quando fazemos uma propriedade privada, usamos por convenção o "_" antes
    private DataBaseContext _context { get; set; }

    [HttpGet]
    public List<Pessoa> Get()
    {
        // Instanciando a classe pessoa
        // Pessoa pessoa = new Pessoa("Carlos", 33, "369.738.278-02");
        // Contrato novoContrato = new Contrato("abc123", 50.46);
        // pessoa.contratos.Add(novoContrato);

        // Para cada pessoa, inclua o contrato
        return _context.Pessoas.Include(p => p.contratos).ToList();
        
    }
    [HttpPost]
    public Pessoa Post(Pessoa pessoa)
    {
        _context.Pessoas.Add(pessoa);
        _context.SaveChanges();

        return pessoa;
    }
    
    // Recebe dados do navegador
    [HttpPut("{id}")]
    public string Update([FromRoute] int id, [FromBody] Pessoa pessoa)
    {
        _context.Pessoas.Update(pessoa);
        _context.SaveChanges();

        return "Dados do ID " + id + " atualizados";
    }
    
    [HttpDelete("{id}")]
    public string Delete([FromRoute] int id)
    {
        var result = _context.Pessoas.SingleOrDefault(e => e.Id == id);
        _context.Pessoas.Remove(result);
        _context.SaveChanges();
        return "Deletado pessoa de ID " + id;
    }

}