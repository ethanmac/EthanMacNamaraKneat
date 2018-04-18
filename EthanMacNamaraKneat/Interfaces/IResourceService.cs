using System.Collections.Generic;

namespace EthanMacNamaraKneat.Interfaces
{
    public interface IResourceService<T>
    {
        List<T> getAllResource();
    }
}