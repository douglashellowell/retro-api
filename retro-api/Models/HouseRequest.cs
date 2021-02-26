using System;
namespace retro_api.Models
{
    public class HouseRequest
    {
        public string HouseName { get; set; }
        public string Founder { get; set; }
        public string Animal { get; set; }

        // don't put method here :(
    }

    // this adds the method onto HouseRequest
    // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-implement-and-call-a-custom-extension-method
    public static class HouseRequestExtension
    {
        public static House ToHouse(this HouseRequest houseRequest)
        {
            return new House()
            {
                HouseName = houseRequest.HouseName,
                Founder = houseRequest.Founder,
                Animal = houseRequest.Animal
            };
        }
    }
}
