using DataSetManager;
using MongoDbManager;

namespace MongoDbManagerTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //var data = FileDataSetManager.ReadData(@"C:\Users\stef_\Desktop\Hogent\2022 - 2023\Sem 2\Programmeren Specialisatie\Belgica\belgica.txt");
            //var sets = FileDataSetManager.MakeDataSetsWithTestSet(data.data, new List<int> { 500, 1000, 2000, 25000, 50000});
            string connectionString = "mongodb://localhost:27017";
            string source = @"C:\Users\stef_\Desktop\Hogent\2022 - 2023\Sem 2\Programmeren Specialisatie\Belgica\belgica.txt";
            string campaign = "April 2023";
            string dataseries = "ModelTest - ID v 5";
            MongoDbDataSetRepository repo = new MongoDbDataSetRepository(connectionString);
            //List<MongoDbDataSet> mongoDataSets = new List<MongoDbDataSet>();

            //DataSetMetaInfo metaInfo = new DataSetMetaInfo(sets[0].data.Count, source, campaign, dataseries, DataSetType.TestSet);
            //MongoDbDataSet testSet = new MongoDbDataSet(sets[0], metaInfo);
            //mongoDataSets.Add(testSet);

            //for (int i = 0; i < sets.Count; i++)
            //{
            //    metaInfo = new DataSetMetaInfo(sets[i].data.Count, source, campaign, dataseries, DataSetType.DataSet);
            //    mongoDataSets.Add(new MongoDbDataSet(sets[i], metaInfo));
            //}

            //repo.WriteDataSets(mongoDataSets);
            var result = repo.FilterDataSets(campaign, DataSetType.DataSet, dataseries);
            Console.WriteLine("end");
        }
    }
}