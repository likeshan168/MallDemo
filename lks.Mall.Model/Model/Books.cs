using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace lks.Mall.Model{
	 	//Books
		public class Books
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
		/// Author
        /// </summary>		
		private string _author;
        public string Author
        {
            get{ return _author; }
            set{ _author = value; }
        }        
		/// <summary>
		/// PublisherId
        /// </summary>		
		private int _publisherid;
        public int PublisherId
        {
            get{ return _publisherid; }
            set{ _publisherid = value; }
        }        
		/// <summary>
		/// PublishDate
        /// </summary>		
		private DateTime _publishdate;
        public DateTime PublishDate
        {
            get{ return _publishdate; }
            set{ _publishdate = value; }
        }        
		/// <summary>
		/// ISBN
        /// </summary>		
		private string _isbn;
        public string ISBN
        {
            get{ return _isbn; }
            set{ _isbn = value; }
        }        
		/// <summary>
		/// WordsCount
        /// </summary>		
		private int _wordscount;
        public int WordsCount
        {
            get{ return _wordscount; }
            set{ _wordscount = value; }
        }        
		/// <summary>
		/// UnitPrice
        /// </summary>		
		private decimal _unitprice;
        public decimal UnitPrice
        {
            get{ return _unitprice; }
            set{ _unitprice = value; }
        }        
		/// <summary>
		/// ContentDescription
        /// </summary>		
		private string _contentdescription;
        public string ContentDescription
        {
            get{ return _contentdescription; }
            set{ _contentdescription = value; }
        }        
		/// <summary>
		/// AurhorDescription
        /// </summary>		
		private string _aurhordescription;
        public string AurhorDescription
        {
            get{ return _aurhordescription; }
            set{ _aurhordescription = value; }
        }        
		/// <summary>
		/// EditorComment
        /// </summary>		
		private string _editorcomment;
        public string EditorComment
        {
            get{ return _editorcomment; }
            set{ _editorcomment = value; }
        }        
		/// <summary>
		/// TOC
        /// </summary>		
		private string _toc;
        public string TOC
        {
            get{ return _toc; }
            set{ _toc = value; }
        }        
		/// <summary>
		/// CategoryId
        /// </summary>		
		private int _categoryid;
        public int CategoryId
        {
            get{ return _categoryid; }
            set{ _categoryid = value; }
        }        
		/// <summary>
		/// Clicks
        /// </summary>		
		private int _clicks;
        public int Clicks
        {
            get{ return _clicks; }
            set{ _clicks = value; }
        }        
		   
	}
}

