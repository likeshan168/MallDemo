using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace lks.Mall.Model{
	 	//BookComment
		public class BookComment
	{
   		     
      	/// <summary>
		/// Id
        /// </summary>		
		private int _id;
        public int Id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// Msg
        /// </summary>		
		private string _msg;
        public string Msg
        {
            get{ return _msg; }
            set{ _msg = value; }
        }        
		/// <summary>
		/// CreateDateTime
        /// </summary>		
		private DateTime _createdatetime;
        public DateTime CreateDateTime
        {
            get{ return _createdatetime; }
            set{ _createdatetime = value; }
        }        
		/// <summary>
		/// BookId
        /// </summary>		
		private int _bookid;
        public int BookId
        {
            get{ return _bookid; }
            set{ _bookid = value; }
        }        
		   
	}
}

