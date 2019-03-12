using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace 数据库练习1
{
    public partial class TestConn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {/*
            DoSelect();
            DoSelectMax();
            DoExecuteNonQuery();*/
        }
        /// <summary>
        /// 执行单行数据查询操作
        /// </summary>
        #region 单行查询
        private void DoSelectMax()
        {
            //1.读取数据库字符串
            string connString = ConfigurationManager.ConnectionStrings["WebBook"].ToString();

            //2.执行数据库连接
            SqlConnection conn = new SqlConnection(connString);
            //指定数据库连接字符串
            conn.ConnectionString = connString;

            //打开数据库
            conn.Open();

            Response.Write("数据库打开成功");
            //3.使用SQLcommand 执行数据库的增加
            //准备T-SQL语句
            string sql = "select StudentNUmber  from Student where StudentName = '刘杰辉'";

            //4.实例化执行对象
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;

            //5.执行查询操作
       
            Object obj = cmd.ExecuteScalar();
            Response.Write("总数居" + obj.ToString());
            
            //6.关闭连接
            conn.Close();
            
        }
        #endregion 
        /// <summary>
        /// 执行多行数据查询操作
        /// </summary>
        #region 多行查询
        private void DoSelect()
        {

            //1.读取数据库字符串
            string connString = ConfigurationManager.ConnectionStrings["WebBook"].ToString();

            //2.执行数据库连接
            SqlConnection conn = new SqlConnection(connString);
            //指定数据库连接字符串
            conn.ConnectionString = connString;

            //打开数据库
            conn.Open();

            Response.Write("数据库打开成功");
            //3.使用SQLcommand 执行数据库的增加
            //准备T-SQL语句
            string sql = "select top 20 * from Student";

            //4.实例化执行对象
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;

            //5.执行查询操作
            SqlDataReader reader = cmd.ExecuteReader();
            

            //循环读取数据
            while (reader.Read())
            {
                Response.Write(reader["StudentName"].ToString()
                    + ","
                    + reader["StudentNumber"].ToString() + "<br>");
            }
            // 关闭Reader流
            reader.Close();

            //6.关闭连接
            conn.Close();
            Response.Write(reader);
        }
        #endregion
        /// <summary>
        /// 执行增加、删除、修改的操作
        /// </summary>
        #region 增删改
        private void DoExecuteNonQuery()
        {
            // 增加

            //1.读取数据库字符串
            string connString = ConfigurationManager.ConnectionStrings["WebBook"].ToString();
            
            //2.执行数据库连接
            SqlConnection conn = new SqlConnection(connString);
            //指定数据库连接字符串
            conn.ConnectionString = connString;

            //打开数据库
            conn.Open();

            Response.Write("数据库打开成功");
            //3.使用SQLcommand 执行数据库的增加
            //准备T-SQL语句

            /*增加*/
            string sql = "insert into Student values('刘杰辉','100000001')";
            //4.实例化插入语句
            SqlCommand cmd = new SqlCommand(sql, conn);

            //5.执行插入对象
            int count = cmd.ExecuteNonQuery();

            //6.关闭连接
            conn.Close();
            Response.Write(count);
 
            //更新

            //1.读取数据库字符串
            string connString1 = ConfigurationManager.ConnectionStrings["WebBook"].ToString();

            //2.执行数据库连接
            SqlConnection conn1 = new SqlConnection(connString);
            //指定数据库连接字符串
            conn.ConnectionString = connString;

            //打开数据库
            conn.Open();

            Response.Write("数据库打开成功");
            //3.使用SQLcommand 执行数据库的增加
            //准备T-SQL语句

            /*更新*/
            string sql1 = "update Student set StudentName = '李文彬' where StudentNumber = '179001252'";
            //4.实例化插入语句
            SqlCommand cmd1 = new SqlCommand(sql, conn);

            //5.执行插入对象
            int count1 = cmd.ExecuteNonQuery();

            //6.关闭连接
            conn.Close();
            Response.Write(count1);


            //删除

            //1.读取数据库字符串
            string connString2 = ConfigurationManager.ConnectionStrings["WebBook"].ToString();

            //2.执行数据库连接
            SqlConnection conn2 = new SqlConnection(connString);
            //指定数据库连接字符串
            conn.ConnectionString = connString;

            //打开数据库
            conn.Open();

            Response.Write("数据库打开成功");
            //3.使用SQLcommand 执行数据库的增加
            //准备T-SQL语句

            /*删除*/
            string sql2 = "delete from Student where StudentName = '姓名99' ";
            //4.实例化插入语句
            SqlCommand cmd2 = new SqlCommand(sql, conn);

            //5.执行插入对象
            int count2 = cmd.ExecuteNonQuery();

            //6.关闭连接
            conn.Close();
            Response.Write(count2);
        }
       
        
        #endregion
    }
}