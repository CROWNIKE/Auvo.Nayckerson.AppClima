using Auvo.Nayckerson.AppClima.WebMVC.Models;
using Auvo.Nayckerson.AppClima.WebMVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auvo.Nayckerson.AppClima.WebMVC.Services.Impl
{
    public class ServiceCidade : IServiceCidade
    {
        private readonly Context context;

        public ServiceCidade(Context context)
        {
            this.context = context;
        }

        public Cidade GetCidade(int? cidadeId)
        {
            return context.Cidades.FirstOrDefault(x => x.Id == cidadeId);
        }

        public IList<Cidade> GetCidades()
        {
            return context.Cidades.ToList();
        }
    }
}