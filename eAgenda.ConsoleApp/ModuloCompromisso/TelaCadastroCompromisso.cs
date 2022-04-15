using eAgenda.ConsoleApp.Compartilhado;
using eAgenda.ConsoleApp.ModuloContato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.ConsoleApp.ModuloCompromisso
{
    public class TelaCadastroCompromisso : TelaBase, ICadastroBasico
    {
        private readonly IRepositorio<Compromisso> _repositorioCompromisso;

        private readonly IRepositorio<Contatos> _repositorioContato;
        private readonly TelaCadastroContato _telaCadastroContato;
        Contatos contato;

        public TelaCadastroCompromisso(IRepositorio<Compromisso> repositorioCompromisso, IRepositorio<Contatos> repositorioContato, TelaCadastroContato telaCadastroContato) : base("Cadastro de Compromissos")
        {
            _repositorioCompromisso = repositorioCompromisso;
            _repositorioContato = repositorioContato;
            _telaCadastroContato = telaCadastroContato;

        }

        public void InserirRegistro()
        {
            MostrarTitulo("Cadastro de Compromisso");

            Compromisso novoCompromisso = ObterCompromisso();

            _repositorioCompromisso.Inserir(novoCompromisso);

            notificador.ApresentarMensagem("Compromisso cadastrado com sucesso!", TipoMensagem.Sucesso);
        }

        public void EditarRegistro()
        {
            MostrarTitulo("Editando Compromisso");

            bool temCompromissoCadastrado = VisualizarRegistro("Pesquisando");

            if (temCompromissoCadastrado == false)
            {
                notificador.ApresentarMensagem("Nenhum compromisso cadastrado para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroCompromisso = ObterNumeroCompromisso();

            Compromisso compromissoAtualizado = ObterCompromisso();

            bool conseguiuEditar = _repositorioCompromisso.Editar(numeroCompromisso, compromissoAtualizado);

            if (!conseguiuEditar)
                notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                notificador.ApresentarMensagem("Compromisso editado com sucesso!", TipoMensagem.Sucesso);
        }

        public void ExcluirRegistro()
        {
            MostrarTitulo("Excluindo Compromisso");

            bool temCompromissoRegistrado = VisualizarRegistro("Pesquisando");

            if (temCompromissoRegistrado == false)
            {
                notificador.ApresentarMensagem("Nenhum compromisso cadastrado para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroCompromisso = ObterNumeroCompromisso();

            bool conseguiuExcluir = _repositorioCompromisso.Excluir(numeroCompromisso);

            if (!conseguiuExcluir)
                notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                notificador.ApresentarMensagem("Compromisso excluído com sucesso", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistro(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Compromissos");

            List<Compromisso> compromissos = _repositorioCompromisso.SelecionarTodos();

            if (compromissos.Count == 0)
            {
                notificador.ApresentarMensagem("Nenhum compromisso disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Compromisso compromisso in compromissos)
                Console.WriteLine(compromisso.ToString());

            Console.ReadLine();

            return true;
        }

        private Compromisso ObterCompromisso()
        {

            Console.Write("Digite o assunto do compromisso: ");
            string assuntoDoCompromisso = Console.ReadLine();

            Console.Write("Digite o local do compromisso: ");
            string localDoCompromisso = Console.ReadLine();

            Console.WriteLine("Digite a data do compromisso: ");
            DateTime dataDoCompromisso = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Digite a hora de inicio do compromisso: ");
            DateTime HoraInicioCompromisso = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Digite a hora de término do compromisso: ");
            DateTime HoraTerminoCompromisso = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Digite o nome do contato participante ");

            string nomeContato = Console.ReadLine();

            contato = BuscarContato(nomeContato);

            



            return new Compromisso(assuntoDoCompromisso, assuntoDoCompromisso, dataDoCompromisso, HoraInicioCompromisso, HoraTerminoCompromisso, contato);
        }

        public int ObterNumeroCompromisso()
        {
            int numeroRegistro;
            bool numeroContatoEncontrado;

            do
            {
                Console.Write("Digite o ID do Contato que deseja editar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroContatoEncontrado = _repositorioCompromisso.ExisteRegistro(numeroRegistro);

                if (numeroContatoEncontrado == false)
                    notificador.ApresentarMensagem("ID do Contato não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroContatoEncontrado == false);

            return numeroRegistro;
        }

        private Contatos BuscarContato(string nomeContato)
        {
            List<Contatos> contatos = _repositorioContato.SelecionarTodos();
            return contatos.Find(c => c.Nome.Equals(nomeContato));
        }
    }
}
