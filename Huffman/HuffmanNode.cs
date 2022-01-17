using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
	internal class HuffmanNode
	{
		public char? Character { get; set; }
		public int Frequency { get; set; }
		public HuffmanNode? LeftNode { get; set; }
		public HuffmanNode? RightNode { get; set; }
	}
}
