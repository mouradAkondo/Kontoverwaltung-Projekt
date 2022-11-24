using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontoverwaltung
{
    public class Kunde
    {

        public string Name { get; set; }
        public string Adresse { get; set; }
        public DateTime Geburtsdatum { get; set; }
        private int alter;

        public Kunde(string name, string addresse, string geburtsdatum)
        {
            this.Geburtsdatum = DateTime.Parse(geburtsdatum);
            this.Name = name;
            this.Adresse = addresse;
            alter = (DateTime.Today - Geburtsdatum).Days / 365;
        }

        internal void PrintKundenInfos()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Adresse);
            Console.WriteLine(Geburtsdatum.ToShortDateString());
            Console.WriteLine("Alter: " + alter);
        }

    }
    public class Konto
    {
        static int IDcounter = 1;
        public Kunde Kunde { get; set; }
        public decimal Kontostand = 0;
        public int KontoID { get; set; }

        public Konto(Kunde kunde)
        {
            this.Kunde = kunde;
            IDcounter++;
            KontoID = IDcounter;
            Console.WriteLine($"Neuer Konto(Indentificationnummer: {KontoID-1}) würde für {kunde.Name} erfolgreich angelegt");
        
        }
        public void geldGutschreiben()
        {
            Console.Write("Wieviel möchten sie einzahlen?: ");
            decimal geldZumGutschreiben = Convert.ToDecimal(Console.ReadLine());
            Kontostand = Kontostand + geldZumGutschreiben;
            Console.WriteLine("Ihre Betrag würde erfolgreich gutgeschrieben");
            Console.WriteLine("Neuer Kontostand: {0}", Kontostand);


        }
        public void geldAbbuchen()
        {
            Console.Write("Wieviel möchten sie abbuchen?: ");
            decimal geldZumAbbuchen = Convert.ToDecimal(Console.ReadLine());

            if (Kontostand >= geldZumAbbuchen)
            {
                Kontostand = Kontostand - geldZumAbbuchen;
                Console.WriteLine("Ihre Betrag würde erfolgreich abbgebucht");
                Console.WriteLine("Neuer Kontostand: {0}", Kontostand);

            }
            else
            {
                Console.WriteLine("Ihr Guthaben reicht nicht aus, um diese Transaktion abzuschließen");
            }


        }
        
    }
    public class Verwaltung
    {
        public string name;
        public List<Kunde> Kundenliste = new List<Kunde>();

        public Verwaltung(string name)
        {
            this.name = name;
        }
        internal void addKunde(Kunde neuerKunde)
        {
            Kundenliste.Add(neuerKunde);
        }
        internal void removeKunde(Kunde nichtKunde)
        {
            Kundenliste.Remove(nichtKunde);
        }
        internal void KundenListeAnzeigen()
        {
           
            Console.WriteLine($"KUNDEN:-----------------({Kundenliste.Count})");
            for (int i = 0; i < Kundenliste.Count; i++)
            {
                if (Kundenliste[i] != null)
                {
                    Kunde kunde = Kundenliste[i];
                    Console.WriteLine("[{0}] {1,-15}\t{2,-40}\t{3,-10}", i, kunde.Name, kunde.Adresse, kunde.Geburtsdatum.ToShortDateString());
                }
            }

        }



    }


    public class Program
    {
        static void Main(string[] args)
        {
            //verwaltung erzeugen
            Verwaltung verwaltung = new Verwaltung("Kontoverwaltung");
            //Kunden anlegen
            Kunde kunde1 = new Kunde("Mustermann", "Musterstraße 123", "09.03.2000");
            Kunde kunde2 = new Kunde("Müller", "Mainzerstraße 456", "10.07.2004");
            //Kunden infos anzeigen
            kunde2.PrintKundenInfos();
            //Konto anlegen
            Konto konto1 = new Konto(kunde1);
            Konto Konto2 = new Konto(kunde2);
            //Kunden in der Kundenliste
            verwaltung.addKunde(kunde1);
            verwaltung.addKunde(kunde2);
            verwaltung.KundenListeAnzeigen();
            //Konto gutschreiben
            konto1.geldGutschreiben();
            //auf Konto abbuchen
            konto1.geldAbbuchen();
            


            Console.ReadKey();


        }
    }
}
