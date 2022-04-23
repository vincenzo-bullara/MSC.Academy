using System.Xml;
using Esercizio;
using MSCAcademy.Week3.Day3;
using Newtonsoft.Json;
using static System.Console;
using static System.Environment;
using static System.IO.Directory;
using static System.IO.Path;

Console.WriteLine("=== FILE SYSTEM ===");
//FileSystemInfo();
//DrivesData();
//WorkWithDirectories();
//WorkWithFiles();
//StreamText();
//StreamTextByLine();
//StreamXMLData();
//StreamJsonData();
LoanerCard<Libro> card = new LoanerCard<Libro>{};
//Libro b1 = new(1, ItemStatus.Returned);
card.SetupUser("Mario", "Rossi", 1, DateTime.Today, UserType.Supporter);
var fullPath = Combine(
GetFolderPath(SpecialFolder.MyDocuments),
"MSC",
"Week3",
"Day3"
);
string jsonFile = Combine(fullPath, "msc-day3.json");
Serialize(jsonFile, card);
LoanerCard<Libro> card2 = new LoanerCard<Libro> { };
card2 = (Deserialize(jsonFile));
Console.WriteLine($"nome: {card2._Name.ToString()}");


static void FileSystemInfo()
{
    WriteLine("{0, -40}{1}", "Path.PathSeparator", PathSeparator);
    WriteLine("{0, -40}{1}", "Path.DirectorySeparatorChar", DirectorySeparatorChar);
    WriteLine("{0, -40}{1}", "GetCurrentDirectory", GetCurrentDirectory());
    WriteLine("{0, -40}{1}", "Environment.SystemDirectory", Environment.SystemDirectory);
    WriteLine("{0, -40}{1}", "Path.GetTempPath", Path.GetTempPath());
    WriteLine("{0, -40}{1}", "MyDocuments", GetFolderPath(SpecialFolder.MyDocuments));
}

static void DrivesData()
{
    WriteLine("{0, 30} | {1, -10} | {2, 7} | {3, 18} | {4, 18}", "Nome", "Tipo", "Formato", "Dimensione", "Spazio Disponibile");
    foreach (DriveInfo drive in DriveInfo.GetDrives())
    {
        if (drive.IsReady)
        {
            WriteLine("{0, 30} | {1, -10} | {2, 7} | {3, 18:N0} | {4, 18:N0}",
                drive.Name, drive.DriveType, drive.DriveFormat, drive.TotalSize, drive.AvailableFreeSpace);
        }
        else
        {
            WriteLine("{0, 30} | {1, -10}", drive.Name, drive.DriveType);
        }
    }
}

static void WorkWithDirectories()
{
    var fullPath = Combine(
        GetFolderPath(SpecialFolder.MyDocuments),
        "MSC",
        "Week3",
        "Day3"
        );
    WriteLine($"Utilizziamo {fullPath} ...");
    WriteLine("Esiste? {0}", Exists(fullPath));
    CreateDirectory(fullPath);
    WriteLine("Esiste ADESSO? {0}", Exists(fullPath));
    Write("Verifica che sia vero e premi ENTER");
    ReadLine();
    Delete(fullPath, true);
    WriteLine("Esiste ANCORA? {0}", Exists(fullPath));
}

static void WorkWithFiles()
{
    var fullPath = Combine(
       GetFolderPath(SpecialFolder.MyDocuments),
       "MSC",
       "Week3",
       "Day3"
       );
    CreateDirectory(fullPath);

    string textFile = Combine(fullPath, "msc-day3.txt");
    WriteLine($"Esiste? {File.Exists(textFile)}");

    string bakFile = Combine(fullPath, "msc-day3.bak");
    File.Copy(sourceFileName: textFile, destFileName: bakFile, overwrite: true);

    Write("Verifica che esiste il bak");
    ReadLine();

    File.Delete(bakFile);
    WriteLine($"Esiste? {File.Exists(bakFile)}");
}

static void StreamText()
{
    var fullPath = Combine(
       GetFolderPath(SpecialFolder.MyDocuments),
       "MSC",
       "Week3",
       "Day3"
       );
    string textFile = Combine(fullPath, "msc-day3.txt");
    StreamWriter sw = File.CreateText(textFile);
    sw.WriteLine("Il mio primo file in streaming");
    sw.Flush();
    sw.Close();

    StreamReader sr = File.OpenText(textFile);
    WriteLine(sr.ReadToEnd());
    sr.Close();
}

