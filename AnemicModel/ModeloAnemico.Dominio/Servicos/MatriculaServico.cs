using System;
using ModeloAnemico.Dominio._base;
using ModeloAnemico.Dominio.Entidades;

namespace ModeloAnemico.Dominio.Servicos
{
    public class MatriculaServico
    {
        private readonly IRepositorioBase<Matricula> _matriculaRepositorio;
        private readonly IRepositorioBase<Curso> _cursoRepositorio;
        private readonly IRepositorioBase<Aluno> _alunoRepositorio;
        public MatriculaServico(
            IRepositorioBase<Matricula> matriculaRepositorio, 
            IRepositorioBase<Curso> cursoRepositorio,
            IRepositorioBase<Aluno> alunoRepositorio)
        {
            _matriculaRepositorio = matriculaRepositorio;
            _cursoRepositorio = cursoRepositorio;
            _alunoRepositorio = alunoRepositorio;
        }

        public void Salvar(int alunoId, int cursoId)
        {
            var curso = _cursoRepositorio.ObterPor(alunoId);
            var aluno = _alunoRepositorio.ObterPor(alunoId);

            var matricula = new Matricula();
            matricula.Aluno = aluno;
            matricula.Curso = curso;

            Validar(curso, aluno, matricula);

            _matriculaRepositorio.Salvar(matricula);
        }

        private void Validar(Curso curso, Aluno aluno, Matricula matricula)
        {
            if(aluno == null) 
                throw new Exception("Aluno não encontrado");
            if(curso == null) 
                throw new Exception("Curso não encontrado");
            if(curso.PublicoAlvo != aluno.PublicoAlvo) 
                throw new Exception("Publico alvo de aluno não pode ser diferente do curso");
        }
    }
}