using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModisaApp.Shared.Interfaces.Providers
{
    public interface IHttpServiceProvider
    {
        Task<TResponse?> Get<TResponse>(string url);
        Task<TResponse?> Post<T, TResponse>(string url, T data);
        Task<TResponse?> Post<TResponse>(string url);
        Task<TResponse?> Put<T, TResponse>(string url, T data);
        Task<TResponse?> Put<TResponse>(string url);
        Task<TResponse?> Delete<TResponse>(string url);
    }
}
