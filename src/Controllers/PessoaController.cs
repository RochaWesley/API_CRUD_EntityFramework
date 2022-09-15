using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

using src.Models;
using src.Persistence;


namespace src.Controllers;


[ApiController]
[Route("[controller]")]  
public class PessoaController : ControllerBase
{
    private DataBaseContext _context { get; set; }

public PessoaController(DataBaseContext context)
{
    this._context = context;

}

[HttpGet]
public ActionResult<List<Pessoa>> Get(){
   var result = _context.Pessoas.Include(p => p.contratos).ToList();
   if(!result.Any()) return NoContent();
    return Ok(result);
}

[HttpPost()]
public ActionResult<Pessoa> Post([FromBody]Pessoa pessoa){
   try
   {
    _context.Pessoas.Add(pessoa);
    _context.SaveChanges();
   }
   catch (System.Exception)
   {
    return BadRequest();
   }
   
    return Created("Criado", pessoa);
}

[HttpPut("{id}")]
public ActionResult<Object> Update([FromRoute] int Id, [FromBody]Pessoa pessoa){
   
   var result = _context.Pessoas.SingleOrDefault(p => p.id == Id);
   if (result is null) return NotFound( new {
    msg = "Registro não encontrado",
    status = HttpStatusCode.NotFound
   });

   try
   {
    _context.Pessoas.Update(pessoa);
    _context.SaveChanges(); 
   }
   catch (System.Exception)
   {
    return BadRequest(new {
        msg = "Houve erro ao enviar solicitação de atualização do "
        + Id + " atualizados",
        status = HttpStatusCode.BadRequest
    });
   } 

    return Ok("Dados do id " + Id + "atualizados");
}

[HttpDelete("{Id}")]
public ActionResult<object> Delete([FromRoute] int Id){
    var result = _context.Pessoas.SingleOrDefault(p => p.id == Id);
    
    if(result is null) return BadRequest(new {
        msg = "Conteúdo inexistente, solicitação inválida",
        status = HttpStatusCode.BadRequest
    });

    _context.Pessoas.Remove(result);
    _context.SaveChanges(); 
    return Ok("Deletado pessoa de Id" + Id);
}

}
