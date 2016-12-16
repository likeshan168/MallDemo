using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace lks.Mall.Model{
	 	//Cart
		public class Cart
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
		/// UserId
        /// </summary>		
		private int _userid;
        public int UserId
        {
            get{ return _userid; }
            set{ _userid = value; }
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
		/// <summary>
		/// Count
        /// </summary>		
		private int _count;
        public int Count
        {
            get{ return _count; }
            set{ _count = value; }
        }        
		   
	}
}

