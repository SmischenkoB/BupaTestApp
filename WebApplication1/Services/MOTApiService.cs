using Microsoft.AspNetCore.Http;
using System.Text.Json;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class MOTApiService
    {
        static HttpClient client = new HttpClient();

        public async Task<VehicleData> GetVehicleData(string registrationNumber, string ApiKey)
        {
            var path = new Uri($"https://beta.check-mot.service.gov.uk/trade/vehicles/mot-tests?registration={registrationNumber}");

            client.DefaultRequestHeaders.Add("x-api-key", ApiKey);

            var response = await client.GetAsync(path);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseResultStream = response.Content.ReadAsStream();
            var DTOResponse = await JsonSerializer.DeserializeAsync<IList<ApiResponseDTO>>(responseResultStream);

            return new VehicleData()
            {
                Colour = DTOResponse[0].primaryColour,
                ExpireDate = DateTime.Parse(DTOResponse[0].motTests[0].expiryDate),
                Make = DTOResponse[0].make,
                Mileage = Int32.Parse(DTOResponse[0].motTests[0]?.odometerValue),
                Model = DTOResponse[0].model
            };
        }
    }
}
