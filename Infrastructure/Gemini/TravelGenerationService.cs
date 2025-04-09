using System.Runtime.ConstrainedExecution;
using System;
using travelplanner.Domain.Models;
using travelplanner.Domain.Service;
using System.Text;

namespace travelplanner.Infrastructure.Gemini
{
    public class TravelGenerationService : ITravelGeneration
    {
        private readonly string? _geminiKey;
        private readonly string? _geminiModel;

        public TravelGenerationService(IConfiguration configuration)
        {
            _geminiKey = configuration.GetSection("Gemini")["Key"];
            _geminiModel = configuration.GetSection("Gemini")["Model"];
        }
        public async Task<string?> GenerateLandmarks(string cityName)
        {
            string prompt = "Beschreibe die wichtigsten Sehenswürdigkeiten der folgenden Stadt: " + cityName;

            return await SendPrompt(prompt);
        }

        public async Task<string?> GernerateTravelReport(IEnumerable<TravelTargets> targets)
        {
            StringBuilder promptBuilder = new StringBuilder();

            promptBuilder.AppendLine("Generiere bitte eine Rundreise durch folgende Orte: ");

            foreach (TravelTargets target in targets)
            {
                promptBuilder.AppendLine(/*Stadtname hier aus dem target extrahieren!*/);
                promptBuilder.AppendLine(/*Beschreibung der Sehenswürdigkeiten hier aus dem Target extrahieren!*/);
                promptBuilder.AppendLine();
            }

            return await SendPrompt(promptBuilder.ToString());
        }

        private async Task<string?> SendPrompt(string prompt)
        {
            var requestUri = $"https://generativelanguage.googleapis.com/v1beta/models/{_geminiModel}:generateContent?key={_geminiKey}";

            var requestBody = new
            {
                contents = new[]
                {
                new
                {
                    parts = new[]
                    {
                        new
                        {
                            text = prompt
                        }
                    }
                }
            }
            };



            //Der Rest muss selbst implementiert werden

            return "";
        }
    }
}
