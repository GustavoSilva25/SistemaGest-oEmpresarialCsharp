using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeCadastroEmp.Models;

namespace SistemaDeCadastroEmp.Controllers
{
    public class EmpresaController : Controller
    {
        public IActionResult formEmpresa()
        {
            return View();
        }

        private readonly AppDbContext _context;

        public EmpresaController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> adicionarEmpresa(EmpresaViewModel model)
        {
            Console.WriteLine("Entrou na Funcao adicionar");
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Entrou no form invalido");
        
                foreach (var kvp in ModelState)
                {
                    var key = kvp.Key;
                    var errors = kvp.Value.Errors;
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"Erro no campo {key}: {error.ErrorMessage}");
                    }
                }

    return View("formEmpresa", model);
            }

            //Criar Empresa
            var empresa = new Empresa
            {   
                // IdEmpresa = model.IdEmpresa,
                RazaoSocial = model.RazaoSocial,
                NomeFantasia = model.NomeFantasia,
                CNPJ = model.CNPJ,
                AreaAtuacao = model.AreaAtuacao,
            };

            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            // Criar Endereco 
            var endereco = new Endereco
            {
                Rua = model.Rua,
                Numero = model.Numero,
                Bairro = model.Bairro,
                Cidade = model.Cidade,
                Estado = model.Estado,
                Cep = model.Cep,
                IdEmpresa = empresa.IdEmpresa,
            };

            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();

            var contato = new Contato
            {
                telefone = model.telefone,
                email = model.email,
                IdEmpresa = empresa.IdEmpresa
            };
            _context.Contatos.Add(contato);

            await _context.SaveChangesAsync();

            TempData["Sucesso"] = "Empresa cadastrada com sucesso!";
            return RedirectToAction("index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> editar(int id)
        {

            var empresa = await _context.Empresas
                        .Include(e => e.endereco)
                        .Include(e => e.contato)
                        .FirstOrDefaultAsync(e => e.IdEmpresa == id);

            if (empresa == null)
            {

                return NotFound();
            }

            var viewModel = new EmpresaViewModel
            {
                IdEmpresa = empresa.IdEmpresa,
                RazaoSocial = empresa.RazaoSocial,
                NomeFantasia = empresa.NomeFantasia,
                CNPJ = empresa.CNPJ,
                AreaAtuacao = empresa.AreaAtuacao,
                telefone = empresa.contato.telefone,
                email = empresa.contato.email,
                Rua = empresa.endereco.Rua,
                Numero = empresa.endereco.Numero,
                Bairro = empresa.endereco.Bairro,
                Cidade = empresa.endereco.Cidade,
                Estado = empresa.endereco.Estado,
                Cep = empresa.endereco.Cep,
            };

            return View("formEmpresa", viewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> atualizarEmpresa(int id, EmpresaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("formEmpresa", model);
            }
            
            var empresa = await _context.Empresas
                .Include(e => e.endereco)
                .Include(e => e.contato)
                .FirstOrDefaultAsync(e => e.IdEmpresa == id);

            if (empresa == null)
            {
                return NotFound();
            }

            empresa.RazaoSocial = model.RazaoSocial;
            empresa.NomeFantasia = model.NomeFantasia;
            empresa.CNPJ = model.CNPJ;
            empresa.AreaAtuacao = model.AreaAtuacao;
            empresa.contato.telefone = model.telefone;
            empresa.contato.email = model.email;
            empresa.endereco.Rua = model.Rua;
            empresa.endereco.Numero = model.Numero;
            empresa.endereco.Bairro = model.Bairro;
            empresa.endereco.Cidade = model.Cidade;
            empresa.endereco.Estado = model.Estado;
            empresa.endereco.Cep = model.Cep;

            await _context.SaveChangesAsync();

            return RedirectToAction("index", "Home");
            
        }
    }    
}