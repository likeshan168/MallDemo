using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace lks.Mall.Model{
	 	//1
		public class sysdiagrams
	{
   		     
      	/// <summary>
		/// name
        /// </summary>		
		private string _name;
        public string name
        {
            get{ return _name; }
            set{ _name = value; }
        }        
		/// <summary>
		/// principal_id
        /// </summary>		
		private int _principal_id;
        public int principal_id
        {
            get{ return _principal_id; }
            set{ _principal_id = value; }
        }        
		/// <summary>
		/// diagram_id
        /// </summary>		
		private int _diagram_id;
        public int diagram_id
        {
            get{ return _diagram_id; }
            set{ _diagram_id = value; }
        }        
		/// <summary>
		/// version
        /// </summary>		
		private int _version;
        public int version
        {
            get{ return _version; }
            set{ _version = value; }
        }        
		/// <summary>
		/// definition
        /// </summary>		
		private byte[] _definition;
        public byte[] definition
        {
            get{ return _definition; }
            set{ _definition = value; }
        }        
		   
	}
}

