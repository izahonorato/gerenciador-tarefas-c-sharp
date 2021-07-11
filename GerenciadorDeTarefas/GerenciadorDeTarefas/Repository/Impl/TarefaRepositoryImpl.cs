using GerenciadorDeTarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Repository.Impl
{
    public class TarefaRepositoryImpl : ITarefaRepository
    {
        private readonly GerenciadorDeTarefasContext _context;

        public TarefaRepositoryImpl(GerenciadorDeTarefasContext context)
        {
            _context = context;
        }

        public void AdicionarTarefa(Tarefa tarefa)
        {
            _context.Tarefa.Add(tarefa);
            _context.SaveChanges();
        }

        public Tarefa GetById(int idTarefa)
        {
            return _context.Tarefa.FirstOrDefault(tarefa => tarefa.Id == idTarefa);
        }

        public void RemoverTarefa(Tarefa tarefa)
        {
            _context.Tarefa.Remove(tarefa);
            _context.SaveChanges();
        }
    }
}
