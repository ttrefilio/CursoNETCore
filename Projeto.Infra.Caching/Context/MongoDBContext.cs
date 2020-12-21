using MongoDB.Driver;
using Projeto.Domain.DTOs;
using Projeto.Infra.Caching.Settings;

namespace Projeto.Infra.Caching.Context
{
    public class MongoDBContext
    {
        private readonly MongoDBSettings mongoDBSettings;
        private IMongoDatabase mongoDatabase;

        public MongoDBContext(MongoDBSettings mongoDBSettings)
        {
            this.mongoDBSettings = mongoDBSettings;
            Initialize();
        }

        private void Initialize()
        {
            var settings = MongoClientSettings.FromUrl
                (new MongoUrl(mongoDBSettings.ConnectionString));

            if (mongoDBSettings.IsSSL)
            {
                settings.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                };
            }

            var client = new MongoClient(settings);
            mongoDatabase = client.GetDatabase(mongoDBSettings.DatabaseName);
        }

        //Configurar as collections que serao criadas no MongoDB
        public IMongoCollection<AlunoDTO> Alunos
        {
            get { return mongoDatabase.GetCollection<AlunoDTO>("Alunos"); }
        }

        public IMongoCollection<ProfessorDTO> Professores
        {
            get { return mongoDatabase.GetCollection<ProfessorDTO>("Professores"); }
        }

        public IMongoCollection<TurmaDTO> Turmas
        {
            get { return mongoDatabase.GetCollection<TurmaDTO>("Turmas"); }
        }
    }
}
