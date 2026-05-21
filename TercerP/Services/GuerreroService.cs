using System.Text.Json;
using TercerP.Models;

namespace TercerP.Services
{
    public class GuerreroService
    {
        private readonly string filePath =
            Path.Combine("wwwroot", "data", "guerreros.json");

        public List<Guerrero> ObtenerGuerreros()
        {
            if (!File.Exists(filePath))
            {
                return new List<Guerrero>();
            }

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Guerrero>();
            }

            return JsonSerializer.Deserialize<List<Guerrero>>(json)
                   ?? new List<Guerrero>();
        }

        public void GuardarGuerrero(Guerrero guerrero)
        {
            List<Guerrero> guerreros = ObtenerGuerreros();

            guerreros.Add(guerrero);

            string json = JsonSerializer.Serialize(
                guerreros,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(filePath, json);
        }
    }
}
