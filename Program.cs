namespace BreadthFirstSearch
{
    class Program
    {
        static void Main()
        {
            var vinicius = new Person(1, "Vinicius", Job.Developer);
            var caio = new Person(2, "Caio", Job.Dentist);
            var mateus = new Person(3, "Mateus", Job.Developer);
            var edwin = new Person(4, "Edwin", Job.Designer);
            var robson = new Person(5, "Robson", Job.Buyer);
            var dhiogo = new Person(6, "Dhiogo", Job.Actor);
            var leticia = new Person(7, "Leticia", Job.Teacher);
            var luiz = new Person(8, "Luiz", Job.Mason);
            var zaira = new Person(9, "Zaira", Job.Baker);
            var gabriela = new Person(10, "Gabriela", Job.Artist);
            var kleber = new Person(11, "Kleber", Job.Actor);
            var camila = new Person(12, "Camila", Job.Actress);
            var viktorija = new Person(13, "Viktorija", Job.Architect);

            vinicius.Friends.Add(caio);
            vinicius.Friends.Add(mateus);
            vinicius.Friends.Add(edwin);
            vinicius.Friends.Add(robson);
            vinicius.Friends.Add(dhiogo);
            vinicius.Friends.Add(leticia);
            vinicius.Friends.Add(zaira);
            vinicius.Friends.Add(luiz);

            robson.Friends.Add(kleber);

            kleber.Friends.Add(camila);

            leticia.Friends.Add(gabriela);

            gabriela.Friends.Add(viktorija);

            // change here which Job you wanna search
            var searchJob = Job.Artist;

            var peopleForSearch = new Queue<Person>(vinicius.Friends);

            var peopleAlreadySearched = new Dictionary<int, bool>
            {
                [vinicius.Id] = true
            };

            while (peopleForSearch.Count != 0)
            {
                var person = peopleForSearch.Dequeue();
                
                if (!peopleAlreadySearched.ContainsKey(person.Id))
                {
                    if (person.Job == searchJob)
                    {
                        Console.WriteLine($"{person.Name} is the closest {searchJob}");
                        break;
                    }
                    else
                    {
                        person.Friends.ForEach(peopleForSearch.Enqueue);
                    }
                }

                if (peopleForSearch.Count == 0)
                {
                    Console.WriteLine($"{searchJob} Not found");
                    break;
                }

                peopleAlreadySearched[person.Id] = true;
            }

            Console.ReadLine();
        }
    }

    enum Job
    {
        Developer,
        Actor,
        Actress,
        Dentist,
        Designer,
        Buyer,
        Teacher,
        Artist,
        Mason,
        Baker,
        Architect
    }

    class Person(int id, string name, Job job)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public Job Job { get; set; } = job;
        public List<Person> Friends { get; set; } = [];
    }
}
