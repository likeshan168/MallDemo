using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace lks.Mall.Model{
	 	//CheckEmail
		public class CheckEmail
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
		/// Actived
        /// </summary>		
		private bool _actived;
        public bool Actived
        {
            get{ return _actived; }
            set{ _actived = value; }
        }        
		/// <summary>
		/// ActiveCode
        /// </summary>		
		private string _activecode;
        public string ActiveCode
        {
            get{ return _activecode; }
            set{ _activecode = value; }
        }        
		   
	}
}

