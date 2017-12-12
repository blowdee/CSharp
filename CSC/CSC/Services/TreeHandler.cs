using CSC.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC
{
    public class TreeHandler : ITreeHandler
    {
        private readonly ITreeOperation _operation;
        private readonly ILogger _logger;
        private Container _container;

        public TreeHandler(Container container, ITreeOperation operation, ILoggerFactory logger)
        {
            _container = container;
            _operation = operation;
            _logger = logger.CreateLogger("TreeHandler.Logger");
        }

        public IEnumerable<string> BuildTree()
        {
            _logger.LogInformation("Tree was builded");
            return _operation.BuildTree();
        }

        public IModel GetItem(int level, int id)
        {
            _logger.LogInformation($"Trying to get item on level {level} with id {id}");
            return _operation.GetItem(level, id);
        }

        public bool AddItem(int level, string value)
        {
            _logger.LogInformation($"Trying to add item to level {level}");
            return _operation.AddItem(level, value);
        }

        public bool EditItem(int level, int id, string value)
        {
            _logger.LogInformation($"Trying to edit item on level {level} with id {id}");
            return _operation.EditItem(level, id, value);
        }

        public bool DeleteItem(int level, int id)
        {
            _logger.LogInformation($"Trying to delete item on level {level} with id {id}");
            return _operation.DeleteItem(level, id);
        }
    }
}