using EthanMacNamaraKneat.Interfaces;

namespace EthanMacNamaraKneat
{
    public class StarShipServiceFactory : IResourceserviceFactory<StarShipService>
    {
        public StarShipServiceFactory()
        {
        }

        public StarShipService CreateInstance()
        {
            return new StarShipService(new CommandLineService(), new SharpTrooper.Core.SharpTrooperCore());
        }
    }
}