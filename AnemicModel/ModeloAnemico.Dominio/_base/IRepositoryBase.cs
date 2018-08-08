namespace ModeloAnemico.Dominio._base
{
    public interface IRepositorioBase<T>
    {
        void Salvar(T entidade);

        void Remover(T entidade);
        T ObterPor(int id);
    }
}