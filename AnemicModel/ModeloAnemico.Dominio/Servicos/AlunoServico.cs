using ModeloAnemico.Dominio.Entidades;
using ModeloAnemico.Dominio._base;
using System;

namespace ModeloAnemico.Dominio.Servicos
{
    public class AlunoServico
    {
        public readonly IRepositorioBase<Aluno> _repositorio;

        public AlunoServico(IRepositorioBase<Aluno> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Salvar(string nome, string cpf, PublicoAlvo publicoAlvo)
        {
            var aluno = new Aluno();
            aluno.Nome = nome;
            aluno.Cpf = cpf;
            aluno.PublicoAlvo = publicoAlvo;

            Validar(aluno);

            _repositorio.Salvar(aluno);
        }

        public void Remover(int id)
        {
            var aluno = _repositorio.ObterPor(id);

            _repositorio.Remover(aluno);
        }

        public void InformarPublicoAlvo(Aluno aluno, PublicoAlvo novoPublicoAlvo) {
            aluno.PublicoAlvo = novoPublicoAlvo;

            _repositorio.Salvar(aluno);
        }

        private void Validar(Aluno aluno)
        {
            if(string.IsNullOrEmpty(aluno.Nome)) 
                throw new Exception("Nome do aluno é obrigatório");
            if(string.IsNullOrEmpty(aluno.Cpf)) 
                throw new Exception("Cpf do aluno é obrigatório");
        }
    }
}