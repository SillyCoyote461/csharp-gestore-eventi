bool execution = true;
var nl = Environment.NewLine;
string line = $"---------------------------------{nl}";

EventSchedule list;

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
        //add event schedule
        case "evento":
            //event list
                //list name
            Console.Write ("Inserisci il nome del programma eventi dove aggiungerlo: ");
            string listName = Console.ReadLine() ?? null;
            list = new EventSchedule(listName);

                //total events
            Console.Write("Quanti eventi vuoi aggiungere? ");
            int listLenght = Convert.ToInt32(Console.ReadLine());

            //loop events
            for(int i = 0; i< listLenght; i++)
            {
                currentEvent = new Event();
                //inputs
                    //title
                Console.Write($"Inserisci titolo del {i + 1}° evento: ");
                currentEvent.Title = Console.ReadLine() ?? "";

                    //capacity
                Console.Write("Inserisci numero posti evento: ");
                currentEvent.Capacity = Convert.ToInt32(Console.ReadLine());

                    //date
                Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
                currentEvent.Date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                //new event and add in list
                list.EventToList(currentEvent);

                //Book seats
                Console.Write("Quanti posti desideri prenotare? ");
                int seats = Convert.ToInt32(Console.ReadLine());
                currentEvent.BookSeat(seats);

                Console.WriteLine($"{nl}Numero posti prenotati: {currentEvent.Booked}");
                Console.WriteLine($"Numero posti disponibili: {currentEvent.Capacity - currentEvent.Booked}{nl}");

                //cancel seat
                Console.Write("Vuoi disdire dei posti (si/no)? ");
                cmd = Console.ReadLine();

                if (cmd == "si")
                {
                    Console.Write("Indica il numero di posti da disdire: ");
                    seats = Convert.ToInt32(Console.ReadLine());
                    currentEvent.CancelSeat(seats);
                    Console.WriteLine($"{nl}Numero posti prenotati: {currentEvent.Booked}");
                    Console.WriteLine($"Numero posti disponibili: {currentEvent.Capacity - currentEvent.Booked}{nl}");
                }
                else
                {
                    Console.WriteLine(nl);
                }

            }
            Console.WriteLine(list);

            break;
    }

}