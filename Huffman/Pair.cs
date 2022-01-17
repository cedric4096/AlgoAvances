using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
	internal class Pair<K, V>
	{
		public Pair(K key, V value)
		{
			Key = key;
			Value = value;
		}

		public K Key { get; set; }

		public V Value { get; set; }
	}
}
