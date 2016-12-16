using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace lks.Mall.Model{
	 	//SysFun
		public class SysFun
	{
   		     
      	/// <summary>
		/// NodeId
        /// </summary>		
		private int _nodeid;
        public int NodeId
        {
            get{ return _nodeid; }
            set{ _nodeid = value; }
        }        
		/// <summary>
		/// DisplayName
        /// </summary>		
		private string _displayname;
        public string DisplayName
        {
            get{ return _displayname; }
            set{ _displayname = value; }
        }        
		/// <summary>
		/// NodeURL
        /// </summary>		
		private string _nodeurl;
        public string NodeURL
        {
            get{ return _nodeurl; }
            set{ _nodeurl = value; }
        }        
		/// <summary>
		/// DisplayOrder
        /// </summary>		
		private int _displayorder;
        public int DisplayOrder
        {
            get{ return _displayorder; }
            set{ _displayorder = value; }
        }        
		/// <summary>
		/// ParentNodeId
        /// </summary>		
		private int _parentnodeid;
        public int ParentNodeId
        {
            get{ return _parentnodeid; }
            set{ _parentnodeid = value; }
        }        
		   
	}
}

