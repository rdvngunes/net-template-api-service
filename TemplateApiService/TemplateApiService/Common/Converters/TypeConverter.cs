using Jal.HttpClient.Model;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using TemplateApiService.Common.Extensions;
using TemplateApiService.Common.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TemplateApiService.Common.Converters
{
    public static class TypeConverter
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Configure()
        {
            TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);


            // 
            // Auto Mapper - HttpResponseMessage -> ApiRestResponseResult 
            TypeAdapterConfig<HttpResponseMessage, ApiRestResponseResult>.NewConfig().PreserveReference(true).MapWith(map => map.ToApiRestResponseResult(), applySettings: true);

            // Auto Mapper - HttpResponse -> ApiRestResponseResult
            TypeAdapterConfig<HttpResponse, ApiRestResponseResult>.NewConfig().PreserveReference(true).MapWith(map => map.ToApiRestResponseResult(), applySettings: true);


            // Auto Mapper - ApiRestResponseResult -> ObjectResult 
            TypeAdapterConfig<ApiRestResponseResult, ObjectResult>.NewConfig().PreserveReference(true).MapWith(map => map.ToObjectResult(), applySettings: true);


        }

    }
}
