using AppLog.API.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppLog.API.Services
{
    public class LogService
    {
        private readonly IMongoCollection<LogModel> _logModel;

        public LogService(ILogDBSettings dBSettings)
        {
            var client = new MongoClient(dBSettings.ConnectionString);
            var database = client.GetDatabase(dBSettings.DatabaseName);

            _logModel = database.GetCollection<LogModel>(dBSettings.ApplicationName);

        }

        public List<LogModel> Get() => _logModel.Find(log => true).ToList();
        public LogModel Get(string Id) => _logModel.Find<LogModel>(log => log.Id == Id).FirstOrDefault();
        public LogModel Create(LogModel model)
        {
            _logModel.InsertOne(model);
            return model;
        }

        public void Update(string Id, LogModel updateModel) =>
            _logModel.ReplaceOne(log => log.Id == Id, updateModel);
        public void Remove(string id) =>
            _logModel.DeleteOne(log => log.Id == id);
        public void Remove(LogModel deleteModel) =>
            _logModel.DeleteOne(log => log.Id == deleteModel.Id);
    }
}
