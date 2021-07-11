using GerenciadorDeTarefas.Enums;
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

        public void AtualizarTarefa(Tarefa tarefa)
        {
            _context.Entry(tarefa).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            _context.Entry(tarefa).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }

        public List<Tarefa> BuscarTarefas(int idUsuario, DateTime? periodoDe, DateTime? periodoAte, StatusTarefaEnum status)
        {
            return _context.Tarefa.Where(tarefa => tarefa.IdUsuario == idUsuario
            && (periodoDe == null || periodoDe == DateTime.MinValue || tarefa.DataPrevistaConclusao > ((DateTime)periodoDe).Date)
            && (periodoAte == null || periodoAte == DateTime.MinValue || tarefa.DataPrevistaConclusao <= ((DateTime)periodoAte).Date)
            && (status == StatusTarefaEnum.Todos || (status == StatusTarefaEnum.Ativos && tarefa.DataConclusao == null)
            || (status == StatusTarefaEnum.Concluídos && tarefa.DataConclusao != null))
            ).ToList();
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
