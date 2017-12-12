using CSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC
{
    public interface ITreeHandler
    {
        IEnumerable<string> BuildTree();

        IModel GetItem(int level, int id);

        bool AddItem(int level, string value);

        bool EditItem(int level, int id, string value);

        bool DeleteItem(int level, int id);
    }
}
