using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace TemplateApiService.Common.Security
{
    public class TokenValidation
    {
        /// <summary>
        /// Validating the token signature
        /// </summary>
        /// <returns></returns>
        public static SecurityKey GetPublicKey(string client)
        {
            StreamReader streamReader = new StreamReader($"KeyStore/{client}-public-key.pem");
            PemReader pemReader = new PemReader(streamReader);

            AsymmetricKeyParameter publicKey = (AsymmetricKeyParameter)pemReader.ReadObject();
            RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaKeyParameters)publicKey);

            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            csp.ImportParameters(rsaParams);

            SecurityKey signInKey = new RsaSecurityKey(csp);

            return signInKey;
        }
    }
}
