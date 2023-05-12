using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace LearnWebForm
{
    public partial class DBConnectionExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["DBConnection"];
            using(SqlConnection dbConnection=new SqlConnection(connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    dbConnection.Open();
                    ltConnectionMessage.Text = "Connection Successfull";
                    try
                    {
                        SqlCommand command = new SqlCommand("SELECT * FROM Color",dbConnection);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ltOutput.Text += $"<li style=\"color:#{reader.GetString(2)}\">{reader.GetString(1)}</li>";
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        ltOutput.Text = $"<li>{ex.Message}</li>";
                    }
                }
                catch(SqlException ex)
                {
                    ltConnectionMessage.Text = $"Connection failed: {ex.Message}";
                }
                finally
                {
                    dbConnection.Close();
                    dbConnection.Dispose();
                }
            }
        }
    }
}