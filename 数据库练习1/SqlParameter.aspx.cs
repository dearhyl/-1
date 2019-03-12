using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class SqlParameterTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Student student = new Student();
            student.StudentName = "陆明华";
            student.StudentNumber = "00000001";
            //调用方法执行创建
            this.CreateBySql(student);
        }
        private void CreateBySql(Student student)
        {
            //1.读取数据库连接字符串
            String connectionstring = ConfigurationManager.ConnectionStrings["WebBook"].ConnectionString;

            // Response.Write(connectionstring); 
            //2.执行数据库连接
            SqlConnection conncetions = new SqlConnection();
            conncetions.ConnectionString = connectionstring;

            //打开数据库
            conncetions.Open();

            //3.使用SQLcommand执行数据库的增加

            //定义SQL语句
            string sql = "insert into Student1(StudentName,StudentNumber) values (@StudentName,@StudentNumber)";

            //实例化执行对象
            SqlCommand cmd = new SqlCommand(sql, conncetions);

            //给cmd对象添加参数
            //(1)添加@StudentName参数
            SqlParameter parameterStudentName = new SqlParameter();
            parameterStudentName.DbType = System.Data.DbType.String;
            parameterStudentName.Direction = System.Data.ParameterDirection.Input;
            parameterStudentName.ParameterName = "@StudentName";
            parameterStudentName.Size = 9;
            parameterStudentName.SqlDbType = System.Data.SqlDbType.VarChar;
            parameterStudentName.SqlValue = student.StudentName;//从参数中获取
            parameterStudentName.Value = student.StudentName;
            //将参数parameterStudentName添加到cmd的集合中
            cmd.Parameters.Add(parameterStudentName);
            //(2)添加参数@StudentNumber
            SqlParameter parameterStudentNumber = new SqlParameter("@StudentNumber", student.StudentName);
            cmd.Parameters.Add(parameterStudentNumber);

            //执行插入操作
            int count = cmd.ExecuteNonQuery();
            //关闭连接
            conncetions.Close();

            Response.Write(count);
        }
    }
}
