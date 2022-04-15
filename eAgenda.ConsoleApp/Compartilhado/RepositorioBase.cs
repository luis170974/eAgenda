using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.ConsoleApp.Compartilhado
{
    public abstract class RepositorioBase<T> : IRepositorio<T> where T : EntidadeBase
    {
        protected readonly List<T> registros;

        protected int contador;

        public RepositorioBase()
        {
            registros = new List<T>();
        }

        public virtual string Inserir(T entidade)
        {
            entidade.numero = ++contador;

            registros.Add(entidade);

            return "REGISTRO_CORRETO";
        }

        public bool Editar(int numeroEscolhido, T entidade)
        {
            for (int i = 0; i < registros.Count; i++)
            {
                if (registros[i].numero == numeroEscolhido)
                {
                    entidade.numero = numeroEscolhido;
                    registros[i] = entidade;

                    return true;
                }

            }
            return false;
        }

        public bool Editar(Predicate<T> condicao, T novaEntidade)
        {
            foreach (T entidade in registros)
            {
                if (condicao(entidade))
                {
                    novaEntidade.numero = entidade.numero;

                    int posicaoParaEditar = registros.IndexOf(entidade);
                    registros[posicaoParaEditar] = novaEntidade;

                    return true;
                }
            }

            return false;
        }

        public bool Excluir(int numeroEscolhido)
        {
            T entidadeSelecionada = SelecionarRegistro(numeroEscolhido);

            if (entidadeSelecionada == null)
                return false;

            registros.Remove(entidadeSelecionada);

            return true;
        }

        public bool Excluir(Predicate<T> condicao)
        {
            foreach (T entidade in registros)
            {
                if (condicao(entidade))
                {
                    registros.Remove(entidade);
                    return true;
                }
            }
            return false;
        }

        public T SelecionarRegistro(int numeroRegistro)
        {
            return registros.Find(x => x.numero.Equals(numeroRegistro));


        }

        public List<T> SelecionarTodos()
        {
            return registros;
        }

        public List<T> Filtrar(Predicate<T> condicao)
        {
            List<T> registrosFiltrados = new List<T>();

            foreach (T registro in registros)
                if (condicao(registro))
                    registrosFiltrados.Add(registro);

            return registrosFiltrados;
        }

        public bool ExisteRegistro(int numeroRegistro)
        {
            foreach (T registro in registros)
                if (registro.numero == numeroRegistro)
                    return true;

            return false;
        }

        public bool ExisteRegistro(Predicate<T> condicao)
        {
            foreach (T entidade in registros)
                if (condicao(entidade))
                    return true;

            return false;
        }



    }
}
