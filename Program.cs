// See https://aka.ms/new-console-template for more information
using BinarySearchTree;
Tree<string> t = new Tree<string>("hi");
t.Add("a").Add("z").Add("b").Add("c").Add("d").Add("e").Add("f").Add("g");
var iterator = t.GetEnumerator();
while (iterator.MoveNext())
{
    Console.WriteLine(iterator.Current.GetValue());
}