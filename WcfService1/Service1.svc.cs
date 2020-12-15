using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using static WcfService1.InsertUser;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: (0)", value);
        }


        public string Insert(InsertUser user)
        {
            string msg;
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-EH3OHBUA;Initial Catalog=MyTestDB;Persist Security=True; User ID=sa;Password=Ghianalf07 ; Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into UserTab (Name, Email) values(@Name, @Email)", con);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Email", user.Email);


            int g = cmd.ExecuteNonQuery();
            if(g==1)
            {
                msg = "Successfully Inserted";
            }
            else
            {
                msg = "Failed to Insert";
            }
            return msg;
        }

        public gettestdata GetInfo()
        {
            gettestdata g = new gettestdata();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-EH3OHBUA;Initial Catalog=MyTestDB;Persist Security=True; User ID=sa;Password=Ghianalf07 ; Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from UserTab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            g.usertab = dt;
            return g;
        }

        public string Update(UpdateUser u)
        {
            string Message = "";
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-EH3OHBUA;Initial Catalog=MyTestDB;Persist Security=True; User ID=sa;Password=Ghianalf07 ; Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update UserTab set Name = @Name, Email = @Email where UserID=@UserID", con);
            cmd.Parameters.AddWithValue("@UserID", u.UID);
            cmd.Parameters.AddWithValue("@Name", u.Name);
            cmd.Parameters.AddWithValue("@Email", u.Email);
            int res = cmd.ExecuteNonQuery();
            if (res == 1)
            {
                Message = "Succesfully Updated";
            }
            else
            {
                Message = "Failed to Updated";
            }
            return Message;
        }

        public string  Delete(DeleteUser d)
        {
            string msg = "";
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-EH3OHBUA;Initial Catalog=MyTestDB;Persist Security=True; User ID=sa;Password=Ghianalf07 ; Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete UserTab where UserID = @UserID", con);
            cmd.Parameters.AddWithValue("@UserID", d.UID);
            int res = cmd.ExecuteNonQuery();
            if (res == 1)
            {
                msg = "Succesfully delete";
            }
            else
            {
                msg = "Failed to delete";
            }
            return msg;
        }
    }
}
