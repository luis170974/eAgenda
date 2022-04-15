using eAgenda.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.ConsoleApp.ModuloContato
{
    public class Contatos : EntidadeBase
    {
        private readonly string _nome;
        private readonly string _email;
        private readonly string _telefone;
        private readonly string _empresa;
        private readonly string _cargo;


        public string Nome { get => _nome; }

        public Contatos(string nome, string email, string telefone, string empresa, string cargo)
        {
            _nome = nome;
            _email = email;
            _telefone = telefone;
            _empresa = empresa;
            _cargo = cargo;

        }

        public override string ToString()
        {
            return "Contato Id: " + numero + Environment.NewLine +
                "Nome do filme: " + _nome + Environment.NewLine +
                "Email do contato: " + _email + Environment.NewLine +
                "Telefone do contato: " + _telefone + Environment.NewLine +
                "Empresa do contato: " + _empresa + Environment.NewLine +
                "Cargo do contato: " + _cargo + Environment.NewLine;

        }

    }
}
