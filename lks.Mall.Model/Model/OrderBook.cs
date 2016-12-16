using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace lks.Mall.Model{
	 	//OrderBook
		public class OrderBook
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
		/// OrderID
        /// </summary>		
		private string _orderid;
        public string OrderID
        {
            get{ return _orderid; }
            set{ _orderid = value; }
        }        
		/// <summary>
		/// BookID
        /// </summary>		
		private int _bookid;
        public int BookID
        {
            get{ return _bookid; }
            set{ _bookid = value; }
        }        
		/// <summary>
		/// Quantity
        /// </summary>		
		private int _quantity;
        public int Quantity
        {
            get{ return _quantity; }
            set{ _quantity = value; }
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
		   
	}
}

