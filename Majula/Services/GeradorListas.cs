using Microsoft.AspNetCore.Mvc.Rendering;
using Pk.Data;

namespace Pk.Services
{
    public class GeradorListas
    {
        private readonly Contexto _context;

        public GeradorListas(Contexto context)
        {
            _context = context;
        }

        public SelectListItem[] ListaStatus()
        {
            var lista = new[] {

                 new SelectListItem () { Value = Constantes.Status.Disponivel, Text = Constantes.Status.Disponivel },
                new SelectListItem () { Value = Constantes.Status.EmUso, Text = Constantes.Status.EmUso },
                 new SelectListItem () { Value = Constantes.Status.Defeito, Text = Constantes.Status.Defeito },
             };
            return lista;
        }

        public SelectListItem[] ListaCategoria()
        {
            var lista = new[] {

                 new SelectListItem () { Value = Constantes.Categoria.Impressora, Text = Constantes.Categoria.Impressora },
                new SelectListItem () { Value = Constantes.Categoria.Nobreak, Text = Constantes.Categoria.Nobreak },
                 new SelectListItem () { Value = Constantes.Categoria.Scanner, Text = Constantes.Categoria.Scanner },
                 new SelectListItem () { Value = Constantes.Categoria.Switch, Text = Constantes.Categoria.Switch },
             };
            return lista;
        }

    }
}