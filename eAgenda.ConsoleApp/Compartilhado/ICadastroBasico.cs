using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.ConsoleApp.Compartilhado
{
    public interface ICadastroBasico
    {

        void InserirRegistro();

        void EditarRegistro();

        void ExcluirRegistro();

        bool VisualizarRegistro(string tipoVisualizacao);


    }
}
