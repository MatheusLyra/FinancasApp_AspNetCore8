using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Add(Usuario usuario)
        {
            using ( var dataContext = new DataContext())
            {
                dataContext.Add(usuario);
                dataContext.SaveChanges();
            }
        }

        public Usuario? Get(string email, string senha)
        {
            //abrindo conexão com o banco de dados através do EF
            using (var dataContext = new DataContext())
            {
                return dataContext
                        .Set<Usuario>()
                        .Where(u => u.Email.Equals(email) && u.Senha.Equals(senha))
                        .FirstOrDefault();
            }
        }

        public bool VerifyExists(string email)
        {
            //abrindo conexão com o banco de dados através do EF
            using (var dataContext = new DataContext())
            {
                return dataContext
                           .Set<Usuario>()
                           .Any(u => u.Email.Equals(email)); // Any (Algum)-> existe algum usuario cujo email seja igual o que estou passando
            }
        }
    }
}
