using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.Collection.Tree
{
    public class Node<T> : IEquatable<Node<T>>
    {
        public string hash;
        public Node<T> parent = null;
        public List<Node<T>> children = new List<Node<T>>();

        T data;

        public Node()
        {
            hash = GetTimestampHash();
        }

	    public static string GetStringSha256Hash(string text)
	    {
	        if (System.String.IsNullOrEmpty(text))
	            return System.String.Empty;
	
	        using (var sha = new System.Security.Cryptography.SHA256Managed())
	        {
	            byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
	            byte[] hash = sha.ComputeHash(textData);
	            return BitConverter.ToString(hash).Replace("-", System.String.Empty);
	        }
	    }
	    
	    public static string GetTimestampHash()
	    {
	    	return GetStringSha256Hash(DateTime.Now.Ticks.ToString());
	    }

        public Node(T data)
        {
            this.data = data;
        }

        public void AddChild(Node<T> node)
        {
            children.Add(node);
            node.parent = this;
        }

        public void RemoveChild(Node<T> node)
        {
            children.Remove(node);
            node.parent = null;
        }

        public bool Equals(Node<T> node)
        {
            if (this.hash == node.hash)
            {
                return true;
            }

            return false;
        }

    }
}
