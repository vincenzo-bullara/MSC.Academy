using Esercizio;


FileReader q = new FileReader();

// assegnazione metodo a evento
q.OnBegin += (object sender, EventArgs e) => {
    Console.WriteLine("Start read");
};
q.OnProgress += (object sender, MyEventArgs e) => {
    Console.WriteLine($"rows: {e.rows},\tDifferent genders: {e.dif}");
};
q.OnEnd += (object sender, MyEventArgs e) => {
    Console.WriteLine($"\nTotal rows: {e.rows},\tDifferent genders: {e.dif}");
};
q.ReadCsv();

