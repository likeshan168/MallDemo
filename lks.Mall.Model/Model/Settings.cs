using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace lks.Mall.Model{
	 	//Settings
		public class Settings
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
		/// <summary>
		/// Value
        /// </summary>		
		private string _value;
        public string Value
        {
            get{ return _value; }
            set{ _value = value; }
        }        
		   
	}
}

