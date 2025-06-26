using BoardApplication.Common.Abstractions.Persistence;
using Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Persistence.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private readonly IMongoCollection<TBoard> _collection;

        public BoardRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<TBoard>("Boards");
        }

        public Task AddAsync(TBoard board, CancellationToken cancellationToken = default)
            => _collection.InsertOneAsync(board, cancellationToken);
    }

}