static void StreamTextByLine()
{
    var fullPath = Combine(
       GetFolderPath(SpecialFolder.MyDocuments),
       "MSC",
       "Week3",
       "Day3"
       );
    string textFile = Combine(fullPath, "msc-day3.csv");

    //nome,cognome,eta,professione
    //noe,rossi,123,"costruttore di arche"
    //luigi,verdi,50,idraulico

    using (StreamWriter sw = File.CreateText(textFile))
    {
        sw.WriteLine("nome,cognome,eta,professione");
        sw.WriteLine("noe,rossi,123,'costruttore di arche'");
        sw.WriteLine("luigi,verdi,50,idraulico");
        sw.Flush();
        sw.Close();
    }

    using (Qualunque q = new Qualunque())
    {

    }

    using (StreamReader sr = File.OpenText(textFile))
    {

        string line = string.Empty;
        while ((line = sr.ReadLine()) != null)
        {
            WriteLine(line);
        }
        sr.Close();
    }
}

static void StreamXMLData()
{
    string[] callsigns = new string[]
    {
        "Boomer", "Athena", "Apollo", "Helo"
    };

    var fullPath = Combine(
       GetFolderPath(SpecialFolder.MyDocuments),
       "MSC",
       "Week3",
       "Day3"
       );
    string xmlFile = Combine(fullPath, "msc-day3.xml");

    //FileStream
    using (FileStream xmlFileStream = File.Create(xmlFile))
    {

        //XmlWriter
        XmlWriter xmlWriter = XmlWriter.Create(xmlFileStream,
            new XmlWriterSettings { Indent = true }
        );

        //<callsigns>
        //  <callsign>Boomer</callsign>
        //</callsigns>

        //WriteStartDocument
        xmlWriter.WriteStartDocument();
        //WriteStartElement
        xmlWriter.WriteStartElement("callsigns");

        //loop sottoelementi
        foreach (string callsign in callsigns)
            xmlWriter.WriteElementString("callsign", callsign);

        //WriteEndElement
        xmlWriter.WriteEndElement();
        xmlWriter.Close();

        xmlFileStream.Flush();
        xmlFileStream.Close();
    }
    using(FileStream xmlFileStream = File.OpenRead(xmlFile))
    {
        XmlReader xmlReader = XmlReader.Create(xmlFileStream);

        while (xmlReader.Read())
        {
            if(xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "callsign")
            {
                xmlReader.Read();
                WriteLine(xmlReader);
            }
        }
    }
}

static void StreamJsonData()
{
    var fullPath = Combine(
      GetFolderPath(SpecialFolder.MyDocuments),
      "MSC",
      "Week3",
      "Day3"
      );
    string jsonFile = Combine(fullPath, "msc-day3.json");

    List<Person> people = new List<Person>
    {
        new Person {Id = 1, FirstName ="Mario", LastName = "Rossi"},
        new Person {Id = 2, FirstName ="Luigi", LastName = "Verdi"},
        new Person {Id = 3, FirstName ="Paolo", LastName = "Bianchi"}
    };

    using(StreamWriter xmlStreamWriter = File.CreateText(jsonFile))
    {
        string jsonData = JsonConvert.SerializeObject(people);

        xmlStreamWriter.Write(jsonData);

        xmlStreamWriter.Flush();
        xmlStreamWriter.Close();
    }

    using (StreamReader xmlStreamWriter = File.OpenText(jsonFile))
    {
        string jsonData = xmlStreamWriter.ReadToEnd();

        var data = JsonConvert.DeserializeObject<List<Person>>(jsonData);

        foreach (Person person in data)
            WriteLine($"[{person.Id}] {person.LastName.ToUpper()} {person.FirstName}");
    }
}

static void Serialize(string path, LoanerCard<Libro> card)
{
    using (StreamWriter xmlStreamWriter = File.CreateText(path))
    {
        string jsonData = JsonConvert.SerializeObject(card);
        xmlStreamWriter.Write(jsonData);

        xmlStreamWriter.Flush();
        xmlStreamWriter.Close();
    }
}
static LoanerCard<Libro> Deserialize(string path)
{
    using (StreamReader xmlStreamWriter = File.OpenText(path))
    {
        string jsonData = xmlStreamWriter.ReadToEnd();

        var data = JsonConvert.DeserializeObject<LoanerCard<Libro>>(jsonData);

        return data;
    }
}

internal class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}