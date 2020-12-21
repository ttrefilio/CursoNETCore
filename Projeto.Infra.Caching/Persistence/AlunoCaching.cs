using MongoDB.Driver;
using Projeto.Domain.DTOs;
using Projeto.Domain.Interfaces.Caching;
using Projeto.Infra.Caching.Context;
using System;
using System.Collections.Generic;

namespace Projeto.Infra.Caching.Persistence
{
    public class AlunoCaching : IAlunoCaching
    {
        private readonly MongoDBContext mongoDBContext;

        public AlunoCaching(MongoDBContext mongoDBContext)
        {
            this.mongoDBContext = mongoDBContext;
        }

        public void Add(AlunoDTO obj)
        {
            mongoDBContext.Alunos.InsertOne(obj);
        }

        public void Update(AlunoDTO obj)
        {
            var filter = Builders<AlunoDTO>.Filter.Eq(a => a.Id, obj.Id);
            mongoDBContext.Alunos.ReplaceOne(filter, obj);
        }

        public void Remove(AlunoDTO obj)
        {
            var filter = Builders<AlunoDTO>.Filter.Eq(a => a.Id, obj.Id);
            mongoDBContext.Alunos.DeleteOne(filter);
        }

        public List<AlunoDTO> GetAll()
        {
            var filter = Builders<AlunoDTO>.Filter.Where(a => true);
            return mongoDBContext.Alunos.Find(filter).ToList();
        }

        public AlunoDTO GetById(Guid id)
        {
            var filter = Builders<AlunoDTO>.Filter.Eq(a => a.Id, id);
            return mongoDBContext.Alunos.Find(filter).FirstOrDefault();
        }
    }
}
