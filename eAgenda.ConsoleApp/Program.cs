using eAgenda.ConsoleApp.Compartilhado;
using System;

namespace eAgenda.ConsoleApp
{
    public class Program
    {
        static NotificadorMensagem notificador = new();
        static TelaAgendaPrincipal menuAgendaPrincipal = new(new NotificadorMensagem());

        static void Main(string[] args)
        {
            while (true)
            {
                TelaBase telaEscolhida = menuAgendaPrincipal.ObterTela();

                if(telaEscolhida == null)
                    break;

                string opcaoEscolhida = telaEscolhida.MostrarOpcoes();

                if(telaEscolhida is ICadastroBasico)
                {
                    ICadastroBasico telaCadastroBasico = (ICadastroBasico)telaEscolhida;

                    if(opcaoEscolhida == "1")
                        telaCadastroBasico.InserirRegistro();

                    if (opcaoEscolhida == "2")
                        telaCadastroBasico.EditarRegistro();

                    if (opcaoEscolhida == "3")
                        telaCadastroBasico.ExcluirRegistro();

                    if (opcaoEscolhida == "4")
                        telaCadastroBasico.VisualizarRegistro("Tela");





                }
                
            }


        }

    }
}
