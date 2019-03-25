using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crawler_shopping.src.DbConnection
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
