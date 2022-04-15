using eAgenda.ConsoleApp.ModuloCompromisso;
using eAgenda.ConsoleApp.ModuloContato;
using eAgenda.ConsoleApp.ModuloTarefa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.ConsoleApp.Compartilhado
{
    public class TelaAgendaPrincipal
    {
        private string opcaoSelecionada;

        private NotificadorMensagem _notficadorDeMensagens;

        


        // Declaraçao de Compromisso

        private IRepositorio<Compromisso> _repositorioCompromisso;

        private TelaCadastroCompromisso _telaCadastroCompromisso;

        // Declaraçao de Contatos

        private IRepositorio<Contatos> _repositorioContato;

        private TelaCadastroContato _telaCadastroContato;

        // Declaraçao de Itens


        // Declaraçao de Tarefas

        private IRepositorio<Tarefa> _repositorioTarefa;

        private TelaCadastroTarefa _telaCadastroTarefa;

        public TelaAgendaPrincipal(NotificadorMensagem notificadorMensagem)
        {
            _repositorioCompromisso = new RepositorioCompromisso();

            _telaCadastroCompromisso = new TelaCadastroCompromisso(_repositorioCompromisso, _repositorioContato, _telaCadastroContato);

            _repositorioContato = new RepositorioContato();

            _telaCadastroContato = new TelaCadastroContato(_repositorioContato);

            _repositorioTarefa = new RepositorioTarefa();

            _telaCadastroTarefa = new TelaCadastroTarefa(_repositorioTarefa);
        }

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Agenda do Zezinho");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Cadastrar Tarefa");
            Console.WriteLine("Digite 2 para Cadastrar Compromisso");
            Console.WriteLine("Digite 3 para Cadastrar Contato");


            Console.WriteLine("Digite s para sair");

            opcaoSelecionada = Console.ReadLine();

            return opcaoSelecionada;
        }

        public TelaBase ObterTela()
        {
            string opcao = MostrarOpcoes();


            TelaBase tela = null;

            if(opcao == "1")
                tela = _telaCadastroTarefa;

            if (opcao == "2")
                tela = _telaCadastroCompromisso;

            if (opcao == "3")
                tela = _telaCadastroContato;

            if (opcao == "s")
                Environment.Exit(0);









            return tela;
        }
    }
}
