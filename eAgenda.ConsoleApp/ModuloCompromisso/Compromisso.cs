using eAgenda.ConsoleApp.Compartilhado;
using eAgenda.ConsoleApp.ModuloContato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.ConsoleApp.ModuloCompromisso
{
    public class Compromisso : EntidadeBase
    {
        private readonly string _assuntoCompromisso;
        private readonly string _localCompromisso;
        private readonly DateTime _dataCompromisso;
        private readonly DateTime _horaInicioCompromisso;
        private readonly DateTime _horaTerminoCompromisso;
        public Contatos _contato;

        public Compromisso(string assuntoCompromisso, string localCompromisso, DateTime dataCompromisso, DateTime horaInicioCompromisso, DateTime horaTerminoCompromisso, Contatos contato)
        {
            _assuntoCompromisso = assuntoCompromisso;
            _localCompromisso = localCompromisso;
            _dataCompromisso = dataCompromisso;
            _horaInicioCompromisso = horaInicioCompromisso;
            _horaTerminoCompromisso = horaTerminoCompromisso;
            _contato = contato;


        }

        public override string ToString()
        {
            return "Compromisso Id: " + numero + Environment.NewLine +
                "Assunto do compromisso: " + _assuntoCompromisso + Environment.NewLine +
                "Local do compromisso: " + _localCompromisso + Environment.NewLine +
                "Data do compromisso: " + _dataCompromisso.ToString("dd/MM/yyyy") + Environment.NewLine +
                "Hora do inicio do compromisso: " + _horaInicioCompromisso.ToString("HH:mm") + Environment.NewLine +
                "Hora do término do compromisso:  " + _horaTerminoCompromisso.ToString("HH:mm") + Environment.NewLine +
                "Contato presente no compromisso:  " + _contato + Environment.NewLine;

        }
    }
}
