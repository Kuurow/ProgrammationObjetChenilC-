using System;

namespace Programme1
{
    class Vivant   //--- Classe Mère
    {
        protected string nom;       // Champs de l'objet
        protected int naissance;

        public Vivant(string n, int a)              // Constructeur
        {                                           // Allocation implicite de l'objet en RAM
            this.nom = n;                           // Initialisation des champs
            this.naissance = a;
        }
        public void afficher()
        {
            Console.WriteLine("Vivant : " + this.nom + " "
                                + this.naissance + " ("
                                + this.calculerAge() + "ans)");
        }
        public int calculerAge()
        {
            return 2020 - this.naissance;
        }
        public string getNom()  // Accesseur en lecture sur le champ nom
        {
            return this.nom;
        }
        public int diffAge(personne p)
        // Calculer et renvoyer la différence d'âge entre :
        // l'objet courant (this) et le paramètre (p)
        {
            //          return Math.Abs( p.calculerAge() - this.calculerAge() );
            return Math.Abs(p.naissance - this.naissance);  //p. est le p2 de p1.diffAge(p2) et this. est le p1                                    
        }

    }

    // ----------------------------------------------------------------------------------------------------------
    class personne : Vivant
    {
        private string prenom;
        private Chien chien;        // Chien adopté par cette personne (ou null)
        private Chien[] chiens;     // Futur tableau des chiens
        private int nbrChiens;  

        public personne(string n, string p, int a) :  // Constructeur
            base (n,a)
        {                                           // Allocation implicite de l'objet en RAm
            this.nom = n;                           // Initialisation des champs
            this.prenom = p;
            this.naissance = a;
            //this.chien = null;                      // pas de chien au départ
            this.chiens = new Chien[10];            // nouveau tableau de 10 chiens
            nbrChiens = 0;
            
        }


        new public void afficher()
        {
            Console.WriteLine("¤-------------------------------------------------------------------¤");
            
            Console.WriteLine("Personne : " + this.prenom + " " + this.nom + " " + this.naissance + " (" +
                                this.calculerAge() + "ans)");
           
            if (this.nbrChiens == 0)
                Console.WriteLine(" pas de chien");
            else
            {
                Console.WriteLine(" Possède  "+this.nbrChiens+" chien(s) : ");

                for (int i = 0; i < this.nbrChiens; i++)
                    Console.WriteLine(chiens[i].getNom() + " ");

                Console.WriteLine();

            }
            
            Console.WriteLine("¤-------------------------------------------------------------------¤");
        }

        public void modifier(string n)
        {
            this.nom = n;            // Initialisation des champs
        }
        private void adopter(Chien c)
        {
            chien = c; // Chainer l'objet Chien dans l'objet Personne
            chiens[nbrChiens] = c;
            nbrChiens++;
        }

        

        // ---------------------------------------------------------------------------------------------------------
        class Chien : Vivant        // Chien Hérite de Vivant (Classe Fille)
        {
            public Chien(string n, int a) :              // Constructeur
                base(n,a)                               // Appel du constructeur Vivant 
            {                                           // Allocation implicite de l'objet en RAM
            }


            new public void afficher()
            {
                Console.WriteLine("Chien : " + this.nom + " " + this.naissance + " (" + this.calculerAge() + "ans)");
            }

        }

        //----------------------------------------------------------------------------------------------------------
        class Chenil
        {
            private int nbrChiens;
            private Chien[] chiens;        // Chien adopté par cette personne (ou null)

            public Chenil()
            {
                this.chiens = new Chien[10];            // nouveau tableau de 10 chiens
                this.nbrChiens = 0;
            }

            public void adopter(Chien c)
            {
                this.chiens[nbrChiens] = c;
                this.nbrChiens++;
            }

            public void faireAdopter( personne p, int numChien )
            {
                if (numChien >= nbrChiens) return;  // Sécurité
                
                Chien c = chiens[numChien];
                p.adopter(c);

                //--- Supprimer le n' chien du tableau
                for (int i = numChien; i < nbrChiens-1; i++)
                {
                    chiens[i] = chiens[i + 1];
                }
                //chiens[numChien] = chiens[nbrChiens - 1];  //remplacement du chien pris par le dernier du tableau
                //nbrChiens--;
            }

            public void afficher()
            {
                Console.WriteLine("¤-------------------------------------------------------------------¤");
                Console.WriteLine("Chiens étant dans le chenil :");
                for( int i = 0;  i < nbrChiens; i++ )
                {
                    Console.WriteLine(i + " Chien : " + chiens[i].getNom() 
                                        + " (" + (chiens[i].calculerAge()) + " ans)");
                }
                Console.WriteLine("¤-------------------------------------------------------------------¤");
                Console.WriteLine();
            }

        } 

        //#######################################################################################################
        class Program
        {
            static personne p1, p2;             // 2 Pointeurs sur objet personne
            static Chenil chenil;
            static Chien c1, c2, c3, c4;        // 2 Pointeurs sur objet chien
            static void Main(string[] args)
            {
                Console.WriteLine("¤-------------------------¤");
                Console.WriteLine("|          CHENIL         |");
                Console.WriteLine("¤-------------------------¤");
                Console.WriteLine();

                p1 = new personne("CLAUDE", "Jean", 1998);      // Construction / Allocation
                p2 = new personne("AYMAR", "Jeannette", 2003);  // Des objets

                chenil = new Chenil();
                c1 = new Chien("Rex", 2009);
                c2 = new Chien("Lux", 2016);
                c3 = new Chien("Vic", 2013);
                c4 = new Chien("Zac", 2005);

                chenil.adopter(c1);       //Chenil qui adopte le chien
                chenil.adopter(c2);       //Chenil qui adopte le chien
                chenil.adopter(c3);       //Chenil qui adopte le chien
                chenil.afficher();        //Chenil qui adopte le chien

                //chenil.faireAdopter(p1,c1);   // Personne p1 qui adopte le chien c1 auprès du chenil


                p1.afficher();  // Appel d'une méthode
                p2.afficher();  // sur un objet
                Console.WriteLine();

                chenil.faireAdopter(p1, 2);
                chenil.faireAdopter(p2, 0);

                Console.WriteLine("Après les adoptions");

                p1.afficher();
                p2.afficher();

                /*c1.afficher();  // Appel d'une méthode
                  c2.afficher();  // sur un objet  
                  Console.WriteLine();

                  p1.adopter(c1);
                  p1.afficher();
                  Console.WriteLine();

                  //p2.afficher(); */

                Console.WriteLine(p1.diffAge(p2));



                Console.WriteLine();
                Console.Write("Fin normale");
                Console.WriteLine();
            }
        }


    }
}
