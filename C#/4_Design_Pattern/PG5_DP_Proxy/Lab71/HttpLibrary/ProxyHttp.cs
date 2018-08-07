using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpLibrary
{
    public class ProxyHttp : IHttpRequestable
    {
        private readonly Lazy<SocketHttp> _socketHttp = new Lazy<SocketHttp>();
        private readonly Lazy<Dictionary<Func<string>, string>> _cacheDictionary // Key: Method, Value: Http result
            = new Lazy<Dictionary<Func<string>, string>>();

        public ProxyHttp()
        {

        }

        public string RequestHttpBinDeleteMethod()
        {
            string result = null;

            if (!this._cacheDictionary.Value.ContainsKey(this._socketHttp.Value.RequestHttpBinDeleteMethod))
            {
                result = this._socketHttp.Value.RequestHttpBinDeleteMethod();
                this._cacheDictionary.Value.Add(this._socketHttp.Value.RequestHttpBinDeleteMethod, result);
            }

            result = this._cacheDictionary.Value[this._socketHttp.Value.RequestHttpBinDeleteMethod];

            return result;
        }

        public string RequestHttpBinGetMethod()
        {
            string result = null;

            if (!this._cacheDictionary.Value.ContainsKey(this._socketHttp.Value.RequestHttpBinGetMethod))
            {
                result = this._socketHttp.Value.RequestHttpBinGetMethod();
                this._cacheDictionary.Value.Add(this._socketHttp.Value.RequestHttpBinGetMethod, result);
            }

            result = this._cacheDictionary.Value[this._socketHttp.Value.RequestHttpBinGetMethod];

            return result;
        }

        public string RequestHttpBinPatchMethod()
        {
            string result = null;

            if (!this._cacheDictionary.Value.ContainsKey(this._socketHttp.Value.RequestHttpBinPatchMethod))
            {
                result = this._socketHttp.Value.RequestHttpBinPatchMethod();
                this._cacheDictionary.Value.Add(this._socketHttp.Value.RequestHttpBinPatchMethod, result);
            }

            result = this._cacheDictionary.Value[this._socketHttp.Value.RequestHttpBinPatchMethod];

            return result;
        }

        public string RequestHttpBinPostMethod()
        {
            string result = null;

            if (!this._cacheDictionary.Value.ContainsKey(this._socketHttp.Value.RequestHttpBinPostMethod))
            {
                result = this._socketHttp.Value.RequestHttpBinPostMethod();
                this._cacheDictionary.Value.Add(this._socketHttp.Value.RequestHttpBinPostMethod, result);
            }

            result = this._cacheDictionary.Value[this._socketHttp.Value.RequestHttpBinPostMethod];

            return result;
        }

        public string RequestHttpBinPutMethod()
        {
            string result = null;

            if (!this._cacheDictionary.Value.ContainsKey(this._socketHttp.Value.RequestHttpBinPutMethod))
            {
                result = this._socketHttp.Value.RequestHttpBinPutMethod();
                this._cacheDictionary.Value.Add(this._socketHttp.Value.RequestHttpBinPutMethod, result);
            }

            result = this._cacheDictionary.Value[this._socketHttp.Value.RequestHttpBinPutMethod];

            return result;
        }
    }
}
