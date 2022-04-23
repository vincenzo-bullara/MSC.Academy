using Utilities.Day4;
using static System.Console;

#region FileSystemWatcher
//FileSystemWatcher fsw = new();

//fsw.Path = @"C:\Users\admin\Desktop";
//fsw.Filter = "*.txt";
//fsw.EnableRaisingEvents = true;
//fsw.NotifyFilter = NotifyFilters.LastWrite  |
//    NotifyFilters.LastAccess    |
//    NotifyFilters.FileName  |
//    NotifyFilters.DirectoryName;

//fsw.Created += (object sender, FileSystemEventArgs e) =>
//{
//    WriteLine("NEW!");
//    using StreamReader sr = File.OpenText(e.FullPath);
//    WriteLine(sr.ReadToEnd());
//    sr.Close();
//};
//fsw.Changed += (object sender, FileSystemEventArgs e) =>
//{
//    WriteLine("CHANGED.");
//    using StreamReader sr = File.OpenText(e.FullPath);
//    WriteLine(sr.ReadToEnd());
//    sr.Close();
//};

//WriteLine("Premi q per uscire.");
//while (!string.Equals(ReadLine(), "q")) ;
#endregion

#region HttpClient API
//HttpClient client = new HttpClient();

//HttpRequestMessage httpRequest = new HttpRequestMessage()
//{

//};
//string json = 
//httpRequest.Content = 

//var response = await client.SendAsync(httpRequest);
//if (response.IsSuccessStatusCode)
//{
//    var jsonResponse = await response.Content.ReadAsStringAsync();
//    var result = JsonConvert.DeserializeObject<T>(jsonResponse);
//}
#endregion

#region LINQ

#region Data

List<Employee> employees = new List<Employee>
{
    new Employee
    {
        ID = 1,
        EmployeeCode = "EMP-01",
        FirstName = "Mario",
        LastName = "Rossi",
        HiringDate = DateTime.Now.AddYears(-5),
        Salary = 23000M,
        Department = Department.IT,
        IsManager = false
    },
    new Employee
    {
        ID = 2,
        EmployeeCode = "EMP-02",
        FirstName = "Luigi",
        LastName = "Verdi",
        HiringDate = DateTime.Now.AddYears(-1),
        Salary = 90000M,
        Department = Department.Finance,
        IsManager = true
    },
    new Employee
    {
        ID = 3,
        EmployeeCode = "EMP-03",
        FirstName = "Paolo",
        LastName = "Bianchi",
        HiringDate = DateTime.Now.AddMonths(-6),
        Salary = 45000M,
        Department = Department.IT,
        IsManager = false
    },
    new Employee
    {
        ID = 4,
        EmployeeCode = "EMP-04",
        FirstName = "Rodolfo",
        LastName = "Brambilla",
        HiringDate = DateTime.Now.AddMonths(-1),
        Salary = 15000M,
        Department = Department.HR,
        IsManager = false
    },
    new Employee
    {
        ID = 5,
        EmployeeCode = "EMP-05",
        FirstName = "Ambrogio",
        LastName = "Brambilla",
        HiringDate = DateTime.Now.AddDays(-15),
        Salary = 40000M,
        Department = Department.Facilities,
        IsManager = true
    },
    new Employee
    {
        ID = 6,
        EmployeeCode = "EMP-06",
        FirstName = "Pietro",
        LastName = "Peones",
        HiringDate = DateTime.Now.AddDays(-5),
        Salary = 4000M,
        Department = Department.IT,
        IsManager = false
    },
    new Employee
    {
        ID = 7,
        EmployeeCode = "EMP-07",
        FirstName = "Luisa",
        LastName = "Corna",
        HiringDate = DateTime.Now.AddYears(-1),
        Salary = 35000M,
        Department = Department.HR,
        IsManager = true
    }
};

#endregion

var qNomiECognomi =
    from e in employees
    where e.IsManager == false
    orderby e.Department, e.Salary descending
    select new
    {
        FN = e.FirstName,
        LN = e.LastName,
        Dept = e.Department
    };


var lNomiECognomi =
    employees
    .OrderByDescending(e => e.Salary)
    .ThenBy(e => e.Department)
    .Where(e => e.IsManager == false)
    .Select(e => new
    {
        FN = e.FirstName,
        LN = e.LastName,
        Dept = e.Department
    });

//foreach (var item in lNomiECognomi)
//    WriteLine($"{item.FN}\t{item.LN}\t\t{item.Dept}");


