using Oficina.Dominio;
using Oficina.Repositorios.SistemaDeArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oficina.WebPages
{
    public class VeiculoAplicacao
    {
        //Fields para os repositorios a serem utilizados (quem providencia os dados)
        //Como field pq será usado em mais de um método
        private VeiculoRepositorio _veiculoRepositorio = new VeiculoRepositorio();
        private MarcaRepositorio _marcaRepositorio = new MarcaRepositorio();
        private ModeloRepositorio _modeloRepositorio = new ModeloRepositorio();
        private CorRepositorio _corRepositorio = new CorRepositorio();

        //Declarar as listas em Properties (prop + tab)
        //Definido as necessidades
        public List<Marca> Marcas { get; set; }
        public string MarcaSelecionada { get; set; }
        public List<Cor> Cores { get; set; }
        public List<Modelo> Modelos { get; set; }
        public List<Combustivel> Combustiveis { get; set; } //enumeradores
        public List<Cambio> Cambios { get; set; } //enumeradores

        //COnstrutor para chamar os dados
        //Inicia as listas populadas
        public VeiculoAplicacao()
        {
            PopularControles();
        }


        private void PopularControles()
        {
            Marcas = _marcaRepositorio.Selecionar();
            Cores = _corRepositorio.Selecionar();
            Combustiveis = Enum.GetValues(typeof(Combustivel)).Cast<Combustivel>().ToList();
            Cambios = Enum.GetValues(typeof(Cambio)).Cast<Cambio>().ToList();

        }
    }
}