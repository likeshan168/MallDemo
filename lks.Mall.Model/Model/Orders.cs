using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace lks.Mall.Model{
	 	//Orders
		public class Orders
	{
   		     
      	/// <summary>
		/// OrderId
        /// </summary>		
		private string _orderid;
        public string OrderId
        {
            get{ return _orderid; }
            set{ _orderid = value; }
        }        
		/// <summary>
		/// OrderDate
        /// </summary>		
		private DateTime _orderdate;
        public DateTime OrderDate
        {
            get{ return _orderdate; }
            set{ _orderdate = value; }
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
		/// TotalPrice
        /// </summary>		
		private decimal _totalprice;
        public decimal TotalPrice
        {
            get{ return _totalprice; }
            set{ _totalprice = value; }
        }        
		/// <summary>
		/// PostAddress
        /// </summary>		
		private string _postaddress;
        public string PostAddress
        {
            get{ return _postaddress; }
            set{ _postaddress = value; }
        }        
		/// <summary>
		/// state
        /// </summary>		
		private int _state;
        public int state
        {
            get{ return _state; }
            set{ _state = value; }
        }        
		   
	}
}

