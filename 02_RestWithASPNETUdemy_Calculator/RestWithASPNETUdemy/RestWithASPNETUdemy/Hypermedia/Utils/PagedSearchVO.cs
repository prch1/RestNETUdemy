using RestWithASPNETUdemy.Hypermedia.Abstract;
using System;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Hypermedia.Utils
{
    public class PagedSearchVO<T> where T : ISupportHyperMedia
    {
        public int PaginaAtual {  get; set; }

        public int TamanhoDaPagina { get; set; }

        public int TotalResultado { get; set; }

        public string CamposOrdenados { get; set; }

        public string OrdenacaoDirecionada { get; set; }

        public Dictionary<string,Object> Filtros { get; set;}

        public List<T> Lista { get; set; }

        public PagedSearchVO(){ }

        public PagedSearchVO(int paginaAtual, int tamanhoDaPagina, string camposOrdenados, string ordenacaoDirecionada)
        {
            PaginaAtual = paginaAtual;
            TamanhoDaPagina = tamanhoDaPagina;
            CamposOrdenados = camposOrdenados;
            OrdenacaoDirecionada = ordenacaoDirecionada;
        }

        public PagedSearchVO(int paginaAtual, int tamanhoDaPagina, string camposOrdenados, string ordenacaoDirecionada, Dictionary<string, object> filtros) 
        { 
            PaginaAtual = paginaAtual;
            TamanhoDaPagina = tamanhoDaPagina;
            CamposOrdenados = camposOrdenados;
            OrdenacaoDirecionada = ordenacaoDirecionada;
            Filtros = filtros;
        }

        public PagedSearchVO(int paginaAtual, string camposOrdenados, string ordenacaoDirecionada) 
             : this (paginaAtual, 10,camposOrdenados, ordenacaoDirecionada){ }

        public int GetPaginaAtual()
        {
            return PaginaAtual == 0 ? 2 : PaginaAtual;
        }

        public int GetTamanhoDaPagina()
        {
            return TamanhoDaPagina == 0 ? 10 : TamanhoDaPagina;
        }
    }
}
