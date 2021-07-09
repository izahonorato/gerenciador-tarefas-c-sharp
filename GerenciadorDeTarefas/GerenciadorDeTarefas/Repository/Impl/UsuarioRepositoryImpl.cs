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
        public void Salvar(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }
    }
}
