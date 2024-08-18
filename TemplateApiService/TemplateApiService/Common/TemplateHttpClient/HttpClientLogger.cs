using Jal.HttpClient.Impl;
using Jal.HttpClient.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Text;

namespace TemplateApiService.Common.SoraHttpClient
{
    public class HttpClientLogger : AbstractHttpInterceptor
    {
        private readonly ILogger<HttpClientLogger> _log;

        public HttpClientLogger(ILogger<HttpClientLogger> log)
        {
            _log = log;
        }

        public override void OnEntry(HttpRequest request)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Constraint Manager Service :: HTTP CLIENT REQUEST :: START");
            builder.AppendLine($"Url: {request.Url}");
            builder.AppendLine($"Route: {request.Uri.PathAndQuery}");
            builder.AppendLine($"Method: {request.HttpMethod.ToString().ToUpper()}");

            foreach (var httpHeader in request.Headers)
            {
                builder.AppendLine($"{httpHeader.Name}: {httpHeader.Value} ");
            }

            var contenttype = request.Content.GetContentType();
            if (!string.IsNullOrWhiteSpace(contenttype))
            {
                builder.AppendLine($"Content Type: {contenttype}");
            }

            builder.AppendLine("");

            if (!string.IsNullOrWhiteSpace(request.Content.ToString()))
            {
                builder.AppendLine($"Body: {request.Content}");
            }

            builder.AppendLine($"Template Service :: HTTP CLIENT REQUEST :: END");

            _log.LogInformation(builder.ToString());
        }

        public override void OnExit(HttpResponse response, HttpRequest request)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Template Service :: HTTP CLIENT RESPONSE :: START");
            builder.AppendLine($"Request Url: {request.Url}");

            if (response.HttpExceptionStatus.HasValue)
            {
                builder.AppendLine($"Response Exception Status: {response.HttpExceptionStatus}");
            }
            else
            {
                builder.AppendLine($"Response Code: {(int)response.HttpStatusCode.Value} - {response.HttpStatusCode}");
            }

            builder.AppendLine($"Response Duration: {response.Duration} ms");

            foreach (var httpHeader in response.Headers)
            {
                builder.AppendLine($"{httpHeader.Name}: {httpHeader.Value} ");
            }

            if (response.Exception != null)
            {
                builder.AppendLine($"Exception: {response.Exception.Message}");
            }

            builder.AppendLine("");

            if (response.Content.IsString())
            {
                builder.AppendLine($"{response.Content.Read()}");
            }

            builder.AppendLine($"Template Service :: HTTP CLIENT RESPONSE :: END");

            _log.LogInformation(builder.ToString());
        }
    }
}
