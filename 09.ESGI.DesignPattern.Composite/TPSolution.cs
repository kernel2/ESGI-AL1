using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ESGI.DesignPattern.Composite
{
    public interface IElement
    {
        string Name { get; }

        void Add(IElement element);

        List<string> List();
    }

    public class Folder : IElement
    {
        private List<IElement> children;

        public string Name { get; }

        public Folder(string name)
        {
            Name = name;

            children = new List<IElement>();
        }

        public void Add(IElement element)
        {
            children.Add(element);
        }

        public List<string> List()
        {
            return new List<string> { 
                            Name 
                    }.Concat(children.SelectMany(c => c.List()))
                     .ToList();
        }
    }

    public class File : IElement
    {
        public string Name { get; }

        public File(string name)
        {
            Name = name;
        }

        public void Add(IElement element)
        {
            throw new Exception();
        }

        public List<string> List()
        {
            return new List<string> { Name };
        }
    }
}
