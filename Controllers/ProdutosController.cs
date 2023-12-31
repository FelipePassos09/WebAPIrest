﻿
using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            List<Produto>? produtos = _context.Produtos.AsNoTracking().ToList();
            if(produtos is null)
            {
                return NotFound("Não há produtos cadastrados.");
            }

            return produtos;
        }

        [HttpGet("primeiro")]
        public ActionResult<Produto> GetPrimeiro()
        {
            var produtos = _context.Produtos.FirstOrDefault();
            if (produtos is null)
            {
                return NotFound("Não há produtos cadastrados.");
            }

            return produtos;
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id) 
        {
            Produto produto = _context.Produtos.AsNoTracking().FirstOrDefault(prod => prod.ProdutoId == id);
            
            if(produto is null)
            {
                return NotFound("Não há este produto cadastrado.");
            }

            return produto;
            
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if(produto is null)
            {
                return BadRequest("Produto não pode ser vazio.");
            }

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId}, produto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto) 
        {
            
            if(id != produto.ProdutoId)
            {
                return BadRequest();
            }
            else if(produto is null)
            {
                return BadRequest("Produto não pode ser vazio.");
            }

            _context.Entry(produto).State = EntityState.Modified;
            //_context.Produtos.Update(produto);//
            _context.SaveChanges();

            return Ok();

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(prod => prod.ProdutoId == id);

            if(produto is null)
            {
                return NotFound("Produto não encontrado.");
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
    }
}
