

using System.Collections.Generic;
using System.Runtime.Serialization;


public class VagaClasse
{
   

    public string _id { get; set; }
   
    public int index { get; set; }
   
    public int age { get; set; }

    public string status { get; set; }
    public string name { get; set; }

    public string gender { get; set; }

    public string email { get; set; }
    public string phone { get; set; }
}
public class VagaClasseLista
{

    public List<VagaClasse> pessoa { get; set; }

    public string name { get; set; }

    public string gender { get; set; }
}
