using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auvo.Nayckerson.AppClima.WebMVC.Models
{
    [Table("PrevisaoClima")]
    public class PrevisaoClima
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataPrevisao { get; set; }
        public string Clima { get; set; }
        public int CidadeId { get; set; }

        [ForeignKey("CidadeId")]
        public Cidade Cidade { get; set; }
        public int TemperaturaMinima { get; set; }
        public int TemperaturaMaxima { get; set; }

        public DayOfWeek DiaDaSemana => DataPrevisao.DayOfWeek;

       
        public string TemperaturaMinimaInCelsius => string.Format("Min{0}℃", TemperaturaMinima);

       
        public string TemperaturaMaximaInCelsius => string.Format("Max{0}℃", TemperaturaMaxima);
    }
}