﻿using Oficina.Dominio;
using Oficina.Repositorios.SistemaDeArquivos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Oficina.WebPages
{
    public class VeiculoAplicacao

        //View Model: O que minha página precisa
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
        public List<Modelo> Modelos { get; set; } = new List<Modelo>(); //para não dar erro na página
        public List<Combustivel> Combustiveis { get; set; } //enumeradores
        public List<Cambio> Cambios { get; set; } //enumeradores

        //COnstrutor para chamar os dados
        //Inicia as listas populadas
        //Toda vez que a classe é chamada ele é executado
        public VeiculoAplicacao()
        {
            PopularControles();
        }


        private void PopularControles()
        {
            Marcas = _marcaRepositorio.Selecionar();
            MarcaSelecionada = HttpContext.Current.Request.QueryString["marcaId"];

            if (!string.IsNullOrEmpty(MarcaSelecionada))
            {
                Modelos = _modeloRepositorio.SelecionarPorMarca(Convert.ToInt32(MarcaSelecionada));
            }

            Cores = _corRepositorio.Selecionar();
            Combustiveis = Enum.GetValues(typeof(Combustivel)).Cast<Combustivel>().ToList();
            Cambios = Enum.GetValues(typeof(Cambio)).Cast<Cambio>().ToList();

        }

        public void Inserir()
        {
            //Ctrl+K+S

            //Tratamento de erro
            // F9 = Cria Breakpoint 
            // F10 = Avança no código
            // F11 = Verifica ser tem dependencia e vai para ela 
            // F5 = Avança de um BRKP para o Outro BRKP

            //normalmente se usa o try/catch na camada de interação com o usuario
            try
            {
                var veiculo = new VeiculoPasseio();
                var formulario = HttpContext.Current.Request.Form;

                veiculo.Ano = Convert.ToInt32(formulario["ano"]);
                veiculo.Cambio = (Cambio)Convert.ToInt32(formulario["cambio"]); //(Cambio)Conv.. = Cast
                veiculo.Combustivel = (Combustivel)Convert.ToInt32(formulario["combustivel"]);
                veiculo.Cor = _corRepositorio.Selecionar(Convert.ToInt32(formulario["cor"]));
                veiculo.Modelo = _modeloRepositorio.SelecionarModeloPorId(Convert.ToInt32(formulario["modelo"]));
                veiculo.Observacao = formulario["observacao"];
                veiculo.Placa = formulario["placa"];
                veiculo.Carroceria = TipoCarroceria.Suv;

                _veiculoRepositorio.Inserir(veiculo);
            }
            catch (FileNotFoundException ex)
            {
                HttpContext.Current.Items.Add("MensagemErro",$"Arquivo {ex.FileName} não econtrado.");
                //Propaga o erro para cima (próxima camada = Veiculo.cshtml), sem ele não vai aparacer na tela
                throw;
            }
            catch (UnauthorizedAccessException)
            {
                HttpContext.Current.Items.Add("MensagemErro", $"Arquivo sem permissão de gravação.");
                throw;
            }
            catch (DirectoryNotFoundException)
            {
                HttpContext.Current.Items.Add("MensagemErro", $"Diretorio não econtrado.");
                throw;
            }
            //Tem que existir sempre um exception em último lugar V V V
            //normalmente se usa apenas o exception
            catch (Exception excecao)
            {
                HttpContext.Current.Items.Add("MensagemErro", $"Ops, ocorreu um erro!");

                //logar o erro no objeto excecao
                //usar componente log4net


                throw;
                //throw excecao;
                //mata toda o erro desta camada para baixo, somente este erro para cima é propagado
            }
            finally
            {
                //independente de sucesso/erro executa o finally
                //executado mesmo que tenha um return antes.
            }
        }
    }
}