using System.Text.Json;
using TercerP.Models;

namespace TercerP.Services
{
    public class ArqueroService
    {
        private readonly string filePath =
            Path.Combine("wwwroot", "data", "arqueros.json");

        public List<Arquero> ObtenerArqueros()
        {
            if (!File.Exists(filePath))
            {
                return new List<Arquero>();
            }

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Arquero>();
            }

            return JsonSerializer.Deserialize<List<Arquero>>(json)
                   ?? new List<Arquero>();
        }

        public void GuardarArquero(Arquero arquero)
        {
            List<Arquero> arqueros = ObtenerArqueros();

            arqueros.Add(arquero);

            string json = JsonSerializer.Serialize(
                arqueros,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(filePath, json);
        }
    }
}
