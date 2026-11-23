
using System.Text;
using System.Text.Json;
using AiDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AiDemo.Pages;

public class IndexModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    [BindProperty]
    public string Prompt { get; set; } = string.Empty;

    public string GeneratedImageUrl { get; set; } =
        "https://placehold.co/800x500?text=Image+Preview";

    public string ImageMessage { get; set; } = string.Empty;

    [BindProperty]
    public string TextPrompt { get; set; } = string.Empty;

    public string TextAnswer { get; set; } = string.Empty;

    public IndexModel(
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }

    public async Task OnPostGenerateImage()
    {
        var endpoint = _configuration["Foundry:Endpoint"];
        var apiKey = _configuration["Foundry:ApiKey"];
        var model = _configuration["Foundry:ImageModel"];

        if (string.IsNullOrWhiteSpace(endpoint) ||
            string.IsNullOrWhiteSpace(apiKey) ||
            string.IsNullOrWhiteSpace(model))
        {
            ImageMessage = "Missing Foundry configuration.";
            GeneratedImageUrl =
                "https://placehold.co/800x500?text=Missing+Secrets";
            return;
        }

        try
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("api-key", apiKey);

            var request = new ImageGenerationRequest
            {
                Prompt = Prompt,
                Width = 1024,
                Height = 768,
                Model = model
            };

            var json = JsonSerializer.Serialize(request);

            using var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var imageEndpoint =
                $"{endpoint.TrimEnd('/')}/mai/v1/images/generations";

            using var response = await client.PostAsync(
                imageEndpoint,
                content);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                using JsonDocument jsonDocument =
                    JsonDocument.Parse(body);

                string? base64Image = jsonDocument.RootElement
                    .GetProperty("data")[0]
                    .GetProperty("b64_json")
                    .GetString();

                if (!string.IsNullOrWhiteSpace(base64Image))
                {
                    GeneratedImageUrl =
                        $"data:image/png;base64,{base64Image}";

                    ImageMessage = "Image generated successfully!";
                }
                else
                {
                    ImageMessage =
                        "The response did not contain an image.";
                }
            }
            else
            {
                ImageMessage =
                    $"Image request failed: {(int)response.StatusCode} " +
                    $"{response.ReasonPhrase}";

                GeneratedImageUrl =
                    "https://placehold.co/800x500?text=Image+Request+Failed";
            }
        }
        catch (Exception ex)
        {
            ImageMessage = $"Error: {ex.Message}";

            GeneratedImageUrl =
                "https://placehold.co/800x500?text=Image+Error";
        }
    }

    public async Task OnPostGenerateText()
    {
        var endpoint = _configuration["Foundry:Endpoint"];
        var apiKey = _configuration["Foundry:ApiKey"];
        var model = _configuration["Foundry:TextModel"];

        if (string.IsNullOrWhiteSpace(endpoint) ||
            string.IsNullOrWhiteSpace(apiKey) ||
            string.IsNullOrWhiteSpace(model))
        {
            TextAnswer = "Missing GPT-5 secret configuration.";
            return;
        }

        try
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("api-key", apiKey);

            var request = new TextGenerationRequest
            {
                Model = model,
                Input = TextPrompt,
                MaxOutputTokens = 1000
            };

            var requestJson = JsonSerializer.Serialize(request);

            using var content = new StringContent(
                requestJson,
                Encoding.UTF8,
                "application/json");

            var textEndpoint = endpoint.TrimEnd('/');

            if (!textEndpoint.EndsWith(
                "/responses",
                StringComparison.OrdinalIgnoreCase))
            {
                textEndpoint = textEndpoint.Contains(
                    "/openai",
                    StringComparison.OrdinalIgnoreCase)
                    ? $"{textEndpoint}/responses"
                    : $"{textEndpoint}/openai/v1/responses";
            }

            using var response = await client.PostAsync(
                $"{textEndpoint}?api-version=v1",
                content);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                using JsonDocument responseJson =
                    JsonDocument.Parse(body);

                string? answer = null;

                if (responseJson.RootElement.TryGetProperty(
                    "output", out var output))
                {
                    foreach (var item in output.EnumerateArray())
                    {
                        if (!item.TryGetProperty(
                            "content", out var contentArray))
                        {
                            continue;
                        }

                        foreach (var contentItem in contentArray.EnumerateArray())
                        {
                            if (contentItem.TryGetProperty(
                                    "type", out var type) &&
                                type.GetString() == "output_text" &&
                                contentItem.TryGetProperty(
                                    "text", out var textElement))
                            {
                                answer = textElement.GetString();
                                break;
                            }
                        }

                        if (!string.IsNullOrWhiteSpace(answer))
                        {
                            break;
                        }
                    }
                }

                TextAnswer = answer ?? "No answer was returned.";
            }
            else
            {
                TextAnswer = "The GPT-5 request failed.";
            }
        }
        catch (Exception ex)
        {
            TextAnswer = $"Error: {ex.Message}";
        }
    }
}
