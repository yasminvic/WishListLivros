using WishListBooks.Models.Entities;

namespace WishListBooks.Helper
{
    public interface ISessao
    {
        User BuscarSessao();
        void CriarSessao(User user);
        void RemoverSessao();
    }
}
