using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
    public class Item : GameObject
    {
        public Item(string[] idents, string name, string desc) : base(idents, name, desc)
        {
        }

        //// New property to combine name and first identifier
        //public string NameWithId
        //{
        //    get
        //    {
        //        return $"{Name} ({GetFirstId()})";
        //    }
        //}

        //// Implement the GetFirstId() method
        //private string GetFirstId()
        //{
        //    if (base.Identifiers.Length > 0)
        //        return base.Identifiers[0];
        //    else
        //        return null;
        //}
    }
}
