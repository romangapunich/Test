using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Test.Model;

namespace Test.Feature.Queries.Contract
{
    public class GetResultTestQuery : IRequest<ResultVm>
    {
        public string Data { get; set; }

        public GetResultTestQuery(string data)
        {
            Data = data;
        }
    }

    public class GetResultTestHandler : IRequestHandler<GetResultTestQuery, ResultVm>
    {
        public async Task<ResultVm> Handle(GetResultTestQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Data))
            {
                return new ResultVm
                {
                    Result = request.Data
                };
            }


            if (int.TryParse(request.Data, out _) || decimal.TryParse(request.Data, out _))
            {
                return new ResultVm
                {
                    Result = Math.Sqrt(Convert.ToDouble(request.Data)).ToString()
                };
            }
           
            var reverse = new string(request.Data.Reverse().ToArray());
            return new ResultVm
            {
                Result = reverse
            };
            
        }
    }
} 
