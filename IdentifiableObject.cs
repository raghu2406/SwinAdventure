using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
    //public class IdentifiableObject
    //{
    //    private List<string> _identifiers;
    //    public IdentifiableObject(string[] idents)
    //    {
    //        _identifiers = new List<string>();
    //        for (int i = 0; i < idents.Length; i++)
    //        {
    //            _identifiers.Add(idents[i].ToLower());
    //        }
    //    }
    //    public bool AreYou(string id)
    //    {
    //        return _identifiers.Contains(id.ToLower());
    //    }
    //    public string FirstId
    //    {
    //        get
    //        {
    //            if (_identifiers.Count == 0)
    //            {
    //                return "";
    //            }
    //            else
    //            {
    //                return _identifiers.First();
    //            }
    //        }
    //    }
    //    public void AddIdentifier(string id)
    //    {
    //        _identifiers.Add(id.ToLower());
    //    }
    //}
    public class IdentifiableObject
    {
        private readonly List<string> _identifiers;

        public IdentifiableObject(string[] initialIdentifiers)
        {
            // The list of identifiers initialised here.
            _identifiers = new List<string>(initialIdentifiers);
        }

        public bool AreYou(string identifier)
        {
            // Check to see if the given identifier exists in the list
            return _identifiers.Contains(identifier, StringComparer.OrdinalIgnoreCase);
        }

        public string FirstId()
        {
            // Return the first identifier (or an empty string if none)
            if (_identifiers.Any())
            {
                return _identifiers.First();
            }
            else
            {
                return string.Empty;
            }
        }

        public void AddIdentifier(string identifier)
        {
            // Converting to lowercase and adding to the list
            _identifiers.Add(identifier.ToLower());
        }

        public void PrivilegeEscalation(string inputPin, string studentId, string tutorialId)
        {
            // Checking if the input PIN matches the last 4 digits of the student ID
            if (inputPin == studentId.Substring(studentId.Length - 4))
            {
                // Replaceing the first identifier with the tutorial ID
                _identifiers[0] = tutorialId;
            }
        }

        // Property to expose the list of identifiers
        public IReadOnlyList<string> GetIdentifiers()
        {
            return _identifiers.AsReadOnly();
        }

        public void PrivilegeEscalation(string studentId, string tutorialId)
        {
            throw new NotImplementedException();
        }
    }
}