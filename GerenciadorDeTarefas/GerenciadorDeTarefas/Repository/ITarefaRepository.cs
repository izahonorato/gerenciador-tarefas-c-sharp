using GerenciadorDeTarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Repository
{
    public interface ITarefaRepository
    {
        public void AdicionarTarefa(Tarefa tarefa);
        Tarefa GetById(int idTarefa);
        void RemoverTarefa(Tarefa tarefa);
    }
}
