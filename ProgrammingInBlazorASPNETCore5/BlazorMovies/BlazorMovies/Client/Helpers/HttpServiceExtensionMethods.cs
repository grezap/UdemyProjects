﻿using BlazorMovies.Shared.DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Helpers
{
    public static class HttpServiceExtensionMethods
    {
        public static async Task<T> GetHelper<T>(this IHttpService httpService, string url)
        {
            var response = await httpService.Get<T>(url);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public static async Task<PaginatedResponse<T>> GetHelper<T>(this IHttpService httpService, string url, PaginationDTO paginationDTO)
        {
            string newURL = "";
            if (url.Contains("?"))
            {
                newURL = $"{url}&page={paginationDTO.Page}&recordsPerPage={paginationDTO.RecordsPerPage}";
            }
            else
            {
                newURL = $"{url}?page={paginationDTO.Page}&recordsPerPage={paginationDTO.RecordsPerPage}";
            }
            var response = await httpService.Get<T>(newURL);
            var totalAmountPages = int.Parse(response.HttpResponseMessage.Headers.GetValues("totalAmountPages").FirstOrDefault());

            var paginatedResponse = new PaginatedResponse<T>() 
            {
                Response = response.Response,
                TotalAmountPages = totalAmountPages
            };

            return paginatedResponse;
        }
    }
}
