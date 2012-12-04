using System.Data;
using Migrator.Framework;

namespace Tuskr.Data.Db
{
    [Migration(1)]
    public class TaskTable : Migration
    {
        public override void Up()
        {
            Database.AddTable("T_TaskData",
                              new Column("TD_Id", DbType.Int64, ColumnProperty.PrimaryKeyWithIdentity),
                              new Column("TD_Name", DbType.String, 50),
                              new Column("TD_Description", DbType.String, 2000),
                              new Column("TD_StartDate", DbType.DateTime),
                              new Column("TD_Duration", DbType.Int32),
                              new Column("TD_Status", DbType.Int16)
                );
        }

        public override void Down()
        {
            Database.RemoveTable("T_TaskData");
        }
    }
}
