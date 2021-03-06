﻿using System;
using System.Collections;

namespace Hoffman
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string input = "rafael";
            HuffmanTree huffmanTree = new HuffmanTree();

            // Build the Huffman tree
            huffmanTree.Build(input);

            // Encode
            BitArray encoded = huffmanTree.Encode(input);

            Console.Write("Codificado: ");
            foreach (bool bit in encoded)
            {
                Console.Write((bit ? 1 : 0) + "");
            }
            Console.WriteLine();

            // Decode
            string decoded = huffmanTree.Decode(encoded);

            Console.WriteLine("Decodificado: " + decoded);

            Console.ReadLine();
        }
    }
}