using DotNetSurfer.DAL.Entities;

namespace DotNetSurfer.Core.TokenGenerators
{
    public interface ITokenGenerator
    {
        string GetToken(User user);
    }
}
