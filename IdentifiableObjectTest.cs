using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Text.RegularExpressions;
using NUnit.Framework;
using System.IO;


namespace SwinAdventure
{
    //public class IdentifiableObjectTest    {

    //    private IdentifiableObject _testObject;
    //    private string _testString;
    //    private string[] _testArray;

    //    private IdentifiableObject _testObject_emp;
    //    private string _testString_emp;
    //    private string[] _testArray_emp;

    //    [SetUp]
    //    public void Setup()
    //    {
    //        _testString = "Raghu";
    //        _testArray = new string[] { "Raghu", "Rohit" };
    //        _testObject = new IdentifiableObject(_testArray);
    //        _testObject.AddIdentifier(_testString);

    //        _testString_emp = "";
    //        _testArray_emp = new string[] { };
    //        _testObject_emp = new IdentifiableObject(_testArray_emp);
    //        _testObject_emp.AddIdentifier(_testString_emp);
    //    }
    //    [Test]
    //    /*Check that it responds "True" to the "Are You" 
    //     * message where the request matches one of the 
    //     * object's identifiers.
    //     */
    //    public void TestAreYou()
    //    {
    //        Assert.IsTrue(_testObject.AreYou(_testString));
    //    }
    //    [Test]
    //    /*Check that it responds "False" to the "Are You" 
    //     * message where the request does not match one of 
    //     * the object's identifiers. 
    //     * To create a mismatch for your <<Student ID>> 
    //     * change any zeros(0) to the letter “O”.*/
    //    public void TestNotAreYou()
    //    {
    //        Assert.IsFalse(_testObject.AreYou("Alok"));
    //    }
    //    [Test]
    //    /*Check that it responds "True" to the "Are You" 
    //     * message where the request matches one of the
    //     * object's identifiers where there is a mismatch
    //     * in case.*/
    //    public void Insensitive()
    //    {
    //        Assert.IsTrue(_testObject.AreYou("RAGHU"));
    //    }
    //    [Test]
    //    /*Check that the first id returns the first 
    //     * identifier in the list of identifiers.*/
    //    public void TestFirstId()
    //    {
    //        Assert.AreEqual("raghu", _testObject.FirstId);
    //        Assert.AreNotEqual("alok", _testObject.FirstId);
    //    }
    //    [Test]
    //    /*Check that an empty string is returned if there are
    //     * no identifiers in the list of identifiers.*/
    //    public void TestFirstIdWithNoId()
    //    {
    //        Assert.AreEqual("", _testObject_emp.FirstId);
    //    }
    //    [Test]
    //    /*Check that you can add identifiers to the object. 
    //     * eg. An Identifiable Object created with identifiers
    //     * “Seekers” and “Athol”, “Keith”, “Bruce” can have
    //     * "Mary" added and then be identified by (calling Are
    //     * You) with “Seekers”,“Keith”, and "Mary".
    //     I used my own friends and relatives' names*/
    //    public void TestAddID()
    //    {
    //        _testObject.AddIdentifier("Alok");
    //        _testObject.AddIdentifier("Abhimanyu");
    //        Assert.IsTrue(_testObject.AreYou("Alok"));
    //        Assert.IsTrue(_testObject.AreYou("Abhimanyu"));
    //    }
    //}
    public class IdentifiableObjectTest
    {
        private IdentifiableObject myObject;

        [SetUp]
        public void Setup()
        {
            // Initialize your test object here
            string[] initialIdentifiers = { "john", "student", "doe" };
            myObject = new IdentifiableObject(initialIdentifiers);
        }

        [Test]
        public void AreYou_ShouldReturnTrue_WhenIdentifierExists()
        {
            // Act
            bool result1 = myObject.AreYou("john");
            bool result2 = myObject.AreYou("student");

            // Assert
            Assert.IsTrue(result1, "'john' should be identified.");
            Assert.IsTrue(result2, "'student' should be identified.");
        }

        [Test]
        public void AreYou_ShouldReturnFalse_WhenIdentifierDoesNotExist()
        {
            // Act
            bool result = myObject.AreYou("smith");

            // Assert
            Assert.IsFalse(result, "'smith' should not be identified.");
        }

        [Test]
        public void AreYou_ShouldBeCaseInsensitive()
        {
            // Act
            bool result1 = myObject.AreYou("john");
            bool result2 = myObject.AreYou("STUDENT");

            // Assert
            Assert.IsTrue(result1, "'john' should be identified.");
            Assert.IsTrue(result2, "'STUDENT' should be identified.");
        }

        [Test]
        public void FirstId_ShouldReturnFirstIdentifier()
        {
            // Act
            string firstId = myObject.FirstId();

            // Assert
            Assert.AreEqual("john", firstId);
        }

        [Test]
        public void FirstId_ShouldReturnEmptyStringWhenNoIdentifiers()
        {
            // Arrange
            var emptyObject = new IdentifiableObject(new string[0]);

            // Act
            string firstId = emptyObject.FirstId();

            // Assert
            Assert.AreEqual(string.Empty, firstId);
        }

        [Test]
        public void AddIdentifier_ShouldAddNewIdentifier()
        {
            // Arrange
            string[] initialIdentifiers = { "Seekers", "Athol", "Keith", "Bruce" };
            var myObject = new IdentifiableObject(initialIdentifiers);

            // Act
            myObject.AddIdentifier("Mary");

            // Assert
            Assert.IsTrue(myObject.AreYou("Seekers"));
            Assert.IsTrue(myObject.AreYou("Keith"));
            Assert.IsTrue(myObject.AreYou("Mary"));
        }

        [Test]
        public void PrivilegeEscalation_ShouldReplaceFirstIdentifier()
        {

            string studentId = "2797"; // Your student ID
            string tutorialId = "COS20007"; // Your tutorial ID

            // Act
            myObject.PrivilegeEscalation("2797", studentId, tutorialId);

            // Assert
            Assert.AreEqual(tutorialId, myObject.FirstId());
        }
    }
}