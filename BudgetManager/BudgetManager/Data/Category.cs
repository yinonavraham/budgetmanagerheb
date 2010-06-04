using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BudgetManager.Data
{
    public class Category
    {
        private static String __qNameSeparator = @" > ";
        private static IList<int> __codes = new List<int>();
        private static int __highestCode = -1;
        private static int __maxLevel = int.MaxValue;


        public static int MaxLevel
        {
            get { return __maxLevel; }
            set { __maxLevel = value; }
        }


        private Category _parent = null;
        private int _code = -1;
        private String _name = null;
        private IDictionary<int,Category> _subCategories = new Dictionary<int,Category>();

        
        public Category(int? code, String name, Category parent)
        {
            this._parent = parent;
            this._code = code == null ? (__highestCode + 1) : (int)code;
            this._name = name;
            Validate();
            __codes.Add(this._code);
            __highestCode = this._code > __highestCode ? this._code : __highestCode;
        }


        public Category(int? code, String name)
        {
            this._code = code == null ? (__highestCode + 1) : (int)code;
            this._name = name;
            Validate();
            __codes.Add(this._code);
            __highestCode = this._code > __highestCode ? this._code : __highestCode;
        }


        public int Code
        {
            get { return this._code; }
        }


        public String Name
        {
            get { return this._name; }
            set { this._name = value; }
        }


        public Category Parent
        {
            get { return this._parent; }
            set { this._parent = value; }
        }


        public ICollection<Category> SubCategories
        {
            get { return this._subCategories.Values; }
        }


        public bool IsRoot
        {
            get { return this._parent == null; }
        }


        public bool IsLeaf
        {
            get { return this._subCategories.Count == 0; }
        }


        private void Validate()
        {
            StringBuilder sb = new StringBuilder();
            if (__codes.Contains(this._code))
            {
                sb.Append("Code already exists: ");
                sb.Append(this._code);
            }
            else if (this._code < 0)
            {
                sb.Append("Code must be greater than zero: ");
                sb.Append(this._code);
            }
            if (String.IsNullOrEmpty(this._name)) 
            {
                if (sb.Length > 0) sb.Append("; ");
                sb.Append("Name cannot be null or empty");
            }
            if (sb.Length > 0) throw new CategoryNotValidException(sb.ToString(), this);
        }


        public override string ToString()
        {
            return String.Format("{0} ({1})", this._name, this._code);
        }


        public String QualifiedName
        {
            get
            {
                String qName = "";
                if (this._parent != null)
                {
                    qName = this._parent.QualifiedName + __qNameSeparator;
                }
                qName += this._name;
                return qName;
            }
        }


        public int Level
        {
            get
            {
                int level = 0;
                if (this._parent != null)
                {
                    level = this._parent.Level + 1;
                }
                return level;
            }
        }


        public Category AddSubCategory(int? code, String name)
        {
            if (this.Level >= __maxLevel) 
                throw new CategoryNotValidException("Can't add add categories above level " + __maxLevel, this);
            Category cat = new Category(code, name, this);
            this._subCategories.Add(cat.Code, cat);
            return cat;
        }


        public bool RemoveSubCategory(int code)
        {
            return this._subCategories.Remove(code);
        }


        public Category GetSubCategory(int code)
        {
            if (this._subCategories.ContainsKey(code))
            {
                return this._subCategories[code];
            }
            else
            {
                foreach (Category cat in this._subCategories.Values)
                {
                    Category c = cat.GetSubCategory(code);
                    if (c != null) return c;
                }
            }
            return null;
        }


        public Category FindSubCategory(String name)
        {
            var cats = from c in this._subCategories.Values where c.Name.Equals(name) select c;
            if (cats != null && cats.Count() > 0) return cats.First();
            else
            {
                foreach (Category cat in this._subCategories.Values)
                {
                    Category c = cat.FindSubCategory(name);
                    if (c != null) return c;
                }
            }
            return null;
        }


        public override bool Equals(object obj)
        {
            Category other = obj as Category;
            if (other == null) return false;
            return this.Code == other.Code;
        }


        internal static void Reset()
        {
            __codes.Clear();
            __highestCode = -1;
        }


        public void RemoveAllSubCategories()
        {
            foreach (Category category in this._subCategories.Values)
            {
                category.RemoveAllSubCategories();
            }
            this._subCategories.Clear();
        }
    }
}
