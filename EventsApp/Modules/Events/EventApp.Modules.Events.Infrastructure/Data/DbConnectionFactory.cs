using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventApp.Modules.Events.Application.Abstractions.Data;
using Npgsql;

namespace EventApp.Modules.Events.Infrastructure.Data;
internal sealed class DbConnectionFactory(NpgsqlDataSource datasource) : IDbConnectionFactory
{
    public async  ValueTask<DbConnection> OpenConnectionAsync()
    {
        return await datasource.OpenConnectionAsync();
    }
}
