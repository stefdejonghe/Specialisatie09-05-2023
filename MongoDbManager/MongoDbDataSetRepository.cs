using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbManager
{
    public class MongoDbDataSetRepository
    {
        private readonly string _connectionString;
        private IMongoClient _dbClient;
        private IMongoDatabase _database;

        public MongoDbDataSetRepository(string connectionString)
        {
            _connectionString = connectionString;
            _dbClient = new MongoClient(_connectionString);
            _database = _dbClient.GetDatabase("Belgica2023");
        }

        public void WriteDataSets(List<MongoDbDataSet> dataSets)
        {
            var collection = _database.GetCollection<MongoDbDataSet>("datasets");
            collection.InsertMany(dataSets);
        }

        public List<MongoDbDataSet> FindDataSets(string campaignCode, DataSetType dataSetType, string dataSeries)
        {
            var collection = _database.GetCollection<MongoDbDataSet>("datasets");
            return collection.Find(x => x.MetaInfo.CampaignCode == campaignCode && x.MetaInfo.DataSetType == dataSetType && x.MetaInfo.DataSeries == dataSeries).ToList();
        }

        public List<MongoDbDataSet> FilterDataSets(string campaignCode, DataSetType dataSetType, string dataSeries)
        {
            var collection = _database.GetCollection<MongoDbDataSet>("datasets");
            var filter1 = Builders<MongoDbDataSet>.Filter.Eq(x => x.MetaInfo.DataSetType, dataSetType);
            var filter2 = Builders<MongoDbDataSet>.Filter.Eq(x => x.MetaInfo.CampaignCode, campaignCode);
            var filter3 = Builders<MongoDbDataSet>.Filter.Eq(x => x.MetaInfo.DataSeries, dataSeries);
            return collection.Find(filter1 & filter2 & filter3).ToList();
        }
    }
}
