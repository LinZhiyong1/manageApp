// 数据库连接
using System.Data.SqlClient;

namespace manageApp
{
    class Dao
    {
        public SqlConnection connection()
        {
            string str = "Data Source=YANFA05;Initial Catalog=stu_db;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(str);
            sqlConnection.Open();// 打开连接数据库
            return sqlConnection;
        }
        public SqlCommand command(string sql)
        {
            SqlCommand sqlCommand = new SqlCommand(sql, connection());
            return sqlCommand;
        }

        // 用于delete update insert,返回受影响的行数
        public int Excute(string sql)
        {
            return command(sql).ExecuteNonQuery();
        }

        // 用于select，返回SqlDataReader对象，包含select数据
        public SqlDataReader read(string sql)
        {
            return command(sql).ExecuteReader();
        }
    }
}
