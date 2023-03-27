bool execution = true;
var nl = Environment.NewLine;
string line = $"---------------------------------{nl}";

List<EventSchedule> lists = new List<EventSchedule>();

Event currentEvent = null;

while (execution)
{
    string cmd = "";

    //command list
    Console.WriteLine
        (
            $"{line}" +
            $"Lista dei comandi: {nl}" +
            $"evento -> aggiungi un evento in calendario. {nl}" +
            $"prenota -> prenota uno o piú posti all'evento.{nl}" +
            $"disdici -> disdici uno o piú prenotazioni all'evento. " +
            $"lista -> ottieni la lista eventi.{nl}" +
            $"chiudi -> chiudi console.{nl}" +
            $"{line}"
        );

    //input
    Console.Write("Digita comando:");
    cmd = Console.ReadLine() ?? "";
    cmd = cmd.Replace(" ", "");
    //menu
    switch(cmd)
    {
        //add event
        case "evento":
            //inputs
                //title
            Console.Write("Inserisci titolo evento: ");
            string title = Console.ReadLine() ?? "";
                //capacity
            Console.Write("Inserisci numero posti evento: ");
            int capacity = Convert.ToInt32(Console.ReadLine());
                //date
            Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
            string[] dateStr = Console.ReadLine().Split("/");
            DateTime date = new DateTime(Convert.ToInt32(dateStr[2]), Convert.ToInt32(dateStr[1]), Convert.ToInt32(dateStr[0]));

            //new event and add in list
            currentEvent = new Event(title, date, capacity);
                //event list
            Console.Write ("Inserisci il nome del programma eventi dove aggiungerlo: ");
            string listName = Console.ReadLine() ?? null;
            if (lists.Count == 0)
            {
                lists.Add(new EventSchedule(listName));
            }
            else
            {
                bool newList = true;
                foreach (var list in lists)
                {
                    if (listName == list.title)
                    {
                        list.EventToList(currentEvent);
                        newList = false;
                    }           
                }
                if (newList)
                {
                    lists.Add(new EventSchedule(listName));
                }
            }
            //Book seats
            Console.Write("Quanti posti desideri prenotare? ");
            int seats = Convert.ToInt32(Console.ReadLine());
            currentEvent.BookSeat(seats);

            Console.WriteLine($"{nl}Numero posti prenotati: {currentEvent.Booked}");
            Console.WriteLine($"Numero posti disponibili: {currentEvent.SeatsLeft}{nl}");

            //cancel seat
            Console.Write("Vuoi disdire dei posti (si/no)? ");
            cmd = Console.ReadLine();

            if(cmd == "si")
            {
                Console.Write("Indica il numero di posti da disdire: ");
                seats = Convert.ToInt32(Console.ReadLine());
                currentEvent.CancelSeat(seats);
                Console.WriteLine($"{nl}Numero posti prenotati: {currentEvent.Booked}");
                Console.WriteLine($"Numero posti disponibili: {currentEvent.SeatsLeft}{nl}");
            }

            break;
    }

}