using Huffman;

/// <summary>
/// Prints the binary code of the specified Huffman tree in the specified string.
/// </summary>
static void printHuffman(HuffmanNode root, string str)
{
	if (root.LeftNode == null && root.RightNode == null && root.Character != null)
	{
		Console.WriteLine($"{root.Character}         | {str}");
		return;
	}

	printHuffman(root.LeftNode, str + "0");
	printHuffman(root.RightNode, str + "1");
}

Console.WriteLine("Enter text to compress :");
string? toEnc = Console.ReadLine();

// Ensuring the entered string is not null
if (toEnc is null)
{
	throw new Exception("Null string");
}

// List of character frequencies
List<(char, int)> frequencies = new List<(char, int)>();

// For each character in entered string, count occurences and add to frequencies
foreach (char character in toEnc)
{
	int found = frequencies.FindIndex(pair => pair.Item1.Equals(character));
	if (found != -1)
	{
		frequencies[found] = (frequencies[found].Item1, frequencies[found].Item2 + 1);
	}
	else
	{
		frequencies.Add((character, 1));
	}
}

// Character priority queue
PriorityQueue<HuffmanNode, int> priorities = new PriorityQueue<HuffmanNode, int>();

// For each frequency, create a new node in Huffman tree
foreach ((char, int) value in frequencies)
{
	HuffmanNode node = new HuffmanNode() { Character = value.Item1, Frequency = value.Item2, LeftNode = null, RightNode = null };

	priorities.Enqueue(node, value.Item2);
}

// Root of Huffman tree
HuffmanNode? root = null;

// While there are nodes in priorities, dequeue 2 nodes and store them as new node children (new root), then enqueue this new node
while (priorities.Count > 1)
{
	HuffmanNode left = priorities.Dequeue();
	HuffmanNode right = priorities.Dequeue();
	HuffmanNode nNode = new HuffmanNode() { Character = null, Frequency = left.Frequency + right.Frequency, LeftNode = left, RightNode = right };

	root = nNode;
	priorities.Enqueue(nNode, nNode.Frequency);
}

Console.WriteLine("Character | Huffman Code");
Console.WriteLine("------------------------");
printHuffman(root, "");