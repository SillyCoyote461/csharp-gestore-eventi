using System.Collections.Generic;

bool execution = true;
var nl = Environment.NewLine;
string line = $"---------------------------------{nl}";

EventSchedule list;

Event currentEvent = null;

string cmd = "";
bool executing = true;
while (executing)
{
    //event list
    //list name
    Console.Write("Inserisci il nome del programma eventi: ");
    string listName = Console.ReadLine() ?? null;
    list = new EventSchedule(listName);

    //total events
    Console.Write("Quanti eventi vuoi aggiungere? ");
    int listLenght = Convert.ToInt32(Console.ReadLine());

    //loop events
    while (list.EventCount() < listLenght)
    {
        currentEvent = new Event();
        //inputs
        //title

        Console.Write($"Inserisci titolo del {list.EventCount() + 1}° evento: ");
        try
        {
            currentEvent.Title = Console.ReadLine() ?? "";
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            continue;
        }


        //capacity
        Console.Write("Inserisci numero posti evento: ");
        try
        {
            currentEvent.Capacity = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            continue;
        }

        //date
        Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
        try
        {
            currentEvent.Date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            continue;
        }

        //new event and add in list
        list.EventToList(currentEvent);

        //Book seats
        Console.Write("Quanti posti desideri prenotare? ");
        int seats = Convert.ToInt32(Console.ReadLine());
        try
        {
            currentEvent.BookSeat(seats);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            continue;
        }

        Console.WriteLine($"{nl}Numero posti prenotati: {currentEvent.Booked}");
        Console.WriteLine($"Numero posti disponibili: {currentEvent.Capacity - currentEvent.Booked}{nl}");

        //cancel seat
        Console.Write("Vuoi disdire dei posti (si/no)? ");
        cmd = Console.ReadLine();

        if (cmd == "si")
        {
            Console.Write("Indica il numero di posti da disdire: ");
            seats = Convert.ToInt32(Console.ReadLine());
            try
            {
                currentEvent.CancelSeat(seats);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }
            Console.WriteLine($"{nl}Numero posti prenotati: {currentEvent.Booked}");
            Console.WriteLine($"Numero posti disponibili: {currentEvent.Capacity - currentEvent.Booked}{nl}");
        }
        else
        {
            Console.WriteLine(nl);
        }

    }

    while (list.EventCount() <= listLenght)
    {
        Conference conf = new Conference();
        //inputs
        //title

        Console.Write($"Inserisci titolo della conferenza: ");
        try
        {
            conf.Title = Console.ReadLine() ?? "";
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            continue;
        }
        //speaker
        Console.Write("Inserisci nome relatore: ");
        string speaker = Console.ReadLine() ?? "";
        try
        {
            conf.Speaker = speaker;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            continue;
        }


        Console.Write("Inserisci prezzo: ");
        double price = Convert.ToDouble(Console.ReadLine());
        try
        {
            conf.Price = price;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            continue;
        }

        //capacity
        Console.Write("Inserisci numero posti evento: ");
        try
        {
            conf.Capacity = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            continue;
        }

        //date
        Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
        try
        {
            conf.Date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            continue;
        }

        //new event and add in list
        list.EventToList(conf);

        //Book seats
        Console.Write("Quanti posti desideri prenotare? ");
        int seats = Convert.ToInt32(Console.ReadLine());
        try
        {
            conf.BookSeat(seats);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            continue;
        }

        Console.WriteLine($"{nl}Numero posti prenotati: {conf.Booked}");
        Console.WriteLine($"Numero posti disponibili: {conf.Capacity - conf.Booked}{nl}");

        //cancel seat
        Console.Write("Vuoi disdire dei posti (si/no)? ");
        cmd = Console.ReadLine();

        if (cmd == "si")
        {
            Console.Write("Indica il numero di posti da disdire: ");
            seats = Convert.ToInt32(Console.ReadLine());
            try
            {
                conf.CancelSeat(seats);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }
            Console.WriteLine($"{nl}Numero posti prenotati: {conf.Booked}");
            Console.WriteLine($"Numero posti disponibili: {conf.Capacity - conf.Booked}{nl}");
        }
        else
        {
            Console.WriteLine(nl);
        }

    }

    Console.WriteLine($"Ci sono {list.EventCount()} eventi nella lista.");
    Console.WriteLine(list);

    Console.Write("Inserisci una data per cercare gli eventi: ");
    DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
    list.GetEventsDate(date);

    list.ClearEvents();

    executing = false;
}
