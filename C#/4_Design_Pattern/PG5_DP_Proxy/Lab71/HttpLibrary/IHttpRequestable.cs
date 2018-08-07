namespace HttpLibrary
{
    public interface IHttpRequestable
    {
        string RequestHttpBinDeleteMethod();

        string RequestHttpBinGetMethod();

        string RequestHttpBinPatchMethod();

        string RequestHttpBinPostMethod();

        string RequestHttpBinPutMethod();
    }
}
