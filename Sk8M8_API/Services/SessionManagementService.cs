using JWT;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sk8M8_API.Enums;
using Sk8M8_API.DataClasses;

namespace Sk8M8_API.Services
{
    public class SessionManagementService
    {
        private const string SecretKey = "BBF3F8EAC329522EBF48CB584CDAF";
        private IJwtAlgorithm Algorithm;
        private IJsonSerializer Serializer;
        private IBase64UrlEncoder UrlEncoder;
        private IJwtValidator Validator;
        private IDateTimeProvider Provider;
        private IJwtEncoder Encoder;
        private IJwtDecoder Decoder;

        private Models.Client Client { get; set; }

        public SessionManagementService(Models.Client Client)
        {
            this.Client = Client;

            this.Algorithm = new HMACSHA384Algorithm();
            this.Serializer = new JsonNetSerializer();
            this.UrlEncoder = new JwtBase64UrlEncoder();
            this.Provider = new UtcDateTimeProvider();
            this.Validator = new JwtValidator(Serializer, Provider);

            this.Encoder = new JwtEncoder(Algorithm, Serializer, UrlEncoder);
            this.Decoder = new JwtDecoder(Serializer, Validator, UrlEncoder);
        }

        /// <summary>
        /// Decodes the provided JWT token
        /// </summary>
        /// <param name="Token">User JWT token</param>
        /// <returns>An object containing status and the decoded object in the JWT token if valid</returns>
        public SessionValidationResult Decode(string Token)
        {
            var Result = new SessionValidationResult();

            try
            {
                var DecodedToken = Decoder.Decode(Token, SecretKey, true);

                Result.Session = DecodedToken;
                Result.Status = SessionValidationResultStatus.Valid;
            } catch (TokenExpiredException)
            {
                Result.Status = SessionValidationResultStatus.Expired;
            } catch (SignatureVerificationException)
            {
                Result.Status = SessionValidationResultStatus.Invalid;
            } catch
            {
                Result.Status = SessionValidationResultStatus.Malformed;
            }

            return Result;
        }

        public string Encode()
        {
            var Token = Encoder.Encode(new DataClasses.UserToken()
            {
                ClientId = this.Client.Id,
                Exp = DateTimeOffset.UtcNow.AddMonths(1).ToUnixTimeSeconds()
            }, SecretKey);

            return Token;
        }
    }
}
