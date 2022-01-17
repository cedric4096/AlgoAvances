using Huffman;

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

if (toEnc is null)
{
	throw new Exception("Null string");
}

List<(char, int)> frequencies = new List<(char, int)>();

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

PriorityQueue<HuffmanNode, int> priorities = new PriorityQueue<HuffmanNode, int>();

foreach ((char, int) value in frequencies)
{
	HuffmanNode node = new HuffmanNode() { Character = value.Item1, Frequency = value.Item2, LeftNode = null, RightNode = null };

	priorities.Enqueue(node, value.Item2);
}

HuffmanNode? root = null;

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