using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 数据库练习1
{
    public partial class DemoDataSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataAdapter();
        }
        private void DataAdapter()
        {
            //1.读取数据库连接字符串
            String connectionstring = ConfigurationManager.ConnectionStrings["WebBook"].ConnectionString;

             
            //2.执行数据库连接
            SqlConnection conncetions = new SqlConnection();
            conncetions.ConnectionString = connectionstring;

            //打开数据库
            conncetions.Open();

            //使用DataAdpter
            //准备DataSet用内存储数据
            DataSet ds = new DataSet();

            //使用DataAdapter填充到DataSet

            SqlDataAdapter adapter = new SqlDataAdapter("select * from Student",conncetions);
            adapter.Fill(ds);

            //显示数据
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();

            //关闭数据库
            conncetions.Close();

        }

    }
}