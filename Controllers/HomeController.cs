using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeCadastroEmp.Models;

namespace SistemaDeCadastroEmp.Controllers;
[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context )
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    //Buscar empresa atraves do cnpj na barra de pesquisa 
    [HttpPost]
    public async Task<IActionResult> index(string searchString)
    {

        var empresas = from emp in _context.Empresas
                        .Include( emp => emp.endereco)
                        .Include( emp => emp.contato) select emp;

        if (!String.IsNullOrEmpty(searchString))
        {
            empresas = empresas.Where(emp => emp.CNPJ.Equals(searchString));
        }
        
        return View(empresas);
        
    }

    //Listar Empresas no Banco de dados salvos
    [HttpGet]
    public async Task<IActionResult> index()
    {
        var empresas = await _context.Empresas
            .Include(e => e.endereco)
            .Include(e => e.contato)
            .ToListAsync();

        return View(empresas);
    }


    // Escluir Empresa
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> delete(int id)
    {
        var empresa = await _context.Empresas
            .Include(e => e.endereco)
            .Include(e => e.contato)
            .FirstOrDefaultAsync(e => e.IdEmpresa == id);

        if (empresa == null)
            return NotFound();

        // Remove dependências
        if (empresa.endereco != null)
            _context.Enderecos.Remove(empresa.endereco);

        if (empresa.contato != null)
            _context.Contatos.Remove(empresa.contato);

        _context.Empresas.Remove(empresa);

        await _context.SaveChangesAsync();

        TempData["Sucesso"] = "Empresa excluída com sucesso!";
        return RedirectToAction(nameof(Index));
    }
    
}
