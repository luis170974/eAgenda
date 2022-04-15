using eAgenda.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static eAgenda.ConsoleApp.ModuloTarefa.Tarefa;

namespace eAgenda.ConsoleApp.ModuloTarefa
{
    public class TelaCadastroTarefa : TelaBase, ICadastroBasico
    {
        private readonly IRepositorio<Tarefa> _repositorioTarefa;
        List<ItemTarefa> ListaDeItens = new();
        ItemTarefa itemTarefa;

        public TelaCadastroTarefa(IRepositorio<Tarefa> repositorioDaTarefa)
            : base("Cadastro de Tarefas")
        {
            _repositorioTarefa = repositorioDaTarefa;

        }

        public void InserirRegistro()
        {
            MostrarTitulo("Cadastro de Tarefa");

            Tarefa novaTarefa = ObterTarefa();

            _repositorioTarefa.Inserir(novaTarefa);

            notificador.ApresentarMensagem("Tarefa cadastrada com sucesso!", TipoMensagem.Sucesso);
        }

        public void EditarRegistro()
        {
            MostrarTitulo("Editando Tarefa");

            bool temTarefaCadastrada = VisualizarRegistro("Pesquisando");

            if (temTarefaCadastrada == false)
            {
                notificador.ApresentarMensagem("Nenhuma tarefa cadastrada para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroTarefa = ObterNumeroTarefa();

            Tarefa tarefaAtualizada = ObterTarefa();

            bool conseguiuEditar = _repositorioTarefa.Editar(numeroTarefa, tarefaAtualizada);

            if (!conseguiuEditar)
                notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                notificador.ApresentarMensagem("Tarefa editada com sucesso!", TipoMensagem.Sucesso);
        }

        public void ExcluirRegistro()
        {
            MostrarTitulo("Excluindo Contato");

            bool temTarefaRegistrada = VisualizarRegistro("Pesquisando");

            if (temTarefaRegistrada == false)
            {
                notificador.ApresentarMensagem("Nenhuma tarefa cadastrada para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroTarefa = ObterNumeroTarefa();

            bool conseguiuExcluir = _repositorioTarefa.Excluir(numeroTarefa);

            if (!conseguiuExcluir)
                notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                notificador.ApresentarMensagem("Tarefa excluído com sucesso", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistro(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Tarefa");

            List<Tarefa> tarefas = _repositorioTarefa.SelecionarTodos();

            if (tarefas.Count == 0)
            {
                notificador.ApresentarMensagem("Nenhuma tarefa disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Tarefa tarefa in tarefas)
                Console.WriteLine(tarefa.ToString());

            Console.ReadLine();

            return true;
        }

        private Tarefa ObterTarefa()
        {

            Prioridade prioridade = Prioridade.Normal;

            Console.Write("Digite o titulo da tarefa: ");
            string tituloTarefa = Console.ReadLine();

            Console.Write("Digite a data de criação da tarefa: ");
            DateTime dataCriacaoTarefa = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Digite a data de conclusão da tarefa: ");
            DateTime dataConclusaoTarefa = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Digite a prioridade da tarefa [1] Baixa, [2] Normal, [3] Alta");
            string opcaoPrioridade = Console.ReadLine();

            if (opcaoPrioridade == "1")
                prioridade = Prioridade.Baixa;

            if (opcaoPrioridade == "2")
                prioridade = Prioridade.Normal;

            if (opcaoPrioridade == "3")
                prioridade = Prioridade.Alta;


            Console.WriteLine("[1] adicionar item para tarefa, [2] nao adicionar nenhum item");
            string opcaoItem = Console.ReadLine();

            switch (opcaoItem)
            {
                case "1":
                    itemTarefa = new();
                    Console.WriteLine("Digite a descrição");
                    itemTarefa._descricao = Console.ReadLine();
                    ListaDeItens.Add(itemTarefa);
                    break;

                case "2":
                    Environment.Exit(0);
                    break;
            }



            return new Tarefa(tituloTarefa, dataCriacaoTarefa, dataConclusaoTarefa, prioridade);
        }

        public int ObterNumeroTarefa()
        {
            int _numeroTarefa;
            bool _numeroTarefaEncontrada;

            do
            {
                Console.Write("Digite o ID da tarefa que deseja editar: ");
                _numeroTarefa = Convert.ToInt32(Console.ReadLine());

                _numeroTarefaEncontrada = _repositorioTarefa.ExisteRegistro(_numeroTarefa);

                if (_numeroTarefaEncontrada == false)
                    notificador.ApresentarMensagem("ID da Tarefa não foi encontrada, digite novamente", TipoMensagem.Atencao);

            } while (_numeroTarefaEncontrada == false);

            return _numeroTarefa;
        }
    }
}
