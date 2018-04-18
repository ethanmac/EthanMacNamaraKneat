namespace EthanMacNamaraKneat.Interfaces
{
    public interface IResourceserviceFactory<T>
    {
        T CreateInstance();
    }
}