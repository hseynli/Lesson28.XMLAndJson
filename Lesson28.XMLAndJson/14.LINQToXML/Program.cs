using System.Xml.Linq;

XElement root = XElement.Parse(@"<root>
                                      <child>
                                        <name>John</name>
                                        <grandchild>
                                            <name>Susan</name>
                                        </grandchild>
                                      </child>
                                      <child>
                                        <name>Alice</name>
                                      </child>
                                  </root>");

// Using Elements()
foreach (var child in root.Elements())
{
    Console.WriteLine("Child Name: " + child.Element("name").Value);
}

// Using Element()
Console.WriteLine("First child name: " + root.Element("child").Element("name").Value);

// Using Descendants()
foreach (var name in root.Descendants("name"))
{
    Console.WriteLine("Name: " + name.Value);
}