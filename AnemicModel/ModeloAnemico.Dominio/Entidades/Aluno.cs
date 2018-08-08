using System;

namespace ModeloAnemico.Dominio.Entidades
{
    public class Aluno
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public PublicoAlvo PublicoAlvo { get; set; }
    }
}
