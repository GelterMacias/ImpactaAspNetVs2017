using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repositorios.WebApi
{
    public class ProductRepositorio
    {
        private HttpClient httpClient = new HttpClient(); //para fazer chamada http
        private string url = "http://localhost:51584/api/products"; //deveria estar no app config

        public async Task<ProductViewModel> Post(ProductViewModel product) //Inserir
        {
            using (var resposta = await httpClient.PostAsJsonAsync(url, product))
            {
                resposta.EnsureSuccessStatusCode();
                return await resposta.Content.ReadAsAsync<ProductViewModel>();
            }
        }

        public async Task Put(ProductViewModel product) //Editar
        {
            //                                                              parametros = Onde , O que
            using (var resposta = await httpClient.PutAsJsonAsync($"{url}/{product.ProductID}",product)) //async precisa de await
            {
                resposta.EnsureSuccessStatusCode();
            }
        }

        public async Task<List<ProductViewModel>> Get() //async só disponivel pelo Nuget MS Web.Api.Client
        {
            using (var resposta = await httpClient.GetAsync(url))
            {
                return await resposta.Content.ReadAsAsync<List<ProductViewModel>>();
            }
        }

        public async Task<ProductViewModel> Get(int id) 
        {
            using (var resposta = await httpClient.GetAsync($"{url}/{id}"))
            {
                return await resposta.Content.ReadAsAsync<ProductViewModel>();
            }
        }

        public async Task Delete(int id) //= void
        {
            using (var resposta = await httpClient.DeleteAsync($"{url}/{id}"))
            {
                resposta.EnsureSuccessStatusCode();
            }
        }

    }
}
