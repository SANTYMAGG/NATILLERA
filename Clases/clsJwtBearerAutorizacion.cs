using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace NATILLERA.Clases
{
    public class clsJwtBearerAutorizacion : DelegatingHandler
    {
        private readonly clsAutorizacion _autorizacion ;
        public clsJwtBearerAutorizacion(clsAutorizacion autorizacion)
        {
            _autorizacion = autorizacion;
        }


        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var authorizationHeader = request.Headers.Authorization;
            if (authorizationHeader != null && authorizationHeader.Scheme == "Bearer")
            {
                var token = authorizationHeader.Parameter;
                var principal = _autorizacion.ValidateToken(token);

                if (principal != null)
                {
                    Thread.CurrentPrincipal = principal;
                    request.GetRequestContext().Principal = principal;
                }
                else
                {
                    return request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Token inválido o expirado");
                }
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}