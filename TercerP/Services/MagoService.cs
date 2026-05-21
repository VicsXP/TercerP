using System.Text.Json;
using TercerP.Models;

namespace TercerP.Services
{
    public class MagoService
    {
        private readonly string filePath =
            Path.Combine("wwwroot", "data", "magos.json");

        public List<Mago> ObtenerMagos()
        {
            if (!File.Exists(filePath))
            {
                return new List<Mago>();
            }

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Mago>();
            }

            return JsonSerializer.Deserialize<List<Mago>>(json)
                   ?? new List<Mago>();
        }

        public void GuardarMago(Mago mago)
        {
            List<Mago> magos = ObtenerMagos();

            magos.Add(mago);

            string json = JsonSerializer.Serialize(
                magos,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(filePath, json);
        }
    }
}
