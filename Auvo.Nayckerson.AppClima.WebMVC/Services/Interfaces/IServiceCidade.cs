using Auvo.Nayckerson.AppClima.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auvo.Nayckerson.AppClima.WebMVC.Services.Interfaces
{
    public interface IServiceCidade
    {
        IList<Cidade> GetCidades();
        Cidade GetCidade(int? cidadeId);
    }
}
