﻿using HandWritingRecognitionServer.Data;
using System;
using System.Data;


namespace HandWritingRecognitionServer
{



    public static class DataBaseManager
    {
        //managing the methods that are used to get and transport info to the database
        public static bool IsUserExists(string username, string password, PaintClient pc)
        {
            string dbPath = "DB.mdf";
            DAL dal = new DAL(dbPath);
            string selectSql = "select * from Users where Password ='" + password + "' and Username = '" + username + "'";
            DataTable dt = dal.GetDataTable(selectSql);
            bool exists = dt.Rows.Count == 1;

            if (exists)
            {
                pc.SendMessage(PaintClientProtocolType.OkValidPasswordAndUsername);
                Console.WriteLine("user " + username + " is connected");
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
            string dbPath = "DB.mdf";
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

        public static bool AddUser(string Username, string Password, PaintClient pc)
        {
            string dbPath = "DB.mdf";
            DAL dal = new DAL(dbPath);
            string selectSql = "select * from users where Username ='" + Username + "'";
            DataTable dt = dal.GetDataTable(selectSql);
            if (dt.Rows.Count == 0)
            {
                string insertSql = "INSERT INTO users (Username,Password,admin) VALUES('" + Username + "','" + Password + "','no')";
                int n = dal.UpdateDB(insertSql);
                pc.SendMessage(PaintClientProtocolType.UserAdded);
                return n == 1;
            }
            return false;
        }//adds user to database

    }
}
