using eAgenda.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.ConsoleApp.ModuloContato
{
    public class TelaCadastroContato : TelaBase, ICadastroBasico
    {
        private readonly IRepositorio<Contatos> _repositorioContato;

        public TelaCadastroContato(IRepositorio<Contatos> repositorioContato) : base("Cadastro de Contato")
        {
            _repositorioContato = repositorioContato;



        }
        public void InserirRegistro()
        {
            MostrarTitulo("Cadastro de Contatos");

            Contatos novoContato = ObterContato();

            _repositorioContato.Inserir(novoContato);

            notificador.ApresentarMensagem("Contato cadastrado com sucesso!", TipoMensagem.Sucesso);
        }

        public void EditarRegistro()
        {
            MostrarTitulo("Editando Contato");

            bool temContatoCadastrado = VisualizarRegistro("Pesquisando");

            if (temContatoCadastrado == false)
            {
                notificador.ApresentarMensagem("Nenhum contato cadastrado para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroContato = ObterNumeroContato();

            Contatos contatoAtualizado = ObterContato();

            bool conseguiuEditar = _repositorioContato.Editar(numeroContato, contatoAtualizado);

            if (!conseguiuEditar)
                notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                notificador.ApresentarMensagem("Contato editado com sucesso!", TipoMensagem.Sucesso);
        }

        public void ExcluirRegistro()
        {
            MostrarTitulo("Excluindo Contato");

            bool temContatosRegistrado = VisualizarRegistro("Pesquisando");

            if (temContatosRegistrado == false)
            {
                notificador.ApresentarMensagem("Nenhum contato cadastrado para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroContato = ObterNumeroContato();

            bool conseguiuExcluir = _repositorioContato.Excluir(numeroContato);

            if (!conseguiuExcluir)
                notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                notificador.ApresentarMensagem("Contato excluído com sucesso", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistro(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Contatos");

            List<Contatos> contatos = _repositorioContato.SelecionarTodos();

            if (contatos.Count == 0)
            {
                notificador.ApresentarMensagem("Nenhum contato disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Contatos contato in contatos)
                Console.WriteLine(contato.ToString());

            Console.ReadLine();

            return true;
        }

        private Contatos ObterContato()
        {

            Console.Write("Digite o nome do contato: ");
            string nomeContato = Console.ReadLine();

            Console.Write("Digite a email do contato: ");
            string emailContato = Console.ReadLine();

            Console.WriteLine("Digite o telefone do contato");
            string telefoneContato = Console.ReadLine();

            Console.WriteLine("Digite o nome da empresa");
            string empresaContato = Console.ReadLine();

            Console.WriteLine("Digite o cargo do contato");
            string cargoContato = Console.ReadLine();



            return new Contatos(nomeContato, emailContato, telefoneContato, empresaContato, cargoContato);
        }

        public int ObterNumeroContato()
        {
            int numeroRegistro;
            bool numeroContatoEncontrado;

            do
            {
                Console.Write("Digite o ID do Contato que deseja editar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroContatoEncontrado = _repositorioContato.ExisteRegistro(numeroRegistro);

                if (numeroContatoEncontrado == false)
                    notificador.ApresentarMensagem("ID do Contato não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroContatoEncontrado == false);

            return numeroRegistro;
        }

    }
}
