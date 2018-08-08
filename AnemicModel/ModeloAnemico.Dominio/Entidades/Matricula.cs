using System;

namespace ModeloAnemico.Dominio.Entidades
{
    public class Matricula
    {
        public Aluno Aluno { get; set; }
        public Curso Curso { get; set; }
        public DateTime Data { get; set; }
    }
}