using NasaImages.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(NasaImages.Services.ApodService))]
namespace NasaImages.Services
{
    public interface IApodService
    {
        Task<TResult> GetAposAsync<TResult>();
    }
}
