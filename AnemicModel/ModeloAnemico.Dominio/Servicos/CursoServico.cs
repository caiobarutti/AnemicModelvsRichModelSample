using System;
using ModeloAnemico.Dominio._base;
using ModeloAnemico.Dominio.Entidades;

namespace ModeloAnemico.Dominio.Servicos
{
    public class CursoServico
    {
        private readonly IRepositorioBase<Curso> _repositorio;

        public CursoServico(IRepositorioBase<Curso> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Salvar(string nome, decimal valor, PublicoAlvo publicoAlvo)
        {
            var curso = new Curso();
            curso.Nome = nome;
            curso.Valor = valor;
            curso.PublicoAlvo = publicoAlvo;

            Validar(curso);

            _repositorio.Salvar(curso);
        }

        public void Remover(int id)
        {
            var curso = _repositorio.ObterPor(id);

            _repositorio.Remover(curso);
        }

        private void Validar(Curso curso)
        {
            if(string.IsNullOrEmpty(curso.Nome)) 
                throw new Exception("Nome do curso é obrigatório");
            if(curso.Valor == 0) 
                throw new Exception("Nome do curso é obrigatório");
        }
    }
}