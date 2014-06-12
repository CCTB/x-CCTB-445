namespace Topic.N.SupportingClasses
{
    public class Book
    {
        private string _Title;
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
            if (string.IsNullOrEmpty(value))
                throw new System.Exception("Title cannot be empty");
                _Title = value;
            }
        }
        private string[] _Authors;
        public string[] Authors
        {
            get
            {
                return _Authors;
            }
            set
            {
            if (value == null)
                throw new System.Exception("Authors cannot be empty");
            foreach (string author in value)
                if (string.IsNullOrEmpty(author))
                    throw new System.Exception("Author cannot be empty");
                _Authors = value;
            }
        }
        private ISBN _Isbn;
        public ISBN Isbn
        {
            get
            {
                return _Isbn;
            }
            set
            {
            if (value == null)
                throw new System.Exception("ISBN cannot be empty");
                _Isbn = value;
            }
        }

        public Book(string title, string[] authors, ISBN isbn)
        {
            Title = title;
            Authors = authors;
            Isbn = isbn;
        }

        public Book()
        {
        }
    }
}