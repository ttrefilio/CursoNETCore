using MongoDB.Driver;
using Projeto.Domain.DTOs;
using Projeto.Domain.Interfaces.Caching;
using Projeto.Infra.Caching.Context;
using System;
using System.Collections.Generic;

namespace Projeto.Infra.Caching.Persistence
{
    public class TurmaCaching : ITurmaCaching
    {
        private readonly MongoDBContext mongoDBContext;

        public TurmaCaching(MongoDBContext mongoDBContext)
        {
            this.mongoDBContext = mongoDBContext;
        }

        public void Add(TurmaDTO obj)
        {
            mongoDBContext.Turmas.InsertOne(obj);
        }

        public void Update(TurmaDTO obj)
        {
            var filter = Builders<TurmaDTO>.Filter.Eq(t => t.Id, obj.Id);
            mongoDBContext.Turmas.ReplaceOne(filter, obj);
        }

        public void Remove(TurmaDTO obj)
        {
            var filter = Builders<TurmaDTO>.Filter.Eq(t => t.Id, obj.Id);
            mongoDBContext.Turmas.DeleteOne(filter);
        }

        public List<TurmaDTO> GetAll()
        {
            var filter = Builders<TurmaDTO>.Filter.Where(t => true);
            return mongoDBContext.Turmas.Find(filter).ToList();
        }

        public TurmaDTO GetById(Guid id)
        {
            var filter = Builders<TurmaDTO>.Filter.Eq(t => t.Id, id);
            return mongoDBContext.Turmas.Find(filter).FirstOrDefault();
        }
    }
}
