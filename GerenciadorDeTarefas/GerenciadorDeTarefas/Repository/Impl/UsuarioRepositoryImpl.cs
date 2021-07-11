using GerenciadorDeTarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Repository.Impl
{
    public class UsuarioRepositoryImpl : IUsuarioRepository
    {
        private readonly GerenciadorDeTarefasContext _context;
        public UsuarioRepositoryImpl(GerenciadorDeTarefasContext context)
        {
            _context = context;
        }

        public bool ExisteUsuarioPeloEmail(string email)
        {
            return _context.Usuario.Any(usuario => usuario.Email.ToLower() == email.ToLower());
        }

        public Usuario GetById(int idUsuario)
        {
            return _context.Usuario.FirstOrDefault(usuario => usuario.Id == idUsuario);
        }

        public Usuario GetUsuarioByLoginSenha(string login, string senha)
        {
            return _context.Usuario.FirstOrDefault(usuario => usuario.Email == login.ToLower() && usuario.Senha == senha);
        }

        public void Salvar(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }
    }
}
