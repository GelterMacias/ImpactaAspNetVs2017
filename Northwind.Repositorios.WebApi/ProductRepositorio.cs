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
        private HttpClient httpClient = new HttpClient();
        private string url = "http://localhost:51584/api/products"; //deveria estar no app config

        public async Task<ProductViewModel> Post(ProductViewModel product)
        {
            using (var resposta = await httpClient.PostAsJsonAsync(url, product))
            {
                resposta.EnsureSuccessStatusCode();
                return await resposta.Content.ReadAsAsync<ProductViewModel>();
            }
        }
    }
}
