using E4DataCapture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace E4DataCapture.Helpers
{
    public class XMLHelper
    {
        public static string path = AppDomain.CurrentDomain.BaseDirectory + "/Users.xml";
        public List<E4DataCapture.Models.User> getAllUsers()
        {

            XDocument doc = XDocument.Load(path);
            List<User> list = doc.Root
                .Descendants("user")
                .Select(node => new User
                {
                    Name = node.Element("Name").Value,
                    Surname = node.Element("Surname").Value,
                    CellNumber = node.Element("CellNumber").Value,
                    UserID = node.Element("UserID").Value

                })
                .ToList();
            return list;
        }
        public void addUser(User usr)
        {
            XmlDocument docUser = new XmlDocument();
            docUser.Load(path);


            XmlNode RootNode = docUser.SelectSingleNode("users");

            XmlNode userNode = RootNode.AppendChild(docUser.CreateNode(XmlNodeType.Element, "user", ""));


            userNode.AppendChild(docUser.CreateNode(XmlNodeType.Element, "UserID", "")).InnerText = usr.UserID + "";
            userNode.AppendChild(docUser.CreateNode(XmlNodeType.Element, "Name", "")).InnerText = usr.Name;
            userNode.AppendChild(docUser.CreateNode(XmlNodeType.Element, "Surname", "")).InnerText = usr.Surname;
            userNode.AppendChild(docUser.CreateNode(XmlNodeType.Element, "CellNumber", "")).InnerText = usr.CellNumber;


            docUser.Save(path);
        }

        public void deleteUser(string userID)
        {
            try
            {
                XmlDocument docUser = new XmlDocument();
                docUser.Load(path);

                XmlNodeList nodes = docUser.GetElementsByTagName("users");
                XmlNode rootNode = nodes[0];

                foreach (XmlNode node in rootNode.ChildNodes)
                {
                    string id = node.ChildNodes[0].InnerText;


                    if (userID.Equals(id))
                    {
                        rootNode.RemoveChild(node);

                        break;
                    }
                }
                docUser.Save(path);
            }
            catch (Exception ex) { }
        }

        public void editUser(User usr)
        {
            try
            {
                XmlDocument docUser = new XmlDocument();
                docUser.Load(path);

                XmlNodeList nodes = docUser.GetElementsByTagName("users");
                XmlNode rootNode = nodes[0];

                foreach (XmlNode node in rootNode.ChildNodes)
                {
                    string id = node.ChildNodes[0].InnerText;


                    if (usr.UserID.Equals(id))
                    {
                        node.ChildNodes[1].InnerText = usr.Name;
                        node.ChildNodes[2].InnerText = usr.Surname;
                        node.ChildNodes[3].InnerText = usr.CellNumber;
                        break;
                    }
                }
                docUser.Save(path);
            }
            catch (Exception ex) { }
        }
    }
}