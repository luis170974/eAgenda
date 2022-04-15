using eAgenda.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.ConsoleApp.ModuloTarefa
{
    public class Tarefa : EntidadeBase
    {
        private readonly string _titulo;
        private readonly DateTime _dataDeCriacaoTarefa;
        private readonly DateTime _dataDeConclusaoTarefa;
        private readonly int _percentualConcluido;
        private readonly bool _statusTarefa;
        public Prioridade _prioridade;

        public Tarefa(string titulo, DateTime dataCriacao, DateTime dataConclusao, Prioridade prioridade)
        {
            _titulo = titulo;
            _dataDeCriacaoTarefa = dataCriacao;
            _dataDeConclusaoTarefa = dataConclusao;
            _prioridade = prioridade;

        }




        public enum Prioridade
        {
            Alta,
            Normal,
            Baixa
        }

        public override string ToString()
        {
            return "Tarefa Id: " + numero + Environment.NewLine +
                "Titulo da tarefa: " + _titulo + Environment.NewLine +
                "Data de criação da tarefa: " + _dataDeCriacaoTarefa + Environment.NewLine +
                "Data de conclusão da tarefa: " + _dataDeConclusaoTarefa + Environment.NewLine +
                "Prioridade da tarefa: " + _prioridade + Environment.NewLine;


        }


    }



}
