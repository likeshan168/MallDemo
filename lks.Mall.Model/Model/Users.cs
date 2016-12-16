using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace lks.Mall.Model
{
    //Users
    public class Users
    {

        /// <summary>
        /// Id
        /// </summary>		
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// LoginId
        /// </summary>		
        private string _loginid;
        public string LoginId
        {
            get { return _loginid; }
            set { _loginid = value; }
        }
        /// <summary>
        /// LoginPwd
        /// </summary>		
        private string _loginpwd;
        public string LoginPwd
        {
            get { return _loginpwd; }
            set { _loginpwd = value; }
        }
        /// <summary>
        /// Name
        /// </summary>		
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// Address
        /// </summary>		
        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        /// <summary>
        /// Phone
        /// </summary>		
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        /// <summary>
        /// Mail
        /// </summary>		
        private string _mail;
        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }
        /// <summary>
        /// UserStateId
        /// </summary>		
        private int _userstateid;
        public int UserStateId
        {
            get { return _userstateid; }
            set { _userstateid = value; }
        }

    }
}

