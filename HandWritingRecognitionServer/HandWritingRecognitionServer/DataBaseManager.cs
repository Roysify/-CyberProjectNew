using HandWritingRecognitionServer.Data;
using System;
using System.Data;


namespace HandWritingRecognitionServer
{
    public static class DataBaseManager
    {
        private static string dbPath = "DB.mdf";
        //managing the methods that are used to get and transport info to the database
        public static bool IsUserExists(string username, string password, PaintClient pc)
        {
            DAL dal = new DAL(dbPath);
            string selectSql = "select * from Users where Password ='" + password + "' and Username = '" + username + "'";
            DataTable dt = dal.GetDataTable(selectSql);
            bool exists = dt.Rows.Count == 1;

            if (exists)
            {
                Console.WriteLine("user " + username + " is connected");
                string email = dt.Rows[0][3].ToString();
                EmailValidation ev = new EmailValidation(email);
                ev.SendValidationCode();
                string msg = ProtocolManager.CreateProtocol(ev.GetRandomCode(), PaintClientProtocolType.OkValidPasswordAndUsername);
                pc.SendMessage(msg);

            }
            else
            {
                pc.SendMessage(PaintClientProtocolType.ErvrorInvalidPasswordAndUsername);
                Console.WriteLine("user " + username + " is invalid");
            }
            return exists;
        }// checks if user exists

        public static bool IsUsernameExists(string username, PaintClient pc)
        {
            DAL dal = new DAL(dbPath);
            string selectSql = "select * from Users where Username = '" + username + "'";
            DataTable dt = dal.GetDataTable(selectSql);
            bool exists = dt.Rows.Count == 1;

            if (!exists)
            {
                Console.WriteLine(username + " is unused");
                return true;
            }
            else
            {
                pc.SendMessage(PaintClientProtocolType.UsernameExists);
                Console.WriteLine(username + " is used");
                return false;
            }
        } //checks if username exists

        public static bool AddUser(string username, string password, string email, PaintClient pc)
        {
            DAL dal = new DAL(dbPath);
            string selectSql = "select * from users where Username ='" + username + "'or Email = '" + email + "'";
            DataTable dt = dal.GetDataTable(selectSql);
            if (dt.Rows.Count == 0)
            {
                string insertSql = "INSERT INTO users (Username,Password,Email,Admin) VALUES('" + username + "','" + password + "','" + email + "',+'no')";
                int n = dal.UpdateDB(insertSql);
                pc.SendMessage(PaintClientProtocolType.UserAdded);
                return n == 1;
            }
            pc.SendMessage(PaintClientProtocolType.UsernameOrEmailUnavailable);
            return false;
        }//adds user to database

        public static void ChangePassword(string newPassword, string email,PaintClient pc)
        {
            DAL dal = new DAL(dbPath);
            string updateSql = "update users set password = '"+ newPassword+"' where Email ='" + email + "'";
            dal.UpdateDB(updateSql);
            pc.SendMessage(PaintClientProtocolType.PasswordChanged);
        }//changes the password based on email

        public static void CheckEmail(string email,PaintClient pc)
        {
            DAL dal = new DAL(dbPath);
            string selectSql = "select * from Users where Email ='" + email + "'";
            DataTable dt = dal.GetDataTable(selectSql);
            bool exists = dt.Rows.Count == 1;

            if (exists)
            {
                pc.SendMessage(PaintClientProtocolType.EmailExists);
                Console.WriteLine("email: " + email + " exists");
            }
            else
            {
                pc.SendMessage(PaintClientProtocolType.EmailInvalid);
                Console.WriteLine("email: " + email + " is invalid");
            }

        }//checks if email exists
        public static string GetEmail(string username)
        {
            DAL dal = new DAL(dbPath);
            string selectSql = "select Email from Users where Username = '" + username + "'";
            DataTable dt = dal.GetDataTable(selectSql);
            return dt.Rows[0][0].ToString();
        } //gets email
    }
}
