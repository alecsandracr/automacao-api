using System;
using RestSharp;
using Xunit;
using FluentAssertions;
using Newtonsoft.Json;
using Correios.Models;

namespace Correios
{
    public class  Program
    {
        private IRestResponse GetCEP(Object CEP)
        {
            var client = new RestClient("http://viacep.com.br/ws/"+CEP+"/json/");
            var RSrequest = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };
            return client.Execute(RSrequest);
        }

        [Fact]
        
        public void sucesso()
        {
            var response = GetCEP("3077440");
            var json = JsonConvert.DeserializeObject<CorreiosResponse>(response.Content);

            json.Cep.Should().Be("3077440");
            json.Logradouro.Should().Be("Rua Maria ");
            json.Complemento.Should().Be("");
            json.Bairro.Should().Be("Havaí");
            json.Localidade.Should().Be("Ibirité");
            json.UF.Should().Be("MG");
            json.Ibge.Should().Be("3077440");
            json.Gia.Should().Be("");
            response.StatusCode.Should().Be(200);

    }

    }
}
