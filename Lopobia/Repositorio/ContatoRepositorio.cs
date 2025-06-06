﻿using Lopobia.Data;
using Lopobia.Models;

namespace Lopobia.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ContatoModel BuscarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> BuscarTodos(int usuarioID)
        {
            return _bancoContext.Contatos.Where(x => x.UsuarioId == usuarioID).ToList();
        }

        public ContatoModel Criar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public ContatoModel Editar(ContatoModel contato)
        {
            ContatoModel contatoDB = BuscarPorId(contato.Id);

            if(contatoDB == null) throw new Exception("O contato não foi encontrado");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();
            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = BuscarPorId(id);

            if (contatoDB == null) throw new Exception("O contato não foi encontrado");

            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
