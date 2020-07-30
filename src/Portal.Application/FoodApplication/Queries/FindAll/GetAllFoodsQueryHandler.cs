using AutoMapper;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Portal.Application.Foods.Models;
using Portal.Domain;
using Portal.Persisatance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Portal.Application.FoodApplication.Queries.FindAll
{
    class GetAllFoodsQueryHandler : IRequestHandler<FindAllFoodsQuery, IList<FoodInfo>>
    {
        //private readonly PortalDbContext _db;
        private readonly IMapper _mapper;
        public GetAllFoodsQueryHandler(/*PortalDbContext db,*/ IMapper mapper)
        {
            //_db = db;
            _mapper = mapper;
        }

        public async Task<IList<FoodInfo>> Handle(FindAllFoodsQuery request, CancellationToken cancellationToken)
        {
            using IDbConnection connection = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=Lemon_master03;Integrated Security=True");
            var q = await connection.QueryAsync<Food>("SELECT * FROM Foods");
            //var model = await _db.Foods.ToListAsync();
            return q.Select(_mapper.Map<Food, FoodInfo>).ToList();
        }
    }
}
