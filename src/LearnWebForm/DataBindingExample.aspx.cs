using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LearnWebForm
{
    public partial class DataBindingExample : System.Web.UI.Page
    {
        private string connectionString;
        public DataBindingExample()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) BindDataToGridView();
        }

        protected void gvColors_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ResetErrorText();
            gvColors.EditIndex = e.NewEditIndex;
            BindDataToGridView();
        }

        protected void gvColors_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ResetErrorText();
            GridViewRow gvRow = (GridViewRow)gvColors.Rows[e.RowIndex];
            HiddenField hiddenField = (HiddenField)gvRow.FindControl("hdnColorId");
            int Id = Convert.ToInt32(hiddenField.Value);

            using (SqlConnection dbConnection=new SqlConnection(connectionString))
            {
                try
                {
                    dbConnection.Open();
                    string sql = $"DELETE FROM Color WHERE ID={Id}";
                    SqlCommand command=new SqlCommand(sql, dbConnection);
                    command.ExecuteNonQuery();
                    gvColors.EditIndex = -1;
                    BindDataToGridView();
                }
                catch (Exception ex)
                {
                    ltError.Text = ex.Message;
                }
                finally
                {
                    dbConnection.Close();
                    dbConnection.Dispose();
                }
            }
        }

        protected void gvColors_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ResetErrorText();
            GridViewRow gvRow = (GridViewRow)gvColors.Rows[e.RowIndex];
            HiddenField hiddenField = (HiddenField)gvRow.FindControl("hdnColorId");
            int Id = Convert.ToInt32(hiddenField.Value);
            string txtName = ((TextBox)gvRow.Cells[1].Controls[0]).Text;
            string txtHex = ((TextBox)gvRow.Cells[2].Controls[0]).Text;

            using (SqlConnection dbConnection=new SqlConnection(connectionString))
            {
                try
                {
                    dbConnection.Open();
                    string sql = $"UPDATE Color SET Name='{txtName}',Hex='{txtHex}' WHERE ID={Id}";
                    SqlCommand command=new SqlCommand(sql, dbConnection);
                    command.ExecuteNonQuery();
                    gvColors.EditIndex = -1;
                    BindDataToGridView();
                }
                catch (Exception ex)
                {
                   ltError.Text = ex.Message;
                }
                finally
                {
                    dbConnection.Close();
                    dbConnection.Dispose();
                }
            }
        }

        protected void gvColors_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvColors.EditIndex = -1;
            BindDataToGridView();
        }
        public void BindDataToGridView()
        {
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                try
                {
                    dbConnection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Color ORDER BY ID", dbConnection);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        gvColors.DataSource = dataSet;
                        gvColors.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    ltError.Text = $"Erro:{ex.Message}";
                }
                finally
                {
                    dbConnection.Close();
                    dbConnection.Dispose();
                }
            }
        }

        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            using(SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                try
                {
                    dbConnection.Open();
                    SqlCommand command = new SqlCommand($"INSERT INTO Color(Name,Hex) values('','')", dbConnection);
                    command.ExecuteNonQuery();
                    BindDataToGridView();
                }
                catch (Exception ex)
                {
                    ltError.Text = ex.Message;
                }
                finally
                {
                    dbConnection.Close();
                    dbConnection.Dispose();
                }
            }
        }

        private void ResetErrorText()
        {
            ltError.Text = string.Empty;
        }
    }
}