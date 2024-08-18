using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateApiService.Common.Security
{
    public class JwsHelper
    {
        private readonly TemplateConfiguration _config;
        private readonly ILogger<JwsHelper> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="logger"></param>
        public JwsHelper(TemplateConfiguration configuration,
            ILogger<JwsHelper> logger)
        {
            _config = configuration;
            _logger = logger;
        }

    
    }
}