var qSalaryAndCountPerDept =
    from e in employees
    group e by new { e.Department, e.LastName } into grp
    select new
    {
        Dept = grp.Key,
        LastName = grp.Key.LastName,
        HeadCount = grp.Count(),
        AvgSalary = grp.Average(v => v.Salary)
    };


var lSalaryAndCountPerDept = employees
    .GroupBy(
        e => new { e.Department, e.LastName },
        (key, group) => new
        {
            Dept = key.Department,
            LastName = key.LastName,
            HeadCount = group.Count(),
            AvgSalary = group.Average(v => v.Salary)
        }
    );

//foreach (var item in lSalaryAndCountPerDept)
//    WriteLine($"{item.Dept}\t{item.LastName}\t{item.HeadCount}\t\t{item.AvgSalary}");

// Skip / Take      servono per la paginazione
var primiCinque = employees.Take(5);
var skippaPrimiTre = employees.Skip(3);

IEnumerable<Employee> pagina = new List<Employee>();
for (int i = 0; i < 3; i++)
{
    pagina = employees.Skip(i * 3).Take(3);
    //    WriteLine($"Pagina #{i+1}");
    //    foreach (Employee e in pagina)
    //        WriteLine($"[{e.ID}] {e.FirstName} {e.LastName}");
}

// Any / All / Contains

bool qualcheFinanziere = employees.Any(
    e => e.Department == Department.Finance);

bool sonoTuttiManager = employees.All(e => e.IsManager == true);

var io = new Employee
{
    ID = 1,
    EmployeeCode = "EMP-01",
    FirstName = "Mario",
    LastName = "Rossi",
    HiringDate = DateTime.Now.AddYears(-5),
    Salary = 23000M,
    Department = Department.IT,
    IsManager = false
};
bool esisteGigi = employees.Contains(io);

var mario = employees[0];

bool esisteMario = employees.Contains(mario);

// First, FirstOrDefault, Single, SingleOrDefault

//var nonEsiste = employees.First(e => e.ID == 123);
var nonEsisteLoStesso = employees
    .FirstOrDefault(e => e.ID == 123);

var troppaRoba = employees
    .SingleOrDefault(e => e.ID == 123);

var sempreTroppaRoba = employees
    .Single(e => e.LastName == "Rossi");

//ReadLine();

#endregion

#region esercitazione LINQ

#region data region
List<Voto> voti = new List<Voto>
{
    new Voto
    {
        ID = 0,
        materia = Materia.Italiano,
        Data = DateTime.Now.AddMonths(-5),
        IdStudente = "LV",
        Valutazione = 3.2m
    },
    new Voto
    {
        ID = 1,
        materia = Materia.Italiano,
        Data = DateTime.Now.AddMonths(-5),
        IdStudente = "MR",
        Valutazione = 9.9m
    },
    new Voto
    {
        ID = 2,
        materia = Materia.Italiano,
        Data = DateTime.Now.AddMonths(-4),
        IdStudente = "LV",
        Valutazione = 9
    },
    new Voto
    {
        ID = 3,
        materia = Materia.Italiano,
        Data = DateTime.Now.AddMonths(-3),
        IdStudente = "PB",
        Valutazione = 8.2m
    },
    new Voto
    {
        ID = 4,
        materia = Materia.Storia,
        Data = DateTime.Now.AddMonths(-5),
        IdStudente = "MR",
        Valutazione = 7.5m
    },
    new Voto
    {
        ID = 5,
        materia = Materia.Matematica,
        Data = DateTime.Now.AddMonths(-5),
        IdStudente = "LV",
        Valutazione = 6.1m
    },
    new Voto
    {
        ID = 6,
        materia = Materia.Matematica,
        Data = DateTime.Now.AddMonths(-4),
        IdStudente = "PB",
        Valutazione = 5.8m
    },
    new Voto
    {
        ID = 7,
        materia = Materia.Arte,
        Data = DateTime.Now.AddMonths(-2),
        IdStudente = "LC",
        Valutazione = 4.9m
    },
        new Voto
    {
        ID = 8,
        materia = Materia.Matematica,
        Data = DateTime.Now.AddMonths(-7),
        IdStudente = "MR",
        Valutazione = 4.2m
    },
        new Voto
    {
        ID = 9,
        materia = Materia.Italiano,
        Data = DateTime.Now.AddMonths(-1),
        IdStudente = "LV",
        Valutazione = 8.1m
    },
        new Voto
    {
        ID = 10,
        materia = Materia.Geografia,
        Data = DateTime.Now.AddMonths(-2),
        IdStudente = "PB",
        Valutazione = 7.7m
    }
};
#endregion

