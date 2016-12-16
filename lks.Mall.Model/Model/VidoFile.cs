using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace lks.Mall.Model{
	 	//VidoFile
		public class VidoFile
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
		/// Title
        /// </summary>		
		private string _title;
        public string Title
        {
            get{ return _title; }
            set{ _title = value; }
        }        
		/// <summary>
		/// FivPath
        /// </summary>		
		private string _fivpath;
        public string FivPath
        {
            get{ return _fivpath; }
            set{ _fivpath = value; }
        }        
		/// <summary>
		/// Status
        /// </summary>		
		private string _status;
        public string Status
        {
            get{ return _status; }
            set{ _status = value; }
        }        
		/// <summary>
		/// FileExt
        /// </summary>		
		private string _fileext;
        public string FileExt
        {
            get{ return _fileext; }
            set{ _fileext = value; }
        }        
		   
	}
}

