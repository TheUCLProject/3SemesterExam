using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlMigrations
{
    /*
     * (JUST IN CASE)
     * Add OptimisticConcurrencyTemplate.Add(migrationBuilder, "TABLENAME") into the newest migration before updating database. MAKE SURE TO ADD "public int Version {get; set;}" TO MODEL!!!
     */
    public class OptimisticConcurrencyTemplate
    {
        public static void Add(MigrationBuilder migrationBuilder, string tableName)
        {
            migrationBuilder.Sql($"CREATE TRIGGER Update{tableName}Version " +
            $"AFTER UPDATE ON {tableName} " +
            "BEGIN " +
            $"UPDATE {tableName} " +
            "SET Version = Version + 1 " +
            "WHERE rowid = NEW.rowid; " +
            "END; ");
        }
    }
}
