namespace lks.Mall.Model
{
    //Articel_Words
    public class Articel_Words
    {

        /// <summary>
        /// Id
        /// </summary>		
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// WordPattern
        /// </summary>		
        private string _wordpattern;
        public string WordPattern
        {
            get { return _wordpattern; }
            set { _wordpattern = value; }
        }

        /// <summary>
        /// 是否禁用
        /// </summary>		
        private bool _isforbid;
        public bool IsForbid
        {
            get { return _isforbid; }
            set { _isforbid = value; }
        }
        /// <summary>
        /// 是否需要审核
        /// </summary>		
        private bool _ismod;
        public bool IsMod
        {
            get { return _ismod; }
            set { _ismod = value; }
        }
        /// <summary>
        /// ReplaceWord
        /// </summary>		
        private string _replaceword;
        public string ReplaceWord
        {
            get { return _replaceword; }
            set { _replaceword = value; }
        }

    }
}

