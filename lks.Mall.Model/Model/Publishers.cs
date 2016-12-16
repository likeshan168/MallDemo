using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace lks.Mall.Model{
	 	//Publishers
		public class Publishers
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
		/// Name
        /// </summary>		
		private string _name;
        public string Name
        {
            get{ return _name; }
            set{ _name = value; }
        }        
		   
	}
}