#region query

#region es1
var qVotiSuff =
    from e in voti
    where e.Valutazione >= 6.5m
    orderby e.Valutazione descending
    select new
    {
        ID = e.IdStudente,
        Mat = e.materia,
        Voto = e.Valutazione
    };

var lVotiSuff =
    voti
    .OrderByDescending(e => e.Valutazione)
    .Where(e => e.Valutazione >= 6.5m)
    .Select(e => new
    {
        ID = e.IdStudente,
        Mat = e.materia,
        Voto = e.Valutazione
    });

//foreach (var item in qVotiSuff)
//    WriteLine($"{item.ID}\t{item.Mat}\t\t{item.Voto}");
//foreach (var item in lVotiSuff)
//    WriteLine($"{item.ID}\t{item.Mat}\t\t{item.Voto}");
#endregion

#region es2
var qStudSuff =
    from e in voti
    group e by new { e.IdStudente, e.materia } into grp
    where grp.Average(v => v.Valutazione) >= 6
    select new
    {
        Studente = grp.Key.IdStudente,
        Materia = grp.Key.materia,
        Media = grp.Average(v => v.Valutazione)
    };

//var qStudSuff2 =
//    from e in qStudSuff
//    where e.Media >= 6
//    select new
//    {
//        Studente = e.Studente,
//        Materia = e.Materia,
//        Media = e.Media
//    };


var lStudSuff = voti
    .GroupBy(
        e => new { e.IdStudente, e.materia },
        (key, group) => new
        {
            Studente = key.IdStudente,
            Materia = key.materia,
            Media = group.Average(v => v.Valutazione)
        }
    )
    .Where(e => e.Media >= 6);

//var lStudSuff2 = lStudSuff
//    .OrderByDescending(e => e.Media)
//    .Where(e => e.Media >= 6)
//    .Select(e => new
//    {
//        Studente = e.Studente,
//        Materia = e.Materia,
//        Media = e.Media
//    });
foreach (var item in qStudSuff)
    WriteLine("{0, -7}{1, -12}{2, -10:f2}", item.Studente, item.Materia, item.Media);
WriteLine();
foreach (var item in lStudSuff)
    WriteLine("{0, -7}{1, -12}{2, -10:f2}", item.Studente, item.Materia, item.Media);
#endregion

#region es3

var qMatStats =
    from e in voti
    group e by new { e.materia } into grp
    select new
    {
        Materia = grp.Key.materia,
        Media = grp.Average(v => v.Valutazione),
        Massimo = grp.Max(v => v.Valutazione),
        Minimo = grp.Min(v => v.Valutazione)
    };

var lMatStats = voti
    .GroupBy(
        e => new { e.IdStudente, e.materia },
        (key, group) => new
        {
            Materia = key.materia,
            Media = group.Average(v => v.Valutazione),
            Massimo = group.Max(v => v.Valutazione),
            Minimo = group.Min(v => v.Valutazione)
        }
    );

//foreach (var item in qMatStats)
//    WriteLine("{0, -15}{1, -10:f2}{2, -10}{3, -10}", item.Materia, item.Media, item.Massimo, item.Minimo);
//foreach (var item in lMatStats)
//    WriteLine("{0, -15}{1, -10:f2}{2, -10}{3, -10}", item.Materia, item.Media, item.Massimo, item.Minimo);

#endregion

#region es4

var qMonthStats =
    from e in voti
    group e by new { e.Data.Month, e.materia } into grp
    select new
    {
        Materia = grp.Key.materia,
        Mese = grp.Key.Month,
        Massimo = grp.Max(v => v.Valutazione)
    };

var lMonthStats = voti
    .GroupBy(
        e => new { e.Data.Month, e.materia },
        (key, group) => new
        {
            Materia = key.materia,
            Mese = key.Month,
            Massimo = group.Max(v => v.Valutazione)
        }
    );

//foreach (var item in qMonthStats)
//    WriteLine("{0, -15}{1, -10}{2, -10}", item.Materia, item.Mese, item.Massimo);
//WriteLine();
//foreach (var item in lMonthStats)
//    WriteLine("{0, -15}{1, -10}{2, -10}", item.Materia, item.Mese, item.Massimo);

#endregion

#endregion

#endregion