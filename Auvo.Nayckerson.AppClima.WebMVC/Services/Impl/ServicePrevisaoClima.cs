using Auvo.Nayckerson.AppClima.WebMVC.Models;
using Auvo.Nayckerson.AppClima.WebMVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Auvo.Nayckerson.AppClima.WebMVC.Services.Impl
{
    public class ServicePrevisaoClima : IServicePrevisaoClima
    {
        private readonly Context context;

        public ServicePrevisaoClima(Context context)
        {
            this.context = context;
        }

        public IList<PrevisaoClima> GetMaisQuentesHoje(int qtd)
        {
            return context.PrevisaoClimas
                          .Include(x => x.Cidade)
                          .Include(x => x.Cidade.Estado)
                          .ToList()
                          .GroupBy(x => x.Cidade)
                          .ToDictionary(
                                x => x.Key,
                                x => x.OrderBy(prev => prev.TemperaturaMaxima)
                                      .FirstOrDefault())
                          .Select(x => x.Value)
                          .ToList();
        }

        public IList<PrevisaoClima> GetMaisFriosHoje(int qtd)
        {
            return context.PrevisaoClimas
                          .Include(x => x.Cidade)
                          .Include(x => x.Cidade.Estado)
                          .ToList()
                          .GroupBy(x => x.Cidade)
                          .ToDictionary(
                                x => x.Key,
                                x => x.OrderByDescending(prev => prev.TemperaturaMinima)
                                      .FirstOrDefault())
                          .Select(x => x.Value)
                          .ToList();
        }

        public IList<PrevisaoClima> GetPrevisoesDosProximos7Dias(int? cidadeId)
        {
            if (cidadeId == null)
            {
                return Enumerable.Empty<PrevisaoClima>().ToList();
            }

            return context.PrevisaoClimas.Where(x => x.CidadeId == cidadeId.Value
                                          && x.DataPrevisao >= DateTime.Today)
                                         .Take(7)
                                         .ToList();
        }
    }
}