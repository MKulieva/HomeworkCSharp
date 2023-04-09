using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using System.ComponentModel.Design;

internal class ContentInfo 
{
    public string path;
    //FileAttributes attr = File.GetAttributes(path);
    private string _type;
    public string Type
    {
        get { return _type; }
        set
        {
            if (path != null)
            {
                if (File.GetAttributes(path).HasFlag(FileAttributes.Directory))
                {
                    _type = "folder";
                }
                else if (!File.GetAttributes(path).HasFlag(FileAttributes.Directory))
                {
                    _type = "file";
                }
            }
            
            else
            {
                _type = value;//!
            }

        }
    }
    private string _name;
    public string Name 
    {
        get { return _name; }
        set 
        {
            if (path != null)
            {
                if (Type == "file")
                {
                    _name = Path.GetFileName(path);
                }
                else if (Type == "folder")
                {
                    _name = Directory.GetCurrentDirectory();//?
                }
            }
            else
            {
                _name = value;
            }


        }
    }

    private DateTime _dateOfChange;
    public DateTime DateOfChange
    {
        get { return _dateOfChange; }
        set
        {
         if (path != null)
            {
                _dateOfChange = Directory.GetLastWriteTime(path);
            }
            else
            {
                _dateOfChange = value;
            }

        }
    }
    
   public ContentInfo(string path) 
    {
       this.path = path;
        this.Type = _type;
        this.Name = _name;
        this.DateOfChange = _dateOfChange;
       /*this.Name = Path.GetFileName (path);
        this.Type = "file";
        this.DateOfChange = File.GetLastWriteTime(path);*/

    }
    public ContentInfo()
    {
        this.Type = _type;
        this.Name = _name;
        this.DateOfChange = _dateOfChange;
    }
}
 
