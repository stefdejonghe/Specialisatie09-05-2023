using DataSetManager;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbManager
{
    public class MongoDbDataSet
    {
        public MongoDbDataSet(DataSet dataSet, DataSetMetaInfo metaInfo)
        {
            DataSet = dataSet;
            MetaInfo = metaInfo;
        }

        public MongoDbDataSet(ObjectId id, DataSet dataSet, DataSetMetaInfo metaInfo)
        {
            Id = id;
            DataSet = dataSet;
            MetaInfo = metaInfo;
        }

        public ObjectId Id { get; set; }
        public DataSet DataSet { get; set; }
        public DataSetMetaInfo MetaInfo { get; set; }
    }
}
