using AutoMapper;
using MediatR;
using Stock_API.Application.Interfaces;
using Stock_API.Application.Services.Stock.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stock_API.Application.Services.Stock.Query
{
    public class GetStockValueByIntervalQuery : IRequest<List<StockDto>>
    {

    }

    public class GetStockValueByIntervalQueryHandler : IRequestHandler<GetStockValueByIntervalQuery,List<StockDto>>
    {
        private readonly IMapper _mapper;
        private readonly IStockService _service;

        public GetStockValueByIntervalQueryHandler(IMapper mapper,IStockService service)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<List<StockDto>> Handle(GetStockValueByIntervalQuery request, CancellationToken cancellationToken)
        {
            var list = new List<StockDto>();

            list.Add(new StockDto
            {
                Value = 431.1,
                date = DateTime.Now
            });
            list.Add(new StockDto
            {
                Value = 400.1,
                date = DateTime.Now.AddMinutes(1)
            });            
            list.Add(new StockDto
            {
                Value = 410.1,
                date = DateTime.Now.AddMinutes(2)
            });

            return list;

        }
    }
}
