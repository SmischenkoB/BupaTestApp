using WebApplication1.Services;

namespace WebApiServiceTests
{
    public class MOTApiServiceTests
    {
        [Fact]
        public async void TestApi_Successful()
        {
            MOTApiService mOTApiService = new MOTApiService();


            //var result = await mOTApiService.GetVehicleData();

            //Assert.NotNull(result);
        }
    }
}